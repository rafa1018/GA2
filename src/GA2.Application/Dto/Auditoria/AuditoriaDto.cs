using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class AuditoriaDto
    {

        public Guid Id { get; set; }
        public string NombreTabla { get; set; }
        public string TipoAccion { get; set; }
        public string NombreColumna { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Guid UsurioId { get; set; }
        public string NombreUsuario { get; set; }
        public Guid Agrupador { get; set; }

    }


    public class listaAuditorias { 

        public int NumeroPaginas { get; set; }
        public int TotalRegistros { get; set; }
        public List<AuditoriaDto> Auditorias { get; set; }

    }

    public class ConsultaAuditoriaDto
    {
        public string? NombreTabla { get; set; }
    
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public Guid? UserId { get; set; }
     
        public string? Agrupador { get; set; }
    
        public bool VerDetalle { get; set; }

        public int PageNum { get; set; }

        public int PageSize { get; set; }

    }

    public class TablasAuditoriaDto
    {
        public string NombreTabla { get; set; }

    }
}
