namespace GA2.Application.Dto
{
    public partial class RunTaskRequest
    {

        private string BarCodeField; // Número de radicado WorkManager E.D. ®.

        private string CommentField; // Comentario Asociado a la tarea que se va a cumplir en WorkManager E.D. ®.

        private string NextStepUserField; // Usuario al que se le asigna la tarea una vez cumple el paso en el flujo de trabajo

        private System.Nullable<int> ProcessIdField; // Identificador (Id) del proceso a iniciar en WorkManager E.D. ®., recordar que el proceso debe estar asociado al formulario y su estado debe ser “Producción”

        private int StepField; // Paso Actual del WorkFlow WorkManager E.D.®.

        private System.Nullable<long> WorkflowIdField; // Identificador (Id) WorkFlow WorkManager E.D.®.

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
        public string Comment
        {
            get
            {
                return this.CommentField;
            }
            set
            {
                this.CommentField = value;
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
        public System.Nullable<int> ProcessId
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Step
        {
            get
            {
                return this.StepField;
            }
            set
            {
                this.StepField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> WorkflowId
        {
            get
            {
                return this.WorkflowIdField;
            }
            set
            {
                this.WorkflowIdField = value;
            }
        }
    }
}
