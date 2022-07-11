
--------------------------
--- author: Cristian Gonzalez
--- descripcion: tabla ALA_AlertaAutomaticas de creditos
--- Date: 21/04/2021
--------------------------
USE [GA2]
GO

/****** Object:  Table [dbo].[ALA_AlertaAutomaticas]    Script Date: 29/04/2021 4:00:19 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ALA_AlertaAutomaticas](
	[ALA_ID] [int] NOT NULL,
	[ALA_DESCRIPCION] [varchar](100) NOT NULL,
	[ALA_MENSAJE] [varchar](1000) NOT NULL,
	[ALA_FECHA_CREACION] [datetime] NOT NULL,
	[ALA_MODIFICADO_POR] [uniqueidentifier] NOT NULL,
	[ALA_FECHA_MODIFICACION] [datetime] NULL,
 CONSTRAINT [PK_ALA_AlertaAutomaticas] PRIMARY KEY CLUSTERED 
(
	[ALA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO]