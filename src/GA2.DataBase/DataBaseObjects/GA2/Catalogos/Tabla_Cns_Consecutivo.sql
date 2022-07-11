
--------------------------
--- author: Cristian Gonzalez
--- descripcion: tabla consecutivo de creditos
--- Date: 21/04/2021
--------------------------
CREATE TABLE [dbo].[CNS_CONSECUTIVO](
	[CNS_ID] [varchar](2) NOT NULL,
	[CNS_DESCRIPCION] [varchar](255) NOT NULL,
	[CNS_ULTIMO_NUMERO] [bigint] NOT NULL,
	[CNS_ESTADO] [int] NOT NULL,
	[CNS_CREADO_POR] [uniqueidentifier] NOT NULL,
	[CNS_FECHA_CREACION] [datetime] NOT NULL,
	[CNS_ACTUALIZADO_POR] [uniqueidentifier] NOT NULL,
	[CNS_FECHA_ACTUALIZA] [datetime] NOT NULL,
 CONSTRAINT [PK_CNS_CONSECUTIVO] PRIMARY KEY CLUSTERED 
(
	[CNS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]