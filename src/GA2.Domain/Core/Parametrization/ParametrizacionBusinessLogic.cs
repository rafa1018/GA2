using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// BusinessLogic de Parametrizacion 
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class ParametrizacionBusinessLogic : IParametrizacionBusinessLogic
    {
        private readonly IParametrizacionRepository _parametrizationRepository;
        private readonly IMensajeRepository _messageRepository;
        private readonly IMapper _mapper;

        public ParametrizacionBusinessLogic(IParametrizacionRepository parametrizationRepository, IMapper mapper, IMensajeRepository messageRepository)
        {
            _parametrizationRepository = parametrizationRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Metodo Obtener seguro
        /// </summary>
        /// <author>Edgar Andrés Riaño Suarez</author>
        /// <date>2/03/202</date>
        /// <returns></returns>
        public async Task<Response<ParametrizacionSeguroDto>> ObtenerSeguro()
        {
            var responseData = this._mapper.Map<ParametrizacionSeguroDto>(
                await this._parametrizationRepository.ObtenerSeguro());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionSeguroDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear y Actualizar seguro mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionSeguroDto"></param>
        /// <returns></returns>

        public async Task<Response<ParametrizacionSeguroDto>> CrearSeguro(ParametrizacionSeguroDto parametrizacionSeguroDto)
        {
            var responseData = this._mapper.Map<ParametrizacionSeguroDto>(
                await this._parametrizationRepository.CrearSeguro(this._mapper.Map<SeguroParametrizacion>(parametrizacionSeguroDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje15; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionSeguroDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Obtener Tasa
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<Response<ParametrizacionTasaDto>> ObtenerTasa()
        {
            var responseData = this._mapper.Map<ParametrizacionTasaDto>(await this._parametrizationRepository.ObtenerTasa());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionTasaDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear y Actualizar tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionTasaDto"></param>
        /// <returns></returns>

        public async Task<Response<ParametrizacionTasaDto>> CrearTasa(ParametrizacionTasaDto parametrizacionTasaDto)
        {
            var responseData = this._mapper.Map<ParametrizacionTasaDto>(
                await this._parametrizationRepository.CrearTasa(this._mapper.Map<TasaParametrizacion>(parametrizacionTasaDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje15; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionTasaDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Obtener Plazo
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<Response<ParametrizacionPlazosDto>> ObtenerPlazo()
        {
            var responseData = this._mapper.Map<ParametrizacionPlazosDto>(
                await this._parametrizationRepository.ObtenerPlazo());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionPlazosDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }

        /// <summary>
        /// Metodo Obtener Parametro Transaccion
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ParametroTransaccionDto>>> ObtenerParametrosTransaccion()
        {
            IEnumerable<ParametroTransaccionDto> responseData = this._mapper.Map<IEnumerable<ParametroTransaccionDto>>(await this._parametrizationRepository.ObtenerParametrosTransaccion());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<IEnumerable<ParametroTransaccionDto>>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear y Actualizar plazos mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionDeadlineDto"></param>
        /// <returns></returns>
        public async Task<Response<ParametrizacionPlazosDto>> CrearPlazo(ParametrizacionPlazosDto parametrizacionDeadlineDto)
        {
            var responseData = this._mapper.Map<ParametrizacionPlazosDto>(
                await this._parametrizationRepository.CrearPlazo(this._mapper.Map<PlazoParametrizacion>(parametrizacionDeadlineDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje15; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionPlazosDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Obtener Legal Tasa
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ParametrizacionLegalTasaDto>>> ObtenerLegalTasa()
        {
            IEnumerable<ParametrizacionLegalTasaDto> responseData = this._mapper.Map<IEnumerable<LegalTasaParametrizacion>, IEnumerable<ParametrizacionLegalTasaDto>>(
                await this._parametrizationRepository.ObtenerLegalTasa());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje12; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<IEnumerable<ParametrizacionLegalTasaDto>>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear legal tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionLegalTasaDto"></param>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLegalTasaDto>> CrearLegalTasa(ParametrizacionLegalTasaDto parametrizacionLegalTasaDto)
        {
            var responseData = this._mapper.Map<ParametrizacionLegalTasaDto>(
                await this._parametrizationRepository.CrearLegalTasa(this._mapper.Map<LegalTasaParametrizacion>(parametrizacionLegalTasaDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje15; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLegalTasaDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }

        /// <summary>
        /// Metodo Actualizar legal tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrotransaccion"></param>
        /// <returns></returns>
        public async Task<Response<ParametroTransaccionDto>> ActualizarParametroTransaccion(ParametroTransaccionDto parametrotransaccion)
        {
            var responseData = this._mapper.Map<ParametroTransaccionDto>(
                await this._parametrizationRepository.ActualizarParametroTransaccion(this._mapper.Map<ParametroTransaccion>(parametrotransaccion)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje16; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametroTransaccionDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Actualizar legal tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionLegalTasaDto"></param>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLegalTasaDto>> ActualizarLegalTasa(ParametrizacionLegalTasaDto parametrizacionLegalTasaDto)
        {
            var responseData = this._mapper.Map<ParametrizacionLegalTasaDto>(
                await this._parametrizationRepository.ActualizarLegalTasa(this._mapper.Map<LegalTasaParametrizacion>(parametrizacionLegalTasaDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje16; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLegalTasaDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Eliminar legal tasa mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionLegalTasaDto"></param>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLegalTasaDto>> EliminarLegalTasa(ParametrizacionLegalTasaDto parametrizacionLegalTasaDto)
        {
            var responseData = this._mapper.Map<ParametrizacionLegalTasaDto>(
                await this._parametrizationRepository.EliminarLegalTasa(this._mapper.Map<LegalTasaParametrizacion>(parametrizacionLegalTasaDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje17; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLegalTasaDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Obtener Legal Alivio
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLegalAlivioDto>> ObtenerLegalAlivio()
        {
            var responseData = this._mapper.Map<ParametrizacionLegalAlivioDto>(await this._parametrizationRepository.ObtenerLegalAlivio());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje13; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLegalAlivioDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear y Actualizar legal alivio mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionLegalAlivioDto"></param>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLegalAlivioDto>> CrearLegalAlivio(ParametrizacionLegalAlivioDto parametrizacionLegalAlivioDto)
        {
            var responseData = this._mapper.Map<ParametrizacionLegalAlivioDto>(
                await this._parametrizationRepository.CrearLegalAlivio(this._mapper.Map<LegalAlivioParametrizacion>(parametrizacionLegalAlivioDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje15; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLegalAlivioDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Obtener Legal Gmf
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLegalGmfDto>> ObtenerLegalGmf()
        {
            var responseData = this._mapper.Map<ParametrizacionLegalGmfDto>(await this._parametrizationRepository.ObtenerLegalGmf());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje14; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLegalGmfDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear y Actualizar legal gmf mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionLegalGmfDto"></param>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLegalGmfDto>> CrearLegalGmf(ParametrizacionLegalGmfDto parametrizacionLegalGmfDto)
        {
            var responseData = this._mapper.Map<ParametrizacionLegalGmfDto>(
                await this._parametrizationRepository.CrearLegalGmf(this._mapper.Map<LegalGmfParametrizacion>(parametrizacionLegalGmfDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje15; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLegalGmfDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Obtener liquidacion
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLiquidacionDto>> ObtenerLiquidacion()
        {
            var responseData = this._mapper.Map<ParametrizacionLiquidacionDto>(await this._parametrizationRepository.ObtenerLiquidacion());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje11; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLiquidacionDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear y Actualizar liquidacion mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionLiquidacionDto"></param>
        /// <returns></returns>
        public async Task<Response<ParametrizacionLiquidacionDto>> CrearLiquidacion(ParametrizacionLiquidacionDto parametrizacionLiquidacionDto)
        {
            var responseData = this._mapper.Map<ParametrizacionLiquidacionDto>(
                await this._parametrizationRepository.CrearLiquidacion(this._mapper.Map<LiquidacionParametrizacion>(parametrizacionLiquidacionDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje15; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametrizacionLiquidacionDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear parametro transaccion mediante el Dto
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>7/05/202</date>
        /// <param name="parametrotransaccion"></param>
        /// <returns></returns>
        public async Task<Response<ParametroTransaccionDto>> CrearParametroTransaccion(ParametroTransaccionDto parametrotransaccion)
        {
            var responseData = this._mapper.Map<ParametroTransaccionDto>(
                    await this._parametrizationRepository.CrearParametroTransaccion(
                         this._mapper.Map<ParametroTransaccion>(parametrotransaccion)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje15; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ParametroTransaccionDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        private async Task<MensajeDto> ObtenerMensaje(string codigoMensaje)
        {
            return this._mapper.Map<MensajeDto>(await this._messageRepository.ObtenerMensaje(codigoMensaje));
        }


        /// <summary>
        /// Metodo para obtener los archivos parametrizados por modalidad
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <date>14/10/2021</date>
        /// <param name="tipoModalidadId"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ParametrizacionArchivoModalidadDto>>> ObtenerParametrizacionArchivosModalidad(int tipoModalidadId)
        {
            IEnumerable<ParametrizacionArchivoModalidadDto> responseData = this._mapper.Map<IEnumerable<ParametrizacionArchivoModalidadDto>>(
                await this._parametrizationRepository.ObtenerParametrizacionArchivosModalidad(tipoModalidadId));

            return new Response<IEnumerable<ParametrizacionArchivoModalidadDto>>
            {
                Data = responseData
            };
        }


        /// <summary>
        /// Metodo para obtener los archivos parametrizados por entidad
        /// </summary>
        /// <author> Edwin Lopez</author>
        /// <date>29/03/2022</date>
        /// <param name="tipoModalidadId"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ParametrizacionArchivoEntidadEducativaDto>>> ObtenerParametrizacionArchivosEntidadEducativa(string entidadId)
        {
            IEnumerable<ParametrizacionArchivoEntidadEducativaDto> responseData = this._mapper.Map<IEnumerable<ParametrizacionArchivoEntidadEducativaDto>>(
                await _parametrizationRepository.ObtenerParametrizacionArchivosEntidadEducativa(entidadId));

            return new Response<IEnumerable<ParametrizacionArchivoEntidadEducativaDto>>
            {
                Data = responseData
            };
        }
    }
}
