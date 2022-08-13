using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BstEnvanter.Dal.Migrations
{
    public partial class YZX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CLocation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLocation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Common",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    cLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common", x => x.id);
                    table.ForeignKey(
                        name: "FK_Common_CLocation_cLocationId",
                        column: x => x.cLocationId,
                        principalTable: "CLocation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Common_Department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    brandId = table.Column<int>(type: "int", nullable: false),
                    modelId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inventoryNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prop1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prop2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prop3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prop4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_brandId",
                        column: x => x.brandId,
                        principalTable: "Brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Model_modelId",
                        column: x => x.modelId,
                        principalTable: "Model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    sexId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    roomNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personel_Department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personel_Sex_sexId",
                        column: x => x.sexId,
                        principalTable: "Sex",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    personelId = table.Column<int>(type: "int", nullable: true),
                    commonId = table.Column<int>(type: "int", nullable: true),
                    campusId = table.Column<int>(type: "int", nullable: false),
                    definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bstId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                    table.ForeignKey(
                        name: "FK_Status_Campus_campusId",
                        column: x => x.campusId,
                        principalTable: "Campus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Status_Common_commonId",
                        column: x => x.commonId,
                        principalTable: "Common",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Status_Personel_personelId",
                        column: x => x.personelId,
                        principalTable: "Personel",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Status_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Common_cLocationId",
                table: "Common",
                column: "cLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Common_departmentId",
                table: "Common",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_departmentId",
                table: "Personel",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_sexId",
                table: "Personel",
                column: "sexId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_brandId",
                table: "Product",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryId",
                table: "Product",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_modelId",
                table: "Product",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_campusId",
                table: "Status",
                column: "campusId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_commonId",
                table: "Status",
                column: "commonId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_personelId",
                table: "Status",
                column: "personelId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_productId",
                table: "Status",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Common");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "CLocation");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Model");
        }
    }
}
