using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDto = GA2.Application.Dto.InsertRequest.FileDto;
using HeaderDto = GA2.Application.Dto.HeaderDto;

namespace GA2.Domain.Core.Credito.WorkManager
{
    /// <summary>
    /// Work Manager Core Negocio
    /// <author>Nicolas FLorez Sarrazola</author>
    /// <date>24/02/2021</date>
    /// </summary>
    public class GestorDocumentalBusinessLogic : IGestorDocumentalBusinessLogic
    {

        private readonly IIntegracionesGA2WorkManagerBusinessLogic _integraciones;
        private readonly ITokenClaims _tokenClaims;
        private readonly ICreditoRepository _creditoRepository;
        private readonly ICatalogosRepository _catalogosRepository;
        private readonly IMapper _mapper;
        private readonly CHKeysOptions _optionsCH;

        /// <summary>
        /// Constructor Negocio WM
        /// </summary>
        /// <param name="mapper">Instancia mapper</param>
        /// <param name="GestorDocumentalRepository">Instancia repositorio gestion documental</param>
        public GestorDocumentalBusinessLogic(
            IMapper mapper,
            ITokenClaims tokenClaims,
            IIntegracionesGA2WorkManagerBusinessLogic integraciones,
            IOptions<CHKeysOptions> optionsCH,
            ICreditoRepository creditoRepository,
            ICatalogosRepository catalogosRepository
            )
        {
            _mapper = mapper;
            _tokenClaims = tokenClaims;
            _integraciones = integraciones;
            _optionsCH = optionsCH.Value;
            _creditoRepository = creditoRepository;
            _catalogosRepository = catalogosRepository;
        }

        public async Task<object> ActualizarRegistro(RequestUpdateDto request)
        {
            var url = _optionsCH.UrlCajaHonor + "api/formUpdate";
            var uri = new Uri(url);
            var updateRequest = GenUpdateRequest(request);
            var update = await this._integraciones.FormUpdateWorkManager(uri, updateRequest, Guid.NewGuid());
            var data = update.Data;
            return update;
        }

        private UpdateRequest GenUpdateRequest(RequestUpdateDto request)
        {
            return new UpdateRequest
            {
                Header = new Application.Dto.HeaderDto
                {
                    Token = _optionsCH.Token,
                    User = _optionsCH.User
                },
                OperationUser = request.OperationUser != string.Empty && request.OperationUser != null ? request.OperationUser : "web",
                FilterParameters = new FilterParametersDto { Field = "Cod_Barras", Operator = "=", Value = request.Radicado },
                FormCode = request.FormCode != string.Empty && request.FormCode != null ? request.FormCode : "219",
                Data = new Application.Dto.DictionaryDto[] { new Application.Dto.DictionaryDto { Field = "C0021", Key = "C0021", Value = request.Actividad } }

            };
        }

        public async Task<object> CrearRegistro(PeticionCreditoBasicaDto peticionCreditoBasica)
        {
            var url = _optionsCH.UrlCajaHonor + "api/forminsert";
            var uri = new Uri(url);
            var peticion = this._mapper.Map<PeticionCreditoBasica>(peticionCreditoBasica);
            var credito = await this._creditoRepository.ObtenerSolicCreditoBasica(peticion);
            var insRequest = await GenInserRequest(credito);
            var insert = await this._integraciones.FormInsertWorkManager(uri, insRequest, Guid.NewGuid());
            try {
                var data = insert.Data;
                var radicado = await this._creditoRepository.ActualizarRadicadoSolicitud(peticion.SOC_ID,data.BarCode);
            }
            catch(Exception ex)
            {
                return insert;
            }
            
            
            return insert;
        }

