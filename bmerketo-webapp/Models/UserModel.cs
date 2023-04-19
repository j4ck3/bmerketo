using bmerketo_webapp.Models.Entities;

namespace bmerketo_webapp.Models
{
    public class UserModel
    {
        public string Id { get; set; } = null!;
        public IList<string>? Roles { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Company { get; set; }
        public AddressEntity? Address { get; set; }
    }
}
