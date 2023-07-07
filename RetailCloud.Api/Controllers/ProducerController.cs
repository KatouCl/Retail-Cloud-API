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
using RetailCloud.Core.Specifications.Producer;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : Controller
    {
        private readonly IBaseRepository<Producer> _producerRepository;

        public ProducerController(IBaseRepository<Producer> producerRepository)
        {
            _producerRepository = producerRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<ProducerDto>>> Get([FromQuery] ProducerSpecParams param)
        {
            var spec = new ProducerWithSpec(param);
            var total = await _producerRepository.CountAsync(spec);
            var producerEntity = await _producerRepository.ListAsync(spec);

            var data = producerEntity.Select(producer => producer.mapToProducerDto()).ToList();
            return Ok(
                new Pagination<ProducerDto>(
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
        public async Task<ActionResult<ProducerDto>> GetById([FromQuery] long id)
        {
            var spec = new ProducerWithSpec(id);
            var producer = await _producerRepository.GetEntityWithSpec(spec);
            if (producer is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти производителя с ID: {id}"));

            var producerDto = producer.mapToProducerDto();
            return Ok(producerDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProducerDto>> Create([FromBody] ProducerDto producerDto)
        {
            var producer = producerDto.mapToProducer();

            //TODO: добавить валидацию на телефон
            var resultEmail = producer.Email is null // Это поле не обязательное 
                ? new ResultValidation(true)
                : EmailValidate.execute(producer.Email);

            var resultInn = producer.Inn is null // Это поле не обязательное 
                ? new ResultValidation(true)
                : InnValidate.execute(producer.Inn);

            var resultKpp = KppValidate.execute(producer.Kpp);

            var hasError = new List<ResultValidation>
                {resultEmail, resultInn, resultKpp}.Any(x => !x.Successful);
            if (hasError)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, "Перепроверьте поля: Email, ИНН, КПП"));

            var resultCreate = await _producerRepository.AddAsync(producer);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProducerDto>> Update([FromBody] ProducerDto producerDto)
        {
            if (producerDto.Id == 0 && producerDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var producer = producerDto.mapToProducer();

            //TODO: добавить валидацию на телефон
            var resultEmail = producer.Email is null // Это поле не обязательное 
                ? new ResultValidation(true)
                : EmailValidate.execute(producer.Email);

            var resultInn = producer.Inn is null // Это поле не обязательное 
                ? new ResultValidation(true)
                : InnValidate.execute(producer.Inn);

            var resultKpp = KppValidate.execute(producer.Kpp);

            var hasError = new List<ResultValidation>
                {resultEmail, resultInn, resultKpp}.Any(x => !x.Successful);
            if (hasError)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, "Перепроверьте поля: Email, ИНН, КПП"));

            try
            {
                await _producerRepository.UpdateAsync(producer);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {producer.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {producer.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProducerDto>> Delete([FromQuery] long id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            if (producer is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти производителя с ID: {id}"));

            producer.IsDeleted = true;
            try
            {
                await _producerRepository.UpdateAsync(producer);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {producer.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {producer.Id}"));
            }
        }
        
    }
}