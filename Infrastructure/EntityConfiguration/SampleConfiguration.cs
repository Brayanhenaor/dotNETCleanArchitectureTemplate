using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfiguration;

public class SampleConfiguration : IEntityTypeConfiguration<Sample>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Sample> builder)
    {
        //Hacer configuraciones que se requieran
    }
}
