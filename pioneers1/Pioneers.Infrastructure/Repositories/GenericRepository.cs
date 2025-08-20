using Microsoft.EntityFrameworkCore;
using Pioneers.Domain.Entities;
using Pioneers.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly PioneersDbContext _ctx;
    public GenericRepository(PioneersDbContext ctx) => _ctx = ctx;

    public Task<T?> GetByIdAsync(int id) => _ctx.Set<T>().FindAsync(id).AsTask();
    public Task<List<T>> GetAllAsync() => _ctx.Set<T>().ToListAsync();
    public Task<List<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> p)
        => _ctx.Set<T>().Where(p).ToListAsync();
    public async Task<T> AddAsync(T entity) { _ctx.Add(entity); await _ctx.SaveChangesAsync(); return entity; }
    public async Task UpdateAsync(T entity) { _ctx.Update(entity); await _ctx.SaveChangesAsync(); }
    public async Task DeleteAsync(T entity) { _ctx.Remove(entity); await _ctx.SaveChangesAsync(); }
}
