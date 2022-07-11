----------------------------------------------------------
-- author Edgar Andrés Riaño Suárez
-- descripcion: Tabla de actividad económica del cliente
-- date: 07 / 05 / 2021
----------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLI_CLIENTE_INFO_ECONOMICA]') AND type in (N'U'))
DROP TABLE [dbo].[CLI_CLIENTE_INFO_ECONOMICA]
GO

CREATE TABLE [dbo].[CLI_CLIENTE_INFO_ECONOMICA](
	[CIE_ID] [int] NOT NULL IDENTITY,
	[CLI_ID] [int] NULL,
	[ACC_ID] [int] NULL,
	[CIE_FECHA_INFO_ECONOMICA] [datetime] NULL,
	[CIE_INGRESO_MENSUAL] [numeric](18,2) NULL,
	[CIE_EGRESO_MENSUAL] [numeric](18,2) NULL,
	[CIE_TOTAL_ACTIVOS] [numeric](18,2) NULL,
	[CIE_TOTAL_PASIVOS] [numeric](18,2) NULL,
	[CIE_TOTAL_PATRIMONIO] [numeric](18,2) NULL,
	[CIE_INGRESO_ADICIONAL] [numeric](18,2) NULL,
	[CIE_CONCEPTO_INGRESO_ADICIONAL] [varchar](255) NULL,
	[CIE_TRANS_EXTRANJERO] [bit] NULL,
	[MND_ID] [int] NULL,
	[CIE_VALOR_TRANSFERENCIA] [numeric](18,2) NULL,
 CONSTRAINT [PK_CIE_ID] PRIMARY KEY CLUSTERED 
(
	[CIE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO