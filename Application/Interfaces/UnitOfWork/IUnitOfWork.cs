using Application.Interfaces.Repositories;

namespace Application.Interfaces.UnitOfWork;

public interface IUnitOfWork
{    
    ISampleRepository SampleRepository { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}