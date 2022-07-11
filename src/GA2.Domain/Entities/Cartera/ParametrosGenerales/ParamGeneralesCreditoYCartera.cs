using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ParamGeneralesCreditoYCartera
    {
        public int PRM_SMLV { get; set; }
        public decimal PRM_PORC_INFLACION { get; set; }
        public decimal PRM_PORC_FINANCIA_VIS { get; set; }
        public decimal PRM_PORC_FINANCIA_NO_VIS { get; set; }
        public decimal PRM_NO_SALARIO_MIN_VIS { get; set; }
        public int PRM_DIAS_VALIDO_PREAPROB { get; set; }
        public int PRM_SCORE_MINIMO { get; set; }
        public decimal PRM_PORC_CAPACIDAD_ENDEUDA { get; set; }
        public int PRM_VIGENCIA_CONSULTA_BURO { get; set; }
        public int PRM_PORC_CANON_INI_LSG { get; set; }
        public int PRM_PORC_CANON_FIN_LSG { get; set; }
        public int PRM_PORC_OPC_COMPRA_LSG { get; set; }
        public int PRM_MESES_LEY_FRECH { get; set; }
        public int PRM_MESES_SUBSIDIO_CUOTA { get; set; }
    }
}
