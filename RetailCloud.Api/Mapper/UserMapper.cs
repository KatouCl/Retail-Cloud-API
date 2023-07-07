using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class UserMapper
    {
        public static User mapToUser(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                DateChange = userDto.DateChange,
                DateCreate = userDto.DateCreate,
                IsDeleted = userDto.IsDeleted,
                Role = userDto.RoleDto.mapToRole(),
                Password = userDto.Password,
                Surname = userDto.Surname,
                Name = userDto.Name,
                Patronymic = userDto.Patronymic,
                Inn = userDto.Inn,
                Telephone = userDto.Telephone,
                Email = userDto.Email,
            };
        }

        public static UserDto mapToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                DateChange = user.DateChange,
                DateCreate = user.DateCreate,
                IsDeleted = user.IsDeleted,
                RoleDto = user.Role.mapToRoleDto(),
                Password = user.Password,
                Surname = user.Surname,
                Name = user.Name,
                Patronymic = user.Patronymic,
                Inn = user.Inn,
                Telephone = user.Telephone,
                Email = user.Email,
            };
        }
    }
}