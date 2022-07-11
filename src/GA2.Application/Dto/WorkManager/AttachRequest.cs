namespace GA2.Application.Dto
{
    public partial class AttachRequest
    {
        private string BarCodeField; // Número de radicado de WorkManager E.D. ®

        private bool CheckWorkflowField; //ATENCION

        private FileDto[] FilesField; // Objeto para enviar los datos de uno o varios archivos que se adicionaran al radicado de WorkManager E.D. ®

        private HeaderDto HeaderField; // Objeto para enviar los datos de autenticación para poder consumir el servicio

        private string OperationUserField; // Usuario del sistema que quedará registrado cómo autor de la carga del documento a un radicado en la base de datos

        [System.Runtime.Serialization.DataMember()]
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

        [System.Runtime.Serialization.DataMember()]
        public bool CheckWorkflow
        {
            get
            {
                return this.CheckWorkflowField;
            }
            set
            {
                this.CheckWorkflowField = value;
            }
        }

        [System.Runtime.Serialization.DataMember()]
        public FileDto[] Files
        {
            get
            {
                return this.FilesField;
            }
            set
            {
                this.FilesField = value;
            }
        }

        [System.Runtime.Serialization.DataMember()]
        public HeaderDto Header
        {
            get
            {
                return this.HeaderField;
            }
            set
            {
                this.HeaderField = value;
            }
        }

        [System.Runtime.Serialization.DataMember()]
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
