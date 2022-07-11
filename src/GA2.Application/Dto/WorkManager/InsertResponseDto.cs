using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class InsertResponseDto
    {
        private string BarCodeField;

        private string[] FileCodesField;

        private string MessageField;

        private long RecordIdField;

        private bool SuccessField;

        private long workflowIdField;

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
        public string[] FileCodes
        {
            get
            {
                return this.FileCodesField;
            }
            set
            {
                this.FileCodesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long RecordId
        {
            get
            {
                return this.RecordIdField;
            }
            set
            {
                this.RecordIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success
        {
            get
            {
                return this.SuccessField;
            }
            set
            {
                this.SuccessField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long workflowId
        {
            get
            {
                return this.workflowIdField;
            }
            set
            {
                this.workflowIdField = value;
            }
        }
    }
}
