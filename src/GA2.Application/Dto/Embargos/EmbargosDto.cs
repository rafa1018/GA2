using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class EmbargosDto
    {

        public Guid Id { get; set; }
        public string RadicadoWorkManager { get; set; }
        public DateTime FechaRadicadoWorkManager { get; set; }
        public string RadicadoJuzgado { get; set; }
        public DateTime FechaRadicadoJuzgado { get; set; }
        public string EmailRespuesta { get; set; }
        public string DireccionRespuesta { get; set; }
        public string NombreDemandante { get; set; }
        public string NombreDemandado { get; set; }
        public string ExpedienteBancoAgrario { get; set; }
        public string Remanente { get; set; }
        public string Observaciones { get; set; }
        public string Respuesta { get; set; }
        public double Valor { get; set; }
        public int ClienteId { get; set; }
        public Guid JuzgadoId { get; set; }
        public Guid ProcesoId { get; set; }
        public Guid TipoEmbargoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public Guid CreadoPor { get; set; }
        public Guid ActualizadoPor { get; set; }

        public string Juzgado { get; set; }

        public string TipoEmbargo { get; set; }

        public string TipoProceso { get; set; }

        public string PrimerNombreCliente { get; set; }
        public string SegundoNombreCliente { get; set; }
        public string PrimerApellidoCliente { get; set; }

        public string SegundoApellidoCliente { get; set; }

        public string IdentificacionCliente { get; set; }

        public string NombreCompletoCliente { get; set; }


        public string TipoIdentificacion { get; set; }




    }


    public class InsetEmbargosDto
    {

        public Guid Id { get; set; }
        public string RadicadoWorkManager { get; set; }
        public DateTime FechaRadicadoWorkManager { get; set; }
        public string RadicadoJuzgado { get; set; }
        public DateTime FechaRadicadoJuzgado { get; set; }
        public string EmailRespuesta { get; set; }
        public string DireccionRespuesta { get; set; }
        public string NombreDemandante { get; set; }
        public string NombreDemandado { get; set; }
        public string ExpedienteBancoAgrario { get; set; }
        public string Remanente { get; set; }
        public string Observaciones { get; set; }
        public string Respuesta { get; set; }
        public double Valor { get; set; }
        public int ClienteTipoIdentificacion { get; set; }
        public string ClienteIdentificacion { get; set; }
        public Guid JuzgadoId { get; set; }
        public Guid ProcesoId { get; set; }
        public Guid TipoEmbargoId { get; set; }
       

    }

    public class EmbargoCuentaConceptoDto {

        public Guid Id { get; set; }
        public double Valor { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool IndicadorCesantias { get; set; }
        public Guid EmbardoId { get; set; }
        public Guid TipoRetencionId { get; set; }
        public Guid TipoEmbargoId { get; set; }
        public int CuentaId { get; set; }
        public int ConceptoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public Guid CreadoPorId { get; set; }
        public Guid ActualizadoPorId { get; set; }
        public bool Estado { get; set; }
        public string RadicadoWorkManager { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoRetencion { get; set; }
        public string Tipoembargo { get; set; }

    }

    public class ConsultaEmbargoRangoFecha
    {
        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

    }





    }
