namespace GA2.Application.Dto
{
    public partial class FileRequest
    {

        private string BarCodeField; // Numero de radicado WorkManager E.D.

        private string DirectoryCodeField; // Código del directorio, se identifica desde WorkManager E.D. ®

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BarCode
        {
            get
            {
                return this.BarCodeField;
            }
            set
            {
                this.BarCodeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DirectoryCode
        {
            get
            {
                return this.DirectoryCodeField;
            }
            set
            {
                this.DirectoryCodeField = value;
            }
        }
    }
}
