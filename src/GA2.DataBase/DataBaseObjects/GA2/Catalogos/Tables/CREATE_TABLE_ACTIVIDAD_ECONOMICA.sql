------------------------------------------
--auhtor Andres Riaño
-- descripcion: Tabla para actividades economicas
-- date: 22 / 12 / 2021
------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACC_ACTIVIDAD_ECONOMICA]') AND type in (N'U'))
DROP TABLE [dbo].[ACC_ACTIVIDAD_ECONOMICA]
GO

CREATE TABLE [dbo].[ACC_ACTIVIDAD_ECONOMICA](
	[ACC_ID] [int] NULL,
	[ACC_DESCRIPCION] [varchar](1000) NULL,
	[ACC_CODIGO_CIUU] [int] NULL,
	[ACC_ESTADO] [int] NULL,
	[ACC_CREADO_POR] [uniqueidentifier] NULL,
	[ACC_FECHA_CREACION] [datetime] NULL,
	[ACC_ACTUALIZADO_POR] [uniqueidentifier] NULL,
	[ACC_FECHA_ACTUALIZA] [datetime] NULL
) ON [PRIMARY]
GO