using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum  EnumTasaSolicitudCreditoParams
    {
            [Description("@SOC_ID")]    
            IdSolicitudCredito,

            [Description("@SOC_FECHA_SOLICITUD")]    
            FechaSolicitud,

            [Description("@SOC_NUMERO_SOLICITUD")]    
            NumeroSolicitud,

            [Description("@TCR_ID")]    
            TipoCredito,

            [Description("@DPD_ID")]    
            IdDepartamento,

            [Description("@DPC_ID")]    
            IdCiudad,

            [Description("@SLS_ID")]    
            IdSLS,

            [Description("@TID_ID")]    
            TipoIdentificacion,

            [Description("@CLI_IDENTIFICACION")]    
            Identificacion,

            [Description("@SOC_DECLARACION_ORIGEN_FONDOS")]    
            DeclaracionOrigenFondos,

            [Description("@SOC_AUTORIZA_USO_DATOS")]    
            AutorizaUsoDatos,

            [Description("@SOC_AUTORIZA_CONSULTA_CENTRALES")]    
            AutorizaConsultaCentrales,

            [Description("@SOC_DECLARACION_ASEGURABILIDAD")]    
            DeclaracionAsegurabilidad,

            [Description("@SOC_CONVENIO_ASEGURADORA")]    
            ConvenioAseguradora,

            [Description("@SOC_CONVENIO_ASEGURADORA_HOGAR")]    
            ConvenioAseguradoraHogar,

            [Description("@ASE_ID")]    
            IdAseguradora,

            [Description("@SOC_DESICION_BURO")]    
            DesicionBuro,

            [Description("@SOC_SCORE")]    
            Score,

            [Description("@SOC_CAPACIDAD_ENDEUDAMIENTO")]    
            CapacidadEndeudamiento,

            [Description("@SOC_NIVEL_ENDEUDAMIENTO")]    
            NivelEndeudamiento,

            [Description("@SOC_NIVEL_ENDEUDAMIENTO_CUOTA")]    
            NivelEndeudamientoCuota,

            [Description("@SOC_PORC_EXTRAPRIMA")]    
            PorcentajeExtraprima,

            [Description("@SOC_VALOR_RECONOCIMIENTO_CREDITO")]    
            ValorReconocimientoCredito,

            [Description("@SOC_OBSERVACION_RECOMENDACION")]    
            ObservacionRecomendacion,

            [Description("@SOC_TASA_FRECH")]    
            TasaFrech,

            [Description("@SOC_VALOR_ALIVIO")]    
            ValorAlivio,

            [Description("@SOC_ESTADO")]    
            Estado,

            [Description("@SOC_CREADO_POR")]    
            CreadoPor,

            [Description("@SOC_FECHA_CREACION")]    
            FechaCreacion,

            [Description("@SOC_ACTUALIZADO_POR")]    
            ActualizadoPor,

            [Description("@SOC_FECHA_ACTUALIZA")]    
            FechaActualizacion

    }
}
