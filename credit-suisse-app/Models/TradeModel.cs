namespace credit_suisse_app.Models
{
    public class TradeModel
    {
        public DateTime referenceDate { get; set; }
        public int businessNumber { get; set; }
        public double value { get; set; }
        public string? clientSector { get; set; }
        public DateTime nextPaymentDate { get; set; }
        public string? category { get; set; }
    }
}