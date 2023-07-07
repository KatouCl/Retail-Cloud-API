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
using RetailCloud.Core.Specifications.User;

namespace RetailCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserController(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<UserDto>>> Get([FromQuery] UserSpecParams param)
        {
            var spec = new UserWithSpec(param);
            var total = await _userRepository.CountAsync(spec);
            var userEntity = await _userRepository.ListAsync(spec);

            var data = userEntity.Select(user => user.mapToUserDto()).ToList();
            return Ok(
                new Pagination<UserDto>(
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
        public async Task<ActionResult<UserDto>> GetById([FromQuery] long id)
        {
            var spec = new UserWithSpec(id);
            var user = await _userRepository.GetEntityWithSpec(spec);
            if (user is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти пользователя с ID: {id}"));

            var userDto = user.mapToUserDto();
            return Ok(userDto);
        }

        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Create([FromBody] UserDto userDto)
        {
            var user = userDto.mapToUser();

            var resultCreate = await _userRepository.AddAsync(user);
            return Ok(resultCreate);
        }

        [HttpPost(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Update([FromBody] UserDto userDto)
        {
            if (userDto.Id == 0 && userDto.GetType() != typeof(long))
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Проверьте ID записи которую хотите изменить"));

            var user = userDto.mapToUser();
            try
            {
                await _userRepository.UpdateAsync(user);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {user.Id} обновлена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось обновить запись с ID: {user.Id}"));
            }
        }

        [HttpPost(nameof(Delete))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Delete([FromQuery] long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null)
                return Ok(new APIResponse(StatusCodes.Status404NotFound, $"Не удалось найти пользователя с ID: {id}"));

            user.IsDeleted = true;
            try
            {
                await _userRepository.UpdateAsync(user);
                return Ok(new APIResponse(StatusCodes.Status200OK, $"Запись с ID: {user.Id} удалена"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Ok(new APIResponse(StatusCodes.Status404NotFound,
                    $"Не удалось удалить запись с ID: {user.Id}"));
            }
        }
    }
}