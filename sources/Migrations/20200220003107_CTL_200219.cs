using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collectly.Migrations
{
    public partial class CTL_200219 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collectly_v5_dataCollections",
                columns: table => new
                {
                    CollectionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataCollections", x => x.CollectionID);
                });

            migrationBuilder.CreateTable(
                name: "collectly_v5_dataLayouts",
                columns: table => new
                {
                    LayoutID = table.Column<string>(nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataLayouts", x => x.LayoutID);
                });

            migrationBuilder.CreateTable(
                name: "collectly_v5_dataTags",
                columns: table => new
                {
                    TagID = table.Column<string>(nullable: false),
                    LayoutID = table.Column<string>(nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<short>(nullable: false),
                    Multiple = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataTags", x => x.TagID);
                    table.ForeignKey(
                        name: "FK_collectly_v5_dataTags_collectly_v5_dataLayouts_LayoutID",
                        column: x => x.LayoutID,
                        principalTable: "collectly_v5_dataLayouts",
                        principalColumn: "LayoutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "collectly_v5_dataTags_index",
                table: "collectly_v5_dataTags",
                column: "LayoutID")
                .Annotation("SqlServer:Include", new[] { "TagID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectly_v5_dataCollections");

            migrationBuilder.DropTable(
                name: "collectly_v5_dataTags");

            migrationBuilder.DropTable(
                name: "collectly_v5_dataLayouts");
        }
    }
}
