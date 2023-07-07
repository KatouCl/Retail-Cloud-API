namespace RetailCloud.Core.Entities
{
    public class SalesJournalPosition : BaseEntity
    {
        public Product Product { get; set; }
        public SalesJournal SalesJournal { get; set; }
        /// <summary>
        /// Реализация товаров по свободной цене
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// CIS - марка. DataMatrix без криптохвоста служит для того чтобы нельзя продать уже проданный маркированный товар
        /// </summary>
        public string? Cis { get; set; }

        public long Price { get; set; }
        public double Quantity { get; set; }
    }
}