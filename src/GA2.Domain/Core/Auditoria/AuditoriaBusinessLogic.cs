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
    public class AuditoriaBusinessLogic : IAuditoriaBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly IAuditoriaRepository _auditoriaRepository;

        public AuditoriaBusinessLogic(IMapper mapper, IAuditoriaRepository auditoriaRepository)
        {
            _mapper = mapper;
            _auditoriaRepository = auditoriaRepository;
        }

        public async Task<Response<listaAuditorias>> ObtenerlogAuditoria(ConsultaAuditoriaDto parametros)
        {
            ConsultaAuditoria param = new ConsultaAuditoria();
            param.AUR_USR_ID = parametros.UserId;
            param.AUR_VER_DETALLE = parametros.VerDetalle;
            param.AUR_FECHA_FILTRO_FIN = parametros.FechaFin;
            param.AUR_FECHA_FILTRO_FIN=parametros.FechaFin;
            param.AUR_AGRUPADOR = parametros.Agrupador;
            param.AUR_NOM_TABLE = parametros.NombreTabla;
            param.PAGENUM = parametros.PageNum;
            param.PAGESIZE = parametros.PageSize;

            int numero = await _auditoriaRepository.ObtenerNumeroRegistrologAuditoria(param);

            double numeropaginas = Convert.ToDouble(numero)/Convert.ToDouble(parametros.PageSize);
            IEnumerable<AuditoriaDto> tipoEmbargos = _mapper.Map<IEnumerable<AuditoriaDto>>(await _auditoriaRepository.ObtenerlogAuditoria(param));

            if (!IsInteger(numeropaginas)) {
                numeropaginas = numeropaginas + 1;
            }

            listaAuditorias lista = new listaAuditorias();
            lista.NumeroPaginas=Convert.ToInt32(numeropaginas);
            lista.TotalRegistros= numero;
            lista.Auditorias = (List<AuditoriaDto>)tipoEmbargos;

            return new Response<listaAuditorias> { Data = lista };

        }

        public async Task<Response<IEnumerable<TablasAuditoriaDto>>> ObtenerTablasAuditoria()
        {

            IEnumerable<TablasAuditoriaDto> tables = _mapper.Map<IEnumerable<TablasAuditoriaDto>>(await _auditoriaRepository.ObtenerTablasAuditoria());
            return new Response<IEnumerable<TablasAuditoriaDto>> { Data = tables };


        }

        public static bool IsInteger(double number)
        {
            return number == Math.Truncate(number);

        }
    }

    

   
}
