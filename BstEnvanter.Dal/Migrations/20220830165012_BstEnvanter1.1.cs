using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class BstEnvanter11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Sex_sexId",
                table: "Personel");

            migrationBuilder.AlterColumn<long>(
                name: "number",
                table: "Service",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "sexId",
                table: "Personel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Sex_sexId",
                table: "Personel",
                column: "sexId",
                principalTable: "Sex",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Sex_sexId",
                table: "Personel");

            migrationBuilder.AlterColumn<int>(
                name: "number",
                table: "Service",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "sexId",
                table: "Personel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Sex_sexId",
                table: "Personel",
                column: "sexId",
                principalTable: "Sex",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
