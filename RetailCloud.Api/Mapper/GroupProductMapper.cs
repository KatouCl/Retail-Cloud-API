using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class GroupProductMapper
    {
        public static GroupProduct mapToGroupProduct(this GroupProductDto groupProductDto)
        {
            return new GroupProduct
            {
                Id = groupProductDto.Id,
                DateChange = groupProductDto.DateChange,
                DateCreate = groupProductDto.DateCreate,
                IsDeleted = groupProductDto.IsDeleted,
                UserCreated = groupProductDto.UserCreated.mapToUser(),
                ProductType = groupProductDto.ProductType,
                Name = groupProductDto.Name,
                IsMarked = groupProductDto.IsMarked
            };
        }

        public static GroupProductDto mapToGroupProductDto(this GroupProduct groupProduct)
        {
            return new GroupProductDto
            {
                Id = groupProduct.Id,
                DateChange = groupProduct.DateChange,
                DateCreate = groupProduct.DateCreate,
                IsDeleted = groupProduct.IsDeleted,
                UserCreated = groupProduct.UserCreated.mapToUserDto(),
                ProductType = groupProduct.ProductType,
                Name = groupProduct.Name,
                IsMarked = groupProduct.IsMarked
            };
        }
    }
}