using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Data.Interfaces;
using Order.Dto.DTO.Request;
using Order.Dto.DTO.Response;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create (UserRequest userRequest)
        {

            var result = await _userInterface.Create(userRequest);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var result= await _userInterface.GetAll();
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var result = await _userInterface.GetById(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("Update/{id}")]

        public async Task<IActionResult> Update(int id, UserRequest userRequest)
        {
            var  result= await _userInterface.Update(id, userRequest);
            if(result == null)
            {
                return NotFound();
             }
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var user= await _userInterface.Delete(id);
            return Ok(user);
        }
    }
}
