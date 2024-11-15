﻿// <auto-generated />
using System;
using DatabaseCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseCore.Migrations
{
    [DbContext(typeof(MicroloanDbContext))]
    [Migration("20241114044328_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("Models.Models.MicroloanItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("CurrentSum")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<float>("GeneralDebt")
                        .HasColumnType("REAL");

                    b.Property<Guid>("MoneyId")
                        .HasColumnType("TEXT");

                    b.Property<float>("RateDebt")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("MoneyId");

                    b.ToTable("MicroloanItem");
                });

            modelBuilder.Entity("Models.Models.Money", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MoneyId")
                        .HasColumnType("TEXT");

                    b.Property<float>("Rate")
                        .HasColumnType("REAL");

                    b.Property<float>("Sum")
                        .HasColumnType("REAL");

                    b.Property<uint>("Time")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Moneis");
                });

            modelBuilder.Entity("Models.Models.MicroloanItem", b =>
                {
                    b.HasOne("Models.Models.Money", "Money")
                        .WithMany("Items")
                        .HasForeignKey("MoneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Money");
                });

            modelBuilder.Entity("Models.Models.Money", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
