using System;
using System.ComponentModel.DataAnnotations;

namespace RetailCloud.Api.Dtos
{
    public class BaseEntityDto
    {
        [Required] public long Id { get; set; }
        [Required] public DateTime DateCreate { get; set; }
        [Required] public DateTime DateChange { get; set; }
        [Required] public bool IsDeleted { get; set; }

        protected BaseEntityDto()
        {
            DateCreate = DateTime.Now;
        }
    }
}