        private async Task<InsertRequest>GenInserRequest(RespuestaCreditoBasica credito)
        {
            var listaCodigos = new List<string>
            {
                "C0001",
                "C0002",
                "C0003",
                "C0004",
                "C0005",
                "C0006",
                "C0007",
                "C0008",
                "C0009",
                "C0010",
                "C0011",
                "C0012",
                "C0013",
                "C0014"
            };
            var diccionarios = new List<InsertRequest.DictionaryDto>();
            var departamento = await  this._catalogosRepository.ObtenerDepartamentoById(credito.DPD_ID_RESIDENCIA);
            var ciudad = await this._catalogosRepository.ObtenerCiudadById(credito.DPC_ID_RESIDENCIA);

            foreach (var codigo in listaCodigos)
            {
                var dictionary = new InsertRequest.DictionaryDto();
                dictionary.Field = codigo;
                switch (codigo)
                {
                    case "C0001":
                        dictionary.Value = credito.SOB_NUMERO_DOCUMENTO;
                        break;
                    case "C0002":
                        dictionary.Value = $"{credito.SOB_PRIMER_NOMBRE} {credito.SOB_SEGUNDO_NOMBRE} {credito.SOB_PRIMER_APELLIDO} {credito.SOB_SEGUNDO_APELLIDO}";
                        break;
                    case "C0003":
                        dictionary.Value = credito.FUERZA;
                        break;
                    case "C0004":
                        dictionary.Value = credito.FECHA_AFILIACION.ToString("yyyy-MM-dd");
                        break;
                    case "C0005":
                        dictionary.Value = credito.CATEGORIA;
                        break;
                    case "C0006":
                        dictionary.Value = departamento.DPD_NOMBRE;
                        break;
                    case "C0007":
                        dictionary.Value = ciudad.DPC_NOMBRE;
                        break;
                    case "C0008":
                        dictionary.Value = credito.SOB_DIRECCION_RESIDENCIA;
                        break;
                    case "C0009":
                        dictionary.Value = credito.SOB_CORREO_PERSONAL;
                        break;
                    case "C0010":
                        dictionary.Value = credito.SOB_TELEFONO_RESIDENCIA;
                        break;
                    case "C0011":
                        dictionary.Value = credito.TIPO_DOCUMENTO_CLIENTE;
                        break;
                    case "C0012":
                        dictionary.Value = credito.SOB_FECHA_EXPEDICION.ToString("yyyy-MM-dd");
                        break;
                    case "C0013":
                        dictionary.Value = credito.CIUDAD_EXPEDICION;
                        break;
                    case "C0014":
                        dictionary.Value = credito.SOB_FECHA_NACIMIENTO.ToString("yyyy-MM-dd");
                        break;
                    default:
                        break;
                }

                diccionarios.Add(dictionary);

            }

            return new InsertRequest()
            {
                CheckWorkflow = true,
                Data = diccionarios.ToArray(),
                FormCode = "219",
                OfficeCode = "01",
                OperationUser = "Web",
                Header = new InsertRequest.HeaderDto
                {
                    Token = _optionsCH.Token,
                    User = _optionsCH.User
                }
            };
        }

        public async Task<object> AttachFiles(AttachRequestDto request)
        {
            var url = _optionsCH.UrlCajaHonor + "api/formUpdate";
            var uri = new Uri(url);
            var attachRequest = GenAttachRequest(request);
            var attach = await this._integraciones.WorkflowAttachFilesWorkManager(uri, attachRequest, Guid.NewGuid());
            var data = attach.Data;
            return attach;
        }

        private WorkflowAttachFilesRequest GenAttachRequest(AttachRequestDto request)
        {
            return new WorkflowAttachFilesRequest
            {
                BarCode = request.Radicado,
                CheckWorkflow = true,
                Files = request.Files.ToArray(),
                OperationUser = request.UserOperation,
                Header = new HeaderDto
                {
                    Token = _optionsCH.Token,
                    User = _optionsCH.User
                }
            };
        }

