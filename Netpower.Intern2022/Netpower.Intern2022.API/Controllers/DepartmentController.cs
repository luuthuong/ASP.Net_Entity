using Microsoft.AspNetCore.Mvc;
using Netpower.Intern2022.Entities.Model;
using Netpower.Intern2022.Responsitories;
using Netpower.Intern2022.Responsitories.Repositories;

namespace Netpower.Intern2022.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private Repositories<DepartmentModel> repo;
        public DepartmentController()
        {
            repo = new Repositories<DepartmentModel>(new MyDBContext());
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await repo.GetData());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Guid ID;
            if (!Guid.TryParse(id, out ID))
            {
                return BadRequest();
            }
            var result = await repo.GetData(ID);
            return result!=null? Ok(result):NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            var data = new DepartmentModel()
            {
                ID = Guid.NewGuid(),
                Name = department.Name,
                PositionModels =null
            };
            await repo.InsertData(data);
            return Ok(data);
        }

        //[HttpPut()]
        //public async Task<IActionResult> Put(string id,[FromForm] Department depatment)
        //{
        //    //if (!Guid.TryParse(id, out Guid ID))
        //    //{
        //    //    return BadRequest();
        //    //}
        //    //var item = await repo.GetData(ID);
        //    //item.Name = depatment.Name;
        //    //await repo.UpdateData(item);
        //    //return Ok(item);


        //}

        [HttpPut()]
        public async Task<IActionResult> Put(DepartmentModel depatment)
        {
            //if (!Guid.TryParse(id, out Guid ID))
            //{
            //    return BadRequest();
            //}
            //var item = await repo.GetData(ID);
            //item.Name = depatment.Name;
            await repo.UpdateData(depatment);
            return Ok(depatment);


        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
