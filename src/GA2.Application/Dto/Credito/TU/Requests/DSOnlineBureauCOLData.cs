using System.Xml.Serialization;
using System.Collections.Generic;

namespace GA2.Application.Dto.Credito.TU.Requests
{
    public class DSOnlineBureauCOLData
    {
        [XmlElement(ElementName = "QueueRequest")]
        public QueueRequest QueueRequest { get; set; }
        [XmlElement(ElementName = "Response")]
        public Response Response { get; set; }
        [XmlElement(ElementName = "Request")]
        public string Request { get; set; }
        [XmlElement(ElementName = "OnlineBureauDDCall")]
        public OnlineBureauDDCall OnlineBureauDDCall { get; set; }
        [XmlElement(ElementName = "IssueDate")]
        public string IssueDate { get; set; }
        [XmlElement(ElementName = "IssuePlace")]
        public string IssuePlace { get; set; }
        [XmlElement(ElementName = "IdType")]
        public string IdType { get; set; }
    }
    public class QueueRequest
    {
        [XmlElement(ElementName = "GenerateReport")]
        public string GenerateReport { get; set; }
        [XmlElement(ElementName = "CommentText")]
        public string CommentText { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento93")]
    public class Endeudamiento93
    {
        [XmlElement(ElementName = "CumplimientoCuota")]
        public string CumplimientoCuota { get; set; }
        [XmlElement(ElementName = "CuotaEsperada")]
        public string CuotaEsperada { get; set; }
        [XmlElement(ElementName = "FechaUltimoAvaluo")]
        public string FechaUltimoAvaluo { get; set; }
        [XmlElement(ElementName = "TipoGarantia")]
        public string TipoGarantia { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantia")]
        public string CubrimientoGarantia { get; set; }
        [XmlElement(ElementName = "ParticipacionTotalDeudas")]
        public string ParticipacionTotalDeudas { get; set; }
        [XmlElement(ElementName = "ValorDeuda")]
        public string ValorDeuda { get; set; }
        [XmlElement(ElementName = "NumeroOperadores")]
        public string NumeroOperadores { get; set; }
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
        [XmlElement(ElementName = "Calificacion")]
        public string Calificacion { get; set; }
        [XmlElement(ElementName = "ModalidadCredito")]
        public string ModalidadCredito { get; set; }
        [XmlElement(ElementName = "NumeroFideicomiso")]
        public string NumeroFideicomiso { get; set; }
        [XmlElement(ElementName = "TipoFideicomiso")]
        public string TipoFideicomiso { get; set; }
        [XmlElement(ElementName = "EntidadOriginadoraCartera")]
        public string EntidadOriginadoraCartera { get; set; }
        [XmlElement(ElementName = "TipoEntidadOriginadoraCartera")]
        public string TipoEntidadOriginadoraCartera { get; set; }
        [XmlElement(ElementName = "NombreEntidad")]
        public string NombreEntidad { get; set; }
        [XmlElement(ElementName = "TipoEntidad")]
        public string TipoEntidad { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento92")]
    public class Endeudamiento92
    {
        [XmlElement(ElementName = "CumplimientoCuota")]
        public string CumplimientoCuota { get; set; }
        [XmlElement(ElementName = "CuotaEsperada")]
        public string CuotaEsperada { get; set; }
        [XmlElement(ElementName = "ValorContingencias")]
        public string ValorContingencias { get; set; }
        [XmlElement(ElementName = "NumeroContingencias")]
        public string NumeroContingencias { get; set; }
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento91")]
    public class Endeudamiento91
    {
        [XmlElement(ElementName = "CubrimientoGarantiaMicrocredito")]
        public string CubrimientoGarantiaMicrocredito { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaVivienda")]
        public string CubrimientoGarantiaVivienda { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaConsumo")]
        public string CubrimientoGarantiaConsumo { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaComercial")]
        public string CubrimientoGarantiaComercial { get; set; }
        [XmlElement(ElementName = "ParticipacionTotalDeudas")]
        public string ParticipacionTotalDeudas { get; set; }
        [XmlElement(ElementName = "Total")]
        public string Total { get; set; }
        [XmlElement(ElementName = "ValorDeudaMicrocredito")]
        public string ValorDeudaMicrocredito { get; set; }
        [XmlElement(ElementName = "ValorDeudaVivienda")]
        public string ValorDeudaVivienda { get; set; }
        [XmlElement(ElementName = "ValorDeudaConsumo")]
        public string ValorDeudaConsumo { get; set; }
        [XmlElement(ElementName = "ValorDeudaComercial")]
        public string ValorDeudaComercial { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesMicrocredito")]
        public string NumeroOperacionesMicrocredito { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesVivienda")]
        public string NumeroOperacionesVivienda { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesConsumo")]
        public string NumeroOperacionesConsumo { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesComercial")]
        public string NumeroOperacionesComercial { get; set; }
        [XmlElement(ElementName = "TipoModena")]
        public string TipoModena { get; set; }
        [XmlElement(ElementName = "Calificacion")]
        public string Calificacion { get; set; }
    }

    [XmlRoot(ElementName = "EndeudamientoTrimIII")]
    public class EndeudamientoTrimIII
    {
        [XmlElement(ElementName = "Endeudamiento93")]
        public List<Endeudamiento93> Endeudamiento93 { get; set; }
        [XmlElement(ElementName = "Endeudamiento92")]
        public List<Endeudamiento92> Endeudamiento92 { get; set; }
        [XmlElement(ElementName = "Endeudamiento91")]
        public List<Endeudamiento91> Endeudamiento91 { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento83")]
    public class Endeudamiento83
    {
        [XmlElement(ElementName = "CumplimientoCuota")]
        public string CumplimientoCuota { get; set; }
        [XmlElement(ElementName = "CuotaEsperada")]
        public string CuotaEsperada { get; set; }
        [XmlElement(ElementName = "FechaUltimoAvaluo")]
        public string FechaUltimoAvaluo { get; set; }
        [XmlElement(ElementName = "TipoGarantia")]
        public string TipoGarantia { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantia")]
        public string CubrimientoGarantia { get; set; }
        [XmlElement(ElementName = "ParticipacionTotalDeudas")]
        public string ParticipacionTotalDeudas { get; set; }
        [XmlElement(ElementName = "ValorDeuda")]
        public string ValorDeuda { get; set; }
        [XmlElement(ElementName = "NumeroOperadores")]
        public string NumeroOperadores { get; set; }
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
        [XmlElement(ElementName = "Calificacion")]
        public string Calificacion { get; set; }
        [XmlElement(ElementName = "ModalidadCredito")]
        public string ModalidadCredito { get; set; }
        [XmlElement(ElementName = "NumeroFideicomiso")]
        public string NumeroFideicomiso { get; set; }
        [XmlElement(ElementName = "TipoFideicomiso")]
        public string TipoFideicomiso { get; set; }
        [XmlElement(ElementName = "EntidadOriginadoraCartera")]
        public string EntidadOriginadoraCartera { get; set; }
        [XmlElement(ElementName = "TipoEntidadOriginadoraCartera")]
        public string TipoEntidadOriginadoraCartera { get; set; }
        [XmlElement(ElementName = "NombreEntidad")]
        public string NombreEntidad { get; set; }
        [XmlElement(ElementName = "TipoEntidad")]
        public string TipoEntidad { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento82")]
    public class Endeudamiento82
    {
        [XmlElement(ElementName = "CumplimientoCuota")]
        public string CumplimientoCuota { get; set; }
        [XmlElement(ElementName = "CuotaEsperada")]
        public string CuotaEsperada { get; set; }
        [XmlElement(ElementName = "ValorContingencias")]
        public string ValorContingencias { get; set; }
        [XmlElement(ElementName = "NumeroContingencias")]
        public string NumeroContingencias { get; set; }
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento81")]
    public class Endeudamiento81
    {
        [XmlElement(ElementName = "CubrimientoGarantiaMicrocredito")]
        public string CubrimientoGarantiaMicrocredito { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaVivienda")]
        public string CubrimientoGarantiaVivienda { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaConsumo")]
        public string CubrimientoGarantiaConsumo { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaComercial")]
        public string CubrimientoGarantiaComercial { get; set; }
        [XmlElement(ElementName = "ParticipacionTotalDeudas")]
        public string ParticipacionTotalDeudas { get; set; }
        [XmlElement(ElementName = "Total")]
        public string Total { get; set; }
        [XmlElement(ElementName = "ValorDeudaMicrocredito")]
        public string ValorDeudaMicrocredito { get; set; }
        [XmlElement(ElementName = "ValorDeudaVivienda")]
        public string ValorDeudaVivienda { get; set; }
        [XmlElement(ElementName = "ValorDeudaConsumo")]
        public string ValorDeudaConsumo { get; set; }
        [XmlElement(ElementName = "ValorDeudaComercial")]
        public string ValorDeudaComercial { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesMicrocredito")]
        public string NumeroOperacionesMicrocredito { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesVivienda")]
        public string NumeroOperacionesVivienda { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesConsumo")]
        public string NumeroOperacionesConsumo { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesComercial")]
        public string NumeroOperacionesComercial { get; set; }
        [XmlElement(ElementName = "TipoModena")]
        public string TipoModena { get; set; }
        [XmlElement(ElementName = "Calificacion")]
        public string Calificacion { get; set; }
    }

    [XmlRoot(ElementName = "EndeudamientoTrimII")]
    public class EndeudamientoTrimII
    {
        [XmlElement(ElementName = "Endeudamiento83")]
        public List<Endeudamiento83> Endeudamiento83 { get; set; }
        [XmlElement(ElementName = "Endeudamiento82")]
        public List<Endeudamiento82> Endeudamiento82 { get; set; }
        [XmlElement(ElementName = "Endeudamiento81")]
        public List<Endeudamiento81> Endeudamiento81 { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento73")]
    public class Endeudamiento73
    {
        [XmlElement(ElementName = "CumplimientoCuota")]
        public string CumplimientoCuota { get; set; }
        [XmlElement(ElementName = "CuotaEsperada")]
        public string CuotaEsperada { get; set; }
        [XmlElement(ElementName = "FechaUltimoAvaluo")]
        public string FechaUltimoAvaluo { get; set; }
        [XmlElement(ElementName = "TipoGarantia")]
        public string TipoGarantia { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantia")]
        public string CubrimientoGarantia { get; set; }
        [XmlElement(ElementName = "ParticipacionTotalDeudas")]
        public string ParticipacionTotalDeudas { get; set; }
        [XmlElement(ElementName = "ValorDeuda")]
        public string ValorDeuda { get; set; }
        [XmlElement(ElementName = "NumeroOperadores")]
        public string NumeroOperadores { get; set; }
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
        [XmlElement(ElementName = "Calificacion")]
        public string Calificacion { get; set; }
        [XmlElement(ElementName = "ModalidadCredito")]
        public string ModalidadCredito { get; set; }
        [XmlElement(ElementName = "NumeroFideicomiso")]
        public string NumeroFideicomiso { get; set; }
        [XmlElement(ElementName = "TipoFideicomiso")]
        public string TipoFideicomiso { get; set; }
        [XmlElement(ElementName = "EntidadOriginadoraCartera")]
        public string EntidadOriginadoraCartera { get; set; }
        [XmlElement(ElementName = "TipoEntidadOriginadoraCartera")]
        public string TipoEntidadOriginadoraCartera { get; set; }
        [XmlElement(ElementName = "NombreEntidad")]
        public string NombreEntidad { get; set; }
        [XmlElement(ElementName = "TipoEntidad")]
        public string TipoEntidad { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento72")]
    public class Endeudamiento72
    {
        [XmlElement(ElementName = "CumplimientoCuota")]
        public string CumplimientoCuota { get; set; }
        [XmlElement(ElementName = "CuotaEsperada")]
        public string CuotaEsperada { get; set; }
        [XmlElement(ElementName = "ValorContingencias")]
        public string ValorContingencias { get; set; }
        [XmlElement(ElementName = "NumeroContingencias")]
        public string NumeroContingencias { get; set; }
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento71")]
    public class Endeudamiento71
    {
        [XmlElement(ElementName = "CubrimientoGarantiaMicrocredito")]
        public string CubrimientoGarantiaMicrocredito { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaVivienda")]
        public string CubrimientoGarantiaVivienda { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaConsumo")]
        public string CubrimientoGarantiaConsumo { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantiaComercial")]
        public string CubrimientoGarantiaComercial { get; set; }
        [XmlElement(ElementName = "ParticipacionTotalDeudas")]
        public string ParticipacionTotalDeudas { get; set; }
        [XmlElement(ElementName = "Total")]
        public string Total { get; set; }
        [XmlElement(ElementName = "ValorDeudaMicrocredito")]
        public string ValorDeudaMicrocredito { get; set; }
        [XmlElement(ElementName = "ValorDeudaVivienda")]
        public string ValorDeudaVivienda { get; set; }
        [XmlElement(ElementName = "ValorDeudaConsumo")]
        public string ValorDeudaConsumo { get; set; }
        [XmlElement(ElementName = "ValorDeudaComercial")]
        public string ValorDeudaComercial { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesMicrocredito")]
        public string NumeroOperacionesMicrocredito { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesVivienda")]
        public string NumeroOperacionesVivienda { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesConsumo")]
        public string NumeroOperacionesConsumo { get; set; }
        [XmlElement(ElementName = "NumeroOperacionesComercial")]
        public string NumeroOperacionesComercial { get; set; }
        [XmlElement(ElementName = "TipoModena")]
        public string TipoModena { get; set; }
        [XmlElement(ElementName = "Calificacion")]
        public string Calificacion { get; set; }
    }

    [XmlRoot(ElementName = "EndeudamientoTrimI")]
    public class EndeudamientoTrimI
    {
        [XmlElement(ElementName = "Endeudamiento73")]
        public List<Endeudamiento73> Endeudamiento73 { get; set; }
        [XmlElement(ElementName = "Endeudamiento72")]
        public List<Endeudamiento72> Endeudamiento72 { get; set; }
        [XmlElement(ElementName = "Endeudamiento71")]
        public List<Endeudamiento71> Endeudamiento71 { get; set; }
    }

    [XmlRoot(ElementName = "EncabezadoEndeudamiento")]
    public class EncabezadoEndeudamiento
    {
        [XmlElement(ElementName = "NumeroCastigosTrimestreIII")]
        public string NumeroCastigosTrimestreIII { get; set; }
        [XmlElement(ElementName = "NumeroCastigosTrimestreII")]
        public string NumeroCastigosTrimestreII { get; set; }
        [XmlElement(ElementName = "NumeroCastigosTrimestreI")]
        public string NumeroCastigosTrimestreI { get; set; }
        [XmlElement(ElementName = "NumeroReestructuracionesTrimestreIII")]
        public string NumeroReestructuracionesTrimestreIII { get; set; }
        [XmlElement(ElementName = "NumeroReestructuracionesTrimestreII")]
        public string NumeroReestructuracionesTrimestreII { get; set; }
        [XmlElement(ElementName = "NumeroReestructuracionesTrimestreI")]
        public string NumeroReestructuracionesTrimestreI { get; set; }
        [XmlElement(ElementName = "NumeroComprasTrimestreIII")]
        public string NumeroComprasTrimestreIII { get; set; }
        [XmlElement(ElementName = "NumeroComprasTrimestreII")]
        public string NumeroComprasTrimestreII { get; set; }
        [XmlElement(ElementName = "NumeroComprasTrimestreI")]
        public string NumeroComprasTrimestreI { get; set; }
        [XmlElement(ElementName = "FechaTrimestreIII")]
        public string FechaTrimestreIII { get; set; }
        [XmlElement(ElementName = "NumeroEntidadesTrimestreIII")]
        public string NumeroEntidadesTrimestreIII { get; set; }
        [XmlElement(ElementName = "FechaTrimestreII")]
        public string FechaTrimestreII { get; set; }
        [XmlElement(ElementName = "NumeroEntidadesTrimestreII")]
        public string NumeroEntidadesTrimestreII { get; set; }
        [XmlElement(ElementName = "FechaTrimestreI")]
        public string FechaTrimestreI { get; set; }
        [XmlElement(ElementName = "NumeroEntidadesTrimestreI")]
        public string NumeroEntidadesTrimestreI { get; set; }
    }

    [XmlRoot(ElementName = "Endeudamiento")]
    public class Endeudamiento
    {
        [XmlElement(ElementName = "EndeudamientoTrimIII")]
        public EndeudamientoTrimIII EndeudamientoTrimIII { get; set; }
        [XmlElement(ElementName = "EndeudamientoTrimII")]
        public EndeudamientoTrimII EndeudamientoTrimII { get; set; }
        [XmlElement(ElementName = "EndeudamientoTrimI")]
        public EndeudamientoTrimI EndeudamientoTrimI { get; set; }
        [XmlElement(ElementName = "EncabezadoEndeudamiento")]
        public EncabezadoEndeudamiento EncabezadoEndeudamiento { get; set; }
    }

    [XmlRoot(ElementName = "Obligacion")]
    public class Obligacion
    {
        [XmlElement(ElementName = "Reestructurado")]
        public string Reestructurado { get; set; }
        [XmlElement(ElementName = "NumeroCuotasMora")]
        public string NumeroCuotasMora { get; set; }
        [XmlElement(ElementName = "NumeroCuotasPactadas")]
        public string NumeroCuotasPactadas { get; set; }
        [XmlElement(ElementName = "EstadoTitular")]
        public string EstadoTitular { get; set; }
        [XmlElement(ElementName = "TipoPago")]
        public string TipoPago { get; set; }
        [XmlElement(ElementName = "EntidadOriginadoraCartera")]
        public string EntidadOriginadoraCartera { get; set; }
        [XmlElement(ElementName = "TipoEntidadOriginadoraCartera")]
        public string TipoEntidadOriginadoraCartera { get; set; }
        [XmlElement(ElementName = "NaturalezaReestructuracion")]
        public string NaturalezaReestructuracion { get; set; }
        [XmlElement(ElementName = "NumeroReestructuraciones")]
        public string NumeroReestructuraciones { get; set; }
        [XmlElement(ElementName = "FechaPermanencia")]
        public string FechaPermanencia { get; set; }
        [XmlElement(ElementName = "FechaPago")]
        public string FechaPago { get; set; }
        [XmlElement(ElementName = "ModoExtincion")]
        public string ModoExtincion { get; set; }
        [XmlElement(ElementName = "FechaCorte")]
        public string FechaCorte { get; set; }
        [XmlElement(ElementName = "ProbabilidadNoPago")]
        public string ProbabilidadNoPago { get; set; }
        [XmlElement(ElementName = "ParticipacionDeuda")]
        public string ParticipacionDeuda { get; set; }
        [XmlElement(ElementName = "Comportamientos")]
        public string Comportamientos { get; set; }
        [XmlElement(ElementName = "MoraMaxima")]
        public string MoraMaxima { get; set; }
        [XmlElement(ElementName = "CubrimientoGarantia")]
        public string CubrimientoGarantia { get; set; }
        [XmlElement(ElementName = "TipoGarantia")]
        public string TipoGarantia { get; set; }
        [XmlElement(ElementName = "CuotasCanceladas")]
        public string CuotasCanceladas { get; set; }
        [XmlElement(ElementName = "TipoMoneda")]
        public string TipoMoneda { get; set; }
        [XmlElement(ElementName = "ValorCuota")]
        public string ValorCuota { get; set; }
        [XmlElement(ElementName = "ValorMora")]
        public string ValorMora { get; set; }
        [XmlElement(ElementName = "SaldoObligacion")]
        public string SaldoObligacion { get; set; }
        [XmlElement(ElementName = "ValorInicial")]
        public string ValorInicial { get; set; }
        [XmlElement(ElementName = "Calificacion")]
        public string Calificacion { get; set; }
        [XmlElement(ElementName = "FechaTerminacion")]
        public string FechaTerminacion { get; set; }
        [XmlElement(ElementName = "FechaApertura")]
        public string FechaApertura { get; set; }
        [XmlElement(ElementName = "Periodicidad")]
        public string Periodicidad { get; set; }
        [XmlElement(ElementName = "LineaCredito")]
        public string LineaCredito { get; set; }
        [XmlElement(ElementName = "ModalidadCredito")]
        public string ModalidadCredito { get; set; }
        [XmlElement(ElementName = "EstadoObligacion")]
        public string EstadoObligacion { get; set; }
        [XmlElement(ElementName = "Calidad")]
        public string Calidad { get; set; }
        [XmlElement(ElementName = "NumeroObligacion")]
        public string NumeroObligacion { get; set; }
        [XmlElement(ElementName = "Sucursal")]
        public string Sucursal { get; set; }
        [XmlElement(ElementName = "Ciudad")]
        public string Ciudad { get; set; }
        [XmlElement(ElementName = "NombreEntidad")]
        public string NombreEntidad { get; set; }
        [XmlElement(ElementName = "TipoEntidad")]
        public string TipoEntidad { get; set; }
        [XmlElement(ElementName = "EstadoContrato")]
        public string EstadoContrato { get; set; }
        [XmlElement(ElementName = "TipoContrato")]
        public string TipoContrato { get; set; }
        [XmlElement(ElementName = "IdentificadorLinea")]
        public string IdentificadorLinea { get; set; }
        [XmlElement(ElementName = "PaqueteInformacion")]
        public string PaqueteInformacion { get; set; }
        [XmlElement(ElementName = "ClaseTarjeta")]
        public string ClaseTarjeta { get; set; }
        [XmlElement(ElementName = "MarcaTarjeta")]
        public string MarcaTarjeta { get; set; }
        [XmlElement(ElementName = "DiasCartera")]
        public string DiasCartera { get; set; }
        [XmlElement(ElementName = "ChequesDevueltos")]
        public string ChequesDevueltos { get; set; }
    }

    [XmlRoot(ElementName = "SectorFinancieroExtinguidas")]
    public class SectorFinancieroExtinguidas
    {
        [XmlElement(ElementName = "Obligacion")]
        public List<Obligacion> Obligacion { get; set; }
    }

    [XmlRoot(ElementName = "SectorFinancieroAlDia")]
    public class SectorFinancieroAlDia
    {
        [XmlElement(ElementName = "Obligacion")]
        public List<Obligacion> Obligacion { get; set; }
    }

    [XmlRoot(ElementName = "SectorFinancieroEnMora")]
    public class SectorFinancieroEnMora
    {
        [XmlElement(ElementName = "Obligacion")]
        public List<Obligacion> Obligacion { get; set; }
    }

    [XmlRoot(ElementName = "SectorRealExtinguidas")]
    public class SectorRealExtinguidas
    {
        [XmlElement(ElementName = "Obligacion")]
        public List<Obligacion> Obligacion { get; set; }
    }

    [XmlRoot(ElementName = "SectorRealAlDia")]
    public class SectorRealAlDia
    {
        [XmlElement(ElementName = "Obligacion")]
        public List<Obligacion> Obligacion { get; set; }
    }

    [XmlRoot(ElementName = "SectorRealEnMora")]
    public class SectorRealEnMora
    {
        [XmlElement(ElementName = "Obligacion")]
        public List<Obligacion> Obligacion { get; set; }
    }

    [XmlRoot(ElementName = "CuentasVigentes")]
    public class CuentasVigentes
    {
        [XmlElement(ElementName = "Obligacion")]
        public List<Obligacion> Obligacion { get; set; }
    }

    [XmlRoot(ElementName = "CuentasExtinguidas")]
    public class CuentasExtinguidas
    {
        [XmlElement(ElementName = "Obligacion")]
        public List<Obligacion> Obligacion { get; set; }
    }

    [XmlRoot(ElementName = "Registro")]
    public class Registro
    {
        [XmlElement(ElementName = "ValorMora")]
        public string ValorMora { get; set; }
        [XmlElement(ElementName = "CuotaObligacionesMora")]
        public string CuotaObligacionesMora { get; set; }
        [XmlElement(ElementName = "SaldoObligacionesMora")]
        public string SaldoObligacionesMora { get; set; }
        [XmlElement(ElementName = "CantidadObligacionesMora")]
        public string CantidadObligacionesMora { get; set; }
        [XmlElement(ElementName = "CuotaObligacionesDia")]
        public string CuotaObligacionesDia { get; set; }
        [XmlElement(ElementName = "SaldoObligacionesDia")]
        public string SaldoObligacionesDia { get; set; }
        [XmlElement(ElementName = "NumeroObligacionesDia")]
        public string NumeroObligacionesDia { get; set; }
        [XmlElement(ElementName = "ParticipacionDeuda")]
        public string ParticipacionDeuda { get; set; }
        [XmlElement(ElementName = "TotalSaldo")]
        public string TotalSaldo { get; set; }
        [XmlElement(ElementName = "NumeroObligaciones")]
        public string NumeroObligaciones { get; set; }
        [XmlElement(ElementName = "PaqueteInformacion")]
        public string PaqueteInformacion { get; set; }
    }

    [XmlRoot(ElementName = "ResumenPrincipal")]
    public class ResumenPrincipal
    {
        [XmlElement(ElementName = "Registro")]
        public List<Registro> Registro { get; set; }
    }

    [XmlRoot(ElementName = "Consolidado")]
    public class Consolidado
    {
        [XmlElement(ElementName = "Registro")]
        public Registro Registro { get; set; }
        [XmlElement(ElementName = "ResumenPrincipal")]
        public ResumenPrincipal ResumenPrincipal { get; set; }
    }

    [XmlRoot(ElementName = "Tercero")]
    public class Tercero
    {
        [XmlElement(ElementName = "Endeudamiento")]
        public Endeudamiento Endeudamiento { get; set; }
        [XmlElement(ElementName = "SectorFinancieroExtinguidas")]
        public SectorFinancieroExtinguidas SectorFinancieroExtinguidas { get; set; }
        [XmlElement(ElementName = "SectorFinancieroAlDia")]
        public SectorFinancieroAlDia SectorFinancieroAlDia { get; set; }
        [XmlElement(ElementName = "CuentasVigentes")]
        public CuentasVigentes CuentasVigentes { get; set; }
        [XmlElement(ElementName = "Consolidado")]
        public Consolidado Consolidado { get; set; }
        [XmlElement(ElementName = "RespuestaConsulta")]
        public string RespuestaConsulta { get; set; }
        [XmlElement(ElementName = "Entidad")]
        public string Entidad { get; set; }
        [XmlElement(ElementName = "Hora")]
        public string Hora { get; set; }
        [XmlElement(ElementName = "Fecha")]
        public string Fecha { get; set; }
        [XmlElement(ElementName = "CodigoMunicipio")]
        public string CodigoMunicipio { get; set; }
        [XmlElement(ElementName = "CodigoDepartamento")]
        public string CodigoDepartamento { get; set; }
        [XmlElement(ElementName = "CodigoCiiu")]
        public string CodigoCiiu { get; set; }
        [XmlElement(ElementName = "RangoEdad")]
        public string RangoEdad { get; set; }
        [XmlElement(ElementName = "EstadoTitular")]
        public string EstadoTitular { get; set; }
        [XmlElement(ElementName = "NumeroInforme")]
        public string NumeroInforme { get; set; }
        [XmlElement(ElementName = "Estado")]
        public string Estado { get; set; }
        [XmlElement(ElementName = "FechaExpedicion")]
        public string FechaExpedicion { get; set; }
        [XmlElement(ElementName = "LugarExpedicion")]
        public string LugarExpedicion { get; set; }
        [XmlElement(ElementName = "NombreCiiu")]
        public string NombreCiiu { get; set; }
        [XmlElement(ElementName = "NombreTitular")]
        public string NombreTitular { get; set; }
        [XmlElement(ElementName = "NumeroIdentificacion")]
        public string NumeroIdentificacion { get; set; }
        [XmlElement(ElementName = "CodigoTipoIndentificacion")]
        public string CodigoTipoIndentificacion { get; set; }
        [XmlElement(ElementName = "TipoIdentificacion")]
        public string TipoIdentificacion { get; set; }
        [XmlElement(ElementName = "IdentificadorLinea")]
        public string IdentificadorLinea { get; set; }
    }

    [XmlRoot(ElementName = "_Attributes_CIFIN")]
    public class _Attributes_CIFIN
    {
        [XmlElement(ElementName = "archivo")]
        public string Archivo { get; set; }
    }

    [XmlRoot(ElementName = "Response")]
    public class Response
    {
        [XmlElement(ElementName = "Tercero")]
        public Tercero Tercero { get; set; }
        [XmlElement(ElementName = "_Attributes_CIFIN")]
        public _Attributes_CIFIN _Attributes_CIFIN { get; set; }
    }

    [XmlRoot(ElementName = "Data")]
    public class Data
    {
        [XmlElement(ElementName = "RawResponse")]
        public string RawResponse { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "GatewayTransactionId")]
        public string GatewayTransactionId { get; set; }
    }

    [XmlRoot(ElementName = "OnlineBureauDDCall")]
    public class OnlineBureauDDCall
    {
        [XmlElement(ElementName = "Success")]
        public string Success { get; set; }
        [XmlElement(ElementName = "Data")]
        public Data Data { get; set; }
    }
}
