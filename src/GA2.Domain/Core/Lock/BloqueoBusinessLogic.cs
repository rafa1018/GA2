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
    /// BusinessLogic de Bloqueo 
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public class BloqueoBusinessLogic : IBloqueoBusinessLogic
    {
        private readonly IBloqueoRepository _lockRepository;
        private readonly IMensajeRepository _messageRepository;
        private readonly IMapper _mapper;

        public BloqueoBusinessLogic(IBloqueoRepository lockRepository, IMapper mapper, IMensajeRepository messageRepository)
        {
            _lockRepository = lockRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Metodo Obtener Bloqueo
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns></returns>
        public async Task<Response<IEnumerable<BloqueoDto>>> ObtenerBloqueoAsync()
        {
            IEnumerable<BloqueoDto> responseData = this._mapper.Map<IEnumerable<Bloqueo>, IEnumerable<BloqueoDto>>(await this._lockRepository.ObtenerBloqueos());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje6; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<IEnumerable<BloqueoDto>>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo Crear Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="parametrizacionBloqueoDto"></param>
        /// <returns></returns>
        public async Task<Response<BloqueoDto>> CrearBloqueo(BloqueoDto parametrizacionBloqueoDto)
        {
            var responseData = this._mapper.Map<BloqueoDto>(
                await this._lockRepository.CrearBloqueo(this._mapper.Map<Bloqueo>(parametrizacionBloqueoDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje8; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<BloqueoDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo  Actualizar Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="parametrizacionBloqueoDto"></param>
        /// <returns></returns>
        public async Task<Response<BloqueoDto>> ActualizarBloqueo(BloqueoDto parametrizacionBloqueoDto)
        {
            var responseData = this._mapper.Map<BloqueoDto>(
                await this._lockRepository.ActualizarBloqueo(this._mapper.Map<Bloqueo>(parametrizacionBloqueoDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje9; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<BloqueoDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }
        /// <summary>
        /// Metodo  Actualizar Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <param name="parametrizacionBloqueoDto"></param>
        /// <returns></returns>
        public async Task<Response<BloqueoDto>> EliminarBloqueo(BloqueoDto parametrizacionBloqueoDto)
        {
            var responseData = this._mapper.Map<BloqueoDto>(
                await this._lockRepository.EliminarBloqueo(this._mapper.Map<Bloqueo>(parametrizacionBloqueoDto)));
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje10; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<BloqueoDto>
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
