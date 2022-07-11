

namespace GA2.Application.Dto
{
    /// <summary>
    /// Request Vigia Carga Transaccion Request
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>13/06/2021</date>
    public class CargaTransaccionRequest
    {
        //En este dato se ingresa en nombre de la función que consume el web Service.
        public string origen { get; set; }
        //El tipo de identificación debe corresponder al código que este definido en la tabla TIPOS DE IDENTIFICACION.
        public string tercero_tipide_codigo { get; set; }
        //El dato debe ser suministrado por la empresa y corresponde al número de identificación del cliente que realizo laoperación.
        public string tercero_numide { get; set; }
        //El código del producto debe corresponder al código que esté definido en la tabla PRODUCTOS.El dato debe ser suministrado por la empresa
        public string producto_codigo { get; set; }
        //Número del producto operado por el cliente. El dato debe ser suministrado por la empresa.
        public string producto_numero { get; set; }
        //El código del tipo de transacción debe corresponder al código que este definido en la tabla TIPOS DE TRANSACCION.
        public string tiptran_codigo { get; set; }
        //Fecha en la cual se realiza la operación, formato MM-DD- YYYY
        public string fecha { get; set; }
        //Numero secuencial que permite diferenciar las operaciones realizadas en la misma fecha
        public string consecutivo { get; set; }
        //Este dato debe corresponder al código que para la ciudad se encuentre definido en la tabla del SISTEMA GEOGRAFICO.
        public string sisgeo_codigo { get; set; }
        //Este dato debe corresponder al código que para la sucursal se encuentre definido en la tabla SUCURSALES.
        public string sucursal_codigo { get; set; }
        //Valor de la operación. El dato debe ser suministrado por la empresa.
        public string valor { get; set; }
        //Valor de la operación en moneda extranjera.El dato debe ser suministrado por la empresa si aplica.
        public string valormonedaextranjera { get; set; }
        //Este dato debe corresponder al código que para la moneda se encuentre definido en la tabla TIPOS DE MONEDA.El dato debe ser
        //suministrado por la empresa si aplica.
        public string tipmon_codigo { get; set; }
        //Si la operación fue realizada a través de un intermediario este dato debe corresponder al código que para el intermediario se encuentre definido en
        //la tabla INTERMEDIARIOS.
        public string intermediario_codigo { get; set; }
        //Si la operación tiene un tercero como contraparte, este dato puede ser suministrado
        public string tipide_remitente { get; set; }
        //En este campo se registra el número de identificación de la persona que hace la contraparte en la operación.
        public string numide_remitente { get; set; }
        //Nombres de la contraparte de la operación.
        public string nombreremitente { get; set; }
        //Apellidos de la contraparte de la operación.
        public string apellidoremitente { get; set; }
        //Si la operación maneja en dato de país de origen o destino, este dato debe corresponder al código que para el país se encuentra definido en la tabla del SISTEMA GEOGRAFICO.
        public string codigopaisremite { get; set; }
        //Nombre de la ciudad en la que se origina o de destino de la operación, cuando aplique.
        public string ciudadremite { get; set; }
        //Dirección reportada en la que se origina o de destino de la operación, cuando aplique.
        public string direccionremite { get; set; }
        //Numero telefónico reportado en la que se origina o de destino de la operación, Cuando aplique.
        public string telefonoremite { get; set; }
        //Corresponde al estado de la operación codificado en la tabla para ESTADOS DE OPERACIÓN, si se requiere
        public string estadooperacion { get; set; }
        //Nombre de la ciudad en la que se origina o de destino de la operación, cuando aplique.
        public string ciudadcliente { get; set; }
        //Dirección reportada en la que se origina o de destino de la operación, cuando aplique.
        public string direccioncliente { get; set; }
        //Teléfono reportado en la que se origina o de destino de la operación, cuando aplique.
        public string telefonocliente { get; set; }
        //Este dato debe corresponder al código que para el medio se encuentra definido en la tabla del MEDIOSOPERACION. El dato debe ser suministrado por la empresa si aplica.
        public string medio_codigo { get; set; }
        //Este dato debe corresponder al código que para la forma de pago se encuentra definido en la tabla del FORMASPAGO.El dato debe ser suministrado por la empresa si aplica.
        public string formapago_codigo { get; set; }
        //Dato de la identificación del cliente desde el cual se recibe la transacción o cualquier dato que sea relevante documentar
        public string referencia1 { get; set; }
        //Dato del numero de producto del cliente desde el cual se recibe la transacción o cualquier dato que sea relevante documentar
        public string referencia2 { get; set; }
        //Observaciones sobre la operación.
        public string observaciones { get; set; }
        //Este dato debe corresponder al código que para los dispositivos se encuentra definido en la tabla del DISPOSITIVOS.El dato debe ser suministrado por la empresa si aplica.
        public string dispositivo_codigo { get; set; }
        //Dirección desde la cual  se efectúa la transacción.El dato debe ser suministrado por la empresa si aplica.
        public string direcciontransaccion { get; set; }
        //Usuario que realiza la ejecución del consumo del web Service.Puede ser el usuario de red o el usuario de base de datos. El dato debe ser suministrado por la empresa si aplica.
        public string usuadi { get; set; }
    }
}
