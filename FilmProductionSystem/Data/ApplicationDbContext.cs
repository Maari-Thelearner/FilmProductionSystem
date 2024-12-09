using FilmProductionSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmProductionSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Film> Films { get; set; }
    
    public DbSet<Crew> Crews { get; set; }
    
    public DbSet<Equipment> Equipments { get; set; }
    
    public DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Crew>(entity =>
        {
            entity.HasOne(c => c.film)
                .WithMany(f => f.Crews)
                .HasForeignKey(c => c.FilmId)
                .OnDelete(DeleteBehavior.NoAction);
        });
        
        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasOne(s => s.film)
                .WithMany(f => f.Schedules)
                .HasForeignKey(s => s.FilmId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}