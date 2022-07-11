-----------------------------------------------
-- author Edgar Andrés Riaño Suárez
-- descripcion: Tabla de teléfonos del cliente
-- date: 07 / 05 / 2021
-----------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DRC_DIRECCION_TELEFONO]') AND type in (N'U'))
DROP TABLE [dbo].[DRC_DIRECCION_TELEFONO]
GO

CREATE TABLE [dbo].[DRC_DIRECCION_TELEFONO](
	[DTL_ID] [int] NOT NULL IDENTITY,
	[DRC_ID] [int] NULL,
	[DTL_INDICATIVO_PAIS] [int] NULL,
	[DTL_INDICATIVO_CIUDAD] [int] NULL,
	[DTL_TELEFONO] [varchar](20) NULL,
	[TPT_ID] [int] NULL,
	[DTL_ENVIO_INFORMACION] [bit] NULL,
	[DTL_ACTIVO] [bit] NULL,
 CONSTRAINT [PK_DTL_ID] PRIMARY KEY CLUSTERED 
(
	[DTL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO