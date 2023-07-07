using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class OrganizationMapper
    {
        public static Organization mapToOrganization(this OrganizationDto organizationDto)
        {
            return new Organization
            {
                Id = organizationDto.Id,
                DateChange = organizationDto.DateChange,
                DateCreate = organizationDto.DateCreate,
                IsDeleted = organizationDto.IsDeleted,
                Description = organizationDto.Description,
                Email = organizationDto.Email,
                Inn = organizationDto.Inn,
                Name = organizationDto.Name,
                Telephone = organizationDto.Telephone,
                Type = organizationDto.Type,
            };
        }

        public static OrganizationDto mapToOrganizationDto(this Organization organization)
        {
            return new OrganizationDto
            {
                Id = organization.Id,
                DateChange = organization.DateChange,
                DateCreate = organization.DateCreate,
                IsDeleted = organization.IsDeleted,
                Description = organization.Description,
                Email = organization.Email,
                Inn = organization.Inn,
                Name = organization.Name,
                Telephone = organization.Telephone,
                Type = organization.Type,
            };
        }
    }
}