using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto.Seven
{
    public class CrearCDPRequestDto
    {
        public int Emp_codi { get; set; } // Smallint 5 Código de la empresa.
        public int Top_codi { get; set; } // Smallint 5 Código del tipo de operación.Debe estar parametrizado en Seven ERP – SGNTOPER.
        public int Mpr_nume { get; set; } // Integer 10 Número del documento. 
        public DateTime Mpr_fech { get; set; } // Date yyyy/mm/dd Fecha de la operación.
        public string Mpr_desc { get; set; } // String 255 Descripción de la operación.
        public string Arb_csuc { get; set; } // String 15 Código de la sucursal. Debe estar parametrizada en Seven ERP – SGNARBOL.
        public string Ter_coda { get; set; } // String 40 Código del tercero.Debe estar parametrizado en Seven ERP – SGNTERCE.
        public string Mpr_tdos { get; set; } // String 5 Inicial del tipo documento de soporte. Debe estar parametrizado en Seven ERP – SPGDOCSO.
        public int Mpr_ndos { get; set; } // Integer 10 Número documento de soporte.
        public int Uni_codi { get; set; } // Smallint 5 Código de la unidad ejecutora.Debe estar parametrizada en Seven ERP – SPGUNIEJ.
        public IEnumerable<DetalleCrearCDP> vDetalle { get; set; } // Array máximo 1000 registros Vector de detalles.
    }
}
