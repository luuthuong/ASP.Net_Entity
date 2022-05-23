using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netpower.Training.Intern2022.API.DTO;
using Netpower.Training.Intern2022.API.Entities;
using Netpower.Training.Intern2022.API.Repositories.Context;
using Netpower.Training.Intern2022.API.Repositories.Repostiory;
using Netpower.Training.Intern2022.API.Services;

namespace Netpower.Training.Intern2022.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _service;

        public DepartmentsController(MyContext context)
        {
            _service = new DepartmentService(new DepartmentRepository(context));
        }
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartment()
        {
            return Ok(await _service.GetDepartmentAsync()) ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(string id)
        {
            bool check=Guid.TryParse(id, out Guid ID);
            var result = await _service.GetDepartmentAsync(ID);
            return check ? (result == null ? NotFound() : Ok(new
            {
                message="success",
                data= result
            })):BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(string id,[FromForm] DepartmentDTO department)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result =await _service.UpdateDepartment(ID, department);
            return check ? (result == null ? NotFound() : Ok(new
            {
                message="sucess",
                data= result
            })) : BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromForm] DepartmentDTO department)
        {
           var result= await _service.InsertDepartment(department);
            if (result != null)
                return Ok(new
                {
                    message= "sucess",
                    data=result
                });
            return BadRequest("PostFail");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment([FromForm] string id)
        {
            bool check = Guid.TryParse(id, out Guid ID);
            var result =await _service.DeleteAsync(ID);
            return check?(result != null ? Ok(new
            {
                message = "sucess",
                data = result
            }) : NotFound()
            ) :BadRequest();
        }
    }
}
