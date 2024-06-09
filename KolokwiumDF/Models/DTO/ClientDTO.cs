namespace KolokwiumDF.Models.DTO
{
    public class ClientDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public int? Value { get; set; }

        public IEnumerable<SubscriptionDTO> Subscriptions { get; set; } = new List<SubscriptionDTO>();

    }
}
