-----------------------------------------------
-- author Edgar Andrés Riaño Suárez
-- descripcion: Tabla de dirección del cliente
-- date: 07 / 05 / 2021
-----------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DRC_DIRECCION_CLIENTE]') AND type in (N'U'))
DROP TABLE [dbo].[DRC_DIRECCION_CLIENTE]
GO

CREATE TABLE [dbo].[DRC_DIRECCION_CLIENTE](
	[DRC_ID] [int] NOT NULL IDENTITY,
	[CLI_ID] [int] NULL,
	[DRC_CONSECUTIVO] [int] NULL,
	[DPP_ID_RESIDENCIA] [int] NULL,
	[DPD_ID_RESIDENCIA] [int] NULL,
	[DPC_ID_RESIDENCIA] [int] NULL,
	[DRC_CIUDAD_RESIDENCIA_EXTRANJERO] [varchar](255) NULL,
	[TPC_TIPO_CALLE] [int] NULL,
	[DRC_NUMERO_1] [int] NULL,
	[LTR_LETRA_1] [int] NULL,
	[BS_BIS_1] [int] NULL,
	[CRD_CARDINAL_1] [int] NULL,
	[DRC_NUMERO_2] [int] NULL,
	[LTR_LETRA_2] [int] NULL,
	[BS_BIS_2] [int] NULL,
	[CRD_CARDINAL_2] [int] NULL,
	[DRC_NUMERO_3] [int] NULL,
	[LTR_LETRA_3] [int] NULL,
	[CRD_CARDINAL_3] [int] NULL,
	[DRC_COMPLEMENTO_DIRECCION] [varchar](50) NULL,
	[DRC_DIRECCION] [varchar](255) NULL,
	[DRC_BARRIO] [varchar](100) NULL,
	[DRC_TIPO_DIR] [int] NULL,
	[ID_SISTEMA_SIS] [int] NULL,
	[TPD_ID] [int] NULL
 CONSTRAINT [PK_DRC_ID] PRIMARY KEY CLUSTERED 
(
	[DRC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO