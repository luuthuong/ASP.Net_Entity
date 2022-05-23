using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Netpower.Training.Intern2022.API.Repositories.Repostiory
{
    public class RepositoryBase<T> where T : class
    {
        private readonly DbContext _context;
        public readonly DbSet<T> _items;
        public RepositoryBase(DbContext context)
        {
            _context = context;
            _items=context.Set<T>();
        }
        public async Task<List<T>> GetDataAsync()
        {
            return await _items.ToListAsync();
        }
        public async Task<T> GetDataAsync(Guid ID)
        {
            return await _items.FindAsync(ID);
        }
        public async Task AddDataAsync(T data)
        {
            await _items.AddAsync(data);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDataAsync(T data)
        {
            _items.Update(data);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteData(T data)
        {
            _items.Remove(data);
            await _context.SaveChangesAsync();
        }
        public async Task<T> CheckExistAsync(Guid ID)
        {
            var result=await _items.FindAsync(ID);
            return result;
        }
    }
}
