using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class MatriculaInmibiliariaDto
    {
        public Guid MaiId{ get; set; }
        public string MaiNumeroMatricula { get; set; }
        public string MaiDireccion { get; set; }
        public  DateTime MaiFechaRegistro { get; set; }
        public string PrpTipoIdentificacion { get; set; }
        public string PrpNumeroIdentificacion { get; set; }
        public string PrpNombreRazonSocial { get; set; }
        public int DcpId { get; set; }
        public int DpdId { get; set; }

        public List<PropietariosMatriculasInmobiliariasDto> Propietarios { get; set; }
        public List<HistotialNovedadesMatriculasInmobiliariasDto> Novedades { get; set; }



    }


    public class OperacionesMatriculasDto
    {

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }

    public class CausalNovedamatriculaDto {

        public Guid Id { get; set; }
        public Guid Top_Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }


}
