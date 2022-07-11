-----------------------------------------------
-- author Edgar Andrés Riaño Suárez
-- descripcion: Tabla de cónyuge del cliente
-- date: 07 / 05 / 2021
-----------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CNY_CONYUGE_CLIENTE]') AND type in (N'U'))
DROP TABLE [dbo].[CNY_CONYUGE_CLIENTE]
GO

CREATE TABLE [dbo].[CNY_CONYUGE_CLIENTE](
	[CNY_ID] [int] NOT NULL IDENTITY,
	[CLI_ID] [int] NULL,
	[CNY_TID_ID] [int] NULL,
	[CNY_IDENTIFICACION] [varchar](20) NULL,
	[CNY_PRIMER_NOMBRE] [varchar](50) NULL,
	[CNY_SEGUNDO_NOMBRE] [varchar](50) NULL,
	[CNY_PRIMER_APELLIDO] [varchar](50) NULL,
	[CNY_SEGUNDO_APELLIDO] [varchar](50) NULL,
	[CNY_ACTIVO] [bit] NULL,
 CONSTRAINT [PK_CNY_ID] PRIMARY KEY CLUSTERED 
(
	[CNY_ID] ASC 
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO