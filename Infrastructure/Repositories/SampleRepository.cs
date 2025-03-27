using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class SampleRepository : Repository<Sample>, ISampleRepository
{
    public SampleRepository(SampleDbContext context) : base(context)
    {
    }
}
