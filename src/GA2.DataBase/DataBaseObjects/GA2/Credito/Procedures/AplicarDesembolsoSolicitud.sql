USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[AplicarDesembolsoSolicitud]    Script Date: 7/07/2021 12:48:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: AprobarComiteCredito
Descripcion: Aprueba el Acta del Comite de Credito
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 24 de 2021
*/
CREATE PROCEDURE [dbo].[AplicarDesembolsoSolicitud] 
@SID_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@SID_APLICADO_POR uniqueidentifier, 
@SID_FECHA_APLICACION datetime

AS
BEGIN
	Declare @contador int,
			     @mUsuario uniqueidentifier,
				 @Notaria int,
				 @Depto int,
				 @ciuad int,
				 @NoTramite int

	-- Actualizo la tabla de Comite
	Update SID_SOLICITUD_INF_DESEMBOLSO Set SID_APLICADO = 'S',
								  SID_APLICADO_POR =  @SID_APLICADO_POR,
								  SID_FECHA_APLICACION = @SID_FECHA_APLICACION,
								  SID_ACTUALIZADO_POR =  @SID_APLICADO_POR,
								  SID_FECHA_ACTUALIZA = @SID_FECHA_APLICACION
     Where SID_ID = @SID_ID
	-- Verifico para asignar el reparto
	Select @contador = Case When NOT_ID IS NULL Then 0 Else 1 End,  @Depto =  SOP.DPD_ID, @ciuad = SOP.DPC_ID
	  From  SOC_SOLICITUD_CREDITO SOC With(NoLock), SOP_SOLICITUD_PRODUCTO SOP With(NoLock)
   Where SOC.SOC_ID = @SOC_ID
       And SOC.SOC_ID = SOP.SOC_ID
       
	IF  @contador = 0
	Begin
			Set @NoTramite = 0
			-- Obtengo el usuario de analisis Juridico
		   Select @mUsuario = ACT.ID_USERS  From TRS_TRAMITE_SOLICITUD TRS, ACT_ACTIVIDAD_TRAMITE_SOLIC ACT, AFL_ACTIVIDAD_FLUJO AFL
		   Where TRS.SOC_ID = @SOC_ID 
		      And TRS.TRS_ID=ACT.TRS_ID
			  And ACT.AFL_ID=AFL.AFL_ID
			  And AFL_CAPTURA_DATOS_JUR='S'

			Update ATU_ASIGNACION_TRAMITE_USUARIO Set ATU_NO_TRAMITES_ASIGNADOS = ATU_NO_TRAMITES_ASIGNADOS+1
			Where ID_USERS = @mUsuario

		   -- Obtengo la Noraria a asignar
		   Select  @Notaria = NTR.NOT_ID, @NoTramite = Case When ATN.ATN_ID IS NULL Then 0 Else ATN.ATN_NO_TRAMITES_ASIGNADOS End
		     From NOT_NOTARIA NTR With(NoLock)
		                          LEFT JOIN  ATN_ASIGNACION_TRAMITE_NOTARIA ATN With(NoLock) ON ATN.NOT_ID = NTR.NOT_ID
		   Where NTR.DPD_ID = @Depto And NTR.DPC_ID = @ciuad

			IF @Notaria IS NOT NULL
			Begin
				Select @contador = COUNT(*) From ATN_ASIGNACION_TRAMITE_NOTARIA
				Where NOT_ID = @Notaria
				Set @NoTramite = @NoTramite + 1
				If @contador = 0
				Begin
					Insert into ATN_ASIGNACION_TRAMITE_NOTARIA (NOT_ID,ATN_NO_TRAMITES_ASIGNADOS,ATN_MODIFICADO_POR,ATN_FECHA_MODIFICACION)
					   Values (@Notaria,@NoTramite, @SID_APLICADO_POR, GETDATE())		
				End
				Else
				Begin
					Update ATN_ASIGNACION_TRAMITE_NOTARIA Set ATN_NO_TRAMITES_ASIGNADOS = @NoTramite
					Where NOT_ID = @Notaria
				End
			End

			Update SOC_SOLICITUD_CREDITO Set NOT_ID = @Notaria, USR_REPARTO = @mUsuario, SOC_FECHA_REPARTO = GETDATE(), SOC_FINALIZA_REPARTO = 'N'
			Where SOC_ID = SOC_ID

	End
   
	-- Retorno los Datos los Datos del Desembolso Aplicado
	Select  * From SID_SOLICITUD_INF_DESEMBOLSO
	 Where SID_ID = @SID_ID

END
