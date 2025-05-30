using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTicketBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    cinema_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cinemas__566287789812A28F", x => x.cinema_id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    duration = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_date = table.Column<DateOnly>(type: "date", nullable: true),
                    poster_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    rating = table.Column<decimal>(type: "decimal(3,1)", nullable: true, defaultValue: 0.0m),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movies__83CDF7494F6405C4", x => x.movie_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__B9BE370F480B365B", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    hall_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cinema_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Halls__A63DE8CF66035EB7", x => x.hall_id);
                    table.ForeignKey(
                        name: "FK__Halls__cinema_id__4316F928",
                        column: x => x.cinema_id,
                        principalTable: "Cinemas",
                        principalColumn: "cinema_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notification_type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    is_read = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__E059842FABAA957D", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK__Notificat__user___72C60C4A",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    refresh_token_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RefreshT__3214EC275A6F7B1D", x => x.refresh_token_id);
                    table.ForeignKey(
                        name: "FK__RefreshTo__user___72C60C4A",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    movie_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    review_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    is_approved = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reviews__60883D90B85C6A6F", x => x.review_id);
                    table.ForeignKey(
                        name: "FK__Reviews__movie_i__6D0D32F4",
                        column: x => x.movie_id,
                        principalTable: "Movies",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Reviews__user_id__6C190EBB",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    screening_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movie_id = table.Column<int>(type: "int", nullable: false),
                    hall_id = table.Column<int>(type: "int", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0.00m),
                    available_seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Screenin__477746C3124979AF", x => x.screening_id);
                    table.ForeignKey(
                        name: "FK__Screening__hall___4E88ABD4",
                        column: x => x.hall_id,
                        principalTable: "Halls",
                        principalColumn: "hall_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Screening__movie__4D94879B",
                        column: x => x.movie_id,
                        principalTable: "Movies",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    seat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hall_id = table.Column<int>(type: "int", nullable: false),
                    row_number = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    seat_number = table.Column<int>(type: "int", nullable: false),
                    seat_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "????")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Seats__906DED9C96E45B70", x => x.seat_id);
                    table.ForeignKey(
                        name: "FK__Seats__hall_id__5441852A",
                        column: x => x.hall_id,
                        principalTable: "Halls",
                        principalColumn: "hall_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    reservation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    screening_id = table.Column<int>(type: "int", nullable: false),
                    reservation_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "?? ??????"),
                    total_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__31384C295D6D873E", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK__Reservati__scree__5AEE82B9",
                        column: x => x.screening_id,
                        principalTable: "Screenings",
                        principalColumn: "screening_id");
                    table.ForeignKey(
                        name: "FK__Reservati__user___59FA5E80",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservation_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    transaction_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__ED1FC9EA13CCCD3C", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__Payments__reserv__66603565",
                        column: x => x.reservation_id,
                        principalTable: "Reservations",
                        principalColumn: "reservation_id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservation_id = table.Column<int>(type: "int", nullable: false),
                    seat_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "????")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tickets__D596F96B7634C851", x => x.ticket_id);
                    table.ForeignKey(
                        name: "FK__Tickets__reserva__5FB337D6",
                        column: x => x.reservation_id,
                        principalTable: "Reservations",
                        principalColumn: "reservation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Tickets__seat_id__60A75C0F",
                        column: x => x.seat_id,
                        principalTable: "Seats",
                        principalColumn: "seat_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Halls_cinema_id",
                table: "Halls",
                column: "cinema_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_user_id",
                table: "Notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_reservation_id",
                table: "Payments",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_user_id",
                table: "RefreshTokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_screening_id",
                table: "Reservations",
                column: "screening_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_user_id",
                table: "Reservations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_movie_id",
                table: "Reviews",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_user_id",
                table: "Reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_hall_id",
                table: "Screenings",
                column: "hall_id");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_movie_id",
                table: "Screenings",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "UQ_Seat_Position",
                table: "Seats",
                columns: new[] { "hall_id", "row_number", "seat_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_reservation_id",
                table: "Tickets",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_seat_id",
                table: "Tickets",
                column: "seat_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E616410448940",
                table: "Users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
