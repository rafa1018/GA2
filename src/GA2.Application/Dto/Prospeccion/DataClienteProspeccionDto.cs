using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DataClienteProspeccionDto
    {
        public int TipoIdentificacion { get; set; }
        public string NumeroDocumento { get; set; }
        public string Fuerza { get; set; }
        public string Categoria { get; set; }
        public string Grado { get; set; }
        public string Nombres { get; set; }
        public string CiudadResidencia { get; set; }
        public string Direccion { get; set; }
        public int TipoTelefonoId { get; set; }
        public string TelefonoFijo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CuotasAportadas { get; set; }
        public string Regimen { get; set; }
        public string TipoAfiliacion { get; set; }
        public int EstratoId { get; set; }
        public string Estrato { get; set; }
        public int NivelEstudiosId { get; set; }
        public string NivelEstudios { get; set; }
        public int ViviendaPropiaId { get; set; }
        public string ViviendaPropia { get; set; }
        public int PersonasCargoId { get; set; }
        public string PersonasCargo { get; set; }
        public int CategoriaId { get; set; }
        public int GradoId { get; set; }
        public int FuerzaId { get; set; }
        public int CiudadResidenciaId { get; set; }
        public int TipoContratoId { get; set; }
        public string TipoContrato { get; set; }
        public int AntiguedadAños { get; set; }
        public string FormaPago { get; set; }
        public string Garantia { get; set; }
    }
}
