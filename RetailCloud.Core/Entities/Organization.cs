namespace RetailCloud.Core.Entities
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization : BaseEntity
    {
        public Type Type { get; set; }
        public string Inn { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }

    public enum Type
    {
        /// <summary>
        /// Неизвестный тип
        /// </summary>
        NONE = 0,
        OP = 1,
        OOO = 2
    }
}