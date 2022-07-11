using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ParamGeneralesSegurosDto
    {
        public int idSeguro { get; set; }
        public decimal seguroVida { get; set; }
        public decimal seguroTodoRiesgo { get; set; }
        public DateTime seguroFechaModificacion { get; set; }
        public int seguroModificadoPor { get; set; }
        public bool seguroEstado { get; set; }
        public int idExcepcionSeguro { get; set; }
        public int departamentoId { get; set; }
        public  int departamentoCodigo { get; set; }
        public int ciudadId { get; set; }
        public int ciudadCodigo { get; set; }
        public string CiudadNombre { get; set; }
        public string DepartamentoNombre { get; set; }
    }
}
