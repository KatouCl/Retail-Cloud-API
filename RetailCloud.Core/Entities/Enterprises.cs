namespace RetailCloud.Core.Entities
{
    public class Enterprises : BaseEntity
    {
        public Organization Organization { get; set; }
        public string Name { get; set; }
        public string Kpp { get; set; }
        public string FsrarId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
    }
}