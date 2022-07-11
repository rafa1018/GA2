USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDatosReparto]    Script Date: 7/07/2021 12:51:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Nombre: ObtenerDatosReparto
Descripcion: Consulta Los Datos para la Generacion del Formato de Reparto
Elaboro: German Eduardo Guarnizo
Fecha: Junio 17 de 2021
*/
CREATE PROC [dbo].[ObtenerDatosReparto]
@SOC_ID uniqueidentifier

AS
Begin
	Declare @mMatricula varchar(12)
	Declare @mMatriculas varchar(50)

	Declare C1 Cursor For
		Select SJI_NUMERO_MATRICULA  From  SJI_SOLICITUD_INF_JUR_INM
		 Where SOC_ID = @SOC_ID
		 Order by SJI_AREA_PRIVADA desc 
    Open C1
    FETCH NEXT FROM C1 INTO @mMatricula
   WHILE @@fetch_status = 0
   Begin
			Set @mMatriculas = @mMatriculas + ' - ' + @mMatricula

			 FETCH NEXT FROM C1 INTO @mMatricula
   End
   CLOSE C1
   DEALLOCATE C1
   If @mMatriculas IS NULL
     Set @mMatriculas = '0 - 0 - 0'

	Select   COnvert(varchar(10),getdate(),111) as FECHA_REPARTO,
	            'CAJA PROMOTORA DE VIVIENDA MILITAR Y DE POLICIA' as COMPANIA, '860.021.967-7' as NIT_COMPANIA,
	             'EMPRESA INDUSTRIAL Y COMERCIAL DEL ESTADO DE CARÁCTER FINANCIERO' as NATURALEZA_COMPANIA,
				 NTR.NOT_DESCRIPCION as NOTARIA, DPC.DPC_NOMBRE as CIUDSD_NOTARIA,
				 Case When TCR_ID=1 Then 'COMPRAVENTA LEASING HABITACIONAL' Else 'COMPRAVENTA INMUEBLE' End ACTO,
				 CO1.COS_VALOR_CREDITO as VALOR_VENTA, SOP.SOP_DIRECCION_INMUEBLE as DIRECCION_INMUEBLE,
				 @mMatriculas as MATRICULAS,
				 SOB.SOB_NUMERO_DOCUMENTO as DOCUMENTO_CLIENTE, 
				 SOB.SOB_PRIMER_NOMBRE+' '+SOB.SOB_SEGUNDO_NOMBRE+' '+SOB.SOB_PRIMER_APELLIDO+' '+SOB.SOB_SEGUNDO_APELLIDO as NOMBRE_CLIENTE,
				 SOP.SOP_NUMERO_DOCUMENTO_VENDEDOR as DOCUMENTO_VENDEDOR,
				 SOP.SOP_NOMBRE_VENDEDOR as NOMBRE_VENDEDOR
	  From  SOC_SOLICITUD_CREDITO SOC With(NoLock),  NOT_NOTARIA NTR With(NoLock), DPC_CIUDAD DPC With(NoLock),
	           COS_COMITE_SOLICITUD_CREDITO CO1 With(NoLock), SOP_SOLICITUD_PRODUCTO SOP With(NoLock),
			   SOB_SOLICITUD_INF_BASICA SOB With(NoLock)
   Where SOC.SOC_ID = @SOC_ID
       And  SOC.NOT_ID = NTR.NOT_ID
	   And SOC.SOC_ID=CO1.SOC_ID
	   And SOC.SOC_ID = SOP.SOC_ID
	   And SOC.SOC_ID = SOB.SOC_ID
	   And NTR.DPD_ID=DPC.DPD_ID And NTR.DPC_ID=DPC.DPC_ID
	
End
