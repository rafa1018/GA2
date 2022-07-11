﻿USE [GA2]
GO

/****** Object:  Table [dbo].[SOC_SOLICITUD_CREDITO]    Script Date: 6/07/2021 8:58:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SOC_SOLICITUD_CREDITO](
	[SOC_ID] [uniqueidentifier] NOT NULL,
	[SOC_FECHA_SOLICITUD] [date] NOT NULL,
	[SOC_NUMERO_SOLICITUD] [bigint] NOT NULL,
	[TCR_ID] [int] NOT NULL,
	[DPD_ID] [int] NOT NULL,
	[DPC_ID] [int] NOT NULL,
	[SLS_ID] [uniqueidentifier] NOT NULL,
	[TID_ID] [int] NOT NULL,
	[CLI_IDENTIFICACION] [varchar](30) NOT NULL,
	[SOC_DECLARACION_ORIGEN_FONDOS] [varchar](500) NOT NULL,
	[SOC_AUTORIZA_USO_DATOS] [char](1) NOT NULL,
	[SOC_AUTORIZA_CONSULTA_CENTRALES] [char](1) NOT NULL,
	[SOC_DECLARACION_ASEGURABILIDAD] [char](1) NOT NULL,
	[SOC_CONVENIO_ASEGURADORA] [char](1) NOT NULL,
	[SOC_CONVENIO_ASEGURADORA_HOGAR] [char](1) NOT NULL,
	[ASE_ID] [int] NOT NULL,
	[SOC_DECISION_BURO] [varchar](20) NULL,
	[SOC_SCORE] [varchar](5) NULL,
	[SOC_CAPACIDAD_ENDEUDAMIENTO] [decimal](22, 2) NULL,
	[SOC_NIVEL_ENDEUDAMIENTO] [decimal](5, 2) NULL,
	[SOC_NIVEL_ENDEUDAMIENTO_CUOTA] [decimal](5, 2) NULL,
	[SOC_PORC_EXTRAPRIMA] [decimal](5, 2) NOT NULL,
	[SOC_VALOR_RECOMENDADO_CREDITO] [decimal](22, 6) NOT NULL,
	[SOC_OBSERVACION_RECOMENDACION] [varchar](500) NULL,
	[SOC_TASA_FECH] [decimal](6, 3) NULL,
	[SOC_VALOR_ALIVIO] [decimal](22, 2) NULL,
	[USR_REPARTO] [uniqueidentifier] NULL,
	[NOT_ID] [int] NULL,
	[SOC_FECHA_REPARTO] [datetime] NULL,
	[SOC_FINALIZA_REPARTO] [char](1) NOT NULL,
	[SOC_FECHA_FINALIZA_REPARTO] [datetime] NULL,
	[SOC_TIPO_ALIVIO] [varchar](20) NULL,
	[SOC_ESTADO] [char](1) NOT NULL,
	[SOC_CREADO_POR] [uniqueidentifier] NOT NULL,
	[SOC_FECHA_CREACION] [datetime] NOT NULL,
	[SOC_ACTUALIZADO_POR] [uniqueidentifier] NULL,
	[SOC_FECHA_ACTUALIZA] [datetime] NULL,
 CONSTRAINT [PK_SOC_SOLICITUD_CREDITO] PRIMARY KEY CLUSTERED 
(
	[SOC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SOC_SOLICITUD_CREDITO] ADD  CONSTRAINT [DF_SOC_SOLICITUD_CREDITO_SOC_CONVENIO_ASEGURADORA_HOGAR]  DEFAULT ('N') FOR [SOC_CONVENIO_ASEGURADORA_HOGAR]
GO

ALTER TABLE [dbo].[SOC_SOLICITUD_CREDITO] ADD  CONSTRAINT [DF_SOC_SOLICITUD_CREDITO_PORC_EXTRAPRIMA]  DEFAULT ((0)) FOR [SOC_PORC_EXTRAPRIMA]
GO

ALTER TABLE [dbo].[SOC_SOLICITUD_CREDITO] ADD  CONSTRAINT [DF_SOC_SOLICITUD_CREDITO_SOC_VALOR_RECOMENDADO_CREDITO]  DEFAULT ((0)) FOR [SOC_VALOR_RECOMENDADO_CREDITO]
GO

ALTER TABLE [dbo].[SOC_SOLICITUD_CREDITO] ADD  CONSTRAINT [DF_SOC_SOLICITUD_CREDITO_SOC_FINALIZA_REPARTO]  DEFAULT ('N') FOR [SOC_FINALIZA_REPARTO]
GO


