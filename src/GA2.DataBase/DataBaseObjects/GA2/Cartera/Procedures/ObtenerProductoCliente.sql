USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProductoCliente]    Script Date: 11/11/2021 15:06:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sergio Ortega Fula>
-- Create date: <2021-09-03>
-- Description:	<Obtener datos de producto por cliente>
-- =============================================
ALTER PROCEDURE [dbo].[ObtenerProductoCliente] 
	-- Add the parameters for the stored procedure here
	@CLI_IDENTIFICACION varchar(15),
	@CLI_TIPO_IDENTIFICACION int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @VALOR_DESEMBOLSO float,
			@FECHA_DESEMBOLSO date,
			@TASA_VIDA DECIMAL(9,7),
			@TASA_TERREMOTO DECIMAL(9,7),
			@DEPTO_INM INT,
			@CIUDA_INM INT
	
	-- Obtengo tasas de seguros
Select  Top 1 @TASA_VIDA = SEG_VIDA/100.0, @TASA_TERREMOTO = SEG_TODO_RIESGO / 100.0
  From PARAM_SEGURO
Where SEG_ESTADO=1
Order by SEG_FECHA_MODIFICACION DESC

-- Obtendo datos del desembolso
Select  @VALOR_DESEMBOLSO = sum(SID_VALOR_DESEMBOLSO) , @FECHA_DESEMBOLSO = MAX(SID_FECHA_DESEMBOLSO)
 From SID_SOLICITUD_INF_DESEMBOLSO DE,  SOC_SOLICITUD_CREDITO SOC
Where DE.SOC_ID = SOC.SOC_ID 
  And SOC.CLI_IDENTIFICACION = @CLI_IDENTIFICACION

If @VALOR_DESEMBOLSO IS NULL
    Set @VALOR_DESEMBOLSO = 0

Select  *, SOC_FECHA_SOLICITUD as FECHA_SOLICITUD, SOC_NUMERO_SOLICITUD as NUMERO_SOLICITUD, SOC.TCR_ID as ID_TIPO_CREDITO,
           TCR_DESCRIPCION AS TIPO_CREDITO,
           SOP_ESTADO_INMUEBLE as VIVIENDA,  TVV_DESCRIPCION as TIPO_VIVIENDA,
		    @VALOR_DESEMBOLSO as VALOR_DESEMBOLSO,  @FECHA_DESEMBOLSO as FECHA_DESEMBOLSO,
           COS_VALOR_CREDITO as MONTO_INICIAL,  0 as SALDO_CAPITAL, COS_PLAZO_CREDITO as PLAZO_CREDITO,
           COS_TEA_CREDITO as TASA_CREDITO, 
		   Case When SOC_TASA_FECH IS NULL Then 0 Else SOC_TASA_FECH End as TASA_FRECH,
		   Case When SOC_VALOR_ALIVIO IS NULL Then 0 Else SOC_VALOR_ALIVIO End as VALOR_ALIVIO,
		   Case When SEU_TODO_RIESGO IS NULL Then @TASA_TERREMOTO Else SEU_TODO_RIESGO End as TASA_SEGURO_TERREMOTO,
		   @TASA_VIDA as TASA_SEGURO_VIDA,
		   TID_DESCRIPCION as TID_DESCRIPCION
  From SOC_SOLICITUD_CREDITO SOC,
          COS_COMITE_SOLICITUD_CREDITO CO,
		  ESC_ESTADO_CARTERA ESC_CARTERA,
           SOP_SOLICITUD_PRODUCTO SOP LEFT JOIN PARAM_SEGURO_UBICACION SEG ON SEG.DPD_ID=SOP.DPD_ID And SEG.DPC_ID=SOP.DPC_ID, 
		   TCR_TIPO_CREDITO TCR, TVV_TIPO_VIVIENDA TVV, TID_TIPO_IDENTIFICACION TID, ESC_ESTADO_CARTERA ESC, CRE_CREDITO CRE
Where SOC.SOC_ID = CO.SOC_ID
   And SOC.SOC_ID = SOP.SOC_ID
   And SOC.TCR_ID = TCR.TCR_ID
   And SOP.TVV_ID = TVV.TVV_ID
   And SOC.CLI_IDENTIFICACION = @CLI_IDENTIFICACION
   And SOC.SOC_ESTADO = ESC_CARTERA.ESC_SIGLA
   AND TID.TID_ID=SOC.TID_ID
   AND SOC.TID_ID=@CLI_TIPO_IDENTIFICACION
   AND ESC.ESC_SIGLA=SOC.SOC_ESTADO
   AND CRE.CRE_ID =SOC.SOC_ID
END
