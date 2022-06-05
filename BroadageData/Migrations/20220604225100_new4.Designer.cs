﻿// <auto-generated />
using System;
using BroadageData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BroadageData.Migrations
{
    [DbContext(typeof(BroadageDBContext))]
    [Migration("20220604225100_new4")]
    partial class new4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BroadageEntity.Entities.AwayTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<string>("MediumName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScoreId")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScoreId");

                    b.ToTable("AwayTeams");
                });

            modelBuilder.Entity("BroadageEntity.Entities.HomeTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScoreId")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScoreId");

                    b.ToTable("HomeTeams");
                });

            modelBuilder.Entity("BroadageEntity.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("RoundId")
                        .HasColumnType("int");

                    b.Property<int?>("StageId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("RoundId");

                    b.HasIndex("StageId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BroadageEntity.Entities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("BroadageEntity.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Current")
                        .HasColumnType("int");

                    b.Property<int>("EextraTime")
                        .HasColumnType("int");

                    b.Property<int>("HalfTime")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("Penalties")
                        .HasColumnType("int");

                    b.Property<int>("Regular")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("BroadageEntity.Entities.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("BroadageEntity.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("BroadageEntity.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("BroadageEntity.Entities.AwayTeam", b =>
                {
                    b.HasOne("BroadageEntity.Entities.Score", "Score")
                        .WithMany("AwayTeams")
                        .HasForeignKey("ScoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Score");
                });

            modelBuilder.Entity("BroadageEntity.Entities.HomeTeam", b =>
                {
                    b.HasOne("BroadageEntity.Entities.Score", "Score")
                        .WithMany("HomeTeams")
                        .HasForeignKey("ScoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Score");
                });

            modelBuilder.Entity("BroadageEntity.Entities.Match", b =>
                {
                    b.HasOne("BroadageEntity.Entities.AwayTeam", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId");

                    b.HasOne("BroadageEntity.Entities.HomeTeam", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId");

                    b.HasOne("BroadageEntity.Entities.Round", "Round")
                        .WithMany()
                        .HasForeignKey("RoundId");

                    b.HasOne("BroadageEntity.Entities.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId");

                    b.HasOne("BroadageEntity.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("BroadageEntity.Entities.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId");

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("Round");

                    b.Navigation("Stage");

                    b.Navigation("Status");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("BroadageEntity.Entities.Score", b =>
                {
                    b.Navigation("AwayTeams");

                    b.Navigation("HomeTeams");
                });
#pragma warning restore 612, 618
        }
    }
}
