-----------------------------------------------
-- author Edgar Andrés Riaño Suárez
-- descripcion: Tabla de correos del cliente
-- date: 07 / 05 / 2021
-----------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DRC_DIRECCION_CORREO]') AND type in (N'U'))
DROP TABLE [dbo].[DRC_DIRECCION_CORREO]
GO

CREATE TABLE [dbo].[DRC_DIRECCION_CORREO](
	[DCE_ID] [int] NOT NULL IDENTITY,
	[DRC_ID] [int] NULL,
	[DCE_CORREO] [varchar](255) NULL,
	[TCE_ID] [int] NULL,
	[DCE_ENVIO_INFORMACION] [bit] NULL,
	[DCE_ACTIVO] [bit] NULL,
 CONSTRAINT [PK_DRC_ID_CONSECUTIVO] PRIMARY KEY CLUSTERED 
(
	[DCE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO