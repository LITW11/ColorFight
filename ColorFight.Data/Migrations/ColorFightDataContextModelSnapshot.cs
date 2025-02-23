﻿// <auto-generated />
using ColorFight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ColorFight.Data.Migrations
{
    [DbContext(typeof(ColorFightDataContext))]
    partial class ColorFightDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ColorFight.Data.ColorStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ColorStats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 1,
                            Name = "Primary"
                        },
                        new
                        {
                            Id = 2,
                            Count = 1,
                            Name = "Secondary"
                        },
                        new
                        {
                            Id = 3,
                            Count = 1,
                            Name = "Success"
                        },
                        new
                        {
                            Id = 4,
                            Count = 1,
                            Name = "Danger"
                        },
                        new
                        {
                            Id = 5,
                            Count = 1,
                            Name = "Warning"
                        },
                        new
                        {
                            Id = 6,
                            Count = 1,
                            Name = "Info"
                        },
                        new
                        {
                            Id = 7,
                            Count = 1,
                            Name = "Light"
                        },
                        new
                        {
                            Id = 8,
                            Count = 1,
                            Name = "Dark"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
