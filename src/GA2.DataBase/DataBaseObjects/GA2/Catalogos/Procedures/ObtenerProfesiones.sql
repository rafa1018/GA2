/*
Nombre: ObtenerProfesiones
Descripcion: Obteniene profesiones que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].ObtenerProfesiones
as
	SELECT PRF_ID, PRF_DESCRIPCION, PRF_ESTADO, PRF_CREADO_POR, PRF_FECHA_CREACION, PRF_ACTUALIZADO_POR, PRF_FECHA_ACTUALIZA
FROM GA2.dbo.PRF_PROFESION