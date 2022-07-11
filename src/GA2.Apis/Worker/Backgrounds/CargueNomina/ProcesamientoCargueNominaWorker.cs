using AutoMapper;
using Azure.Storage.Blobs.Models;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Worker.Backgrounds.CargueNomina
{
    /// <summary>
    /// 
    /// </summary>
    class ProcesamientoCargueNominaWorker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaWorkerRepository _cuentaWorkerRepository;
        private readonly int documentoProcesar = 6;

        public ProcesamientoCargueNominaWorker(ILogger<Worker> logger,
                                               IMapper mapper,
                                               ICuentaWorkerRepository cuentaWorkerRepository,
                                               IMovimientoRepository movimientoRepository,
                                               IClienteRepository clienteRepository)

        {
            _logger = logger;
            _mapper = mapper;
            _cuentaWorkerRepository = cuentaWorkerRepository;
            _movimientoRepository = movimientoRepository;
            _clienteRepository = clienteRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                var documentos = await _movimientoRepository.ObtenerDocumentosCarga(documentoProcesar);

                foreach (var item in documentos)
                {
                    _logger.LogInformation("Worker init at: {time}", DateTimeOffset.Now);
                    // obtener la cuenta storage por el nombre del archivo item.DCT_NOMBRE
                    var cuentaStorage = await _movimientoRepository.ObtenerBlobStoragePorNombre(item.DCT_NOMBRE);
                    var blob = await  ObtenerDocumentoBlob(cuentaStorage);
                    StreamReader reader = new(blob.Content);
                    var componentes = DeserializarComponente(reader);
                    foreach (var componente in componentes.BODY)
                    {
                        //Validacion de existencia de cliente
                        var cliente = await _clienteRepository.ObtenerClientePorTipoIdentificationYNumero
                            (componente.TIPO_IDENTIFICACION, componente.IDENTIFICACION);

                        if (cliente == null)
                        {
                            _logger.LogInformation("Worker clients register at: {time}", DateTimeOffset.Now);
                            //armar cliente
                            var a = await _clienteRepository.InsertarClienteNomina(componente);
                            _logger.LogInformation("Worker clients register at: {time}", DateTimeOffset.Now);
                        }

                    }
                    var clieentesBody = JsonConvert.SerializeObject(componentes.BODY);
                    componentes.DOCUMENTO = _mapper.Map<DocumentoDto>(item);
                    var componentesJson = JsonConvert.SerializeObject(componentes);

                    // Registra Clientes Crear Cliente no existentes
                    _ = await _movimientoRepository.ValidarNomina(clieentesBody);
                    _logger.LogInformation("Worker clients register at: {time}", DateTimeOffset.Now);

                    // creacion de cuentas Crear Cuentas no existentes
                    _ = await  _cuentaWorkerRepository.ParametrosCreacionCuenta(componentesJson);
                    _logger.LogInformation("Worker accounts at: {time}", DateTimeOffset.Now);

                    _ = await EliminarDocumentoBlob(cuentaStorage);
                }



                // En caso de error cambiar el estado a fallido o novedad sobre el documento enviar correo y notificar.
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }
        }

        private async Task<BlobDownloadInfo> ObtenerDocumentoBlob(CuentaStorage cuentaStorage)
        {
            try
            {
                return await _movimientoRepository.DescargarArchivoStorage(cuentaStorage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static ComponentesDTO DeserializarComponente(StreamReader reader)
        {
            try
            {
                var blobString = reader.ReadToEnd();
                ComponentesDTO componentes = JsonConvert.DeserializeObject<ComponentesDTO>(blobString);
                return componentes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<Azure.Response> EliminarDocumentoBlob(CuentaStorage cuentaStorage)
        {
            try
            {
                return await _movimientoRepository.EliminarArchivoStorage(cuentaStorage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
