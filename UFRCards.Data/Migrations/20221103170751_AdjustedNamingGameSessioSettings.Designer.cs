﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UFRCards.Data;

#nullable disable

namespace UFRCards.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221103170751_AdjustedNamingGameSessioSettings")]
    partial class AdjustedNamingGameSessioSettings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UFRCards.Data.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AnswerText")
                        .HasColumnType("text");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionCategory")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.GameRound", b =>
                {
                    b.Property<int>("GameSessionId")
                        .HasColumnType("integer");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("GameSessionId", "RoundNumber");

                    b.HasIndex("QuestionId");

                    b.ToTable("GameRound");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.GameSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GameSessionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.PlayerAnswersSelection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("integer");

                    b.Property<int>("GameRoundGameSessionId")
                        .HasColumnType("integer");

                    b.Property<int>("GameRoundId")
                        .HasColumnType("integer");

                    b.Property<int>("GameRoundRoundNumber")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("GameRoundGameSessionId", "GameRoundRoundNumber");

                    b.ToTable("PlayerAnswersSelection");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameSessionId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionCategory")
                        .HasColumnType("integer");

                    b.Property<string>("QuestionText")
                        .HasColumnType("text");

                    b.Property<int>("QuestionType")
                        .HasColumnType("integer");

                    b.Property<int>("SlotsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.Answer", b =>
                {
                    b.HasOne("UFRCards.Data.Entities.Player", null)
                        .WithMany("Answers")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.GameRound", b =>
                {
                    b.HasOne("UFRCards.Data.Entities.GameSession", "GameSession")
                        .WithMany("GameRounds")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UFRCards.Data.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSession");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.GameSession", b =>
                {
                    b.OwnsOne("UFRCards.Data.Entities.GameSessionSettings", "GameSessionSettings", b1 =>
                        {
                            b1.Property<int>("GameSessionId")
                                .HasColumnType("integer");

                            b1.Property<int>("CurrentRound")
                                .HasColumnType("integer");

                            b1.Property<int>("MaxRounds")
                                .HasColumnType("integer");

                            b1.Property<int>("PlayersCount")
                                .HasColumnType("integer");

                            b1.Property<int>("RoundsPassed")
                                .HasColumnType("integer");

                            b1.HasKey("GameSessionId");

                            b1.ToTable("GameSessions");

                            b1.WithOwner()
                                .HasForeignKey("GameSessionId");
                        });

                    b.Navigation("GameSessionSettings");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.Player", b =>
                {
                    b.HasOne("UFRCards.Data.Entities.GameSession", "GameSession")
                        .WithMany("Players")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSession");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.PlayerAnswersSelection", b =>
                {
                    b.HasOne("UFRCards.Data.Entities.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UFRCards.Data.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UFRCards.Data.Entities.GameRound", "GameRound")
                        .WithMany("PlayerAnswersSelections")
                        .HasForeignKey("GameRoundGameSessionId", "GameRoundRoundNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("GameRound");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.Question", b =>
                {
                    b.HasOne("UFRCards.Data.Entities.GameSession", null)
                        .WithMany("Questions")
                        .HasForeignKey("GameSessionId");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.GameRound", b =>
                {
                    b.Navigation("PlayerAnswersSelections");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.GameSession", b =>
                {
                    b.Navigation("GameRounds");

                    b.Navigation("Players");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("UFRCards.Data.Entities.Player", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
