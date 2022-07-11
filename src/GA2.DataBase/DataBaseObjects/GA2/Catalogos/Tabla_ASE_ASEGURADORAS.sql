
--------------------------
--- author: Cristian Gonzalez
--- descripcion: tabla consecutivo de creditos
--- Date: 21/04/2021
--------------------------
USE [GA2]
GO

/****** Object:  Table [dbo].[ASE_ASEGURADORAS]    Script Date: 27/04/2021 10:09:08 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ASE_ASEGURADORAS](
	[ASE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ASE_RAZON_SOCIAL] [varchar](100) NOT NULL,
	[ASE_SITIO_WEB] [varchar](100) NOT NULL,
	[ASE_ESTADO] [int] NOT NULL,
	[ASE_CREADO_POR] [uniqueidentifier] NOT NULL,
	[ASE_FECHA_CREACION] [datetime] NOT NULL,
	[ASE_ACTUALIZADO_POR] [uniqueidentifier] NOT NULL,
	[ASE_FECHA_ACTUALIZA] [datetime] NOT NULL,
 CONSTRAINT [PK_ASE_ASEGURADORAS] PRIMARY KEY CLUSTERED 
(
	[ASE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO