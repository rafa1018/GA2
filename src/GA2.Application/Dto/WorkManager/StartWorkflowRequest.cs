namespace GA2.Application.Dto
{
    public partial class StartWorkflowRequest
    {

        private string BarCodeField; // Número de radicado WorkManager E.D. ®

        private string NextStepUserField; // Usuario al que se le asigna la tarea una vez inicia el flujo de trabajo.

        private string OperationUserField; // Usuario del sistema que quedará registrado cómo la persona que inició el flujo de trabajo

        private long ProcessIdField; // Id del proceso a iniciar en WorkManager E.D.®., recordar que el proceso debe estar asociado al formulario y su estado debe ser “Producción”.

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
        public string NextStepUser
        {
            get
            {
                return this.NextStepUserField;
            }
            set
            {
                this.NextStepUserField = value;
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ProcessId
        {
            get
            {
                return this.ProcessIdField;
            }
            set
            {
                this.ProcessIdField = value;
            }
        }
    }
}
