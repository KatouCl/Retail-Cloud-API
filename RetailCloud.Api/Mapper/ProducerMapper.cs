using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class ProducerMapper
    {
        public static Producer mapToProducer(this ProducerDto producerDto)
        {
            return new Producer
            {
                Id = producerDto.Id,
                DateChange = producerDto.DateCreate,
                DateCreate = producerDto.DateCreate,
                IsDeleted = producerDto.IsDeleted,
                OrganizationType = producerDto.OrganizationType,
                TaxIndexType = producerDto.TaxIndexType,
                Inn = producerDto.Inn,
                Kpp = producerDto.Kpp,
                FsrarId = producerDto.FsrarId,
                ShortName = producerDto.ShortName,
                FullName = producerDto.FullName,
                Country = producerDto.Country,
                RegionCode = producerDto.RegionCode,
                Telephone = producerDto.Telephone,
                Email = producerDto.Email,
                Description = producerDto.Description
            };
        }

        public static ProducerDto mapToProducerDto(this Producer producer)
        {
            return new ProducerDto
            {
                Id = producer.Id,
                DateChange = producer.DateCreate,
                DateCreate = producer.DateCreate,
                IsDeleted = producer.IsDeleted,
                OrganizationType = producer.OrganizationType,
                TaxIndexType = producer.TaxIndexType,
                Inn = producer.Inn,
                Kpp = producer.Kpp,
                FsrarId = producer.FsrarId,
                ShortName = producer.ShortName,
                FullName = producer.FullName,
                Country = producer.Country,
                RegionCode = producer.RegionCode,
                Telephone = producer.Telephone,
                Email = producer.Email,
                Description = producer.Description
            };
        }
    }
}