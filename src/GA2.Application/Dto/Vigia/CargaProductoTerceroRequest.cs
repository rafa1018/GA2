

namespace GA2.Application.Dto
{
    /// <summary>
    /// Request Vigia Carga Producto Tercero
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>13/06/2021</date>
    public class CargaProductoTerceroRequest
    {
        //En este dato se ingresa en nombre de la función que consume el web Service.
        public string Origen { get; set; }
        //El tipo de identificación debe corresponder al código que este definido en la tabla TIPOS DE IDENTIFICACION.
        public string Tipide_codigo { get; set; }
        //El dato debe ser suministrado por la empresa y corresponde al número de identificación del cliente para el que se registra el producto
        public string Numide { get; set; }
        //El código del producto debe corresponder al código que esté definido en la tabla PRODUCTOS.El dato debe ser suministrado por la empresa.
        public string Producto_codigo { get; set; }
        //Número del producto definido para el cliente.El dato debe ser suministrado por la empresa.
        public string Producto_numero { get; set; }
        //Este dato debe corresponder al código que para la sucursal se encuentre definido en la tabla SUCURSALES.
        public string Sucursal_codigo { get; set; }
        //Fecha en la cual se abre el producto, el formato debe ser MM-DD- YYYY
        public string Fechaapertura { get; set; }
        //Este dato corresponde al monto de cupo quemaneja el cliente para el producto.El dato debe ser suministrado por la empresa.
        public string Cupo { get; set; }
        //Este dato corresponde al monto de saldo del producto a la fecha que se este ingresando del datos para el producto del cliente.El dato debe ser suministrado por la empresa si aplica.
        public string Saldo { get; set; }
        //Este dato corresponde al monto de la cuota del producto a la fecha que se este ingresando del datos para el producto del cliente.El dato debeser suministrado por la empresa si aplica.
        public string Cuota { get; set; }
        //Este dato debe corresponder al código que para la vigencia se encuentre definido en la tabla VIGENCIAS.Este dato hace referencia al estado del producto. El dato debe ser suministrado por la empresa si aplica.
        public string Vigencia { get; set; }
        //Este dato debe corresponder al código que para la titularidad se encuentre definido en la tabla TITULARIDADES
        public string Titularidad { get; set; }
        //Fecha en la cual se cancela el producto, el formato debe ser MMDD- YYYY.El dato debe ser suministrado por la empresa si aplica.
        public string Fechacancelacion { get; set; }
    }
}
