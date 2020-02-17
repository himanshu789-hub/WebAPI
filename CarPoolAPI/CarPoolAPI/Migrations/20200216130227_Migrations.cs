using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPoolAPI.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vechicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPlate = table.Column<string>(nullable: true),
                    Type = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Capacity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vechicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offerrings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    TentativeTime = table.Column<DateTime>(nullable: true),
                    DepartTime = table.Column<DateTime>(nullable: true),
                    SeatsAvail = table.Column<int>(nullable: true),
                    Discount = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PricePerKM = table.Column<float>(nullable: false),
                    TotalEarning = table.Column<float>(nullable: true),
                    MaxOfferSeats = table.Column<int>(nullable: true),
                    VechicleRef = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offerrings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offerrings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Offerrings_Vechicles_VechicleRef",
                        column: x => x.VechicleRef,
                        principalTable: "Vechicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    RequestedSource = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    RequestedDestination = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    FarePrice = table.Column<float>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: true),
                    DepartingTime = table.Column<DateTime>(nullable:true),
                    EndTime = table.Column<DateTime>(nullable:true),
                    Soure = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AnounceId = table.Column<string>(nullable: true),
                    OfferId = table.Column<int>(nullable: false),
                    SeatsBooked = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Offerrings_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offerrings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ViaPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    OfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViaPoints_Offerrings_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offerrings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anounces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    BookingRef = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anounces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anounces_Bookings_BookingRef",
                        column: x => x.BookingRef,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Anounces_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnounceOfferrings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    AnounceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnounceOfferrings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnounceOfferrings_Anounces_AnounceId",
                        column: x => x.AnounceId,
                        principalTable: "Anounces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnounceOfferrings_Offerrings_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offerrings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Gender", "Name", "Password" },
                values: new object[,]
                {
                    { 3301, 20, "MALE", "Monu", "monu" },
                    { 3302, 22, "MALE", "Abhinav", "abhinav" },
                    { 3306, 24, "MALE", "Sreyash", "sreyash" },
                    { 3305, 21, "FEMALE", "Priya", "priya" },
                    { 3308, 24, "MALE", "Devansh", "devansh" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnounceOfferrings_AnounceId",
                table: "AnounceOfferrings",
                column: "AnounceId");

            migrationBuilder.CreateIndex(
                name: "IX_AnounceOfferrings_OfferId",
                table: "AnounceOfferrings",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Anounces_BookingRef",
                table: "Anounces",
                column: "BookingRef",
                unique: true,
                filter: "[BookingRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Anounces_UserId",
                table: "Anounces",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OfferId",
                table: "Bookings",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offerrings_UserId",
                table: "Offerrings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offerrings_VechicleRef",
                table: "Offerrings",
                column: "VechicleRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViaPoints_OfferId",
                table: "ViaPoints",
                column: "OfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnounceOfferrings");

            migrationBuilder.DropTable(
                name: "ViaPoints");

            migrationBuilder.DropTable(
                name: "Anounces");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Offerrings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vechicles");
        }
    }
}
