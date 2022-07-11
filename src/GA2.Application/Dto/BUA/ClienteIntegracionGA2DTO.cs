using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class Pais
    {
        public string IdPais { get; set; }
        public int IdPaisEntero { get; set; }
    }

    public class Departamento
    {
        public string IdDepartamento { get; set; }
        public int IdDepartamentoEntero { get; set; }
        public Pais Pais { get; set; }
    }

    public class CiudadNacimiento
    {
        public Departamento Departamento { get; set; }
        public string IdCiudad { get; set; }
        public int IdCiudadEntero { get; set; }

    }

    public class TipoIdConyuge
    {
        public int IdTipoId { get; set; }
    }

    public class Conyuge
    {
        public string CelularConyuge { get; set; }
        public string IdentificacionConyuge { get; set; }
        public string PrimerApellidoConyuge { get; set; }
        public string PrimerNombreConyuge { get; set; }
        public string SegundoApellidoConyuge { get; set; }
        public string SegundoNombreConyuge { get; set; }
        public string TelefonoFijoConyuge { get; set; }
        public TipoIdConyuge TipoIdConyuge { get; set; }
    }

    public class CiudadResidencia
    {
        public Departamento Departamento { get; set; }
        public string IdCiudad { get; set; }
        public int IdCiudadEntero { get; set; }
    }

    public class Direccion
    {
        public string BarrioResidencia { get; set; }
        public string Celular { get; set; }
        public CiudadResidencia CiudadResidencia { get; set; }
        public string CorreoInstitucional { get; set; }
        public string CorreoPersonal { get; set; }
        public string DireccionResidencia { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Telefono { get; set; }
        public int TipoDirCo { get; set; }
        public int TipoDirRes { get; set; }
        public string TelefonoMostrar { get; set; }
        public int TipoTelefono { get; set; }
        public string Correo { get; set; }
        public int TipoCorreo { get; set; }
    }

    public class EstadoActualCli
    {
        public List<object> CausalBloqueo { get; set; }
        public int IdEstado { get; set; }
    }

    public class Categoria
    {
        public int IdCategoria { get; set; }
    }

    public class Fuerza
    {
        public int IdFuerza { get; set; }
    }

    public class Grado
    {
        public int IdGrado { get; set; }
        public Categoria Categoria { get; set; }
        public Fuerza Fuerza { get; set; }
    }

    public class InformacionFinanciera
    {
        public string ConceptoIngresosAdicionales { get; set; }
        public int EgresoMensual { get; set; }
        public int IngresoMensual { get; set; }
        public int IngresosAdicionales { get; set; }
        public int TotalActivos { get; set; }
        public int TotalPasivos { get; set; }
        public int TotalPatrimonio { get; set; }
    }

    public class LugarExpedicion
    {
        public Departamento Departamento { get; set; }
        public string IdCiudad { get; set; }
        public int IdCiudadEntero { get; set; }
    }

    public class TipoActorIntegracion
    {
        public int IdTipoActor { get; set; }
    }

    public class TipoId
    {
        public int IdTipoId { get; set; }
    }

    public class TipoViviendaPosee
    {
        public int TipoViviendaId { get; set; }
    }

    public class CuentaIntegracion
    {
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoProducto { get; set; }
        public int EstadoCuenta { get; set; }
        public int CausalEstadoCuenta { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaPrimerAporte { get; set; }
        public decimal Saldo { get; set; }
        public decimal SaldoEnCanje { get; set; }
        public decimal SaldoDisponible { get; set; }
        public int Cuotas { get; set; }
        //public List<DocumentoIntegracion> Documento { get; set; }
        public List<Movimiento> Movimientos { get; set; }
        public List<ConceptosSaldosBloqueos> ConceptosSaldosBloqueos { get; set; }
    }

    public class ConceptosSaldosBloqueos
    {
        public int CantidadIngresos { get; set; }
        public string Concepto { get; set; }
        public int Documento { get; set; }
        public string EstadoBloqueo { get; set; }
        public DateTime FechaBloqueo { get; set; }
        public DateTime FechaUltimoAporteConcepto { get; set; }
        public int IdConcepto { get; set; }
        public int IdExpd { get; set; }
        public string NroExpd { get; set; }
        public string Origen { get; set; }
        public decimal SaldoConceptoCuenta { get; set; }
        public decimal SaldoInicialAno { get; set; }
        public decimal ValorAcumulado { get; set; }
        public decimal ValorBloqueo { get; set; }
    }

    public class DocumentoIntegracion
    {
        public int IdDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public DateTime FechaInicial { get; set; }
        public int IdEstadoDocumento { get; set; }
        public int IdCausalEstado { get; set; }
        public DateTime FechaDecision { get; set; }
        public int Anulacion { get; set; }
        public string Alerta { get; set; }
    }

    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdConcepto { get; set; }
        public int Valor { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaProceso { get; set; }
        public string AnoPeriodo { get; set; }
    }

    public class AporteCategoria
    {
        public int IdCategoria { get; set; }
        public int CuotasAcumuladas { get; set; }
        public DateTime FechaUltimaCuota { get; set; }
        public DateTime FechaPrimeraCuota { get; set; }
    }

    public class DependienteIntegracion
    {
        public int TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string NombreDependiente { get; set; }
        public decimal ParticDependiente { get; set; }
    }

    public class ClienteIntegracionGA2DTO
    {
        public string Actividad { get; set; }
        public CiudadNacimiento CiudadNacimiento { get; set; }
        public Conyuge Conyuge { get; set; }
        public DateTime DerechoAdquirido { get; set; }
        public Direccion Direccion { get; set; }
        public bool EnvioInformacion { get; set; }
        public EstadoActualCli EstadoActualCli { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime FechaActualizaDatos { get; set; }
        public DateTime FechaAdquisicionVivienda { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaAltaCalculada { get; set; }
        public DateTime FechaExpedicionId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Grado Grado { get; set; }
        public int IdPatrocinador { get; set; }
        public int IdRegistro { get; set; }
        public string Identificacion { get; set; }
        public InformacionFinanciera InformacionFinanciera { get; set; }
        public LugarExpedicion LugarExpedicion { get; set; }
        public int ModeloSubsidio { get; set; }
        public int Participacion { get; set; }
        public int ParticipacionSubsidio { get; set; }
        public string PrimerApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string Profesion { get; set; }
        public int Regimen { get; set; }
        public string Resolucion { get; set; }
        public string SegundoApellido { get; set; }
        public object SegundoNombre { get; set; }
        public string Sexo { get; set; }
        public int TasaAporte { get; set; }
        public int TasaAporteVoluntario { get; set; }
        public int TasaSalarioBase { get; set; }
        public TipoActorIntegracion TipoActor { get; set; }
        public TipoId TipoId { get; set; }
        public TipoViviendaPosee TipoViviendaPosee { get; set; }
        public string Unidad { get; set; }
        public int UnidadEjecutora { get; set; }
        public string Payload { get; set; }
        public List<CuentaIntegracion> Cuentas { get; set; }
        public List<AporteCategoria> AportesCategoria { get; set; }
        public List<DependienteIntegracion> Dependiente { get; set; }
    }

    public class ObtenerBuaResponse
    {
        public ClienteIntegracionGA2DTO ObtenerBUAResult { get; set; }
    }
}
