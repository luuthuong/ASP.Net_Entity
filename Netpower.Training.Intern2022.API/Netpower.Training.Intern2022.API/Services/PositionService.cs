using Netpower.Training.Intern2022.API.DTO;
using Netpower.Training.Intern2022.API.Entities;
using Netpower.Training.Intern2022.API.Repositories.Repostiory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Netpower.Training.Intern2022.API.Services
{
    public class PositionService
    {
        private readonly PositionRepository _positions;
        public PositionService(PositionRepository positons)
        {
            _positions = positons;
        }
        public async Task<List<Position>> GetPositionAsync()
        {
            return await _positions.GetDataAsync();
        }
        public async Task<Position> GetPositionAsync(Guid id)
        {
            return await _positions.GetDataAsync(id);
        }
        public async Task<PositionDTO> InsertPositionAsync(PositionDTO position)
        {
            var check = await _positions.IsExist(position.Name);
            if (check > 0)
                return null;
            await _positions.AddDataAsync(new Position()
            {
                CreateAt = DateTime.Now,
                ID = Guid.NewGuid(),
                Name = position.Name,
                DepartmentID=position.ID
            });
            return position;
        }
        public async Task<Position> UpdatePositionAsync(Guid id,PositionDTO position)
        {
            var result=await _positions.CheckExistAsync(id);
            if (result == null)
                return null;
            result.Name = position.Name;
            await _positions.UpdateDataAsync(result);
            return result;
        }
        public async Task<Position> DeleteAsync(Guid id)
        {
            var result = await _positions.CheckExistAsync(id);
            if (result != null)
            {
                await _positions.DeleteData(result);
                return result;
            }
            return null;
        }
    }
}
