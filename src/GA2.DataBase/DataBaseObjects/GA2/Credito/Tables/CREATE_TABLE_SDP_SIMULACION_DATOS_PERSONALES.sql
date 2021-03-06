USE [GA2]
GO

/****** Object:  Table [dbo].[SDP_SIMULACION_DATOS_PERSONALES]    Script Date: 6/07/2021 8:52:09 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SDP_SIMULACION_DATOS_PERSONALES](
	[SDP_ID] [uniqueidentifier] NOT NULL,
	[SLS_ID] [uniqueidentifier] NOT NULL,
	[FRZ_ID] [int] NOT NULL,
	[CTG_ID] [int] NOT NULL,
	[GRD_ID] [int] NOT NULL,
	[SDP_NUMERO_DOCUMENTO] [varchar](15) NOT NULL,
	[SDP_NOMBRES_APELLIDOS] [varchar](100) NOT NULL,
	[SDP_EDAD] [int] NOT NULL,
	[SDP_FECHA_AFILIACION] [date] NOT NULL,
	[DPD_ID] [int] NOT NULL,
	[DPC_ID] [int] NOT NULL,
	[SDP_DIRECCION] [varchar](60) NOT NULL,
	[SDP_TELEFONO_FIJO] [varchar](15) NOT NULL,
	[SDP_TELEFONO_CELULAR] [varchar](15) NOT NULL,
	[SDP_E_MAIL] [varchar](100) NOT NULL,
	[SDP_CUOTAS] [int] NOT NULL,
	[SDP_REGIMEN] [varchar](7) NOT NULL,
	[SDP_VALOR_INMUEBLE] [float] NOT NULL,
	[TVV_ID] [int] NOT NULL,
	[DPD_ID_INMUEBLE] [int] NULL,
	[DPC_ID_INMUEBLE] [int] NULL,
	[SDP_USUARIO_ACTUALIZA] [uniqueidentifier] NOT NULL,
	[SDP_FECHA_ACTUALIZA] [datetime] NOT NULL,
 CONSTRAINT [PK_SDP_SIMULACION_DATOS_PERSONALES] PRIMARY KEY CLUSTERED 
(
	[SDP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SDP_SIMULACION_DATOS_PERSONALES]  WITH CHECK ADD  CONSTRAINT [FK_SDP_SIMULACION_DATOS_PERSONALES_SLS_SOLICITUD_SIMULACION] FOREIGN KEY([SLS_ID])
REFERENCES [dbo].[SLS_SOLICITUD_SIMULACION] ([SLS_ID])
GO

ALTER TABLE [dbo].[SDP_SIMULACION_DATOS_PERSONALES] CHECK CONSTRAINT [FK_SDP_SIMULACION_DATOS_PERSONALES_SLS_SOLICITUD_SIMULACION]
GO