        public async Task<object> CrearFlujoFirmasComite(RequestFlujoFirmasDto request)
        {
            var datosComite = (await _creditoRepository.ObtenerComiteCredito(new DatosComiteCredito() {  COC_ID=request.IdComite, 
                                                                                                        COC_FECHA=request.FechaComite, 
                                                                                                        ESTADO=request.EstadoComite, 
                                                                                                        COC_NUMERO_COMITE=request.ComiteNumero})).ToArray();
            var temasComite = await _creditoRepository.ObtenerComiteCreditoTemas(new RequestTemaComiteCredito() { COC_ID=datosComite[0].COC_ID,IND=0});

            var url = _optionsCH.UrlCajaHonor + "api/forminsert";
            var uri = new Uri(url);
            var insRequest = GenInserRequestFlujoFirmas(datosComite[0],temasComite,request.RequiereFirmaGerencia,request.AttachedFile);
            var insert = await this._integraciones.FormInsertWorkManager(uri, insRequest, Guid.NewGuid());
            try
            {
                var data = insert.Data;
                var radicado = await this._creditoRepository.ActualizarRadicadoComiteCredito(request.ComiteNumero, data.BarCode);
            }
            catch (Exception ex)
            {
                insert.ReturnMessage = ex.Message;
                return insert;
            }


            return insert;
        }

        private InsertRequest GenInserRequestFlujoFirmas(DatosComiteCredito datosComite, IEnumerable<TemaComiteCredito> temasComite, bool requiereFirmaGerencia, string attachedFile)
        {
            var listaCodigos = new List<string>
            {
                "C0001",
                "C0002",
                "C0003",
                "C0004",
                "C0005",
                "C0006",
                "C0007",
                "C0008",
                "C0009",
                "C0010",
                "C0011"
            };

            var diccionarios = new List<InsertRequest.DictionaryDto>();

            foreach (var codigo in listaCodigos)
            {
                var dictionary = new InsertRequest.DictionaryDto();
                dictionary.Field = codigo;
                switch (codigo)
                {
                    case "C0001":
                        dictionary.Value = $"{datosComite.COC_NUMERO_COMITE}";
                        break;
                    case "C0002":
                        dictionary.Value = $"{datosComite.COC_FECHA}";
                        break;
                    case "C0003":
                        dictionary.Value = "TEMAS";
                        break;
                    case "C0004":
                        dictionary.Value = $"{temasComite.ToArray()[0].DESCRIPCION_TEMA}";
                        break;
                    case "C0005":
                        dictionary.Value = $"{temasComite.ToArray()[0].COT_OBSERVACION}";
                        break;
                    case "C0006":
                        dictionary.Value = $"{temasComite.ToArray()[1].DESCRIPCION_TEMA}";
                        break;
                    case "C0007":
                        dictionary.Value = $"{temasComite.ToArray()[1].COT_OBSERVACION}";
                        break;
                    case "C0008":
                        dictionary.Value = $"{temasComite.ToArray()[2].DESCRIPCION_TEMA}";
                        break;
                    case "C0009":
                        dictionary.Value = $"{temasComite.ToArray()[2].COT_OBSERVACION}";
                        break;
                    case "C0010":
                        dictionary.Value = $"{requiereFirmaGerencia}";
                        break;
                    case "C0011":
                        dictionary.Value = attachedFile;
                        break;
                    default:
                        break;
                }
                diccionarios.Add(dictionary);

                
            }

            var lista = new List<FileDto>() { new FileDto() { Base64String=attachedFile, Description= "133-FIRMA ACTAS COMITÉ DE CRÉDITO LEASING" } };
            return new InsertRequest()
            {
                CheckWorkflow = true,
                Data = diccionarios.ToArray(),
                FormCode = "133",
                OfficeCode = "01",
                OperationUser = "Web",
                Files = lista.ToArray(),
                ProcessId=289,
                Header = new InsertRequest.HeaderDto
                {
                    Token = _optionsCH.Token,
                    User = _optionsCH.User
                }
                
            };
        }
    }
}
