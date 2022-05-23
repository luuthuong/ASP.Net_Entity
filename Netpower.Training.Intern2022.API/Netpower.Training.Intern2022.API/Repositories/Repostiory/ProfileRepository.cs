using Microsoft.EntityFrameworkCore;
using Netpower.Training.Intern2022.API.Entities;

namespace Netpower.Training.Intern2022.API.Repositories.Repostiory
{
    public class ProfileRepository : RepositoryBase<Profile>
    {
        public ProfileRepository(DbContext context) : base(context)
        {}
        //public async Task<int> IsExist()
        //{

        //}
    }
}
