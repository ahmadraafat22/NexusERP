namespace NexusERP.Application.Features.Customers.Queries.GetById
{
    public class GetCustomerDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
