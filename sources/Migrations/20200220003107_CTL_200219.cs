using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collectly.Migrations
{
    public partial class CTL_200219 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collectly_v5_dataLayouts",
                columns: table => new
                {
                    LayoutID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataLayouts", x => x.LayoutID);
                });

            migrationBuilder.CreateTable(
                name: "collectly_v5_dataLayoutTags",
                columns: table => new
                {
                    LayoutTagID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutID = table.Column<long>(nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<short>(nullable: false),
                    Multiple = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataLayoutTags", x => x.LayoutTagID);
                    table.ForeignKey(
                        name: "FK_collectly_v5_dataLayoutTags_collectly_v5_dataLayouts_LayoutID",
                        column: x => x.LayoutID,
                        principalTable: "collectly_v5_dataLayouts",
                        principalColumn: "LayoutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "collectly_v5_dataLayoutTags_index_Layout",
                table: "collectly_v5_dataLayoutTags",
                column: "LayoutID")
                .Annotation("SqlServer:Include", new[] { "LayoutTagID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectly_v5_dataLayoutTags");

            migrationBuilder.DropTable(
                name: "collectly_v5_dataLayouts");
        }
    }
}
