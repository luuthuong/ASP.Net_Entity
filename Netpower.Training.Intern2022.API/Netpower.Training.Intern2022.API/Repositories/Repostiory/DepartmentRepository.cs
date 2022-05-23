using Microsoft.EntityFrameworkCore;
using Netpower.Training.Intern2022.API.Entities;
using System.Threading.Tasks;

namespace Netpower.Training.Intern2022.API.Repositories.Repostiory
{
    public class DepartmentRepository:RepositoryBase<Department>
    {
        public DepartmentRepository(DbContext context) : base(context){}

        public async Task<int> IsExistAsync(string name)
        {
          return await this._items.CountAsync(item=>item.Name == name);
        }
    }
}
