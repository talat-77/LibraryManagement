using LibraryManagement.Application.Repository;
using LibraryManagement.Domain.Entities.Common;
using LibraryManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repository
{
    public class WriteRepository<T> : IWriteRepository<T>  where T : BaseEntity
    {
        private readonly LibraryManagementDbContext _context;

        public WriteRepository(LibraryManagementDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table 
            => _context.Set<T>();   

        public async Task<bool> AddAsync(T model) {
           EntityEntry<T> entityEntry = await Table.AddAsync(model);
            await SaveAsync();
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
            await SaveAsync();  
            return true;    
        }

        public bool Remove(T model)
        {
         EntityEntry entityEntry = Table.Remove(model);
            _context.SaveChanges();
           return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var deleted = await Table.FindAsync(id);
            Table.Remove(deleted);
            await SaveAsync();  
            return true;
            
         
        }

        public bool RemoveRange(List<T> model)
        {
            Table.RemoveRange(model);
            _context.SaveChanges();
            return true;    

        }

        public async Task<int> SaveAsync()
    =>await _context.SaveChangesAsync();

        public bool Update(T model)
        {
       EntityEntry<T> entityEntry = Table.Update(model);
            _context.SaveChanges();
          return entityEntry.State == EntityState.Modified;
         

        }

       
    }
}
