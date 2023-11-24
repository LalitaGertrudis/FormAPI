using Microsoft.EntityFrameworkCore;

namespace FormAPI.Models;

public class FormContext : DbContext
{
    public FormContext(DbContextOptions<FormContext> options)
        : base(options)
    {
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<User> Users { get; set; }
}