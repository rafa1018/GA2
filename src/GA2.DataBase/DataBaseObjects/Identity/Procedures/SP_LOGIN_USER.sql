﻿-- =============================================
-- Author:		Oscar Julian Rojas
-- Create date: 24/04/2021
-- Description:	SP para la validacion de usuario
-- =============================================
CREATE PROCEDURE [dbo].[LoginUser]
@USR_EMAIL nvarchar(150),
@USR_USERNAME nvarchar(150),
@USR_PASSWORD nvarchar(150)
AS 
BEGIN
SELECT USR_ID, USR_NOMBRE, USR_SEGUNDONOMBRE, USR_APELLIDO, USR_SEGUNDOAPELLIDO, USR_USERNAME, USR_PASSWORD, USR_IDENTIFICACION, TID_ID, USR_EMAIL, ROLID, USR_MODIFICADOPOR, USR_FECHAMODIFICACION, USR_CREADOPOR, USR_FECHACREACION, USR_ESTADO
FROM GA2.dbo.USR_USERS
WHERE
USR_USERNAME=@USR_USERNAME OR
USR_EMAIL = @USR_EMAIL AND
USR_PASSWORD= @USR_PASSWORD 
END;
