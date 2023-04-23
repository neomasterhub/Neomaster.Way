namespace DEA.L1.Domain.Model.Repositories;

public interface IRepository<T>
    where T : class
{
    void Save(T entity);
}
