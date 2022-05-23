using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Responsitories.Repositories
{
    public class Repositories<T>where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _items;
        public Repositories(DbContext context)
        {
            this._context = context;
            this._items = context.Set<T>();
        }
        public async Task<List<T>> GetData()
        {
            return await  _items.ToListAsync();
        }
        public async Task<T> GetData(Guid ID)
        {
            var result = await _items.FindAsync(ID);
            return result;
        }
        public async Task InsertData(T data)
        {
            await _items.AddAsync(data);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateData(T data)
        {
            _items.Update(data);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteData(T data)
        {
            this._context.Remove(data);
            await this._context.SaveChangesAsync();
        }
    }
}
