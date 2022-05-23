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
    public class ProfilesController : ControllerBase
    {
        private readonly ProfileService _service;
        public ProfilesController(MyContext context)
        {
            _service = new ProfileService(new ProfileRepository(context));
        }
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            return Ok(await _service.GetProfileAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(string id)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.GetProfileAsync(ID);
            return check ? (result == null ? Ok(new
            {
                message="sucess",
                data=result
            }):NotFound()) : BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(string id, [FromForm] ProfileDTO profile)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.UpdateProfileAsync(ID, profile);
            return check ? (result == null ? NotFound() : Ok(new
            {
                message = "sucess",
                data = result
            })) : BadRequest();

        }

        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile([FromForm]ProfileDTO profile)
        {
            var result = await _service.InsertProfileAsync(profile);
            if (result != null)
                return Ok(new
                {
                    message = "sucess",
                    data = result
                });
            return BadRequest("PostFail");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile([FromForm] string id)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.DeleteProfileAsync(ID);
            return check ? (result != null ? Ok(new
            {
                message = "sucess",
                data = result
            }) : NotFound()
            ) : BadRequest();
        }
    }
}
