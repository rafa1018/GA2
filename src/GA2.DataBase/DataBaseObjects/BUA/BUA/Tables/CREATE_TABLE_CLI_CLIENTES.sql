-------------------------------------------------------
-- author Edgar Andrés Riaño Suárez
-- descripcion: Tabla de información básica del usuario
-- date: 07 / 05 / 2021
-------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLI_CLIENTE]') AND type in (N'U'))
DROP TABLE [dbo].[CLI_CLIENTE]
GO

CREATE TABLE [dbo].[CLI_CLIENTE](
	[CLI_ID] [int] NOT NULL IDENTITY,
	[TPA_ID] [int] NULL,
	[TID_ID] [int] NULL,
	[CLI_IDENTIFICACION] [varchar](30) NULL UNIQUE,
	[CLI_FECHA_EXPEDICION] [date] NULL,
	[DPD_ID_IDENTIFICACION_EXPEDIDA] [int] NULL,
	[DPC_ID_IDENTIFICACION_EXPEDIDA] [int] NULL,
	[CLI_LUGAR_EXPEDICION] [varchar](50) NULL,
	[CLI_CODIGO_MILITAR] [varchar](30) NULL,
	[CLI_PRIMER_NOMBRE] [varchar](50) NULL,
	[CLI_SEGUNDO_NOMBRE] [varchar](50) NULL,
	[CLI_PRIMER_APELLIDO] [varchar](50) NULL,
	[CLI_SEGUNDO_APELLIDO] [varchar](50) NULL,
	[CLI_FECHA_NACIMIENTO] [datetime] NULL,
	[DPP_ID_PAIS_NACIMIENTO] [int] NULL,
	[DPD_ID] [int] NULL,
	[DPC_ID] [int] NULL,
	[CLI_LUGAR_NACIMIENTO] [varchar](50) NULL,
	[CAT_SEXO] [char](1) NULL,
	[CAT_ESTADO_CIVIL] [char](1) NULL,
	[CLI_PROFESION] [int] NULL,
	[CLI_UNIDAD] [varchar](15) NULL,
	[CTG_ID] [int] NULL,
	[FRZ_ID] [int] NULL,
	[GRD_ID] [int] NULL,
	[UEJ_ID] [int] NULL,	
	[CLI_FECHA_INSCRIPCION] [datetime] NULL,
	[CLI_FECHA_ALTA] [datetime] NULL,
	[CLI_REGIMEN] [int] NULL,
	[CTS_SLP] [datetime] NULL,
	[CLI_FECHA_REINTEGRO] [datetime] NULL,
	[ECL_ID] [int] NULL,
	[CLI_VALIDACION] [varchar](255) NULL,
	[CLI_ID_PATROCINADOR] [int] NULL,
	[CLI_PARTICIPACION] [decimal](25, 4) NULL,
	[CLI_RESOLUCION] [varchar](50) NULL,
	[CLI_VALIDACION_BIOMETRICA] [bit] NULL,
	[ECL_ID_AVAL] [int] null,
	[CLI_INTEGRACION_GA2] [bit] null,
	[CLI_ACTIVO] [bit] null,
	[CLI_INTEGRACION_GA2_PAYLOAD] [varchar](max) null
 CONSTRAINT [PK_CIE_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[CLI_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO