using System.ComponentModel.DataAnnotations;

namespace RetailCloud.Api.Dtos
{
    public class UserDto : BaseEntityDto
    {
        public RoleDto RoleDto { get; set; }
        public long RoleId { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Patronymic { get; set; }
        [Required] public string Inn { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}