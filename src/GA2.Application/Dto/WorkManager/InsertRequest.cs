namespace GA2.Application.Dto
{
    public partial class InsertRequest
    {
        private bool CheckWorkflowField;

        private DictionaryDto[] DataField;

        private FileDto[] FilesField;

        private string FormCodeField;

        private HeaderDto HeaderField;

        private string OfficeCodeField;

        private string OperationUserField;

        private System.Nullable<long> ProcessIdField;

        private string nextStepUserField;

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public DictionaryDto[] Data
        {
            get
            {
                return this.DataField;
            }
            set
            {
                this.DataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OfficeCode
        {
            get
            {
                return this.OfficeCodeField;
            }
            set
            {
                this.OfficeCodeField = value;
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
        public System.Nullable<long> ProcessId
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
        public string nextStepUser
        {
            get
            {
                return this.nextStepUserField;
            }
            set
            {
                this.nextStepUserField = value;
            }
        }

        public class DictionaryDto
        {
            private string FieldField;

            private string KeyField;

            private string ValueField;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Field
            {
                get
                {
                    return this.FieldField;
                }
                set
                {
                    this.FieldField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Key
            {
                get
                {
                    return this.KeyField;
                }
                set
                {
                    this.KeyField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Value
            {
                get
                {
                    return this.ValueField;
                }
                set
                {
                    this.ValueField = value;
                }
            }
        }
        public class FileDto
        {
            private string Base64StringField;

            private string DescriptionField;

            private string DirectoryCodeField;

            private string DocumentTypeCodeField;

            private string ExtField;

            private string GUIDField;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Base64String
            {
                get
                {
                    return this.Base64StringField;
                }
                set
                {
                    this.Base64StringField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Description
            {
                get
                {
                    return this.DescriptionField;
                }
                set
                {
                    this.DescriptionField = value;
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

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string DocumentTypeCode
            {
                get
                {
                    return this.DocumentTypeCodeField;
                }
                set
                {
                    this.DocumentTypeCodeField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Ext
            {
                get
                {
                    return this.ExtField;
                }
                set
                {
                    this.ExtField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string GUID
            {
                get
                {
                    return this.GUIDField;
                }
                set
                {
                    this.GUIDField = value;
                }
            }
        }

        public class HeaderDto
        {
            private string TokenField;

            private string UserField;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Token
            {
                get
                {
                    return this.TokenField;
                }
                set
                {
                    this.TokenField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string User
            {
                get
                {
                    return this.UserField;
                }
                set
                {
                    this.UserField = value;
                }
            }
        }
    }
}
