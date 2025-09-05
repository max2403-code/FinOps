namespace Inventory.Domain
{
    public class SupplierInfo
    {
        public required string CompanyName { get; set; }
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? TaxId { get; set; }

        public string? Website { get; set; }
        public string? BankDetails { get; set; }
        public string? Notes { get; set; }
    }
}
