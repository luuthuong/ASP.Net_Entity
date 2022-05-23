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
    public class PositionsController : ControllerBase
    {
        private readonly PositionService _service;

        public PositionsController(MyContext context)
        {
            _service = new PositionService(new PositionRepository(context));
        }

        [HttpGet]
        public async Task<IActionResult> GetPosition()
        {
            return Ok(await _service.GetPositionAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPosition(string id)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.GetPositionAsync(ID);
            return check ? (result == null ? NotFound() : Ok(new
            {
                message = "success",
                data = result
            })) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosition(string id,[FromForm] PositionDTO position)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.UpdatePositionAsync(ID, position);
            return check ? (result == null ? NotFound() : Ok(new
            {
                message = "sucess",
                data = result
            })) : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Position>> PostPosition([FromForm] PositionDTO position)
        {
            var result = await _service.InsertPositionAsync(position);
            if (result != null)
                return Ok(new
                {
                    message = "sucess",
                    data = result
                });
            return BadRequest("PostFail");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(string id)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result = await _service.DeleteAsync(ID);
            return check ? (result != null ? Ok(new
            {
                message = "sucess",
                data = result
            }) : NotFound()
            ) : BadRequest();
        }

    }
}
