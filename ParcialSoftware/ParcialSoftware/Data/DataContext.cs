using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ParcialSoftware.Data;

namespace ParcialSoftware.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Entrance> Entrances { get; set; }

        public DbSet<TicketEntrance> TicketsEntrance { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Entrance>().HasIndex("Id","Description").IsUnique();
            modelBuilder.Entity<TicketEntrance>().HasIndex("TicketId", "EntranceId").IsUnique();

        }

    }
}
