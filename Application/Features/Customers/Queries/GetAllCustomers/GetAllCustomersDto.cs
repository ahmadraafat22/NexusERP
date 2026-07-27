namespace NexusERP.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
