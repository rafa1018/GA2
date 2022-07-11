IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'BUAAZURELOGIN')
BEGIN
	DROP USER BUAAZURELOGIN
	DROP LOGIN BUAAZURELOGIN
END


CREATE LOGIN BUAAZURELOGIN WITH PASSWORD = 'r434565_reqewrtyui_kJHGFDSDS_bcvNBVCX'
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'BUAAZURELOGIN')
BEGIN
    CREATE USER BUAAZURELOGIN FOR LOGIN BUAAZURELOGIN
    EXEC sp_addrolemember N'db_owner', N'BUAAZURELOGIN'
	GRANT SELECT,UPDATE,INSERT,DELETE,EXECUTE ON SCHEMA::dbo TO BUAAZURELOGIN;
END;
GO