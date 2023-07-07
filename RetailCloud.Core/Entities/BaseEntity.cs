using System;

namespace RetailCloud.Core.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateChange { get; set; }
        public bool IsDeleted { get; set; }

        protected BaseEntity()
        {
            DateCreate = DateTime.Now;
        }
    }
}