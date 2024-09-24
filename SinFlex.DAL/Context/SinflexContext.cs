using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sinflex.Model.Entities;
using Sinflex.DAL.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.DAL.Context
{
    public class SinflexContext: IdentityDbContext<AppUser, AppUserRole, Guid>
    {
		public SinflexContext()
		{
		}

		public SinflexContext(DbContextOptions<SinflexContext> options) : base(options) { }

        //DbSets

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies{ get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Booth> Booths { get; set; }
        public DbSet<AirDate> AirDates { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-9MDFIEQ\\SQLEXPRESS;Database=SinflexDB;Trusted_Connection=True;TrustServerCertificate=true;");


        //    base.OnConfiguring(optionsBuilder);
        //}



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new SaloonConfiguration());

            base.OnModelCreating(builder);
        }
    }
}

