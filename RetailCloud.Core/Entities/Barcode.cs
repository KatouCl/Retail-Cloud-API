namespace RetailCloud.Core.Entities
{
    public class Barcode : BaseEntity
    {
        public Product Product { get; set; }
        public User UserCreated { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
    }
}