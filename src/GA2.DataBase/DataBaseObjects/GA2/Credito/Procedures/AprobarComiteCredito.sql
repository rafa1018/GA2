USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[AprobarComiteCredito]    Script Date: 6/07/2021 4:23:10 p. m. ******/
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
ALTER PROCEDURE [dbo].[AprobarComiteCredito] 
@COC_ID bigint,
@COC_ACTUALIZADO_POR uniqueidentifier, 
@COC_FECHA_ACTUALIZA datetime

AS
BEGIN
	-- Actualizo la tabla de Comite
	Update COC_COMITE_CREDITO Set COC_ESTADO = 'A',
								  COC_ACTUALIZADO_POR =  @COC_ACTUALIZADO_POR,
								  COC_FECHA_ACTUALIZA = @COC_FECHA_ACTUALIZA
    Where COC_ID = @COC_ID
	
	-- Actualizo las solicitudes
	Declare @AFL_ID uniqueidentifier
	Declare @TRS_ID uniqueidentifier
	Declare @RESULTADO varchar(500)
	Declare @APROBADA char(1)
	Declare @RECHAZADA char(1)


	Declare C1 Cursor For
	Select AFL.AFL_ID, TRS.TRS_ID, CO1.COS_RESULTADO, CO1.COS_APROBADA, CO1.COS_RECHAZADA
	  From COS_COMITE_SOLICITUD_CREDITO CO1 With(NoLock),
	     TRS_TRAMITE_SOLICITUD TRS With(NoLock),
		 ACT_ACTIVIDAD_TRAMITE_SOLIC ACT With(NoLock),
		 AFL_ACTIVIDAD_FLUJO AFL With(NoLock)
   Where CO1.SOC_ID = TRS.SOC_ID
     And TRS.TRS_ID = ACT.TRS_ID
	 And ACT.ACT_ESTADO = 1
	 And ACT.AFL_ID = AFL.AFL_ID
	 And AFL.ESS_ID = 7
	 And CO1.COC_ID = @COC_ID
	Order by CO1.SOC_ID
   Open C1
    FETCH NEXT FROM C1 INTO @AFL_ID,@TRS_ID, @RESULTADO,@APROBADA,@RECHAZADA
   WHILE @@fetch_status = 0
   BEGIN
        IF @APROBADA = 'S' 
			Exec ApruebaActividadTramite @AFL_ID,  @TRS_ID, @RESULTADO,  @COC_ACTUALIZADO_POR,  @COC_FECHA_ACTUALIZA
		Else
		Begin
			 IF @RECHAZADA = 'S' 
			 Begin
				Exec RechazarActividadTramite @AFL_ID,  @TRS_ID, @RESULTADO,  @COC_ACTUALIZADO_POR,  @COC_FECHA_ACTUALIZA
			 End
		End		 
        FETCH NEXT FROM C1 INTO @AFL_ID,@TRS_ID, @RESULTADO,@APROBADA,@RECHAZADA
   END
   CLOSE C1
   DEALLOCATE C1
	-- Retorno los Datos de los Temas del Orden de Dia
	Select  * From COC_COMITE_CREDITO
	Where COC_ID = @COC_ID

END
