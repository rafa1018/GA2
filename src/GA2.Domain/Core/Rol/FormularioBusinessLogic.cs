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
    /// Formulario Logica
    /// </summary>
    public class FormularioBusinessLogic : IFormularioBusinessLogic
    {
        /// <summary>
        /// Inyeccion de formuarlio repositorio
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        private readonly IFormularioRepository _formularioRepository;

        /// <summary>
        /// Mappeador
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formularioRepository"></param>
        /// <param name="mapper"></param>
        public FormularioBusinessLogic(IFormularioRepository formularioRepository, IMapper mapper)
        {
            _formularioRepository = formularioRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formulario"></param>
        /// <returns></returns>
        public async Task<Response<FormularioDto>> ActualizarFormulario(FormularioDto formulario)
        {
            return new Response<FormularioDto>
            {
                Data = this.mapper.Map<FormularioDto>(
                    await this._formularioRepository.ActualizarFormulario(
                        this.mapper.Map<Formulario>(formulario)))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formulario"></param>
        /// <returns></returns>
        public async Task<Response<FormularioDto>> CrearFormulario(FormularioDto formulario)
        {

            return new Response<FormularioDto>
            {
                Data = this.mapper.Map<FormularioDto>(
                  await this._formularioRepository.CrearFormulario(
                      this.mapper.Map<Formulario>(formulario)))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formulario"></param>
        /// <returns></returns>
        public async Task<Response<FormularioDto>> ObtenerFormularioPorId(FormularioDto formulario)
        {
            return new Response<FormularioDto>
            {
                Data = this.mapper.Map<FormularioDto>(
                  await this._formularioRepository.CrearFormulario(
                      this.mapper.Map<Formulario>(formulario)))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<FormularioDto>>> ObtenerFormularios()
        {
            return new Response<IEnumerable<FormularioDto>>
            {
                Data = this.mapper.Map<IEnumerable<FormularioDto>>(
                  await this._formularioRepository.ObtenerFormularios())
            };
        }
    }
}
