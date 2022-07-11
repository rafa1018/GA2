using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class NuevaCuentasConceptosBusinessLogic : ICuentasBusinessLogic
    {

        /// <summary>
        /// Propiedades privadas Core Negocio
        /// </summary>
        private readonly IMapper _mapper;
        private readonly ICuentasConceptosRepository _cuentasConceptosRepository;

        public NuevaCuentasConceptosBusinessLogic(IMapper mapper, ICuentasConceptosRepository cuentasConceptosRepository)
        {
            _mapper = mapper;
            _cuentasConceptosRepository = cuentasConceptosRepository;
        }

        public async Task<Response<InsertCuentaConcepto>> CrearCuentaAfiliado(InsertCuentaConcepto cuenta)
        {

            InsertCuentaConcepto cuentaResult = await _cuentasConceptosRepository.validarExisteCuenta(cuenta.CTA_NUMERO);
            InsertCuentaConcepto cuentaTipoResult = await _cuentasConceptosRepository.validarExisteCuentaTipo(cuenta.CLI_ID, cuenta.TCT_ID);

            if (cuentaResult != null || cuentaTipoResult != null)
            {
                Response<InsertCuentaConcepto> respuesta = new Response<InsertCuentaConcepto>();
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "La Cuenta ya existe!";
                return respuesta;
            }
            else
            {
                InsertCuentaConcepto result = await _cuentasConceptosRepository.InsertarNuevaCuenta(cuenta);
                return new Response<InsertCuentaConcepto> { Data = result };
            }
        }

    }
}
