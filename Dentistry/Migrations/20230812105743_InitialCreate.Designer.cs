﻿// <auto-generated />
using System.Collections.Generic;
using Dentistry.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dentistry.Migrations
{
    [DbContext(typeof(ModelDBContext))]
    [Migration("20230812105743_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dentistry.Models.OperationType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("OperationTypeName")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("OperationTypes");
                });

            modelBuilder.Entity("Dentistry.Models.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("OperationNotices")
                        .HasColumnType("text");

                    b.Property<int>("OperationTypeID")
                        .HasColumnType("integer");

                    b.Property<List<int>>("OperationsTeeths")
                        .HasColumnType("integer[]");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("OperationTypeID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Dentistry.Models.Patient", b =>
                {
                    b.HasOne("Dentistry.Models.OperationType", "OperationType")
                        .WithMany()
                        .HasForeignKey("OperationTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationType");
                });
#pragma warning restore 612, 618
        }
    }
}