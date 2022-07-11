namespace GA2.Application.Dto
{
    public partial class DeleteRequest
    {

        private string FormCodeField; // Código del formulario

        private string OperationUserField; // Usuario del sistema que quedará registrado cómo autor de la eliminación del registro en la base de datos.

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FormCode
        {
            get
            {
                return this.FormCodeField;
            }
            set
            {
                this.FormCodeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperationUser
        {
            get
            {
                return this.OperationUserField;
            }
            set
            {
                this.OperationUserField = value;
            }
        }
    }
}
