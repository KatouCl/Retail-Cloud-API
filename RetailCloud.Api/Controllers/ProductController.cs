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
using RetailCloud.Core.Specifications.Product;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IBaseRepository<Product> _productRepository;

        public ProductController(IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<ProductDto>>> Get([FromQuery] ProductSpecParams param)
        {
            var spec = new ProductWithSpec(param);
            var total = await _productRepository.CountAsync(spec);
            var productEntity = await _productRepository.ListAsync(spec);

            var data = productEntity.Select(product => product.mapToProductDto()).ToList();
            return Ok(
                new Pagination<ProductDto>(
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
        public async Task<ActionResult<ProductDto>> GetById([FromQuery] long id)
        {
            var spec = new ProductWithSpec(id);
            var productEntity = await _productRepository.GetEntityWithSpec(spec);
            if (productEntity is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти товар с ID: {id}"));

            var productDto = productEntity.mapToProductDto();
            return Ok(productDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto productDto)
        {
            var groupProduct = productDto.mapToProduct();

            var resultCreate = await _productRepository.AddAsync(groupProduct);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto productDto)
        {
            if (productDto.Id == 0 && productDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var product = productDto.mapToProduct();
            try
            {
                await _productRepository.UpdateAsync(product);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {product.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {product.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Delete([FromQuery] long id)
        {
            var groupProduct = await _productRepository.GetByIdAsync(id);
            if (groupProduct is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось найти товар с ID: {id}"));

            groupProduct.IsDeleted = true;
            try
            {
                await _productRepository.UpdateAsync(groupProduct);
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