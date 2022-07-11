namespace GA2.Application.Dto.Seven
{
    public class DetalleCrearCDP
    {
        public string Rub_codi { get; set; } // String 40 Código del rubro.Debe estar parametrizado en Seven ERP – SPGRUBRO.
        public string Pro_codi { get; set; } // String 128 Código del producto.Debe estar parametrizado en Seven ERP – 2 SINPRODU.
        public string Arb_codc { get; set; } // String 15 Código del centro de costo.Debe estar parametrizado en Seven ERP – SGNARBOL.
        public string Arb_coda { get; set; } // String 15 Código del área de negocio.Debe estar parametrizado en Seven ERP – SGNARBOL.
        public string Arb_codp { get; set; } // String 15 Código del proyecto.Debe estar parametrizado en Seven ERP – SGNARBOL.
        public decimal Dmp_valo { get; set; } // Numérico 16,2 Valor.
        public string Dmp_desc { get; set; } // String 255 Descripción del detalle.
    }
}