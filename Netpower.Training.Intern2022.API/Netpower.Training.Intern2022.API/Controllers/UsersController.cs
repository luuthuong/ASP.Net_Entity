using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netpower.Training.Intern2022.API.DTO;
using Netpower.Training.Intern2022.API.Entities;
using Netpower.Training.Intern2022.API.Repositories.Context;
using Netpower.Training.Intern2022.API.Repositories.Repostiory;
using Netpower.Training.Intern2022.API.Services;

namespace Netpower.Training.Intern2022.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;
        public UsersController(MyContext context)
        {
            _service = new UserService(new UserRepository(context));
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _service.GetUserAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromForm] string id)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.GetUserAsync(ID);
            return check ? (result == null ? Ok(new
            {
                message = "sucess",
                data = result
            }) : NotFound()) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, [FromForm] UserUpdateDTO user)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.UpdateUserAsync(ID, user);
            return check ? (result == null ? NotFound() : Ok(new
            {
                message = "sucess",
                data = result
            })) : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromForm] UserDTO user)
        {
            var result = await _service.InsertUserAsync(user);
            if (result != null)
                return Ok(new
                {
                    message = "sucess",
                    data = result
                });
            return BadRequest("PostFail");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.DeleteUserAsync(ID);
            return check ? (result != null ? Ok(new
            {
                message = "sucess",
                data = result
            }) : NotFound()
            ) : BadRequest();
        }

    }
}
