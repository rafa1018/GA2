namespace GA2.Application.Dto
{
    public partial class UpdateRequest
    {

        public DictionaryDto[] DataField; // Diccionario o colección de valores tipo “Key – Value” con los datos que se actualizarán en el formulario.La parte “Key” del diccionario corresponde al nombre del campo en el formulario y la parte “value” corresponde al valor del mismo.

        public FilterParametersDto FilterParametersField; // Objeto para enviar los datos del filtro de búsqueda para modificar o actualizar radicados.

        public string FormCodeField; // Código del formulario. 

        public HeaderDto HeaderField; // Objeto para enviar los datos de autenticación para poder consumir el servicio.

        public string OperationUserField; // Usuario del sistema que quedará registrado cómo autor de la modificación o actualización del registro en la base de datos

        [System.Runtime.Serialization.DataMember()]
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
        public FilterParametersDto FilterParameters
        {
            get
            {
                return this.FilterParametersField;
            }
            set
            {
                this.FilterParametersField = value;
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

    public class HeaderDto
    {
        public string TokenField;

        public string UserField;

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

    public class FilterParametersDto
    {
        public string FieldField;

        public string OperatorField;

        public string ValueField;

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
        public string Operator
        {
            get
            {
                return this.OperatorField;
            }
            set
            {
                this.OperatorField = value;
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

    public class DictionaryDto
    {
        public string FieldField;

        public string KeyField;

        public string ValueField;

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
}
