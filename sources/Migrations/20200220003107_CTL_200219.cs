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
                    LayoutID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataLayouts", x => x.LayoutID);
                });

            migrationBuilder.CreateTable(
                name: "collectly_v5_dataItems",
                columns: table => new
                {
                    ItemID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    LayoutID = table.Column<long>(nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    CollectionID = table.Column<long>(nullable: true),
                    CollectionSequence = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataItems", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_collectly_v5_dataItems_collectly_v5_dataCollections_CollectionID",
                        column: x => x.CollectionID,
                        principalTable: "collectly_v5_dataCollections",
                        principalColumn: "CollectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_collectly_v5_dataItems_collectly_v5_dataLayouts_LayoutID",
                        column: x => x.LayoutID,
                        principalTable: "collectly_v5_dataLayouts",
                        principalColumn: "LayoutID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "collectly_v5_dataItemProperties",
                columns: table => new
                {
                    ItemPropertyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<long>(nullable: false),
                    LayoutTagID = table.Column<long>(nullable: false),
                    ValueText = table.Column<string>(maxLength: 500, nullable: true),
                    ValueNumeric = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    ValueBoolean = table.Column<bool>(nullable: true),
                    ValueDate = table.Column<DateTime>(nullable: true),
                    ValueUrl = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataItemProperties", x => x.ItemPropertyID);
                    table.ForeignKey(
                        name: "FK_collectly_v5_dataItemProperties_collectly_v5_dataItems_ItemID",
                        column: x => x.ItemID,
                        principalTable: "collectly_v5_dataItems",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collectly_v5_dataItemProperties_collectly_v5_dataLayoutTags_LayoutTagID",
                        column: x => x.LayoutTagID,
                        principalTable: "collectly_v5_dataLayoutTags",
                        principalColumn: "LayoutTagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "collectly_v5_dataItemProperties_index",
                table: "collectly_v5_dataItemProperties",
                column: "ItemID")
                .Annotation("SqlServer:Include", new[] { "ItemPropertyID" });

            migrationBuilder.CreateIndex(
                name: "IX_collectly_v5_dataItemProperties_LayoutTagID",
                table: "collectly_v5_dataItemProperties",
                column: "LayoutTagID");

            migrationBuilder.CreateIndex(
                name: "IX_collectly_v5_dataItems_CollectionID",
                table: "collectly_v5_dataItems",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_collectly_v5_dataItems_LayoutID",
                table: "collectly_v5_dataItems",
                column: "LayoutID");

            migrationBuilder.CreateIndex(
                name: "collectly_v5_dataItems_index",
                table: "collectly_v5_dataItems",
                columns: new[] { "ResourceID", "LayoutID", "CollectionID" })
                .Annotation("SqlServer:Include", new[] { "ItemID" });

            migrationBuilder.CreateIndex(
                name: "collectly_v5_dataLayoutTags_index",
                table: "collectly_v5_dataLayoutTags",
                column: "LayoutID")
                .Annotation("SqlServer:Include", new[] { "LayoutTagID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectly_v5_dataItemProperties");

            migrationBuilder.DropTable(
                name: "collectly_v5_dataItems");

            migrationBuilder.DropTable(
                name: "collectly_v5_dataLayoutTags");

            migrationBuilder.DropTable(
                name: "collectly_v5_dataCollections");

            migrationBuilder.DropTable(
                name: "collectly_v5_dataLayouts");
        }
    }
}
