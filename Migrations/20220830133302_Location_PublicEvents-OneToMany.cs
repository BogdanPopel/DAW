using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW.Migrations
{
    public partial class Location_PublicEventsOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Locations_LocationId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_LocationId",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Adresses");

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PublicEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicEvents_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AdressId",
                table: "Locations",
                column: "AdressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicEvents_LocationId",
                table: "PublicEvents",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Adresses_AdressId",
                table: "Locations",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Adresses_AdressId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "PublicEvents");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AdressId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_LocationId",
                table: "Adresses",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Locations_LocationId",
                table: "Adresses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
