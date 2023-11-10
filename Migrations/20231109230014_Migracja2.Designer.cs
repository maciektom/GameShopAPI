﻿// <auto-generated />
using System;
using InternetGameShopAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternetGameShopAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231109230014_Migracja2")]
    partial class Migracja2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InternetGameShopAPI.Domain.Game", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Game_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("GameId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("InternetGameShopAPI.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("User_ID");

                    b.Property<DateTime>("DateOfBirth")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2")
                        .HasColumnName("Date Of Birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("InternetGameShopAPI.Domain.UserGames", b =>
                {
                    b.Property<Guid>("Game_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Game_ID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.Property<Guid>("User_id")
                        .HasMaxLength(255)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("User_ID");

                    b.HasKey("Game_id");

                    b.HasIndex("User_id");

                    b.ToTable("UserGames", (string)null);
                });

            modelBuilder.Entity("InternetGameShopAPI.Domain.UserGames", b =>
                {
                    b.HasOne("InternetGameShopAPI.Domain.User", "User")
                        .WithMany("GamesOwned")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InternetGameShopAPI.Domain.User", b =>
                {
                    b.Navigation("GamesOwned");
                });
#pragma warning restore 612, 618
        }
    }
}