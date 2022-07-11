namespace GA2.Application.Dto
{
    public partial class StringFileRequest
    {

        private string FileCodeField; // Código del archivo almacenado en WorkManager E.D. ®.

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileCode
        {
            get
            {
                return this.FileCodeField;
            }
            set
            {
                this.FileCodeField = value;
            }
        }
    }
}
