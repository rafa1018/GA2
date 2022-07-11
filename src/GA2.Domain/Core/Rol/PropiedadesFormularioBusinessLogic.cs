using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Propiedades Formulario logica negocio
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/04/2021</date>
    public class PropiedadesFormularioBusinessLogic
    {
        /// <summary>
        /// Propiedadformulario repository 
        /// </summary>
        /// <auhtor>Oscar Julian Rojas</auhtor>
        /// <date>29/04/2021</date>
        private readonly IPropiedadFormularioRepository _propiedadFormularioRepository;

        /// <summary>
        /// Imapper inyeccion de mapeador
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor Inyectando propiedad repository y mapper
        /// </summary>
        /// <param name="propiedadFormularioRepository">PropieaddFormulario repositorio</param>
        /// <param name="mapper">Mapeador de PropiedadFormulario a dto</param>
        public PropiedadesFormularioBusinessLogic(IPropiedadFormularioRepository propiedadFormularioRepository, IMapper mapper)
        {
            _propiedadFormularioRepository = propiedadFormularioRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Actualizar propiedad formulario
        /// </summary>
        /// <param name="propiedadFormulario">Propiedad formulario a actualizar</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        /// <returns>Propiedad actualizada</returns>
        public async Task<Response<PropiedadFormularioDto>> ActualizarPropiedadFormulario(PropiedadFormularioDto propiedadFormulario)
        {
            return new Response<PropiedadFormularioDto>
            {
                Data = this._mapper.Map<PropiedadFormularioDto>(
                    await this._propiedadFormularioRepository.ActualizarPropiedadFormulario(
                        this._mapper.Map<PropiedadFormulario>(propiedadFormulario)))
            };
        }

        /// <summary>
        /// Crear propiedad formulario
        /// </summary>
        /// <param name="propiedadFormulario">propiedad a crear</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        /// <returns>Propieadad creada</returns>
        public async Task<Response<PropiedadFormularioDto>> CrearPropiedadFormulario(PropiedadFormularioDto propiedadFormulario)
        {
            return new Response<PropiedadFormularioDto>
            {
                Data = this._mapper.Map<PropiedadFormularioDto>(
                  await this._propiedadFormularioRepository.CrearPropiedadFormulario(
                      this._mapper.Map<PropiedadFormulario>(propiedadFormulario)))
            };
        }

        /// <summary>
        /// Eliminar Propiedad Formulario
        /// </summary>
        /// <param name="propiedadFormulario">Propieadad aeliminar</param>
        /// <returns>Propiedad eliminada</returns>
        public async Task<Response<PropiedadFormularioDto>> EliminarPropiedadFormulario(PropiedadFormularioDto propiedadFormulario)
        {
            return new Response<PropiedadFormularioDto>
            {
                Data = this._mapper.Map<PropiedadFormularioDto>(
                await this._propiedadFormularioRepository.EliminarPropiedadFormulario(
                    this._mapper.Map<PropiedadFormulario>(propiedadFormulario)))
            };
        }

        /// <summary>
        /// Obnteer propidades de formulario
        /// </summary>
        /// <param name="propiedadFormulario">Id de formulario</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        /// <returns>Lista de propiedades de formulario</returns>
        public async Task<Response<IEnumerable<PropiedadFormularioDto>>> ObtenerPropiedadesFormularioPorFormularioId(Guid propiedadFormulario)
        {
            return new Response<IEnumerable<PropiedadFormularioDto>>
            {
                Data = this._mapper.Map<IEnumerable<PropiedadFormularioDto>>(
                          await this._propiedadFormularioRepository.ObtenerPropiedadesFormularioPorFormularioId(
                              propiedadFormulario))
            };
        }

    }
}
