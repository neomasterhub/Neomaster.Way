using DEA.L1.Domain.Model.Entities;
using DEA.L1.Domain.Model.Repositories;

namespace DEA.L3.Infrastructure.DAL;

internal class Repository<T> : IRepository<T>
    where T : Observable
{
    private readonly DBContext _context;

    public Repository(DBContext context)
    {
        _context = context;
    }

    public void Save(T entity)
    {
        _context.SaveChanges(entity);
    }
}
