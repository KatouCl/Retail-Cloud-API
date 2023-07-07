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
using RetailCloud.Core.Specifications.Enterprises;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterprisesController : Controller
    {
        private readonly IBaseRepository<Enterprises> _enterprisesRepository;
        private readonly IBaseRepository<Organization> _organizationRepository;

        public EnterprisesController(IBaseRepository<Enterprises> enterprisesRepository,
            IBaseRepository<Organization> organizationRepository)
        {
            _enterprisesRepository = enterprisesRepository;
            _organizationRepository = organizationRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<EnterprisesDto>>> Get([FromQuery] EnterprisesSpecParams param)
        {
            var spec = new EnterprisesWithSpecOrg(param);
            var total = await _enterprisesRepository.CountAsync(spec);
            var enterprisesEntity = await _enterprisesRepository.ListAsync(spec);

            var data = enterprisesEntity.Select(enterprises => enterprises.mapToEnterprisesDto()).ToList();
            return Ok(
                new Pagination<EnterprisesDto>(
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
        public async Task<ActionResult<EnterprisesDto>> GetById([FromQuery] long id)
        {
            var spec = new EnterprisesWithSpecOrg(id);
            var enterprises = await _enterprisesRepository.GetEntityWithSpec(spec);
            if (enterprises is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти точку с ID: {id}"));

            var enterprisesDto = enterprises.mapToEnterprisesDto();
            return Ok(enterprisesDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EnterprisesDto>> Create([FromBody] EnterprisesDto enterprisesDto)
        {
            var organization = await _organizationRepository.GetByIdAsync(enterprisesDto.OrganizationId);
            if (organization is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти организацию с ID: {enterprisesDto.OrganizationId}"));

            var organizationDto = organization.mapToOrganizationDto();
            enterprisesDto.OrganizationDto = organizationDto;

            var enterprises = enterprisesDto.mapToEnterprises();

            var resultEmail = EmailValidate.execute(enterprises.Email);
            var resultKpp = KppValidate.execute(enterprises.Kpp);

            var hasError = new List<ResultValidation>
                {resultEmail, resultKpp}.Any(x => !x.Successful);
            if (hasError)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, "Перепроверьте поля: Email, КПП"));

            var resultCreate = await _enterprisesRepository.AddAsync(enterprises);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EnterprisesDto>> Update([FromBody] EnterprisesDto enterprisesDto)
        {
            if (enterprisesDto.Id == 0 && enterprisesDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var organization = await _organizationRepository.GetByIdAsync(enterprisesDto.OrganizationId);
            if (organization is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти организацию с ID: {enterprisesDto.OrganizationId}"));

            var enterprises = enterprisesDto.mapToEnterprises();

            var resultEmail = EmailValidate.execute(enterprises.Email);
            var resultKpp = KppValidate.execute(enterprises.Kpp);

            var hasError = new List<ResultValidation>
                {resultEmail, resultKpp}.Any(x => !x.Successful);
            if (hasError)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, "Перепроверьте поля: Email, КПП"));

            try
            {
                await _enterprisesRepository.UpdateAsync(enterprises);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {enterprises.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {enterprises.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EnterprisesDto>> Delete([FromQuery] long id)
        {
            var enterprises = await _enterprisesRepository.GetByIdAsync(id);
            if (enterprises is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти организацию с ID: {id}"));

            enterprises.IsDeleted = true;
            try
            {
                await _enterprisesRepository.UpdateAsync(enterprises);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {enterprises.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {enterprises.Id}"));
            }
        }
        
    }
}