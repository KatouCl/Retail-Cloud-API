using RetailCloud.Core.Entities.Enums;

namespace RetailCloud.Core.Entities
{
    public class Product : BaseEntity
    {
        public GroupProduct GroupProduct { get; set; }
        public User UserCreated { get; set; }
        public Units Units { get; set; }
        public Producer Producer { get; set; }
        public TaxIndexType TaxIndexType { get; set; }
        public ItemType ItemType { get; set; }
        public string Name { get; set; }
        public string PrintName { get; set; }
        public string? Artikul { get; set; }
    }
}