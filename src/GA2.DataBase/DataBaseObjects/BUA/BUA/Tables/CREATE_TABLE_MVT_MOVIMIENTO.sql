IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MVT_MOVIMIENTO]') AND type in (N'U'))
DROP TABLE [dbo].[MVT_MOVIMIENTO]
GO

CREATE TABLE [dbo].[MVT_MOVIMIENTO](
	[MVT_ID] [int] IDENTITY(1,1) NOT NULL,
	[CTA_ID] [int] NULL,
	[CNC_ID] [int] NULL,
	[MVT_VALOR] [numeric](25, 2) NULL,
	[CAT_TIPO_MOVIMIENTO] [char](1) NULL,
	[MVT_FECHA_PROCESO] [datetime] NULL,
	[DCT_ID] [int] NULL,
	[MVT_ANO_PERIODO] [varchar](6) NULL,
	[MVT_FECHA_MOVIMIENTO] [datetime] NULL
) ON [PRIMARY]
GO

