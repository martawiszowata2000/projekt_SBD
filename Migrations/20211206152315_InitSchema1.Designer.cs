﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projekt_SBD.Data;

namespace projekt_SBD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211206152315_InitSchema1")]
    partial class InitSchema1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("projekt_SBD.Models.Asystent", b =>
                {
                    b.Property<int>("AsystentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DrugieImie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AsystentId");

                    b.ToTable("Asystenci");
                });

            modelBuilder.Entity("projekt_SBD.Models.AsystentGodzinyPracy", b =>
                {
                    b.Property<int>("ZmianaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AsystentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Koniec")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Poczatek")
                        .HasColumnType("datetime2");

                    b.HasKey("ZmianaId");

                    b.HasIndex("AsystentId");

                    b.ToTable("AsystenciGodzinyPracy");
                });

            modelBuilder.Entity("projekt_SBD.Models.Choroba", b =>
                {
                    b.Property<int>("ChorobaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazwaChoroby")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChorobaId");

                    b.ToTable("Choroby");
                });

            modelBuilder.Entity("projekt_SBD.Models.Pacjent", b =>
                {
                    b.Property<int>("PacjentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumerTelefonu")
                        .HasColumnType("int");

                    b.Property<int>("PESEL")
                        .HasColumnType("int");

                    b.HasKey("PacjentId");

                    b.ToTable("Pacjenci");
                });

            modelBuilder.Entity("projekt_SBD.Models.PacjentChoroba", b =>
                {
                    b.Property<int>("PacjentId")
                        .HasColumnType("int");

                    b.Property<int>("ChorobaId")
                        .HasColumnType("int");

                    b.HasKey("PacjentId", "ChorobaId");

                    b.HasIndex("ChorobaId");

                    b.ToTable("PacjenciChoroby");
                });

            modelBuilder.Entity("projekt_SBD.Models.PacjentUczulenie", b =>
                {
                    b.Property<int>("PacjentId")
                        .HasColumnType("int");

                    b.Property<int>("UczulenieId")
                        .HasColumnType("int");

                    b.HasKey("PacjentId", "UczulenieId");

                    b.HasIndex("UczulenieId");

                    b.ToTable("PacjenciUczulenia");
                });

            modelBuilder.Entity("projekt_SBD.Models.Stomatolog", b =>
                {
                    b.Property<int>("StomatologId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DrugieImie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StomatologId");

                    b.ToTable("Stomatolodzy");
                });

            modelBuilder.Entity("projekt_SBD.Models.StomatologGodzinyPracy", b =>
                {
                    b.Property<int>("ZmianaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Koniec")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Poczatek")
                        .HasColumnType("datetime2");

                    b.Property<int>("StomatologId")
                        .HasColumnType("int");

                    b.HasKey("ZmianaId");

                    b.HasIndex("StomatologId");

                    b.ToTable("StomatolodzyGodzinyPracy");
                });

            modelBuilder.Entity("projekt_SBD.Models.Uczulenie", b =>
                {
                    b.Property<int>("UczulenieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazwaAlergenu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UczulenieId");

                    b.ToTable("Uczulenia");
                });

            modelBuilder.Entity("projekt_SBD.Models.Usluga", b =>
                {
                    b.Property<int>("UslugaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cena")
                        .HasColumnType("real");

                    b.Property<string>("UslugaNazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UslugaId");

                    b.ToTable("Uslugi");
                });

            modelBuilder.Entity("projekt_SBD.Models.Wizyta", b =>
                {
                    b.Property<int>("WizytaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AsystentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataGodzina")
                        .HasColumnType("datetime2");

                    b.Property<int>("PacjentId")
                        .HasColumnType("int");

                    b.Property<int>("StomatologId")
                        .HasColumnType("int");

                    b.HasKey("WizytaId");

                    b.HasIndex("AsystentId");

                    b.HasIndex("PacjentId");

                    b.HasIndex("StomatologId");

                    b.ToTable("Wizyty");
                });

            modelBuilder.Entity("projekt_SBD.Models.WizytaUsluga", b =>
                {
                    b.Property<int>("WizytaId")
                        .HasColumnType("int");

                    b.Property<int>("UslugaId")
                        .HasColumnType("int");

                    b.HasKey("WizytaId", "UslugaId");

                    b.HasIndex("UslugaId");

                    b.ToTable("WizytyUslugi");
                });

            modelBuilder.Entity("projekt_SBD.Models.AsystentGodzinyPracy", b =>
                {
                    b.HasOne("projekt_SBD.Models.Asystent", null)
                        .WithMany("GodzinyPracy")
                        .HasForeignKey("AsystentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("projekt_SBD.Models.PacjentChoroba", b =>
                {
                    b.HasOne("projekt_SBD.Models.Choroba", "Choroba")
                        .WithMany("PacjenciChoroby")
                        .HasForeignKey("ChorobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt_SBD.Models.Pacjent", "Pacjent")
                        .WithMany("PacjenciChoroby")
                        .HasForeignKey("PacjentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("projekt_SBD.Models.PacjentUczulenie", b =>
                {
                    b.HasOne("projekt_SBD.Models.Pacjent", "Pacjent")
                        .WithMany("PacjenciUczulenia")
                        .HasForeignKey("PacjentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt_SBD.Models.Uczulenie", "Uczulenie")
                        .WithMany("PacjenciUczulenia")
                        .HasForeignKey("UczulenieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("projekt_SBD.Models.StomatologGodzinyPracy", b =>
                {
                    b.HasOne("projekt_SBD.Models.Stomatolog", null)
                        .WithMany("GodzinyPracy")
                        .HasForeignKey("StomatologId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("projekt_SBD.Models.Wizyta", b =>
                {
                    b.HasOne("projekt_SBD.Models.Asystent", null)
                        .WithMany("Wizyty")
                        .HasForeignKey("AsystentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt_SBD.Models.Pacjent", null)
                        .WithMany("Wizyty")
                        .HasForeignKey("PacjentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt_SBD.Models.Stomatolog", null)
                        .WithMany("Wizyty")
                        .HasForeignKey("StomatologId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("projekt_SBD.Models.WizytaUsluga", b =>
                {
                    b.HasOne("projekt_SBD.Models.Usluga", "Usluga")
                        .WithMany("WizytyUslugi")
                        .HasForeignKey("UslugaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt_SBD.Models.Wizyta", "Wizyta")
                        .WithMany("WizytyUslugi")
                        .HasForeignKey("WizytaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
