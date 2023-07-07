using RetailCloud.Core.Entities.Enums;

namespace RetailCloud.Core.Entities
{
    public class GroupProduct : BaseEntity
    {
        public User UserCreated { get; set; }
        public ProductType ProductType { get; set; }
        public string Name { get; set; }
        public bool IsMarked { get; set; }
    }
}