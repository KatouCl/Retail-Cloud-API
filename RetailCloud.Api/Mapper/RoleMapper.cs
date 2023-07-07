using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class RoleMapper
    {
        public static Role mapToRole(this RoleDto roleDto)
        {
            return new Role
            {
                Id = roleDto.Id,
                DateChange = roleDto.DateChange,
                DateCreate = roleDto.DateCreate,
                IsDeleted = roleDto.IsDeleted,
                Name = roleDto.Name,
            };
        }

        public static RoleDto mapToRoleDto(this Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                DateChange = role.DateChange,
                DateCreate = role.DateCreate,
                IsDeleted = role.IsDeleted,
                Name = role.Name,
            };
        }
    }
}