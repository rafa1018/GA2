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
    /// BusinessLogic de estado 
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/202</date>
    /// </summary>
    public class EstadoBusinessLogic : IEstadoBusinessLogic
    {
        private readonly IEstadoRepository _stateRepository;
        private readonly IMensajeRepository _messageRepository;
        private readonly IMapper _mapper;

        public EstadoBusinessLogic(IEstadoRepository stateRepository, IMapper mapper, IMensajeRepository messageRepository)
        {
            _stateRepository = stateRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Metodo Obtener Estado
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<Response<IEnumerable<EstadoDto>>> ObtenerEstado()
        {
            IEnumerable<EstadoDto> responseData = this._mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoDto>>(await this._stateRepository.ObtenerEstados());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje2; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<IEnumerable<EstadoDto>>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionEstadoDto"></param>
        /// <returns></returns>
        public async Task<Response<EstadoDto>> CrearEstado(EstadoDto parametrizacionEstadoDto)
        {
            var responseData = this._mapper.Map<EstadoDto>(
                await this._stateRepository.CrearEstado(this._mapper.Map<Estado>(parametrizacionEstadoDto)));
            string codigoMensaje = "";
            if(responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje3; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<EstadoDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo  Actualizar estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionEstadoDto"></param>
        /// <returns></returns>
        public async Task<Response<EstadoDto>> ActualizarEstado(EstadoDto parametrizacionEstadoDto)
        {
            var responseData = this._mapper.Map<EstadoDto>(
                await this._stateRepository.ActualizarEstado(this._mapper.Map<Estado>(parametrizacionEstadoDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje4; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<EstadoDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo  Actualizar estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="parametrizacionEstadoDto"></param>
        /// <returns></returns>
        public async Task<Response<EstadoDto>> EliminarEstado(EstadoDto parametrizacionEstadoDto)
        {
            var responseData = this._mapper.Map<EstadoDto>(
                await this._stateRepository.EliminarEstado(this._mapper.Map<Estado>(parametrizacionEstadoDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje5; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<EstadoDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }

        private async Task<MensajeDto> ObtenerMensaje(string codigoMensaje)
        {
            return this._mapper.Map<MensajeDto>(await this._messageRepository.ObtenerMensaje(codigoMensaje));
        }
    }
}
