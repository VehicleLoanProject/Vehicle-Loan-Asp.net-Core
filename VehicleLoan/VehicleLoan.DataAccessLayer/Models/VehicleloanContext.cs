using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleLoan.DataAccessLayer.Models
{
    public partial class VehicleloanContext : DbContext
    {
        public VehicleloanContext()
        {
        }

        public VehicleloanContext(DbContextOptions<VehicleloanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicantDetails> ApplicantDetails { get; set; }
        public virtual DbSet<ApplicationStatus> ApplicationStatus { get; set; }
        public virtual DbSet<IdentityDocuments> IdentityDocuments { get; set; }
        public virtual DbSet<LoanDetails> LoanDetails { get; set; }
        public virtual DbSet<LoanScheme> LoanScheme { get; set; }
        public virtual DbSet<RoleType> RoleType { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= LAPTOP-CTHV3RB5;Database=Vehicleloan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantDetails>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("pk_applicant_details");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AppliedOn).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExistingEmi).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfEmployement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearlySalary).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicantDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_applicant_details");
            });

            modelBuilder.Entity<ApplicationStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("pk_application_status");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IdentityDocuments>(entity =>
            {
                entity.HasKey(e => e.IdentityId)
                    .HasName("pk_identity_documents");

                entity.Property(e => e.Adharcard)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Pancard)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Salaryslip)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.IdentityDocuments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_identity_documents");
            });

            modelBuilder.Entity<LoanDetails>(entity =>
            {
                entity.HasKey(e => e.LoanAppId)
                    .HasName("pk_loan_details");

                entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.LoanDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_loan_details_custid");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.LoanDetails)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_loan_details_status_id");
            });

            modelBuilder.Entity<LoanScheme>(entity =>
            {
                entity.HasKey(e => e.SchemeId)
                    .HasName("pk_loan_scheme");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emi).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaxLoanAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProcessingFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SchemeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.LoanScheme)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_loan_scheme");
            });

            modelBuilder.Entity<RoleType>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("pk_user_type");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_user_registration");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_registration");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.CarMake)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExshowroomPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OnroadPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehicle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
