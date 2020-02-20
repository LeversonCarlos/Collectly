﻿// <auto-generated />
using System;
using Collectly.API.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Collectly.Migrations
{
    [DbContext(typeof(dbContext))]
    partial class dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Collectly.API.Collections.CollectionData", b =>
                {
                    b.Property<long>("CollectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("CollectionID");

                    b.ToTable("collectly_v5_dataCollections");
                });

            modelBuilder.Entity("Collectly.API.Items.ItemData", b =>
                {
                    b.Property<long>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CollectionID")
                        .HasColumnType("bigint");

                    b.Property<short?>("CollectionSequence")
                        .HasColumnType("smallint");

                    b.Property<long>("LayoutID")
                        .HasColumnType("bigint");

                    b.Property<string>("ResourceID")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("ItemID");

                    b.HasIndex("CollectionID");

                    b.HasIndex("LayoutID");

                    b.HasIndex("ResourceID", "LayoutID", "CollectionID")
                        .HasName("collectly_v5_dataItems_index")
                        .HasAnnotation("SqlServer:Include", new[] { "ItemID" });

                    b.ToTable("collectly_v5_dataItems");
                });

            modelBuilder.Entity("Collectly.API.Items.ItemPropertyData", b =>
                {
                    b.Property<long>("ItemPropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ItemID")
                        .HasColumnType("bigint");

                    b.Property<long>("LayoutTagID")
                        .HasColumnType("bigint");

                    b.Property<bool?>("ValueBoolean")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ValueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ValueNumeric")
                        .HasColumnType("decimal(15,4)");

                    b.Property<string>("ValueText")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ValueUrl")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("ItemPropertyID");

                    b.HasIndex("ItemID")
                        .HasName("collectly_v5_dataItemProperties_index")
                        .HasAnnotation("SqlServer:Include", new[] { "ItemPropertyID" });

                    b.HasIndex("LayoutTagID");

                    b.ToTable("collectly_v5_dataItemProperties");
                });

            modelBuilder.Entity("Collectly.API.Layouts.LayoutData", b =>
                {
                    b.Property<long>("LayoutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("LayoutID");

                    b.ToTable("collectly_v5_dataLayouts");
                });

            modelBuilder.Entity("Collectly.API.Layouts.LayoutTagData", b =>
                {
                    b.Property<long>("LayoutTagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LayoutID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Multiple")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<short>("Type")
                        .HasColumnType("smallint");

                    b.HasKey("LayoutTagID");

                    b.HasIndex("LayoutID")
                        .HasName("collectly_v5_dataLayoutTags_index")
                        .HasAnnotation("SqlServer:Include", new[] { "LayoutTagID" });

                    b.ToTable("collectly_v5_dataLayoutTags");
                });

            modelBuilder.Entity("Collectly.API.Items.ItemData", b =>
                {
                    b.HasOne("Collectly.API.Collections.CollectionData", "CollectionDetails")
                        .WithMany()
                        .HasForeignKey("CollectionID");

                    b.HasOne("Collectly.API.Layouts.LayoutData", "LayoutDetails")
                        .WithMany()
                        .HasForeignKey("LayoutID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Collectly.API.Items.ItemPropertyData", b =>
                {
                    b.HasOne("Collectly.API.Items.ItemData", "ItemDetails")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Collectly.API.Layouts.LayoutTagData", "LayoutTagDetails")
                        .WithMany()
                        .HasForeignKey("LayoutTagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Collectly.API.Layouts.LayoutTagData", b =>
                {
                    b.HasOne("Collectly.API.Layouts.LayoutData", "LayoutDetails")
                        .WithMany()
                        .HasForeignKey("LayoutID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
