namespace GA2.Application.Dto
{
    public partial class QueryRequest
    {

        private string FormCodeField; // Código del formulario. 

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
    }
}
