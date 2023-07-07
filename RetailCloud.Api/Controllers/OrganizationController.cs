using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailCloud.Api.Dtos;
using RetailCloud.Api.Errors;
using RetailCloud.Api.Helpers;
using RetailCloud.Api.Mapper;
using RetailCloud.Api.Utils.Validate;
using RetailCloud.Core.Entities;
using RetailCloud.Core.Interfaces;
using RetailCloud.Core.Specifications.Organization;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : Controller
    {
        private readonly IBaseRepository<Organization> _organizationRepository;

        public OrganizationController(IBaseRepository<Organization> organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<OrganizationDto>>> Get(
            [FromQuery] OrganizationSpecParams param)
        {
            var spec = new OrganizationWithSpec(param);
            var total = await _organizationRepository.CountAsync(spec);
            var organizations = await _organizationRepository.ListAsync(spec);
            var data = organizations.Select(organization => organization.mapToOrganizationDto()).ToList();
            return Ok(
                new Pagination<OrganizationDto>(
                    page: param.Page,
                    pageSize: param.PageSize,
                    count: data.Count,
                    total: total,
                    data: data
                ));
        }

        [HttpGet(nameof(GetById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrganizationDto>> GetById([FromQuery] long id)
        {
            var spec = new OrganizationWithSpec(id);
            var organization = await _organizationRepository.GetEntityWithSpec(spec);
            if (organization is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти организацию с ID: {id}"));

            var organizationDto = organization.mapToOrganizationDto();
            return Ok(organizationDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrganizationDto>> Create([FromBody] OrganizationDto organizationDto)
        {
            var organization = organizationDto.mapToOrganization();

            var validateEmail = EmailValidate.execute(organization.Email);
            var validateInn = InnValidate.execute(organization.Inn);

            var hasError = new List<ResultValidation>
                {validateEmail, validateInn}.Any(x => !x.Successful);
            if (hasError)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, "Перепроверьте поля: email, inn"));

            var resultCreate = await _organizationRepository.AddAsync(organization);

            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrganizationDto>> Update([FromBody] OrganizationDto organizationDto)
        {
            if (organizationDto.Id == 0 && organizationDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var organization = organizationDto.mapToOrganization();

            var validateEmail = EmailValidate.execute(organization.Email);
            var validateInn = InnValidate.execute(organization.Inn);

            var hasError = new List<ResultValidation>
                {validateEmail, validateInn}.Any(x => !x.Successful);
            if (hasError)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, "Перепроверьте поля: email, inn"));

            try
            {
                await _organizationRepository.UpdateAsync(organization);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {organization.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {organization.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrganizationDto>> Delete([FromQuery] long id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id);
            if (organization is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти организацию с ID: {id}"));

            organization.IsDeleted = true;
            try
            {
                await _organizationRepository.UpdateAsync(organization);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {organization.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {organization.Id}"));
            }
        }
        
    }
}