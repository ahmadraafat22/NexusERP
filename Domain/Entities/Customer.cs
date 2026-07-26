namespace NexusERP.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
