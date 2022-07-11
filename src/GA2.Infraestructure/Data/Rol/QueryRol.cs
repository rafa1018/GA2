namespace GA2.Infraestructure.Data
{
    public class QueryRol
    {
        public const string QueryInsert = @"INSERT INTO ROL(ID, DESCRIPTION,CREATEON,CREATEBY,MODIFIEDBY,MODIFIEDON,STATE) 
                                    VALUES (@ID, @DESCRIPTION,@CREATEON,@CREATEBY,@MODIFIEDBY,@MODIFIEDON,@STATE);" + QueryGetById;

        public const string QueryGet = @"SELECT ID, DESCRIPTION,CREATEON,CREATEBY,MODIFIEDBY,MODIFIEDON,STATE FROM ROL ORDER BY CREATEON DESC";

        public const string QueryGetById = @"SELECT ID, DESCRIPTION,CREATEON,CREATEBY,MODIFIEDBY,MODIFIEDON,STATE FROM ROL WHERE ID=@ID";

        public const string QueryUpdate = @"UPDATE ROL Rol
                            SET DESCRIPTION= @DESCRIPTION,MODIFIEDBY=@MODIFIEDBY,MODIFIEDON=@MODIFIEDON,STATE=@STATE 
                            WHERE Rol.ID= @ID;" + QueryGetById;

        public const string QueryDelete = @"UPDATE ROL Rol
                            SET STATE=@STATE 
                            WHERE Rol.ID= @ID;" + QueryGetById;
    }
}
