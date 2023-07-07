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
using RetailCloud.Core.Specifications.Barcode;
using BarcodeSpecParams = RetailCloud.Core.Specifications.Barcode.BarcodeSpecParams;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : Controller
    {
        private readonly IBaseRepository<Barcode> _barcodeRepository;

        public BarcodeController(IBaseRepository<Barcode> barcodeRepository)
        {
            _barcodeRepository = barcodeRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<BarcodeDto>>> Get([FromQuery] BarcodeSpecParams param)
        {
            var spec = new BarcodeWithSpec(param);
            var total = await _barcodeRepository.CountAsync(spec);
            var barcodeEntity = await _barcodeRepository.ListAsync(spec);

            var data = barcodeEntity.Select(barcodeEntity => barcodeEntity.mapToBarcodeDto()).ToList();
            return Ok(
                new Pagination<BarcodeDto>(
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
        public async Task<ActionResult<BarcodeDto>> GetById([FromQuery] long id)
        {
            var spec = new BarcodeWithSpec(id);
            var barcodeEntity = await _barcodeRepository.GetEntityWithSpec(spec);
            if (barcodeEntity is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти штрих-код с ID: {id}"));

            var barcodeDto = barcodeEntity.mapToBarcodeDto();
            return Ok(barcodeDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BarcodeDto>> Create([FromBody] BarcodeDto barcodeDto)
        {
            var barcode = barcodeDto.mapToBarcode();

            var resultCreate = await _barcodeRepository.AddAsync(barcode);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BarcodeDto>> Update([FromBody] BarcodeDto barcodeDto)
        {
            if (barcodeDto.Id == 0 && barcodeDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var barcode = barcodeDto.mapToBarcode();
            try
            {
                await _barcodeRepository.UpdateAsync(barcode);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {barcode.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {barcode.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BarcodeDto>> Delete([FromQuery] long id)
        {
            var barcode = await _barcodeRepository.GetByIdAsync(id);
            if (barcode is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти штрих-код с ID: {id}"));

            barcode.IsDeleted = true;
            try
            {
                await _barcodeRepository.UpdateAsync(barcode);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {barcode.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {barcode.Id}"));
            }
        }
    }
}