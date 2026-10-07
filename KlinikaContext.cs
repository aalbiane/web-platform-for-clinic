using System;
using System.Collections.Generic;
using Klinika.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Klinika;

public partial class KlinikaContext : DbContext
{
    public KlinikaContext()
    {
    }

    public KlinikaContext(DbContextOptions<KlinikaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Klinika> Klinikas { get; set; }

    public virtual DbSet<Medsestra> Medsestras { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientZaklyuchenie> PatientZaklyuchenies { get; set; }

    public virtual DbSet<Vrach> Vraches { get; set; }

    public virtual DbSet<VrachPatient> VrachPatients { get; set; }

    public virtual DbSet<Zaklyuchenie> Zaklyuchenies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=klinika;Username=postgres;Password=khasmutdinova05");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Klinika>(entity =>
        {
            entity.HasKey(e => e.NumberKlinik).HasName("klinika_pkey");

            entity.ToTable("klinika");

            entity.Property(e => e.NumberKlinik)
                .ValueGeneratedNever()
                .HasColumnName("number_klinik");
            entity.Property(e => e.Address)
                .HasMaxLength(254)
                .HasColumnName("address");
            entity.Property(e => e.NameKlinik)
                .HasMaxLength(50)
                .HasColumnName("name_klinik");
        });

        modelBuilder.Entity<Medsestra>(entity =>
        {
            entity.HasKey(e => e.Fio).HasName("medsestra_pkey");

            entity.ToTable("medsestra");

            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("fio");
            entity.Property(e => e.NumberTelephone).HasColumnName("number_telephone");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.TabNum).HasColumnName("tab_num");

            entity.HasOne(d => d.TabNumNavigation).WithMany(p => p.Medsestras)
                .HasForeignKey(d => d.TabNum)
                .HasConstraintName("medsestra_tab_num_fkey");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient).HasName("patient_pkey");

            entity.ToTable("patient");

            entity.Property(e => e.IdPatient)
                .ValueGeneratedNever()
                .HasColumnName("id_patient");
            entity.Property(e => e.PassportDannye)
                .HasMaxLength(254)
                .HasColumnName("passport_dannye");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        modelBuilder.Entity<PatientZaklyuchenie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("patient_zaklyuchenie");

            entity.Property(e => e.IdPatt).HasColumnName("id_patt");
            entity.Property(e => e.IdZakl).HasColumnName("id_zakl");

            entity.HasOne(d => d.IdPattNavigation).WithMany()
                .HasForeignKey(d => d.IdPatt)
                .HasConstraintName("patient_zaklyuchenie_id_patt_fkey");

            entity.HasOne(d => d.IdZaklNavigation).WithMany()
                .HasForeignKey(d => d.IdZakl)
                .HasConstraintName("patient_zaklyuchenie_id_zakl_fkey");
        });

        modelBuilder.Entity<Vrach>(entity =>
        {
            entity.HasKey(e => e.TabN).HasName("vrach_pkey");

            entity.ToTable("vrach");

            entity.Property(e => e.TabN)
                .ValueGeneratedNever()
                .HasColumnName("tab_n");
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("fio");
            entity.Property(e => e.NLklinik).HasColumnName("n_lklinik");
            entity.Property(e => e.NumberTelephone).HasColumnName("number_telephone");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Speciality)
                .HasMaxLength(254)
                .HasColumnName("speciality");

            entity.HasOne(d => d.NLklinikNavigation).WithMany(p => p.Vraches)
                .HasForeignKey(d => d.NLklinik)
                .HasConstraintName("vrach_n_lklinik_fkey");
        });

        modelBuilder.Entity<VrachPatient>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("vrach_patient");

            entity.Property(e => e.IdPat).HasColumnName("id_pat");
            entity.Property(e => e.TabbN).HasColumnName("tabb_n");

            entity.HasOne(d => d.IdPatNavigation).WithMany()
                .HasForeignKey(d => d.IdPat)
                .HasConstraintName("vrach_patient_id_pat_fkey");

            entity.HasOne(d => d.TabbNNavigation).WithMany()
                .HasForeignKey(d => d.TabbN)
                .HasConstraintName("vrach_patient_tabb_n_fkey");
        });

        modelBuilder.Entity<Zaklyuchenie>(entity =>
        {
            entity.HasKey(e => e.IdZaklyuchenie).HasName("zaklyuchenie_pkey");

            entity.ToTable("zaklyuchenie");

            entity.Property(e => e.IdZaklyuchenie)
                .ValueGeneratedNever()
                .HasColumnName("id_zaklyuchenie");
            entity.Property(e => e.Diagnoz)
                .HasMaxLength(254)
                .HasColumnName("diagnoz");
            entity.Property(e => e.FioPatient)
                .HasMaxLength(254)
                .HasColumnName("fio_patient");
            entity.Property(e => e.SposobLechenie)
                .HasMaxLength(254)
                .HasColumnName("sposob_lechenie");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
