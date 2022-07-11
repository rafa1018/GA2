IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DPT_DEPENDIENTE]') AND type in (N'U'))
DROP TABLE [dbo].[DPT_DEPENDIENTE]
GO

CREATE TABLE [dbo].[DPT_DEPENDIENTE](
	[DPT_ID] [int] IDENTITY(1,1) NOT NULL,
	[CLI_ID] [int] NULL,
	[TID_ID] [int] NULL,
	[DPT_IDENTIFICACION] [varchar](30) NULL,
	[DPT_NOMBRE] [varchar](30) NULL,
	[DPT_PARTICIPACION] [numeric](18, 2) NULL
) ON [PRIMARY]
GO