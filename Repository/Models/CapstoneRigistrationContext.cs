using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.Models
{
	public partial class CapstoneRigistrationContext : DbContext
	{
		public CapstoneRigistrationContext()
		{
		}

		public CapstoneRigistrationContext(DbContextOptions<CapstoneRigistrationContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Group> Groups { get; set; } = null!;
		public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;
		public virtual DbSet<LecturerInGroup> LecturerInGroups { get; set; } = null!;
		public virtual DbSet<Semester> Semesters { get; set; } = null!;
		public virtual DbSet<Student> Students { get; set; } = null!;
		public virtual DbSet<StudentInGroup> StudentInGroups { get; set; } = null!;
		public virtual DbSet<StudentInSemester> StudentInSemesters { get; set; } = null!;
		public virtual DbSet<Topic> Topics { get; set; } = null!;
		public virtual DbSet<TopicOfLecturer> TopicOfLecturers { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(GetConnectionString());
		}

		public string GetConnectionString()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfiguration configuration = builder.Build();
			return configuration.GetConnectionString("DefaultConnection");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Group>(entity =>
			{
				entity.ToTable("Group");

				entity.Property(e => e.Name).HasMaxLength(50);

				entity.HasOne(d => d.LeaderNavigation)
					.WithMany(p => p.Groups)
					.HasForeignKey(d => d.Leader)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKGroup668588");

				entity.HasOne(d => d.Semester)
					.WithMany(p => p.Groups)
					.HasForeignKey(d => d.SemesterId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKGroup667084");

				entity.HasOne(d => d.Topic)
					.WithMany(p => p.Groups)
					.HasForeignKey(d => d.TopicId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKGroup466710");
			});

			modelBuilder.Entity<Lecturer>(entity =>
			{
				entity.ToTable("Lecturer");

				entity.Property(e => e.Code)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Name).HasMaxLength(50);

				entity.Property(e => e.Password)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<LecturerInGroup>(entity =>
			{
				entity.ToTable("LecturerInGroup");

				entity.HasOne(d => d.Group)
					.WithMany(p => p.LecturerInGroups)
					.HasForeignKey(d => d.GroupId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKLecturerIn304804");

				entity.HasOne(d => d.InMainLecturerNavigation)
					.WithMany(p => p.LecturerInGroupInMainLecturerNavigations)
					.HasForeignKey(d => d.InMainLecturer)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKLecturerIn121503");

				entity.HasOne(d => d.Lecturer)
					.WithMany(p => p.LecturerInGroupLecturers)
					.HasForeignKey(d => d.LecturerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKLecturerIn674099");
			});

			modelBuilder.Entity<Semester>(entity =>
			{
				entity.ToTable("Semester");

				entity.HasIndex(e => e.Name, "UQ__Semester__737584F66A3EA0A6")
					.IsUnique();

				entity.Property(e => e.EndDate).HasColumnType("date");

				entity.Property(e => e.Name)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.StartDate).HasColumnType("date");
			});

			modelBuilder.Entity<Student>(entity =>
			{
				entity.ToTable("Student");

				entity.HasIndex(e => e.Code, "UQ__Student__A25C5AA7CAC93335")
					.IsUnique();

				entity.Property(e => e.Avatar)
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.Code)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.DateOfBirth).HasColumnType("date");

				entity.Property(e => e.FullName).HasMaxLength(50);
			});

			modelBuilder.Entity<StudentInGroup>(entity =>
			{
				entity.ToTable("StudentInGroup");

				entity.HasOne(d => d.Group)
					.WithMany(p => p.StudentInGroups)
					.HasForeignKey(d => d.GroupId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKStudentInG346740");

				entity.HasOne(d => d.Student)
					.WithMany(p => p.StudentInGroups)
					.HasForeignKey(d => d.StudentId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKStudentInG305462");
			});

			modelBuilder.Entity<StudentInSemester>(entity =>
			{
				entity.ToTable("StudentInSemester");

				entity.HasOne(d => d.Semester)
					.WithMany(p => p.StudentInSemesters)
					.HasForeignKey(d => d.SemesterId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKStudentInS617386");

				entity.HasOne(d => d.Student)
					.WithMany(p => p.StudentInSemesters)
					.HasForeignKey(d => d.StudentId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKStudentInS871375");
			});

			modelBuilder.Entity<Topic>(entity =>
			{
				entity.ToTable("Topic");

				entity.Property(e => e.CreateDate).HasColumnType("date");

				entity.Property(e => e.Description)
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.Name)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.HasOne(d => d.Semester)
					.WithMany(p => p.Topics)
					.HasForeignKey(d => d.SemesterId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKTopic750096");
			});

			modelBuilder.Entity<TopicOfLecturer>(entity =>
			{
				entity.ToTable("TopicOfLecturer");

				entity.HasOne(d => d.Lecturer)
					.WithMany(p => p.TopicOfLecturers)
					.HasForeignKey(d => d.LecturerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKTopicOfLec966583");

				entity.HasOne(d => d.Topic)
					.WithMany(p => p.TopicOfLecturers)
					.HasForeignKey(d => d.TopicId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKTopicOfLec108276");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
