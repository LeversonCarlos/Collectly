﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collectly.Migrations
{
    public partial class CTL_200301 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collectly_v5_dataItems",
                columns: table => new
                {
                    ItemID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    LayoutID = table.Column<string>(nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    CollectionID = table.Column<long>(nullable: true),
                    CollectionSequence = table.Column<short>(nullable: true),
                    OriginalItemID = table.Column<long>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "collectly_v5_dataProperties",
                columns: table => new
                {
                    PropertyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<long>(nullable: false),
                    TagID = table.Column<string>(nullable: false),
                    ValueText = table.Column<string>(maxLength: 500, nullable: true),
                    ValueNumeric = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    ValueBoolean = table.Column<bool>(nullable: true),
                    ValueDate = table.Column<DateTime>(nullable: true),
                    ValueUrl = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectly_v5_dataProperties", x => x.PropertyID);
                    table.ForeignKey(
                        name: "FK_collectly_v5_dataProperties_collectly_v5_dataItems_ItemID",
                        column: x => x.ItemID,
                        principalTable: "collectly_v5_dataItems",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collectly_v5_dataProperties_collectly_v5_dataTags_TagID",
                        column: x => x.TagID,
                        principalTable: "collectly_v5_dataTags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collectly_v5_dataItems_CollectionID",
                table: "collectly_v5_dataItems",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "collectly_v5_dataItems_index",
                table: "collectly_v5_dataItems",
                columns: new[] { "ResourceID", "LayoutID", "CollectionID" })
                .Annotation("SqlServer:Include", new[] { "ItemID" });

            migrationBuilder.CreateIndex(
                name: "collectly_v5_dataProperties_index",
                table: "collectly_v5_dataProperties",
                column: "ItemID")
                .Annotation("SqlServer:Include", new[] { "PropertyID" });

            migrationBuilder.CreateIndex(
                name: "IX_collectly_v5_dataProperties_TagID",
                table: "collectly_v5_dataProperties",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectly_v5_dataProperties");

            migrationBuilder.DropTable(
                name: "collectly_v5_dataItems");
        }
    }
}