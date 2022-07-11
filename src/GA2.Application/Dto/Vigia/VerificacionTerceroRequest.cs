

namespace GA2.Application.Dto
{
    /// <summary>
    /// Request Vigia Verificacion Tercero Request
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>13/06/2021</date>
    public class VerificacionTerceroRequest
    {
        //Usuario del directorio activo o de base de datos que está ejecutando la ejecución del web Service.
        public string Pe_Origen { get; set; }
        //Dato que se verifica en las listas restrictivas.
        public string Pe_Dato { get; set; }
        //Indica al servicio si el dato que se recibe en el parámetro pe_dato, corresponde a un número de
        //identificación(1) o a un nombre o alias(2).
        public string Pe_TipoVerificacion { get; set; }
        //(2).SI pe_porcentaje PORCENTAJE CARÁCTER 3 Indica al servicio el porcentaje de coincidencia mínima que debe darse en la
        //comparación de la cadena de entrada con los datos de las listas restrictivas.Aplica exclusivamente para la
        //comparación de cadena mas no de números de identificación. El Valor debe estar entre { '0' - '100'}
        public string Pe_Porcentaje { get; set; }

    }
}
