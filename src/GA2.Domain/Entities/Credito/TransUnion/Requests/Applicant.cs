namespace GA2.Domain.Entities
{
    public class Applicant
    {
        public int IdType { get; set; }
        public string IdNumber { get; set; }
        public string LastName { get; set; }
        public string RecentPhoneNumber { get; set; }
        public string IdExpeditionDate { get; set; }
        public string Occupation { get; set; }
        public string MonthlyIncome { get; set; }
        public string CuotaTDCTU1 { get; set; }
        public string CuotaRotativaTU1 { get; set; }
        public string CuotaResto { get; set; }
        public string Score { get; set; }
        public string CapacidadEndeudamiento { get; set; }
    }
}
