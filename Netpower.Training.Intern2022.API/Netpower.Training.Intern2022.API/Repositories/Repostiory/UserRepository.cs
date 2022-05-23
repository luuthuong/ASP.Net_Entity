using Microsoft.EntityFrameworkCore;
using Netpower.Training.Intern2022.API.Entities;
using System.Threading.Tasks;

namespace Netpower.Training.Intern2022.API.Repositories.Repostiory
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
        public async Task<int> IsExistNameAsync(string Name)
        {
            return await this._items.CountAsync(item=>item.UserName==Name);
        }
        public async Task<int> IsExistMailAsync(string Mail)
        {
            return await this._items.CountAsync(item => item.Email == Mail);
        }
    }
}
