﻿USE [GA2]
GO

/****** Object:  Table [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS]    Script Date: 6/07/2021 9:05:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS](
	[SDF_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SLC_ID] [bigint] NOT NULL,
	[SDF_VALOR_SALARIO] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_INGRESOS] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_TOTAL_INGRESOS] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_DESCUENTO_NOMINA] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_DESCUENTOS] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_TOTAL_EGRESOS] [decimal](25, 6) NOT NULL,
	[SDF_USUARIO_ACTUALIZA] [varchar](30) NOT NULL,
	[SDF_FECHA_ACTUALIZA] [datetime] NOT NULL,
	[SDF_VALOR_OTROS_INGRESOS1] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_INGRESOS2] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_INGRESOS3] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_INGRESOS4] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_DESCUENTOS1] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_DESCUENTOS2] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_DESCUENTOS3] [decimal](25, 6) NOT NULL,
	[SDF_VALOR_OTROS_DESCUENTOS4] [decimal](25, 6) NOT NULL,
	[SDF_DESCRIPCION_SALARIO] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_INGRESOS] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_ING1] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_ING2] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_ING3] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_ING4] [varchar](50) NULL,
	[SDF_DESCRIPCION_DESCTO_NOMINA] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_DESCUENTO] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_DECTO1] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_DECTO2] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_DECTO3] [varchar](50) NULL,
	[SDF_DESCRIPCION_OTRO_DECTO4] [varchar](50) NULL,
 CONSTRAINT [PK_SDF_SOLICITUD_DATOS_FINANCIEROS] PRIMARY KEY CLUSTERED 
(
	[SDF_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] ADD  CONSTRAINT [DF_SDF_SOLICITUD_DATOS_FINANCIEROS_SDF_VALOR_OTROS_INGRESOS1]  DEFAULT ((0)) FOR [SDF_VALOR_OTROS_INGRESOS1]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] ADD  CONSTRAINT [DF_SDF_SOLICITUD_DATOS_FINANCIEROS_SDF_VALOR_OTROS_INGRESOS2]  DEFAULT ((0)) FOR [SDF_VALOR_OTROS_INGRESOS2]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] ADD  CONSTRAINT [DF_SDF_SOLICITUD_DATOS_FINANCIEROS_SDF_VALOR_OTROS_INGRESOS3]  DEFAULT ((0)) FOR [SDF_VALOR_OTROS_INGRESOS3]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] ADD  CONSTRAINT [DF_SDF_SOLICITUD_DATOS_FINANCIEROS_SDF_VALOR_OTROS_INGRESOS4]  DEFAULT ((0)) FOR [SDF_VALOR_OTROS_INGRESOS4]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] ADD  CONSTRAINT [DF_SDF_SOLICITUD_DATOS_FINANCIEROS_SDF_VALOR_OTROS_DESCUENTOS1]  DEFAULT ((0)) FOR [SDF_VALOR_OTROS_DESCUENTOS1]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] ADD  CONSTRAINT [DF_SDF_SOLICITUD_DATOS_FINANCIEROS_SDF_VALOR_OTROS_DESCUENTOS2]  DEFAULT ((0)) FOR [SDF_VALOR_OTROS_DESCUENTOS2]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] ADD  CONSTRAINT [DF_SDF_SOLICITUD_DATOS_FINANCIEROS_SDF_VALOR_OTROS_DESCUENTOS3]  DEFAULT ((0)) FOR [SDF_VALOR_OTROS_DESCUENTOS3]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] ADD  CONSTRAINT [DF_SDF_SOLICITUD_DATOS_FINANCIEROS_SDF_VALOR_OTROS_DESCUENTOS4]  DEFAULT ((0)) FOR [SDF_VALOR_OTROS_DESCUENTOS4]
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS]  WITH CHECK ADD  CONSTRAINT [FK_SDF_SOLICITUD_DATOS_FINANCIEROS_SLC_SOLICITUD_CREDITO] FOREIGN KEY([SLC_ID])
REFERENCES [dbo].[SLC_SOLICITUD_CREDITO] ([SLC_ID])
GO

ALTER TABLE [dbo].[SDF_SOLICITUD_DATOS_FINANCIEROS] CHECK CONSTRAINT [FK_SDF_SOLICITUD_DATOS_FINANCIEROS_SLC_SOLICITUD_CREDITO]
GO

