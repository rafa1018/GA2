using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ParamGeneralesCreditoYCarteraDto
    {
        public int parametroSalarioMinimo{ get; set; }
        public decimal porcentajeInflacion { get; set; }
        public decimal porcentajeViviendaVis { get; set; }
        public decimal porcentajeViviendaNoVis { get; set; }
        public decimal limiteSalariosVis { get; set; }
        public int diasPreaprobado { get; set; }
        public int puntajeMinimoCentrales { get; set; }
        public decimal porcentajeMinimoEndeudamiento { get; set; }
        public int vigenciaDiasConsultaCentrales { get; set; }
        public int porcentajeMinimoCanonInicial { get; set; }
        public int porcentajeMaximoCanonInicial { get; set; }
        public int porcentajeMaximoOpcionCompra { get; set; }
        public int maximoMesesAlivioTasa { get; set; }
        public int numeroMesesAlivio { get; set; }

    }
}
