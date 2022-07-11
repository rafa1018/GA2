namespace GA2.Application.Dto
{
    public partial class ListRequest
    {

        private System.Nullable<long> FatherItemIdField; // Identificador (Id) de ítem lista padre WorkManager E.D. ®.

        private long ListIdField; // Identificador (Id) de lista WorkManager E.D. ®. 

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> FatherItemId
        {
            get
            {
                return this.FatherItemIdField;
            }
            set
            {
                this.FatherItemIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ListId
        {
            get
            {
                return this.ListIdField;
            }
            set
            {
                this.ListIdField = value;
            }
        }
    }
}
