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
using RetailCloud.Core.Specifications.Producer;
using RetailCloud.Core.Specifications.Role;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IBaseRepository<Role> _roleRepository;

        public RoleController(IBaseRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<RoleDto>>> Get([FromQuery] RoleSpecParams param)
        {
            var spec = new RoleWithSpec(param);
            var total = await _roleRepository.CountAsync(spec);
            var roleEntity = await _roleRepository.ListAsync(spec);

            var data = roleEntity.Select(role => role.mapToRoleDto()).ToList();
            return Ok(
                new Pagination<RoleDto>(
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
        public async Task<ActionResult<RoleDto>> GetById([FromQuery] long id)
        {
            var spec = new RoleWithSpec(id);
            var role = await _roleRepository.GetEntityWithSpec(spec);
            if (role is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти роль с ID: {id}"));

            var roleDto = role.mapToRoleDto();
            return Ok(roleDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoleDto>> Create([FromBody] RoleDto roleDto)
        {
            var role = roleDto.mapToRole();

            var resultCreate = await _roleRepository.AddAsync(role);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoleDto>> Update([FromBody] RoleDto roleDto)
        {
            if (roleDto.Id == 0 && roleDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var role = roleDto.mapToRole();
            try
            {
                await _roleRepository.UpdateAsync(role);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {role.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {role.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoleDto>> Delete([FromQuery] long id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти производителя с ID: {id}"));

            role.IsDeleted = true;
            try
            {
                await _roleRepository.UpdateAsync(role);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {role.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {role.Id}"));
            }
        }
    }
}