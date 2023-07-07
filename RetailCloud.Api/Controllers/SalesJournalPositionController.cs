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
using RetailCloud.Core.Specifications.Role;
using RetailCloud.Core.Specifications.SalesJournalPosition;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesJournalPositionController : Controller
    {
        private readonly IBaseRepository<SalesJournalPosition> _salesJournalPositionRepository;

        public SalesJournalPositionController(IBaseRepository<SalesJournalPosition> salesJournalPositionRepository)
        {
            _salesJournalPositionRepository = salesJournalPositionRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<SalesJournalPositionDto>>> Get(
            [FromQuery] SalesJournalPositionSpecParams param)
        {
            var spec = new SalesJournalPositionWithSpec(param);
            var total = await _salesJournalPositionRepository.CountAsync(spec);
            var salesJournalPositionEntity = await _salesJournalPositionRepository.ListAsync(spec);

            var data = salesJournalPositionEntity.Select(salesJournalPositionEntity =>
                salesJournalPositionEntity.mapToSalesJournalPositionDto()).ToList();
            return Ok(
                new Pagination<SalesJournalPositionDto>(
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
        public async Task<ActionResult<SalesJournalPositionDto>> GetById([FromQuery] long id)
        {
            var spec = new SalesJournalPositionWithSpec(id);
            var salesJournalPosition = await _salesJournalPositionRepository.GetEntityWithSpec(spec);
            if (salesJournalPosition is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти детали журнала продаж с ID: {id}"));

            var salesJournalPositionDto = salesJournalPosition.mapToSalesJournalPositionDto();
            return Ok(salesJournalPositionDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesJournalPositionDto>> Create(
            [FromBody] SalesJournalPositionDto salesJournalPositionDto)
        {
            var salesJournalPosition = salesJournalPositionDto.mapToSalesJournalPosition();

            var resultCreate = await _salesJournalPositionRepository.AddAsync(salesJournalPosition);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesJournalPositionDto>> Update(
            [FromBody] SalesJournalPositionDto salesJournalPositionDto)
        {
            if (salesJournalPositionDto.Id == 0 && salesJournalPositionDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var salesJournalPosition = salesJournalPositionDto.mapToSalesJournalPosition();
            try
            {
                await _salesJournalPositionRepository.UpdateAsync(salesJournalPosition);
                return Ok(new APIResponse(StatusCodes.Status200OK,
                    $"Запись с ID: {salesJournalPosition.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {salesJournalPosition.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesJournalPositionDto>> Delete([FromQuery] long id)
        {
            var salesJournalPosition = await _salesJournalPositionRepository.GetByIdAsync(id);
            if (salesJournalPosition is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти детали журнала продаж с ID: {id}"));

            salesJournalPosition.IsDeleted = true;
            try
            {
                await _salesJournalPositionRepository.UpdateAsync(salesJournalPosition);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {salesJournalPosition.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {salesJournalPosition.Id}"));
            }
        }
    }
}