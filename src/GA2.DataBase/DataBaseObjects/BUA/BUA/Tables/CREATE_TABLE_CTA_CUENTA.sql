IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CTA_CUENTA]') AND type in (N'U'))
DROP TABLE [dbo].[CTA_CUENTA]
GO

CREATE TABLE [dbo].[CTA_CUENTA](
	[CTA_ID] [int] IDENTITY(1,1) NOT NULL,
	[CTA_ID_INTEGRACION] [int] NOT NULL,
	[CTA_NUMERO] [int] NULL,
	[CLI_ID] [int] NULL,
	[TCT_ID] [int] NULL,
	[ECT_ID] [int] NULL,
	[CCN_ID] [int] NULL,
	[DCT_ID] [int] NULL,
	[CTA_FECHA_CREACION] [datetime] NULL,
	[CTA_FECHA_CIERRE] [date] NULL,
	[CTA_FECHA_PRIMER_APORTE] [date] NULL,
	[CTA_SALDO] [numeric](25, 2) NULL,
	[CTA_SALDO_CANJE] [decimal](18, 0) NULL,
	[CTA_SALDO_DISPONIBLE] [decimal](18, 0) NULL,
	[CTA_CUOTAS] [int] NULL
) ON [PRIMARY]
GO
