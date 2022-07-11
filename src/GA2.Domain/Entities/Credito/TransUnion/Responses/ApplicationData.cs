namespace GA2.Domain.Entities
{
    public class ApplicationData
    {
        public VelocityCheckReasons VelocityCheckReasons { get; set; }
        public string ReturnMessage { get; set; }
        public IDVReasonsCode IDVReasonsCode { get; set; }
        public OTPReasons OTPReasons { get; set; }
        public string RiskLevel { get; set; }
        public IDAReasons IDAReasons { get; set; }
        public IDMReasonsCode IDMReasonsCode { get; set; }
        public string IDMOutcome { get; set; }
        public string Product { get; set; }
    }
}