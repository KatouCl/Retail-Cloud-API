using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailCloud.Api.Errors;
using RetailCloud.Api.Helpers;
using RetailCloud.Api.Mapper;
using RetailCloud.Core.Entities;
using RetailCloud.Core.Interfaces;
using RetailCloud.Core.Specifications.SalesJournal;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesJournalController : Controller
    {
        private readonly IBaseRepository<SalesJournal> _salesJournalRepository;

        public SalesJournalController(IBaseRepository<SalesJournal> salesJournalRepository)
        {
            _salesJournalRepository = salesJournalRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<SalesJournalDto>>> Get(
            [FromQuery] SalesJournalSpecParams param)
        {
            var spec = new SalesJournalWithSpec(param);
            var total = await _salesJournalRepository.CountAsync(spec);
            var salesJournal = await _salesJournalRepository.ListAsync(spec);
            var data = salesJournal.Select(salesJournal => salesJournal.mapToSalesJournalDto()).ToList();
            return Ok(
                new Pagination<SalesJournalDto>(
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
        public async Task<ActionResult<SalesJournalDto>> GetById([FromQuery] long id)
        {
            var spec = new SalesJournalWithSpec(id);
            var salesJournal = await _salesJournalRepository.GetEntityWithSpec(spec);
            if (salesJournal is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти журнал продаж с ID: {id}"));

            var salesJournalDto = salesJournal.mapToSalesJournalDto();
            return Ok(salesJournalDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesJournalDto>> Create([FromBody] SalesJournalDto salesJournalDto)
        {
            var salesJournal = salesJournalDto.mapToSalesJournal();

            var resultCreate = await _salesJournalRepository.AddAsync(salesJournal);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesJournalDto>> Update([FromBody] SalesJournalDto salesJournalDto)
        {
            if (salesJournalDto.Id == 0 && salesJournalDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var salesJournal = salesJournalDto.mapToSalesJournal();
            try
            {
                await _salesJournalRepository.UpdateAsync(salesJournal);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {salesJournal.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {salesJournal.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesJournalDto>> Delete([FromQuery] long id)
        {
            var salesJournal = await _salesJournalRepository.GetByIdAsync(id);
            if (salesJournal is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти журнал продаж с ID: {id}"));

            salesJournal.IsDeleted = true;
            try
            {
                await _salesJournalRepository.UpdateAsync(salesJournal);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {salesJournal.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {salesJournal.Id}"));
            }
        }
    }
}