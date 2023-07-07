using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class UnitsMapper
    {
        public static Units mapToUnits(this UnitsDto units)
        {
            return new Units
            {
                Id = units.Id,
                DateChange = units.DateChange,
                DateCreate = units.DateCreate,
                IsDeleted = units.IsDeleted,
                UserCreated = units.UserCreated.mapToUser(),
                Name = units.Name
            };
        }

        public static UnitsDto mapToUnitsDto(this Units units)
        {
            return new UnitsDto
            {
                Id = units.Id,
                DateChange = units.DateChange,
                DateCreate = units.DateCreate,
                IsDeleted = units.IsDeleted,
                UserCreated = units.UserCreated.mapToUserDto(),
                Name = units.Name
            };
        }
    }
}