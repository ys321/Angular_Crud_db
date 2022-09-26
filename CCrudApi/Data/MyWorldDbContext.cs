using Microsoft.EntityFrameworkCore;

namespace  CCrudApi.Data;

public class MyWorldDbContext : DbContext
{
    public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
    {
 
    }
    public DbSet<CCrudApi.Data.Entities.Cruds> Cruds { get; set; }
}