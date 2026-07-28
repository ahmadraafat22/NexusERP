namespace NexusERP.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
