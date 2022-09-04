using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicEvents_Locations_LocationId",
                table: "PublicEvents");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "PublicEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicEvents_Locations_LocationId",
                table: "PublicEvents",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicEvents_Locations_LocationId",
                table: "PublicEvents");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "PublicEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicEvents_Locations_LocationId",
                table: "PublicEvents",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
