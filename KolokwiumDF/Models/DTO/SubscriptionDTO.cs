namespace KolokwiumDF.Models.DTO
{
    public class SubscriptionDTO
    {
        public int IdSubscription { get; set; }
        public string Name { get; set; } = null!;

        public int RenewalPeriod { get; set; }
        public int TotalPaidAmount { get; set; }
    }
}
