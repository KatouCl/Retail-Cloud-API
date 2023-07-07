using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class EnterprisesMapper
    {
        public static Enterprises mapToEnterprises(this EnterprisesDto enterprisesDto)
        {
            return new Enterprises
            {
                Id = enterprisesDto.Id,
                DateChange = enterprisesDto.DateCreate,
                DateCreate = enterprisesDto.DateCreate,
                IsDeleted = enterprisesDto.IsDeleted,
                Organization = enterprisesDto.OrganizationDto.mapToOrganization(),
                Name = enterprisesDto.Name,
                Kpp = enterprisesDto.Kpp,
                FsrarId = enterprisesDto.FsrarId,
                ShortName = enterprisesDto.ShortName,
                FullName = enterprisesDto.FullName,
                Address = enterprisesDto.Address,
                Telephone = enterprisesDto.Telephone,
                Email = enterprisesDto.Email,
                Description = enterprisesDto.Description
            };
        }

        public static EnterprisesDto mapToEnterprisesDto(this Enterprises enterprises)
        {
            return new EnterprisesDto
            {
                Id = enterprises.Id,
                DateChange = enterprises.DateChange,
                DateCreate = enterprises.DateCreate,
                IsDeleted = enterprises.IsDeleted,
                OrganizationDto = enterprises.Organization.mapToOrganizationDto(),
                OrganizationId = enterprises.Organization.Id,
                Name = enterprises.Name,
                Kpp = enterprises.Kpp,
                FsrarId = enterprises.FsrarId,
                ShortName = enterprises.ShortName,
                FullName = enterprises.FullName,
                Address = enterprises.Address,
                Telephone = enterprises.Telephone,
                Email = enterprises.Email,
                Description = enterprises.Description
            };
        }
    }
}