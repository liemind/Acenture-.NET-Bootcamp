﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Salvo.Models;

namespace Salvo.Migrations
{
    [DbContext(typeof(SalvoContext))]
    partial class SalvoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Salvo.Models.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Salvo.Models.GamePlayer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GameId");

                    b.Property<DateTime?>("JoinDate")
                        .IsRequired();

                    b.Property<long>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("Salvo.Models.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Salvo.Models.Salvo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GamePlayerId");

                    b.Property<int>("Turn");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayerId");

                    b.ToTable("Salvos");
                });

            modelBuilder.Entity("Salvo.Models.SalvoLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cell");

                    b.Property<long>("SalvoId");

                    b.HasKey("Id");

                    b.HasIndex("SalvoId");

                    b.ToTable("SalvoLocations");
                });

            modelBuilder.Entity("Salvo.Models.Score", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FinishDate");

                    b.Property<long>("GameId");

                    b.Property<long>("PlayerId");

                    b.Property<double>("Point");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Salvo.Models.Ship", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GamePlayerId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayerId");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("Salvo.Models.ShipLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location");

                    b.Property<long>("ShipId");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.ToTable("ShipLocations");
                });

            modelBuilder.Entity("Salvo.Models.GamePlayer", b =>
                {
                    b.HasOne("Salvo.Models.Game", "Game")
                        .WithMany("GamePlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Salvo.Models.Player", "Player")
                        .WithMany("GamePlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salvo.Models.Salvo", b =>
                {
                    b.HasOne("Salvo.Models.GamePlayer", "GamePlayer")
                        .WithMany("Salvos")
                        .HasForeignKey("GamePlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salvo.Models.SalvoLocation", b =>
                {
                    b.HasOne("Salvo.Models.Salvo", "Salvo")
                        .WithMany("Locations")
                        .HasForeignKey("SalvoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salvo.Models.Score", b =>
                {
                    b.HasOne("Salvo.Models.Game", "Game")
                        .WithMany("Scores")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Salvo.Models.Player", "Player")
                        .WithMany("Scores")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salvo.Models.Ship", b =>
                {
                    b.HasOne("Salvo.Models.GamePlayer", "GamePlayer")
                        .WithMany("Ships")
                        .HasForeignKey("GamePlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salvo.Models.ShipLocation", b =>
                {
                    b.HasOne("Salvo.Models.Ship", "Ship")
                        .WithMany("Locations")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
