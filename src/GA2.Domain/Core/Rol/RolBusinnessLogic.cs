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
    public class RolBusinessLogic : IRolBusinessLogic
    {
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;

        public RolBusinessLogic(IRolRepository rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<Response<RolDto>> CreateRol(RolDto roldto)
        {
            var rol = this._mapper.Map<Rol>(roldto);
            return new Response<RolDto> { Data = this._mapper.Map<RolDto>(await this._rolRepository.CrearRol(rol)) };
        }

        public async Task<Response<RolDto>> UpdateRol(RolDto roldto)
        {
            var rol = this._mapper.Map<Rol>(roldto);
            return new Response<RolDto> { Data = this._mapper.Map<RolDto>(await this._rolRepository.ActualizarRol(rol)) };
        }

        public async Task<Response<RolDto>> DeleteRol(RolDto roldto)
        {
            var rol = this._mapper.Map<Rol>(roldto);
            return new Response<RolDto> { Data = this._mapper.Map<RolDto>(await this._rolRepository.ActualizarRol(rol)) };
        }

        public async Task<Response<IEnumerable<RolDto>>> GetAllRol()
        {
            return new Response<IEnumerable<RolDto>> { Data = this._mapper.Map<IEnumerable<RolDto>>(await this._rolRepository.ObtenerRoles()) };
        }

        public async Task<Response<RolDto>> GetByIdRol(Guid id)
        {
            return new Response<RolDto> { Data = this._mapper.Map<RolDto>(await this._rolRepository.ObtenerRolPorId(id)) };
        }
    }
}
