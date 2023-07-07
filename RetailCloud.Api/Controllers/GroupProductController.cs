using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailCloud.Api.Dtos;
using RetailCloud.Api.Errors;
using RetailCloud.Api.Helpers;
using RetailCloud.Api.Mapper;
using RetailCloud.Core.Entities;
using RetailCloud.Core.Interfaces;
using RetailCloud.Core.Specifications.GroupProduct;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupProductController : Controller
    {
        private readonly IBaseRepository<GroupProduct> _groupProductRepository;

        public GroupProductController(IBaseRepository<GroupProduct> groupProductRepository)
        {
            _groupProductRepository = groupProductRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<GroupProductDto>>> Get([FromQuery] GroupProductSpecParams param)
        {
            var spec = new GroupProductWithSpec(param);
            var total = await _groupProductRepository.CountAsync(spec);
            var groupProductEntity = await _groupProductRepository.ListAsync(spec);

            var data = groupProductEntity.Select(groupProduct => groupProduct.mapToGroupProductDto()).ToList();
            return Ok(
                new Pagination<GroupProductDto>(
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
        public async Task<ActionResult<GroupProductDto>> GetById([FromQuery] long id)
        {
            var spec = new GroupProductWithSpec(id);
            var groupProductEntity = await _groupProductRepository.GetEntityWithSpec(spec);
            if (groupProductEntity is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти группу товаров с ID: {id}"));

            var groupProductDto = groupProductEntity.mapToGroupProductDto();
            return Ok(groupProductDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GroupProductDto>> Create([FromBody] GroupProductDto groupProductDto)
        {
            var groupProduct = groupProductDto.mapToGroupProduct();

            var resultCreate = await _groupProductRepository.AddAsync(groupProduct);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GroupProductDto>> Update([FromBody] GroupProductDto groupProductDto)
        {
            if (groupProductDto.Id == 0 && groupProductDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var groupProduct = groupProductDto.mapToGroupProduct();
            try
            {
                await _groupProductRepository.UpdateAsync(groupProduct);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {groupProduct.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {groupProduct.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GroupProductDto>> Delete([FromQuery] long id)
        {
            var groupProduct = await _groupProductRepository.GetByIdAsync(id);
            if (groupProduct is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти группу товаров с ID: {id}"));

            groupProduct.IsDeleted = true;
            try
            {
                await _groupProductRepository.UpdateAsync(groupProduct);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {groupProduct.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {groupProduct.Id}"));
            }
        }
    }
}