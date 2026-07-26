namespace NexusERP.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
