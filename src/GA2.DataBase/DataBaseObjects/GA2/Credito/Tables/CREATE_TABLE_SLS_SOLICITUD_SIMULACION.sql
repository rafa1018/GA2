﻿USE [GA2]
GO

/****** Object:  Table [dbo].[SLS_SOLICITUD_SIMULACION]    Script Date: 6/07/2021 7:28:10 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SLS_SOLICITUD_SIMULACION](
	[SLS_ID] [uniqueidentifier] NOT NULL,
	[SLS_FECHA_SOLICITUD] [date] NOT NULL,
	[TCR_ID] [int] NOT NULL,
	[SLS_NUMERO_PREAPROBADO] [bigint] NOT NULL,
	[SLS_PROBLEMA_EMAIL] [bit] NOT NULL,
	[SLS_ENVIO_NOTIFICACION] [bit] NOT NULL,
	[SLS_RUTA_PDF_RESUMEN] [varchar](200) NULL,
	[SLS_PORC_EXTRAPRIMA] [decimal](5, 2) NOT NULL,
	[SLS_ESTADO] [char](1) NOT NULL,
	[SLS_USUARIO_ACTUALIZA] [uniqueidentifier] NOT NULL,
	[SLS_FECHA_ACTUALIZA] [datetime] NOT NULL,
 CONSTRAINT [PK_SLS_SOLICITUD_SIMULACION] PRIMARY KEY CLUSTERED 
(
	[SLS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SLS_SOLICITUD_SIMULACION] ADD  CONSTRAINT [DF_SLS_SOLICITUD_SIMULACION_PORC_EXTRAPRIMA]  DEFAULT ((0)) FOR [SLS_PORC_EXTRAPRIMA]
GO


