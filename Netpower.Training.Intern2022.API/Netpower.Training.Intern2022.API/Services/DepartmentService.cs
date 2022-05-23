using Netpower.Training.Intern2022.API.DTO;
using Netpower.Training.Intern2022.API.Entities;
using Netpower.Training.Intern2022.API.Repositories.Repostiory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Netpower.Training.Intern2022.API.Services
{
    public class DepartmentService:ServiceBase
    {
        private readonly DepartmentRepository _deparments ;
        public DepartmentService(DepartmentRepository departments)
        {
            this._deparments = departments;
        }
        public async Task<List<Department>> GetDepartmentAsync()
        {
            return await _deparments.GetDataAsync();
        }
        public async Task<Department> GetDepartmentAsync(Guid id)
        {
            return await _deparments.GetDataAsync(id);
        }
        public async Task<DepartmentDTO> InsertDepartment(DepartmentDTO department)
        {
            var checkName=await this._deparments.IsExistAsync(department.Name);
            if (checkName > 0)
            {
                return null;
            }
            await _deparments.AddDataAsync(new Department()
            {
                CreateAt = DateTime.Now,
                ID = Guid.NewGuid(),
                Name = department.Name,
            });
            return department;
        }


        public async Task<Department> UpdateDepartment(Guid ID,DepartmentDTO department)
        {
            var result =await _deparments.CheckExistAsync(ID);
            if (result == null|| await _deparments.IsExistAsync(department.Name) > 0)
            {
                return null;
            }
            result.Name = department.Name;
            await _deparments.UpdateDataAsync(result);
            return result;
        }
        public async Task<Department> DeleteAsync(Guid id)
        {
          var result= await _deparments.CheckExistAsync(id);
            if(result != null)
            {
                await _deparments.DeleteData(result);
                return result;
            }
            return null;
        }
    }
}
