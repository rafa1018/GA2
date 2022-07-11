﻿/*
Nombre: GRADO
Descripcion: Tabla Grado
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GRD_GRADO]') AND type in (N'U'))
DROP TABLE [dbo].[GRD_GRADO]
GO

CREATE TABLE [dbo].[GRD_GRADO](
	[GRD_ID] [int] NOT NULL,
	[GRD_DESCRIPCION] [varchar](60) NOT NULL,
	[CTG_ID] [int] NOT NULL,
	[GRD_ESPECIAL] [int] NOT NULL,
	[GRD_CODIGO] [int] NOT NULL,
	[GRD_SIGLA] [varchar](7) NOT NULL,
	[FRZ_ID] [int] NOT NULL,
	[GRD_CIVIL] [int] NOT NULL,
	[GRD_ACTIVO] [int] NOT NULL,
	[GRD_FACTOR_SBS] [int] NULL,
	[GRD_ANOS_ASCENSO] [int] NULL,
 CONSTRAINT [PK_GRD_GRADO] PRIMARY KEY CLUSTERED 
(
	[GRD_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
