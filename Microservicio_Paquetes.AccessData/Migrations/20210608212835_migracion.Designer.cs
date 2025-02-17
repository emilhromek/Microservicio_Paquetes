﻿// <auto-generated />
using System;
using Microservicio_Paquetes.AccessData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Microservicio_Paquetes.AccessData.Migrations
{
    [DbContext(typeof(PaquetesDbContext))]
    [Migration("20210608212835_migracion")]
    partial class migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DateTime");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PasajeroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Destino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Atractivo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Excursion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bloqueada")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId");

                    b.ToTable("Excursion");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.FormaPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("FormaPago");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Efectivo"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Tarjeta de crédito"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Tarjeta de débito"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Mercado Pago"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Pago Fácil"
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Bitcoin"
                        });
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.HabitacionHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Disponibles")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("TipoHabitacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TipoHabitacionId");

                    b.ToTable("HabitacionHotel");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int>("DireccionId")
                        .HasColumnType("int");

                    b.Property<int>("Estrellas")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sucursal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.HotelPension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("HotelPension");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Ninguna (sin pensión)"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Desayuno"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Media pensión"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Pensión completa"
                        });
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Paquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Descuento")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<string>("FechaSalida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaVuelta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PaqueteEstadoId")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.Property<int>("TotalNoches")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaqueteEstadoId");

                    b.ToTable("Paquete");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.PaqueteDestino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int>("PaqueteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId");

                    b.HasIndex("PaqueteId");

                    b.ToTable("PaqueteDestino");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.PaqueteEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("PaqueteEstado");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Activo"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Cerrado"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Bloqueado"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Cancelado"
                        });
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.PaqueteHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("HotelPensionId")
                        .HasColumnType("int");

                    b.Property<int>("Noches")
                        .HasColumnType("int");

                    b.Property<int>("PaqueteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelPensionId");

                    b.HasIndex("PaqueteId");

                    b.ToTable("PaqueteHotel");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.PaqueteViaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PaqueteId")
                        .HasColumnType("int");

                    b.Property<int>("ViajeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaqueteId");

                    b.ToTable("PaqueteViaje");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FormaPagoId")
                        .HasColumnType("int");

                    b.Property<int>("IdPaquete")
                        .HasColumnType("int");

                    b.Property<bool>("Pagado")
                        .HasColumnType("bit");

                    b.Property<int?>("PaqueteId")
                        .HasColumnType("int");

                    b.Property<int>("PasajeroId")
                        .HasColumnType("int");

                    b.Property<int>("Pasajeros")
                        .HasColumnType("int");

                    b.Property<int>("PrecioTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormaPagoId");

                    b.HasIndex("PaqueteId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.ReservaExcursion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExcursionId")
                        .HasColumnType("int");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcursionId");

                    b.HasIndex("ReservaId");

                    b.ToTable("ReservaExcursion");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.ReservaHabitacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoHabitacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("ReservaId");

                    b.HasIndex("TipoHabitacionId");

                    b.ToTable("ReservaHabitacion");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.ReservaPasajero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PasajeroId")
                        .HasColumnType("int");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("ReservaPasajero");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.TipoHabitacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Plazas")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoHabitacion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Habitación con una cama simple",
                            Plazas = 1,
                            Tipo = "Simple"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Habitación con dos camas simples",
                            Plazas = 2,
                            Tipo = "Doble"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Habitación con una cama matrimonial",
                            Plazas = 2,
                            Tipo = "Matrimonial"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Habitación con una cama matrimonial y dos simples",
                            Plazas = 4,
                            Tipo = "Matrimonial + dos simples"
                        });
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Comentario", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Destino", "Destino")
                        .WithMany("Comentarios")
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Excursion", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Destino", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.HabitacionHotel", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Hotel", "Hotel")
                        .WithMany("HabitacionHoteles")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservicio_Paquetes.Domain.Entities.TipoHabitacion", null)
                        .WithMany("HabitacionesHotel")
                        .HasForeignKey("TipoHabitacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Hotel", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Destino", "Destino")
                        .WithMany("Hoteles")
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Paquete", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.PaqueteEstado", "PaqueteEstado")
                        .WithMany("Paquetes")
                        .HasForeignKey("PaqueteEstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaqueteEstado");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.PaqueteDestino", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Destino", "Destino")
                        .WithMany("PaqueteDestinos")
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Paquete", "Paquete")
                        .WithMany("PaqueteDestinos")
                        .HasForeignKey("PaqueteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Paquete");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.PaqueteHotel", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservicio_Paquetes.Domain.Entities.HotelPension", "HotelPension")
                        .WithMany("PaqueteHoteles")
                        .HasForeignKey("HotelPensionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Paquete", "Paquete")
                        .WithMany("PaqueteHoteles")
                        .HasForeignKey("PaqueteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("HotelPension");

                    b.Navigation("Paquete");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.PaqueteViaje", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Paquete", "Paquete")
                        .WithMany("PaqueteViajes")
                        .HasForeignKey("PaqueteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paquete");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Reserva", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.FormaPago", "FormaPago")
                        .WithMany("Reservas")
                        .HasForeignKey("FormaPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Paquete", "Paquete")
                        .WithMany("Reservas")
                        .HasForeignKey("PaqueteId");

                    b.Navigation("FormaPago");

                    b.Navigation("Paquete");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.ReservaExcursion", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Excursion", "Excursion")
                        .WithMany("ReservaExcursiones")
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Reserva", "Reserva")
                        .WithMany("ReservaExcursiones")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excursion");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.ReservaHabitacion", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Reserva", "Reserva")
                        .WithMany("ReservaHabitaciones")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservicio_Paquetes.Domain.Entities.TipoHabitacion", "TipoHabitacion")
                        .WithMany()
                        .HasForeignKey("TipoHabitacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Reserva");

                    b.Navigation("TipoHabitacion");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.ReservaPasajero", b =>
                {
                    b.HasOne("Microservicio_Paquetes.Domain.Entities.Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Destino", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Hoteles");

                    b.Navigation("PaqueteDestinos");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Excursion", b =>
                {
                    b.Navigation("ReservaExcursiones");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.FormaPago", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("HabitacionHoteles");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.HotelPension", b =>
                {
                    b.Navigation("PaqueteHoteles");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Paquete", b =>
                {
                    b.Navigation("PaqueteDestinos");

                    b.Navigation("PaqueteHoteles");

                    b.Navigation("PaqueteViajes");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.PaqueteEstado", b =>
                {
                    b.Navigation("Paquetes");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.Reserva", b =>
                {
                    b.Navigation("ReservaExcursiones");

                    b.Navigation("ReservaHabitaciones");
                });

            modelBuilder.Entity("Microservicio_Paquetes.Domain.Entities.TipoHabitacion", b =>
                {
                    b.Navigation("HabitacionesHotel");
                });
#pragma warning restore 612, 618
        }
    }
}
