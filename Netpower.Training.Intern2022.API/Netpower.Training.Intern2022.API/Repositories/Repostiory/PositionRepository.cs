using Microsoft.EntityFrameworkCore;
using Netpower.Training.Intern2022.API.Entities;
using System.Threading.Tasks;

namespace Netpower.Training.Intern2022.API.Repositories.Repostiory
{
    public class PositionRepository:RepositoryBase<Position>
    {
        public PositionRepository(DbContext context) :base(context) { }
        public async Task<int> IsExist(string name)
        {
            return await this._items.CountAsync(item=>item.Name==name);
        }
    }
}
