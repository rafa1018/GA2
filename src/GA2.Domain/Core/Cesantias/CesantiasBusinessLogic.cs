using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Consecutivo Logica
    /// <author>Erwin Pantoja España</author>
    /// <date>27/09/2021</date>
    /// </summary>
    /// 
    public class CesantiasBusinessLogic : ICesantiasBusinessLogic
    {

        private readonly IMapper _mapper;
        private readonly ICesantiasRepository _cesantiasRepository;
        private readonly IClientRequestProvider _iClientRequestProvider;
        private readonly ICatalogosRepository _catalogsRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="catalogsRepository"></param>
        /// <param name="cesantiasRepository"></param>
        /// <param name="iClientRequestProvider"></param>
        public CesantiasBusinessLogic(
            IMapper mapper, 
            ICesantiasRepository cesantiasRepository,
            IClientRequestProvider iClientRequestProvider, 
            ICatalogosRepository catalogsRepository
            )
        {
            _mapper = mapper;
            _cesantiasRepository = cesantiasRepository;
            _iClientRequestProvider = iClientRequestProvider;
            _catalogsRepository = catalogsRepository;
        }

        /// <summary>
        /// Metodo logica de negocio para obtener la solicitud del tramite para cesantias
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <param name="solicitud"></param>
        /// <returns>IEnumerable<ObtenerTramiteCesantiasDto></returns>
        public async Task<Response<ObtenerTramiteCesantiasDto>> ObtenerTramiteCesantias(ParametrosObtenerCesantiasDto solicitud)
        {
            Response<ClienteCesantiasDto> clienteDto = new Response<ClienteCesantiasDto>();
            clienteDto = await _iClientRequestProvider.ObtenerInformacionClientePorDocumentoYTipo(0, "", (int)solicitud.IdCliente);

            Response<ObtenerTramiteCesantiasDto> respuesta = new Response<ObtenerTramiteCesantiasDto>();

            if (clienteDto.Data == null) {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "El afiliado no existe en BUA";
                return respuesta;
            }

            var tramiteSolicitud = this._mapper.Map<ParametrosObtenerCesantias>(solicitud);
            tramiteSolicitud.CLI_ID = clienteDto.Data.IdCliente;


            respuesta.Data = this._mapper.Map<ObtenerTramiteCesantiasDto>(await this._cesantiasRepository.ObtenerTramiteCesantias(tramiteSolicitud));

            respuesta.Data.NOMBRE_CLIENTE = $"{clienteDto.Data.PrimerNombre} {clienteDto.Data.SegundoNombre} {clienteDto.Data.PrimerApellido} {clienteDto.Data.SegundoApellido}";
            respuesta.Data.CORREO_PERSONAL = clienteDto.Data.CorreoPersonal;
            respuesta.Data.NO_CELULAR = clienteDto.Data.NumeroCelular;
            respuesta.Data.TELEFONO_RESIDENCIA = clienteDto.Data.TelefonoResidencia;
            respuesta.Data.CEDULA_CLIENTE = int.Parse(clienteDto.Data.Identificacion);
            respuesta.Data.DIRECCION_RESIDENCIA = clienteDto.Data.Direccion;

            return respuesta;
        }


        public async Task<Response<InformacionBasicaCesantiasDto>> InformacionBasicaCesantias(int numeroIdentificacion) {
            Response<ClienteCedulaDto> clienteDto = await
                _iClientRequestProvider.ObtenerInformacionClienteCedula(numeroIdentificacion);

            IEnumerable<TipoIdentificacion> litaTipoIdentificacion = await _catalogsRepository.ObtenerTiposIdentificacion();
            IEnumerable<Entities.Departamento> departamentos = await _catalogsRepository.ObtenerDepartamentos();
            IEnumerable <Ciudad> ciudad = await _catalogsRepository.ObtenerCiudades();
            IEnumerable<CatalogoValor> catalogoValor = await _catalogsRepository.ObtenerValoresCatalogos();
            IEnumerable<Entities.Fuerzas> fuerzas = await _catalogsRepository.ObtenerFuerzas();
            IEnumerable<Entities.Categoria> categorias = await _catalogsRepository.ObtenerCategorias();
            IEnumerable<Entities.Grado> grados = await _catalogsRepository.ObtenerGrados();
            IEnumerable<Profesion> profesiones = await _catalogsRepository.ObtenerProfesiones();


            Response<InformacionBasicaCesantiasDto> respuesta = new Response<InformacionBasicaCesantiasDto>();
            InformacionBasicaCesantiasDto informacionBasicaCesantias = new InformacionBasicaCesantiasDto();

            informacionBasicaCesantias.clientIdentificationType = litaTipoIdentificacion
                                                    .Where(x => x.TID_ID == clienteDto.Data.IdTipoIdentificacion)
                                                    .FirstOrDefault()
                                                    .TID_DESCRIPCION;
            informacionBasicaCesantias.sobIDNumber = clienteDto.Data.Identificacion;
            informacionBasicaCesantias.sobExpeditionDate = clienteDto.Data.FechaExpedicionDocumento;
            informacionBasicaCesantias.expeditionState = departamentos.Where(x => x.DPD_ID == clienteDto.Data.IdDepartamentoExpedicionDocumento)
                                                    .FirstOrDefault()
                                                    .DPD_NOMBRE;
            informacionBasicaCesantias.expeditionCity = ciudad.Where(x => x.DPC_ID == clienteDto.Data.IdCiudadExpedicionDocumento)
                                                    .FirstOrDefault()
                                                    .DPC_NOMBRE;
            informacionBasicaCesantias.sobFirstLastName = clienteDto.Data.PrimerApellido;
            informacionBasicaCesantias.sobSecondLastName = clienteDto.Data.SegundoApellido;
            informacionBasicaCesantias.sobFirstName = clienteDto.Data.PrimerNombre;
            informacionBasicaCesantias.sobMiddleName = clienteDto.Data.SegundoNombre;
            informacionBasicaCesantias.sobBirthDate = clienteDto.Data.FechaNacimiento;
            informacionBasicaCesantias.bornState = departamentos.Where(x => x.DPD_ID == clienteDto.Data.IdDepartamentoNacimiento)
                                                    .FirstOrDefault()
                                                    .DPD_NOMBRE;
            informacionBasicaCesantias.bornCity = ciudad.Where(x => x.DPC_ID == clienteDto.Data.IdCiudadNacimiento)
                                                    .FirstOrDefault()
                                                    .DPC_NOMBRE;
            informacionBasicaCesantias.sobSex = catalogoValor.Where(x => x.CAT_ID == 1 && x.CVL_CODIGO == clienteDto.Data.Sexo)
                                                    .FirstOrDefault()
                                                    .CVL_DESCRIPCION;
            informacionBasicaCesantias.civilState = catalogoValor.Where(x => x.CAT_ID == 2 && x.CVL_CODIGO == clienteDto.Data.EstadoCivil)
                                                    .FirstOrDefault()
                                                    .CVL_DESCRIPCION;
            informacionBasicaCesantias.educationLevel = "Falta";
            informacionBasicaCesantias.force = fuerzas.Where(x => x.FRZ_ID == clienteDto.Data.IdFuerza)
                                                    .FirstOrDefault()
                                                    .FRZ_DESCRIPCION;
            informacionBasicaCesantias.category = categorias.Where(x => x.CTG_ID == clienteDto.Data.IdCategoria)
                                                    .FirstOrDefault()
                                                    .CTG_DESCRIPCION;
            informacionBasicaCesantias.grade = grados.Where(x => x.GRD_ID == clienteDto.Data.IdGrado)
                                                    .FirstOrDefault()
                                                    .GRD_DESCRIPCION;
            informacionBasicaCesantias.profession = profesiones.Where(x => x.PRF_ID == clienteDto.Data.IdProfesion)
                                                    .FirstOrDefault()
                                                    .PRF_DESCRIPCION;
            respuesta.Data = informacionBasicaCesantias;

            return respuesta;
        }
    }
}
