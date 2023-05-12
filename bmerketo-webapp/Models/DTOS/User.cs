using bmerketo_webapp.Models.Entities;

namespace bmerketo_webapp.Models.DTOS
{
    public class User
    {
        public string Id { get; set; } = null!;
        public IList<string>? Roles { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public AddressEntity? Address { get; set; }
    }
}
