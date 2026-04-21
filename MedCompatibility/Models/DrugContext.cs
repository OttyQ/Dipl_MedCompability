using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Models;

public partial class DrugContext : DbContext
{
    public DrugContext(DbContextOptions<DrugContext> options)
        : base(options)
    {
    }

    public virtual DbSet<activesubstance> activesubstances { get; set; }

    public virtual DbSet<analysis> analyses { get; set; }

    public virtual DbSet<interaction> interactions { get; set; }

    public virtual DbSet<interactiontype> interactiontypes { get; set; }

    public virtual DbSet<manufacturer> manufacturers { get; set; }

    public virtual DbSet<medicine> medicines { get; set; }

    public virtual DbSet<prescription> prescriptions { get; set; }

    public virtual DbSet<risklevel> risklevels { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<scan> scans { get; set; }

    public virtual DbSet<user> users { get; set; }
    
    public virtual DbSet<doctor_patient> doctor_patient { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<activesubstance>(entity =>
        {
            entity.HasKey(e => e.SubstanceId).HasName("PRIMARY");

            entity.ToTable("activesubstance");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<analysis>(entity =>
        {
            entity.HasKey(e => e.AnalysisId).HasName("PRIMARY");

            entity.ToTable("analysis");

            entity.HasIndex(e => e.UserId, "FK_Analysis_User");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.analyses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Analysis_User");

            entity.HasMany(d => d.Interactions).WithMany(p => p.Analyses)
                .UsingEntity<Dictionary<string, object>>(
                    "analysisresult",
                    r => r.HasOne<interaction>().WithMany()
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AR_Interaction"),
                    l => l.HasOne<analysis>().WithMany()
                        .HasForeignKey("AnalysisId")
                        .HasConstraintName("FK_AR_Analysis"),
                    j =>
                    {
                        j.HasKey("AnalysisId", "InteractionId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("analysisresult");
                        j.HasIndex(new[] { "InteractionId" }, "FK_AR_Interaction");
                    });
        });

        modelBuilder.Entity<interaction>(entity =>
        {
            entity.HasKey(e => e.InteractionId).HasName("PRIMARY");

            entity.ToTable("interaction");

            entity.HasIndex(e => e.RiskLevelId, "FK_Interaction_Risk");

            entity.HasIndex(e => e.SubstanceId2, "FK_Interaction_Sub2");

            entity.HasIndex(e => e.InteractionTypeId, "FK_Interaction_Type");

            entity.HasIndex(e => new { e.SubstanceId1, e.SubstanceId2 }, "UK_Interaction_Pair").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Recommendation).HasColumnType("text");

            entity.HasOne(d => d.InteractionType).WithMany(p => p.interactions)
                .HasForeignKey(d => d.InteractionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interaction_Type");

            entity.HasOne(d => d.RiskLevel).WithMany(p => p.interactions)
                .HasForeignKey(d => d.RiskLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interaction_Risk");

            entity.HasOne(d => d.SubstanceId1Navigation).WithMany(p => p.interactionSubstanceId1Navigations)
                .HasForeignKey(d => d.SubstanceId1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interaction_Sub1");

            entity.HasOne(d => d.SubstanceId2Navigation).WithMany(p => p.interactionSubstanceId2Navigations)
                .HasForeignKey(d => d.SubstanceId2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interaction_Sub2");
        });

        modelBuilder.Entity<interactiontype>(entity =>
        {
            entity.HasKey(e => e.InteractionTypeId).HasName("PRIMARY");

            entity.ToTable("interactiontype");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PRIMARY");

            entity.ToTable("manufacturer");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Республика Беларусь'");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<medicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("PRIMARY");

            entity.ToTable("medicine");

            entity.HasIndex(e => e.ManufacturerId, "FK_Medicine_Manufacturer");

            entity.HasIndex(e => e.GTIN, "GTIN").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Form).HasMaxLength(50);
            entity.Property(e => e.GTIN).HasMaxLength(14);
            entity.Property(e => e.INN).HasMaxLength(200);
            entity.Property(e => e.TradeName).HasMaxLength(200);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.medicines)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Manufacturer");

            entity.HasMany(d => d.Substances).WithMany(p => p.Medicines)
                .UsingEntity<Dictionary<string, object>>(
                    "medicinesubstance",
                    r => r.HasOne<activesubstance>().WithMany()
                        .HasForeignKey("SubstanceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MS_Substance"),
                    l => l.HasOne<medicine>().WithMany()
                        .HasForeignKey("MedicineId")
                        .HasConstraintName("FK_MS_Medicine"),
                    j =>
                    {
                        j.HasKey("MedicineId", "SubstanceId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("medicinesubstance");
                        j.HasIndex(new[] { "SubstanceId" }, "FK_MS_Substance");
                    });
        });

        // ==========================================================
        // ОБНОВЛЕННАЯ СЕКЦИЯ PRESCRIPTION (ДАТЫ, ДОЗИРОВКА)
        // ==========================================================
        modelBuilder.Entity<prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PRIMARY");

            entity.ToTable("prescription");

            entity.HasIndex(e => e.DoctorId, "FK_Prescription_Doctor");
            entity.HasIndex(e => e.MedicineId, "FK_Prescription_Medicine");
            entity.HasIndex(e => new { e.PatientId, e.PrescribedAt }, "IX_Prescription_Patient_Date");

            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PrescribedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            
            // --- НОВЫЕ ПОЛЯ ---
            entity.Property(e => e.StartDate).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.EndDate).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Dosage).HasMaxLength(100);
            // ------------------

            entity.HasOne(d => d.Doctor).WithMany(p => p.prescriptionDoctors)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Doctor");

            entity.HasOne(d => d.Medicine).WithMany(p => p.prescriptions)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Medicine");

            entity.HasOne(d => d.Patient).WithMany(p => p.prescriptionPatients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Patient");
        });

        modelBuilder.Entity<risklevel>(entity =>
        {
            entity.HasKey(e => e.RiskLevelId).HasName("PRIMARY");

            entity.ToTable("risklevel");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<scan>(entity =>
        {
            entity.HasKey(e => e.ScanId).HasName("PRIMARY");

            entity.ToTable("scan");

            entity.HasIndex(e => e.MedicineId, "FK_Scan_Medicine");

            entity.HasIndex(e => new { e.UserId, e.ScannedAt }, "IX_Scan_User_Date");

            entity.Property(e => e.ScannedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Medicine).WithMany(p => p.scans)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scan_Medicine");

            entity.HasOne(d => d.User).WithMany(p => p.scans)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Scan_User");
        });

        modelBuilder.Entity<user>(entity =>
{
    entity.HasKey(e => e.UserId).HasName("PRIMARY");

    entity.ToTable("user");

    entity.HasIndex(e => e.RoleId, "FK_User_Role");
    entity.HasIndex(e => e.Login, "IX_User_Login").IsUnique();
    entity.HasIndex(e => new { e.LastName, e.FirstName, e.MiddleName }, "IX_User_Name");

    entity.Property(e => e.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("datetime");
    entity.Property(e => e.FirstName).HasMaxLength(50);
    entity.Property(e => e.IsApproved).HasDefaultValueSql("'0'");
    entity.Property(e => e.LastName).HasMaxLength(50);
    entity.Property(e => e.Login).HasMaxLength(50);
    entity.Property(e => e.MiddleName).HasMaxLength(50);
    entity.Property(e => e.PasswordHash).HasMaxLength(255);

    entity.HasOne(d => d.Role).WithMany(p => p.users)
        .HasForeignKey(d => d.RoleId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_User_Role");

    // ==========================================================
    // НОВАЯ СЕКЦИЯ: АЛЛЕРГИИ (МНОГИЕ-КО-МНОГИМ)
    // ==========================================================
    entity.HasMany(d => d.Allergies)
        .WithMany(p => p.AllergicUsers)
        .UsingEntity<Dictionary<string, object>>(
            "user_allergy", 
            r => r.HasOne<activesubstance>().WithMany()
                .HasForeignKey("SubstanceId")
                .OnDelete(DeleteBehavior.Cascade) // Явное каскадное удаление, как в SQL
                .HasConstraintName("FK_UA_Substance"),
            l => l.HasOne<user>().WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade) // Явное каскадное удаление, как в SQL
                .HasConstraintName("FK_UA_User"),
            j =>
            {
                j.HasKey("UserId", "SubstanceId");
                j.ToTable("user_allergy");
                j.HasIndex(new[] { "SubstanceId" }, "FK_UA_Substance");
            });
});
        
        // ==========================================================
        // НОВАЯ СЕКЦИЯ DOCTOR_PATIENT (МНОГИЕ-КО-МНОГИМ)
        // ==========================================================
        modelBuilder.Entity<doctor_patient>(entity =>
        {
            entity.HasKey(e => new { e.DoctorId, e.PatientId }).HasName("PRIMARY");

            entity.ToTable("doctor_patient");

            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Doctor).WithMany()
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DP_Doctor");

            entity.HasOne(d => d.Patient).WithMany()
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DP_Patient");
        });

        //фильтры для удаления
        modelBuilder.Entity<user>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<medicine>().HasQueryFilter(m => !m.IsDeleted);
        
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
