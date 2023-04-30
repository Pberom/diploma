using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElJournal
{
    public partial class ElJournalContext : DbContext
    {
        public ElJournalContext()
        {
        }

        public ElJournalContext(DbContextOptions<ElJournalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Academ> Academ { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Commentary> Commentary { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<NameItem> NameItem { get; set; }
        public virtual DbSet<Practice> Practice { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<ProfessorsItem> ProfessorsItem { get; set; }
        public virtual DbSet<Semestr> Semestr { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<UserStudent> UserStudent { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LUCKY\\SQLEXPRESS;Initial Catalog=ElJournal;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academ>(entity =>
            {
                entity.HasKey(e => e.IdAcadem);

                entity.Property(e => e.IdAcadem).HasColumnName("ID_Academ");

                entity.Property(e => e.DateAcadem)
                    .HasColumnName("Date_Academ")
                    .HasColumnType("date");

                entity.Property(e => e.FioprepodAcadem)
                    .IsRequired()
                    .HasColumnName("FIOPrepod_Academ")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FormControlAcadem)
                    .IsRequired()
                    .HasColumnName("FormControl_Academ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberAcadem)
                    .IsRequired()
                    .HasColumnName("Number_Academ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TerraAcadem)
                    .IsRequired()
                    .HasColumnName("Terra_Academ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeAcadem)
                    .IsRequired()
                    .HasColumnName("Time_Academ")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.CustommarksId).HasColumnName("Custommarks_ID");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.VisitersId).HasColumnName("Visiters_ID");

                entity.HasOne(d => d.Visiters)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.VisitersId)
                    .HasConstraintName("FK_AspNetUsers_Visitor");
            });

            modelBuilder.Entity<Commentary>(entity =>
            {
                entity.HasKey(e => e.IdComm);

                entity.Property(e => e.IdComm).HasColumnName("ID_Comm");

                entity.Property(e => e.AcademId).HasColumnName("Academ_ID");

                entity.Property(e => e.Commentary1)
                    .HasColumnName("Commentary")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PracticeId).HasColumnName("Practice_ID");

                entity.Property(e => e.StudentsDannId).HasColumnName("Students_Dann_ID");

                entity.HasOne(d => d.Academ)
                    .WithMany(p => p.Commentary)
                    .HasForeignKey(d => d.AcademId)
                    .HasConstraintName("FK_Commentary_Academ");

                entity.HasOne(d => d.Practice)
                    .WithMany(p => p.Commentary)
                    .HasForeignKey(d => d.PracticeId)
                    .HasConstraintName("FK_Commentary_Practice");

                entity.HasOne(d => d.StudentsDann)
                    .WithMany(p => p.Commentary)
                    .HasForeignKey(d => d.StudentsDannId)
                    .HasConstraintName("FK_Commentary_Students");
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.Property(e => e.CodeProfessorItemId).HasColumnName("CodeProfessorItem_ID");

                entity.Property(e => e.Evaluation1)
                    .IsRequired()
                    .HasColumnName("Evaluation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SemestrId).HasColumnName("Semestr_ID");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.CodeProfessorItem)
                    .WithMany(p => p.Evaluation)
                    .HasForeignKey(d => d.CodeProfessorItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evaluation_Professors_Item");

                entity.HasOne(d => d.Semestr)
                    .WithMany(p => p.Evaluation)
                    .HasForeignKey(d => d.SemestrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evaluation_Semestr");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Evaluation)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evaluation_Students");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeGroup)
                    .HasColumnName("Code_Group")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameGroup)
                    .HasColumnName("Name_Group")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<NameItem>(entity =>
            {
                entity.ToTable("Name_Item");

                entity.Property(e => e.NameItem1)
                    .IsRequired()
                    .HasColumnName("Name_Item")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Practice>(entity =>
            {
                entity.HasKey(e => e.IdPractice);

                entity.Property(e => e.IdPractice).HasColumnName("ID_Practice");

                entity.Property(e => e.DatePlacePractice)
                    .IsRequired()
                    .HasColumnName("DatePlace_Practice")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FioprepodPractic)
                    .IsRequired()
                    .HasColumnName("FIOPrepod_Practic")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NamePractice)
                    .IsRequired()
                    .HasColumnName("Name_Practice")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumberPractice)
                    .IsRequired()
                    .HasColumnName("Number_Practice")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.F)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.I)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.O)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessorsItem>(entity =>
            {
                entity.ToTable("Professors_Item");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemId).HasColumnName("Item_ID");

                entity.Property(e => e.ProfessorId).HasColumnName("Professor_ID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ProfessorsItem)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_Professors_Item_Name_Item");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.ProfessorsItem)
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("FK_Professors_Item_Professor");
            });

            modelBuilder.Entity<Semestr>(entity =>
            {
                entity.HasKey(e => e.IdSemestr);

                entity.Property(e => e.IdSemestr).HasColumnName("ID_Semestr");

                entity.Property(e => e.NameSemesrt)
                    .HasColumnName("Name_Semesrt")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupId).HasColumnName("Group_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Students_Group");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Students_UserStudent");
            });

            modelBuilder.Entity<UserStudent>(entity =>
            {
                entity.HasKey(e => e.IdUserStudents);

                entity.Property(e => e.IdUserStudents).HasColumnName("ID_UserStudents");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleS)
                    .HasColumnName("Middle_S")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameS)
                    .IsRequired()
                    .HasColumnName("Name_S")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherEmail)
                    .HasColumnName("Other_Email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SecondS)
                    .IsRequired()
                    .HasColumnName("Second_S")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasKey(e => e.IdVisitor);

                entity.Property(e => e.IdVisitor).HasColumnName("Id_Visitor");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
