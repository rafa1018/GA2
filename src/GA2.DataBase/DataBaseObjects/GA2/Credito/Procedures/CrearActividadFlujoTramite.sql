USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearActividadFlujoTramite]    Script Date: 7/07/2021 12:32:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Nombre: CrearPreAprobado
Descripcion: Crea una actividad del Flujo del Tramite de la solicitud
Elaboro: German Eduardo Guarnizo
Fecha: Abril 21 de 2021
*/

CREATE PROCEDURE [dbo].[CrearActividadFlujoTramite] 
@ACT_ID uniqueidentifier,
@TRS_ID uniqueidentifier,
@FLU_ID int,
@ORDEN_ACTUAL int,
@ACT_ESTADO int,
@ACT_OBSERVACION varchar(500),
@ID_USERS uniqueidentifier,
@ACT_CREADO_POR uniqueidentifier,
@ACT_FECHA_CREACION datetime

AS
BEGIN

	Declare @mIdAct int
	Declare @mOrden int
	Declare @mConta int
	Declare @musrAct uniqueidentifier
	Declare @NoTramite int
	Declare @DesRol varchar(50)
	Declare @mFechaFin datetime
	Declare @mailAliado varchar(100)
	Declare @mEnvioAlertaAliado char(1)
   Set @mIdAct = 0
	Set @mOrden = 0
	Set @mConta = 0
	Set @NoTramite = 0
	If @ACT_ESTADO = 4
	  Set @mFechaFin = GETDATE()

	Select Top 1 @mIdAct = AFL_ID, @mOrden = AFL_ORDEN
	  From AFL_ACTIVIDAD_FLUJO
	Where FLU_ID = @FLU_ID
	  And AFL_ORDEN > @ORDEN_ACTUAL
	  AND AFL_ESTADO = 1
	  AND AFL_ACTIVIDAD_PRINCIPAL='S'
	--- Pendiente Asignacion del Usuario
	Select Top 1 @musrAct = US.ID_USERS, @NoTramite = Case When ATU.ATU_NO_TRAMITES_ASIGNADOS IS NULL THEN 0 Else ATU_NO_TRAMITES_ASIGNADOS END
	  From USA_USUARIO_ACTIVIDAD US With(NoLock) 
           LEFT JOIN ATU_ASIGNACION_TRAMITE_USUARIO ATU With(NoLock) ON US.ID_USERS=ATU.ID_USERS
	 Where US.AFL_ID = @mIdAct
	 Order by Case When ATU.ATU_NO_TRAMITES_ASIGNADOS IS NULL THEN 0 Else ATU_NO_TRAMITES_ASIGNADOS END 
	 
	 If @musrAct IS NOT NULL
	 Begin
		Select @mConta = COUNT(*) From ATU_ASIGNACION_TRAMITE_USUARIO
		  Where ID_USERS = @musrAct
	    SET @ID_USERS = @musrAct
 		Set @NoTramite = @NoTramite + 1
		If @mConta = 0
		Begin
		    Insert Into ATU_ASIGNACION_TRAMITE_USUARIO (ID_USERS,ATU_NO_TRAMITES_ASIGNADOS, ATU_MODIFICADO_POR, ATU_FECHA_MODIFICACION)
			 Values (@musrAct,@NoTramite,@ACT_CREADO_POR, GETDATE())
		End
		Else
		Begin
			Update ATU_ASIGNACION_TRAMITE_USUARIO Set ATU_NO_TRAMITES_ASIGNADOS = @NoTramite
			Where ID_USERS = @musrAct
		End
	 End
	
	--- Creo la actividad
	Select @mConta = count(*) From ACT_ACTIVIDAD_TRAMITE_SOLIC Where TRS_ID = @TRS_ID And AFL_ID = @mIdAct
	If @mConta = 0
	Begin
		  Insert Into ACT_ACTIVIDAD_TRAMITE_SOLIC (ACT_ID, TRS_ID, AFL_ID, ID_USERS, ACT_FECHA_INICIO,
												   ACT_FECHA_FINALIZA, ACT_OBSERVACION, ACT_ESTADO,
												   ACT_CREADO_POR, ACT_FECHA_CREACION
												  )
		  Values (NEWID(), @TRS_ID, @mIdAct, @ID_USERS, GETDATE(),
				  @mFechaFin, @ACT_OBSERVACION, @ACT_ESTADO,
				  @ACT_CREADO_POR, @ACT_FECHA_CREACION)
	End
	  -- Valido si existe una actividad segundaria para lanzarla
	Declare C1 Cursor For
	Select  AFL_ID, Case When AFL_CAPTURA_DATOS_TEC='S' OR AFL_CAPTURA_DATOS_JUR='S' Then 'S' Else 'N' End
	  From AFL_ACTIVIDAD_FLUJO
	Where FLU_ID = @FLU_ID
	  And AFL_ORDEN = @mOrden
	  AND AFL_ESTADO = 1
	  AND AFL_ACTIVIDAD_PRINCIPAL='N'
	ORDER BY AFL_ID
    OPEN C1 
	FETCH NEXT FROM C1 Into @mIdAct, @mEnvioAlertaAliado
	WHILE @@FETCH_STATUS = 0
	Begin
	    --Select 'XXX', @mIdAct
	 	--- Obtengo el usuario a asignar a la actividad
		Select Top 1 @musrAct = US.ID_USERS, @NoTramite = Case When ATU.ATU_NO_TRAMITES_ASIGNADOS IS NULL THEN 0 Else ATU_NO_TRAMITES_ASIGNADOS END,
		       @DesRol = RL.RL_DESCRIPCION
		  From USA_USUARIO_ACTIVIDAD US With(NoLock) 
			   LEFT JOIN ATU_ASIGNACION_TRAMITE_USUARIO ATU With(NoLock) ON US.ID_USERS=ATU.ID_USERS,
			   USR_USERS USR With(NoLock), RL_ROL RL With(NoLock)
		 Where US.AFL_ID = @mIdAct
		   And US.ID_USERS = USR.USR_ID
		   And USR.ROLID=RL.RL_ID
		 Order by Case When ATU.ATU_NO_TRAMITES_ASIGNADOS IS NULL THEN 0 Else ATU_NO_TRAMITES_ASIGNADOS END 
		 IF @musrAct IS NOT NULL 
		 Begin
			SET @ID_USERS = @musrAct
			If @DesRol != 'Perito'
			Begin
				Select @mConta = COUNT(*) From ATU_ASIGNACION_TRAMITE_USUARIO
				Where ID_USERS = @musrAct
 				Set @NoTramite = @NoTramite + 1
				If @mConta = 0
				Begin
					Insert Into ATU_ASIGNACION_TRAMITE_USUARIO (ID_USERS,ATU_NO_TRAMITES_ASIGNADOS, ATU_MODIFICADO_POR, ATU_FECHA_MODIFICACION)
					 Values (@musrAct,@NoTramite,@ACT_CREADO_POR, GETDATE())
				End
				Else
				Begin
					Update ATU_ASIGNACION_TRAMITE_USUARIO Set ATU_NO_TRAMITES_ASIGNADOS = @NoTramite
				    Where ID_USERS = @musrAct
				End
				--- Creo la actividad segundaria
				Select @mConta = count(*) From ACT_ACTIVIDAD_TRAMITE_SOLIC Where TRS_ID = @TRS_ID And AFL_ID = @mIdAct
				If @mConta = 0
				Begin
						  Insert Into ACT_ACTIVIDAD_TRAMITE_SOLIC (ACT_ID, TRS_ID, AFL_ID, ID_USERS, ACT_FECHA_INICIO,
																   ACT_FECHA_FINALIZA, ACT_OBSERVACION, ACT_ESTADO,
																   ACT_CREADO_POR, ACT_FECHA_CREACION
																  )
						  Values (NEWID(), @TRS_ID, @mIdAct, @ID_USERS, GETDATE(),
								  @mFechaFin, @ACT_OBSERVACION, @ACT_ESTADO,
								  @ACT_CREADO_POR, @ACT_FECHA_CREACION)
				End
				IF @mEnvioAlertaAliado = 'S'
				Begin
						-- Creo el Envio de la Alerta		    
						 Declare @mAlerta varchar(500),
									  @url varchar(200),
									  @ID1 uniqueidentifier,
									  @mNombre varchar(200),
									  @mCedula varchar(15),
									  @mCeluar varchar(15),
									  @mEmail varchar(50)

						Select @mailAliado = USR_EMAIL From USR_USERS 
						Where  USR_ID = @musrAct

					   Select @mCedula = SOB.SOB_NUMERO_DOCUMENTO, @mCeluar = SOB.SOB_CELULAR, @mEmail = SOB.SOB_CORREO_PERSONAL, 
								  @mNombre = SOB_PRIMER_NOMBRE+' '+SOB.SOB_SEGUNDO_NOMBRE+' '+SOB.SOB_PRIMER_APELLIDO+' '+SOB.SOB_SEGUNDO_APELLIDO					  
						  From SOC_SOLICITUD_CREDITO SOC With(NoLock), TRS_TRAMITE_SOLICITUD TR With(NoLock), SOB_SOLICITUD_INF_BASICA SOB With(NoLock)
					   Where SOC.SOC_ID = TR.SOC_ID And TR.TRS_ID = @TRS_ID And SOC.SOC_ID=SOB.SOC_ID

						Select @mAlerta = ALA_MENSAJE, @url = URL_CREDITO  From ALA_ALERTA_AUTOMATICAS, PRM_SIMULADOR Where ALA_ID = 3
						Set @ID1 = NEWID()
						Set @mAlerta = REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@mAlerta,'&1&',@mNombre),'&2&',Convert(varchar(10),@ACT_FECHA_CREACION,111)),'&5&',@url),'&3&',@mNombre),'&4&',@mCedula),'&6&',@mEmail),'&7&',@mCeluar)
						Exec CrearEnvioAlerta  @ID1, @mailAliado, 'Envio Aprobación Estudio Credito	',@mAlerta, '', 'N', @ACT_CREADO_POR, @ACT_FECHA_CREACION
				  End
			End
		 End
	
	   FETCH NEXT FROM C1 Into @mIdAct, @mEnvioAlertaAliado
	End
	CLOSE C1
	DEALLOCATE C1
	-- Retorno el Registro de la Actividad
	--Select * From ACT_ACTIVIDAD_TRAMITE_SOLIC
	--Where ACT_ID = @ACT_ID
END
