using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microservicio_Paquetes.Domain.Entities;

namespace Microservicio_Paquetes.AccessData
{
    public class PaquetesDbContext: DbContext 
    {

        public PaquetesDbContext(DbContextOptions<PaquetesDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=mspaquetes;Trusted_Connection=True;");
        }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Excursion> Excursion { get; set; }
        public DbSet<FormaPago> FormaPago { get; set; }
        public DbSet<HabitacionHotel> HabitacionHotel { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelPension> HotelPension { get; set; }
        public DbSet<Paquete> Paquete { get; set; }
        public DbSet<PaqueteDestino> PaqueteDestino { get; set; }
        public DbSet<PaqueteEstado> PaqueteEstado { get; set; }
        public DbSet<PaqueteHotel> PaqueteHotel { get; set; }
        public DbSet<PaqueteViaje> PaqueteViaje { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<ReservaExcursion> ReservaExcursion { get; set; }
        public DbSet<ReservaHabitacion> ReservaHabitacion { get; set; }
        public DbSet<ReservaPasajero> ReservaPasajero { get; set; }
        public DbSet<TipoHabitacion> TipoHabitacion { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HotelPension>().HasData(new HotelPension[] {
                new HotelPension{Id = 1, Descripcion = "Ninguna (sin pensión)"},
                new HotelPension{Id = 2, Descripcion = "Desayuno"},
                new HotelPension{Id = 3, Descripcion = "Media pensión"},
                new HotelPension{Id = 4, Descripcion = "Pensión completa"},
            });

            modelBuilder.Entity<PaqueteEstado>().HasData(new PaqueteEstado[] {
                new PaqueteEstado{Id = 1, Descripcion = "Activo"},
                new PaqueteEstado{Id = 2, Descripcion = "Cerrado"},
                new PaqueteEstado{Id = 3, Descripcion = "Bloqueado"},
                new PaqueteEstado{Id = 4, Descripcion = "Cancelado"},
            });

            modelBuilder.Entity<TipoHabitacion>().HasData(new TipoHabitacion[] {
                new TipoHabitacion{Id = 1, Tipo = "Simple",
                Descripcion = "Habitación con una cama simple", Plazas = 1},
                new TipoHabitacion{Id = 2, Tipo = "Doble",
                Descripcion = "Habitación con dos camas simples", Plazas = 2},
                new TipoHabitacion{Id = 3, Tipo = "Matrimonial",
                Descripcion = "Habitación con una cama matrimonial", Plazas = 2},
                new TipoHabitacion{Id = 4, Tipo = "Matrimonial + dos simples",
                Descripcion = "Habitación con una cama matrimonial y dos simples", Plazas = 4},
            });

            modelBuilder.Entity<FormaPago>().HasData(new FormaPago[] {
                new FormaPago{Id = 1, Descripcion = "Efectivo"},
                new FormaPago{Id = 2, Descripcion = "Tarjeta de crédito"},
                new FormaPago{Id = 3, Descripcion = "Tarjeta de débito"},
                new FormaPago{Id = 4, Descripcion = "Mercado Pago"},
                new FormaPago{Id = 5, Descripcion = "Pago Fácil"},
                new FormaPago{Id = 6, Descripcion = "Bitcoin"},
            });
        }

    }
}
