namespace RetailCloud.Core.Entities
{
    public class User : BaseEntity
    {
        public Role Role { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Inn { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}