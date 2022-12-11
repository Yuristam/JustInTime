﻿// <auto-generated />
using System;
using JustInTime.DAL.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JustInTime.DAL.Migrations
{
    [DbContext(typeof(NotesDbContext))]
    [Migration("20221211155250_Init 30th Migration")]
    partial class Init30thMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.CheckList", b =>
                {
                    b.Property<int>("CheckListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CheckListId"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("CheckListId");

                    b.HasIndex("PersonId");

                    b.ToTable("CheckLists");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.GlobalNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("GlobalNotes");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("PersonId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.ToDo", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToDoId"), 1L, 1);

                    b.Property<int>("CheckListId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ToDoId");

                    b.HasIndex("CheckListId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.CheckList", b =>
                {
                    b.HasOne("JustInTime.DAL.Domain.Entities.Person", "Person")
                        .WithMany("CheckLists")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.Note", b =>
                {
                    b.HasOne("JustInTime.DAL.Domain.Entities.Person", "Person")
                        .WithMany("Notes")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.ToDo", b =>
                {
                    b.HasOne("JustInTime.DAL.Domain.Entities.CheckList", "CheckList")
                        .WithMany("ToDos")
                        .HasForeignKey("CheckListId");

                    b.Navigation("CheckList");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.CheckList", b =>
                {
                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("JustInTime.DAL.Domain.Entities.Person", b =>
                {
                    b.Navigation("CheckLists");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
