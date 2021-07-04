using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Paquetes.AccessData.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lugar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Atractivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelPension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Plazas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    PasajeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Excursion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Bloqueada = table.Column<bool>(type: "bit", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excursion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Excursion_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sucursal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estrellas = table.Column<int>(type: "int", nullable: false),
                    Bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    DireccionId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaSalida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVuelta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNoches = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<int>(type: "int", nullable: false),
                    PaqueteEstadoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paquete_PaqueteEstado_PaqueteEstadoId",
                        column: x => x.PaqueteEstadoId,
                        principalTable: "PaqueteEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabitacionHotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoHabitacionId = table.Column<int>(type: "int", nullable: false),
                    Disponibles = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionHotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitacionHotel_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitacionHotel_TipoHabitacion_TipoHabitacionId",
                        column: x => x.TipoHabitacionId,
                        principalTable: "TipoHabitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteDestino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteDestino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaqueteDestino_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteDestino_Paquete_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteHotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Noches = table.Column<int>(type: "int", nullable: false),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    HotelPensionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteHotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaqueteHotel_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteHotel_HotelPension_HotelPensionId",
                        column: x => x.HotelPensionId,
                        principalTable: "HotelPension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteHotel_Paquete_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteViaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteViaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaqueteViaje_Paquete_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Pasajeros = table.Column<int>(type: "int", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false),
                    PasajeroId = table.Column<int>(type: "int", nullable: false),
                    FormaPagoId = table.Column<int>(type: "int", nullable: false),
                    IdPaquete = table.Column<int>(type: "int", nullable: false),
                    PaqueteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_FormaPago_FormaPagoId",
                        column: x => x.FormaPagoId,
                        principalTable: "FormaPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Paquete_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaExcursion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    ExcursionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaExcursion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaExcursion_Excursion_ExcursionId",
                        column: x => x.ExcursionId,
                        principalTable: "Excursion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaExcursion_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaHabitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    TipoHabitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHabitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_TipoHabitacion_TipoHabitacionId",
                        column: x => x.TipoHabitacionId,
                        principalTable: "TipoHabitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaPasajero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    PasajeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaPasajero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaPasajero_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaPago",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta de crédito" },
                    { 3, "Tarjeta de débito" },
                    { 4, "Mercado Pago" },
                    { 5, "Pago Fácil" },
                    { 6, "Bitcoin" }
                });

            migrationBuilder.InsertData(
                table: "HotelPension",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 4, "Pensión completa" },
                    { 3, "Media pensión" },
                    { 1, "Ninguna (sin pensión)" },
                    { 2, "Desayuno" }
                });

            migrationBuilder.InsertData(
                table: "PaqueteEstado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Cerrado" },
                    { 3, "Bloqueado" },
                    { 4, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "TipoHabitacion",
                columns: new[] { "Id", "Descripcion", "Plazas", "Tipo" },
                values: new object[,]
                {
                    { 3, "Habitación con una cama matrimonial", 2, "Matrimonial" },
                    { 1, "Habitación con una cama simple", 1, "Simple" },
                    { 2, "Habitación con dos camas simples", 2, "Doble" },
                    { 4, "Habitación con una cama matrimonial y dos simples", 4, "Matrimonial + dos simples" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_DestinoId",
                table: "Comentario",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Excursion_DestinoId",
                table: "Excursion",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionHotel_HotelId",
                table: "HabitacionHotel",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionHotel_TipoHabitacionId",
                table: "HabitacionHotel",
                column: "TipoHabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_DestinoId",
                table: "Hotel",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_PaqueteEstadoId",
                table: "Paquete",
                column: "PaqueteEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteDestino_DestinoId",
                table: "PaqueteDestino",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteDestino_PaqueteId",
                table: "PaqueteDestino",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteHotel_HotelId",
                table: "PaqueteHotel",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteHotel_HotelPensionId",
                table: "PaqueteHotel",
                column: "HotelPensionId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteHotel_PaqueteId",
                table: "PaqueteHotel",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteViaje_PaqueteId",
                table: "PaqueteViaje",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_FormaPagoId",
                table: "Reserva",
                column: "FormaPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PaqueteId",
                table: "Reserva",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursion_ExcursionId",
                table: "ReservaExcursion",
                column: "ExcursionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursion_ReservaId",
                table: "ReservaExcursion",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_HotelId",
                table: "ReservaHabitacion",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_ReservaId",
                table: "ReservaHabitacion",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_TipoHabitacionId",
                table: "ReservaHabitacion",
                column: "TipoHabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaPasajero_ReservaId",
                table: "ReservaPasajero",
                column: "ReservaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "HabitacionHotel");

            migrationBuilder.DropTable(
                name: "PaqueteDestino");

            migrationBuilder.DropTable(
                name: "PaqueteHotel");

            migrationBuilder.DropTable(
                name: "PaqueteViaje");

            migrationBuilder.DropTable(
                name: "ReservaExcursion");

            migrationBuilder.DropTable(
                name: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "ReservaPasajero");

            migrationBuilder.DropTable(
                name: "HotelPension");

            migrationBuilder.DropTable(
                name: "Excursion");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "PaqueteEstado");
        }
    }
}
