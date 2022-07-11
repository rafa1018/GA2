using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Request Vigia Carga Tercero Request
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>13/06/2021</date>
    public class CargaTerceroRequest
    {
        //En este dato se ingresa en nombre de la función que consume el web Service.
        public string origen { get; set; }
        //El tipo de identificación debe corresponder al código que este definido en la tabla TIPOS DE IDENTIFICACION.
        public string tipide_codigo { get; set; }
        //El dato debe ser suministrado  por la empresa
        public string numide { get; set; }
        //El dato debe ser suministrado por la empresa.
        public string nombres { get; set; }
        //El dato debe ser suministrado por la empresa para las personas naturales
        public string apellidos { get; set; }
        //Este dato debe corresponder al código que para la ciudad se encuentre definido en la tabla del SISTEMA GEOGRAFICO.
        public string sisgeo_codigo { get; set; }
        //Identificador del tipo de persona, el dato debe ser N o J.N para personas naturales y J para personas jurídicas
        public string tipo { get; set; }
        //El código debe corresponder al código que este definido en la tabla PROFESIONES.
        public string profesion_codigo { get; set; }
        //El código debe corresponder al código que este definido en la tabla ACTIVIDADES
        public string actividad_codigo { get; set; }
        //Dato del monto de activos reportado por el tercero
        public string activo { get; set; }
        //Dato del monto de pasivos reportado por el tercero.
        public string pasivo { get; set; }
        //Dato del monto de patrimonio reportado por el tercero.
        public string patrimonio { get; set; }
        //Dato del monto de ingresos reportado por el tercero.
        public string ingresos { get; set; }
        //Dato del monto de egresos reportado por el tercero.
        public string egresos { get; set; }
        //Dato del monto del cupo total asignado al tercero
        public string cupototal { get; set; }
        //Este dato es la calificación que se tenga para el tercero, si se tiene se carga de lo contrario
        //será generado por el sistema con base en el proceso de calificación de riesgo
        public string tipcal_codigo { get; set; }
        //Este dato indica el tipo de vinculo que tiene la persona con la empresa, usualmente
        //son clientes o usuarios, en cualquier caso debe corresponder con el código que este definido en la tabla
        //TIPOS DE VINCULACION.
        public string tipvin_codigo { get; set; }
        //El dato debe ser suministrado por la empresa si existe
        public string direccion { get; set; }
        //El dato debe ser suministrado por la empresa si existe
        public string telefono { get; set; }
        //El dato debe ser suministrado por la empresa si existe
        public string numcelular { get; set; }
        //El dato debe ser suministrado por la empresa si existe
        public string email { get; set; }
        //Fecha en la cual se vinculo el cliente al negocio
        public string fecha_vinculacion { get; set; }
        //Fecha en la cual se realizo la última actualización de los datos SARLAFT
        public string fecha_actualizacion { get; set; }
        //Este dato corresponde al código del funcionario de la empresa que vinculo el tercero al negocio
        public string funcionario_responsable { get; set; }
        //El código debe corresponder al código que este definido en la tabla CIIU.
        public string ciiu_codigo { get; set; }
        //Este dato indica si el tercero esta marcado como una persona expuesta públicamente.
        public string pep { get; set; }
        //En caso de ser el tercero PEP, este código debe corresponderal código que se tenga registrado en la tabla TIPOS DEPEP.
        public string tippep_codigo { get; set; }
        //Código de la sucursal en la cual se vinculó al tercero
        public string sucursal_codigo { get; set; }
        //Dato del monto del total de otros egresos reportado por el tercero
        public string total_otros_ingresos { get; set; }
        //En este campo se puede registrar la fecha deconstitución de las personas jurídicas o la fecha de
        //nacimiento de las personas jurídicas.
        public string fecha_nacimiento { get; set; }
        //En este campo se debe ingresar una S o una N según se exente de análisis o no al SItercero.El dato debe ser suministrado por la empresa
        public string exentoanalisis { get; set; }
        //En este campo se registra el tipo de identificación de la persona que referencia al tercero.El código debe
        //corresponder al código que este definido en la tabla TIPOS DE IDENTIFICACION. 
        public string tipide_referencia { get; set; }
        //En este campo se registra el número de identificación de la persona que referencia al tercero.
        public string numide_referencia { get; set; }
        //Este dato corresponde al tipo de relación existente entre el tercero y quien lo referencia
        public string tipoderelacion_codigo { get; set; }
        // Los datos aceptados para este campo son M para masculino y F para femenino
        public string sexo { get; set; }
        //En este campo se puede ingresar comentarios generales acerca del tercero.
        public string comentarios { get; set; }
        //0 Descripción de los otros ingresos reportados por el tercero
        public string detotring { get; set; }
        //En este campo se debe ingresar una S o una N según el cliente autorice o no que se le notifique por medios electrónicos.
        public string autorizanotificacion { get; set; }
        //Este campo contiene el dato del digito verificador para los números de identificación que maneja este dato
        public string dv { get; set; }
        //Este dato corresponde al tipo de la naturaleza jurídica para los terceros jurídicos.
        public string naturalezajuridica { get; set; }
        //En este campo se debe ingresar una S o una N según el tercero opere o no en monedas extranjeras
        public string operamonedaextranjera { get; set; }
        //En este campo se debe ingresar una S o una N según el tercero maneje o no recursos públicos.
        public string manejarecursospublicos { get; set; }
        //Este dato debe corresponder al código que para el país se encuentre definido en la tabla del SISTEMA GEOGRAFICO.
        public string sisgeo_nacionalidad { get; set; }
        //Indica el estado del tercero en el sistema.Los datos aceptados son A para activo e I para inactivo. 
        public string estado { get; set; }
        //Usuario del directorio activo o de base de datos que está ejecutando la ejecución del web Service.
        public string usuadi { get; set; }
    }
}
