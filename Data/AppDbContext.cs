using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using projekt_SBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.IO;


namespace projekt_SBD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Asystent> Asystenci { get; set; }
        public DbSet<AsystentGodzinyPracy> AsystenciGodzinyPracy { get; set; }
        public DbSet<Stomatolog> Stomatolodzy { get; set; }
        public DbSet<StomatologGodzinyPracy> StomatolodzyGodzinyPracy { get; set; }
        public DbSet<Choroba> Choroby { get; set; }
        public DbSet<Pacjent> Pacjenci { get; set; }
        public DbSet<Uczulenie> Uczulenia { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        public DbSet<WizytaUsluga> WizytyUslugi { get; set; }
        public DbSet<PacjentChoroba> PacjenciChoroby { get; set; }
        public DbSet<PacjentUczulenie> PacjenciUczulenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath("C:\\Users\\User\\source\\repos\\martawiszowata2000\\projekt_SBD")
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ProjektDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asystent>().HasKey(m => m.AsystentId);
            modelBuilder.Entity<AsystentGodzinyPracy>().HasKey(m => m.ZmianaId);
            modelBuilder.Entity<Stomatolog>().HasKey(m => m.StomatologId);
            modelBuilder.Entity<StomatologGodzinyPracy>().HasKey(m => m.ZmianaId);
            modelBuilder.Entity<Choroba>().HasKey(m => m.ChorobaId);
            modelBuilder.Entity<Pacjent>().HasKey(m => m.PacjentId);
            modelBuilder.Entity<Uczulenie>().HasKey(m => m.UczulenieId);
            modelBuilder.Entity<Usluga>().HasKey(m => m.UslugaId);
            modelBuilder.Entity<Wizyta>().HasKey(m => m.WizytaId);

            modelBuilder.Entity<WizytaUsluga>().HasKey(kp => new { kp.WizytaId, kp.UslugaId });
            modelBuilder.Entity<PacjentChoroba>().HasKey(kp => new { kp.PacjentId, kp.ChorobaId });
            modelBuilder.Entity<PacjentUczulenie>().HasKey(kp => new { kp.PacjentId, kp.UczulenieId });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asystent>()
                   .HasMany(b => b.GodzinyPracy)
                   .WithOne();
            modelBuilder.Entity<Stomatolog>()
                   .HasMany(b => b.GodzinyPracy)
                   .WithOne();
            modelBuilder.Entity<Asystent>()
                   .HasMany(b => b.Wizyty)
                   .WithOne();
            modelBuilder.Entity<Stomatolog>()
                   .HasMany(b => b.Wizyty)
                   .WithOne();
            modelBuilder.Entity<Pacjent>()
                   .HasMany(b => b.Wizyty)
                   .WithOne();
            modelBuilder.Entity<WizytaUsluga>()
                .HasOne(b => b.Wizyta)
                .WithMany(b => b.WizytyUslugi)
                .HasForeignKey(b => b.WizytaId);
            modelBuilder.Entity<WizytaUsluga>()
                .HasOne(b => b.Usluga)
                .WithMany(b => b.WizytyUslugi)
                .HasForeignKey(b => b.UslugaId);
            modelBuilder.Entity<PacjentChoroba>()
                .HasOne(b => b.Pacjent)
                .WithMany(b => b.PacjenciChoroby)
                .HasForeignKey(b => b.PacjentId);
            modelBuilder.Entity<PacjentChoroba>()
                .HasOne(b => b.Choroba)
                .WithMany(b => b.PacjenciChoroby)
                .HasForeignKey(b => b.ChorobaId); 
            modelBuilder.Entity<PacjentUczulenie>()
                 .HasOne(b => b.Pacjent)
                 .WithMany(b => b.PacjenciUczulenia)
                 .HasForeignKey(b => b.PacjentId);
            modelBuilder.Entity<PacjentUczulenie>()
                .HasOne(b => b.Uczulenie)
                .WithMany(b => b.PacjenciUczulenia)
                .HasForeignKey(b => b.UczulenieId);
        }
    }
}
