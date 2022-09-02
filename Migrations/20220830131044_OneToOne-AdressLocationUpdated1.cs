using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW.Migrations
{
    public partial class OneToOneAdressLocationUpdated1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Adresses_AdressId",
                table: "Locations");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AdressId",
                table: "Locations",
                column: "AdressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Adresses_AdressId",
                table: "Locations",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
