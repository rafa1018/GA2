IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CRO_CRONOGRAMANOVEDAD]') AND type in (N'U'))
DROP TABLE [dbo].[CRO_CRONOGRAMANOVEDAD]
GO

CREATE TABLE [dbo].[CRO_CRONOGRAMANOVEDAD](
	[CRO_ID] [int] IDENTITY(1,1) NOT NULL,
	[UEJ_ID] [int] NULL,
	[CRO_FECHA_REPORTE] [datetime] NULL,
	[CRO_FECHA_INICIO] [datetime] NULL,
	[CRO_FECHA_FIN] [datetime] NULL,
	[CRO_PERIODO] [varchar](10) NULL,
	[FRT_ID] [int] NULL,
	[MDE_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CRO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

