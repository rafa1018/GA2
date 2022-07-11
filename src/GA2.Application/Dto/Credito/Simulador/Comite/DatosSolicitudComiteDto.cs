﻿using System;

namespace GA2.Application.Dto
{
    public class DatosSolicitudComiteDto
    {
        public Guid idSolicitudDatosComite { get; set; }
        public Guid idSolicitudCredito { get; set; }
        public int idtipoIdentificacion { get; set; }
        public int numeroDocumento { get; set; }
        public DateTime fechaExpedicion { get; set; }
        public int iddepartamentoExpedicion { get; set; }
        public int idCiudadExpedicion { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int idDepartamentoNacimiento { get; set; }
        public int idCiudadNacimiento { get; set; }
        public string sexo { get; set; }
        public string estadoCivil { get; set; }
        public string nivelEducacion { get; set; }
        public int idFuerza { get; set; }
        public int idCategoria { get; set; }
        public int idGrado { get; set; }
        public int idDepartamentoResidencia { get; set; }
        public int idCiudadResidencia { get; set; }
        public string direccionResidencia { get; set; }
        public string correoPersonal { get; set; }
        public string telefonoResidencia { get; set; }
        public string celular { get; set; }
        public int idDepartamentoOficina { get; set; }
        public int idCiudadOficina { get; set; }
        public string direccionOficina { get; set; }
        public string correoInstitucional { get; set; }
        public string telefonoOficina { get; set; }
        public int ACC_ID { get; set; }
        public int PRF_ID { get; set; }
        public string tieneTransaccionMe { get; set; }
        public string tipoTransaccionMe { get; set; }
        public string tipoProductoMe { get; set; }
        public string bancoTransaccionMe { get; set; }
        public string numeroProductoMe { get; set; }
        public int saldoPromedioMe { get; set; }
        public string monedaTransaccionMe { get; set; }
        public int DPP_ID_ME { get; set; }
        public int DPD_ID_ME { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Guid actualizadoPor { get; set; }
        public DateTime fechaActualiza { get; set; }
        public int salarioBasico { get; set; }
        public int totalEgredos { get; set; }
        public int totalIngresos { get; set; }
        public string departamentoResidencia { get; set; }
        public string ciudadResidencia { get; set; }
        public string departamentoInmueble { get; set; }
        public string ciudadInmueble { get; set; }
        public string direccionInmueble { get; set; }
        public string departamentoOficina { get; set; }
        public string ciudadOficina { get; set; }
        public string fuerza { get; set; }
        public string categoria { get; set; }
        public string grado { get; set; }
        public string decisionBuro { get; set; }
        public string score { get; set; }
        public string capacidadEndeudamiento { get; set; }
        public string nivelEndeudamiento { get; set; }
        public string nivelEndeudamientoCuota { get; set; }
        public int edad { get; set; }
        public string EdadJuridica { get; set; }
        public string tipoVivienda { get; set; }
        public string nombreVivienda { get; set; }
        public string tipoParqueadero { get; set; }
        public string anoConstruccion { get; set; }
        public string conceptoTecnico { get; set; }
        public string conceptoJuridico { get; set; }
        public int avaluoComercial { get; set; }
        public int avaluoCatastral { get; set; }
        public int ventaInmueble { get; set; }
        public decimal porcFinanciacion { get; set; }
        public int plazoFinanciacion { get; set; }
        public decimal valorCredito { get; set; }
        public int numeroCuotas { get; set; }
        public decimal NivelEndeudamientoCuotaAQM { get; set; }
        public decimal NivelEndeudamientoAQM { get; set; }
        public string HabitoPago { get; set; }
        public string Estrato { get; set; }
        public int Area { get; set; }
        public int ValorMetroCuadrado { get; set; }
        public string sex { get; set; }
    }
}