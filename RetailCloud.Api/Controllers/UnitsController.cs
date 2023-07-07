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
using RetailCloud.Core.Specifications.Units;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : Controller
    {
        private readonly IBaseRepository<Units> _unitRepository;

        public UnitsController(IBaseRepository<Units> unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<UnitsDto>>> Get([FromQuery] UnitsSpecParams param)
        {
            var spec = new UnitsWithSpec(param);
            var total = await _unitRepository.CountAsync(spec);
            var unitEntity = await _unitRepository.ListAsync(spec);

            var data = unitEntity.Select(units => units.mapToUnitsDto()).ToList();
            return Ok(
                new Pagination<UnitsDto>(
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
        public async Task<ActionResult<UnitsDto>> GetById([FromQuery] long id)
        {
            var spec = new UnitsWithSpec(id);
            var unit = await _unitRepository.GetEntityWithSpec(spec);
            if (unit is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти ед.измерения с ID: {id}"));

            var unitsDto = unit.mapToUnitsDto();
            return Ok(unitsDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UnitsDto>> Create([FromBody] UnitsDto unitsDto)
        {
            var unit = unitsDto.mapToUnits();

            var resultCreate = await _unitRepository.AddAsync(unit);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UnitsDto>> Update([FromBody] UnitsDto unitsDto)
        {
            if (unitsDto.Id == 0 && unitsDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var unit = unitsDto.mapToUnits();
            try
            {
                await _unitRepository.UpdateAsync(unit);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {unit.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {unit.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UnitsDto>> Delete([FromQuery] long id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            if (unit is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти ед.измерения с ID: {id}"));

            unit.IsDeleted = true;
            try
            {
                await _unitRepository.UpdateAsync(unit);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {unit.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {unit.Id}"));
            }
        }
    }
}