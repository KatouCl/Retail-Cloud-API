namespace RetailCloud.Core.Entities
{
    public class Units : BaseEntity
    {
        public User UserCreated { get; set; }
        public string Name { get; set; }
    }
}