using MadreseV6.Domain.ManyToMany.StudentsCourse;
using MadreseV6.Domain.ManyToMany.TeachersGrade;
using MadreseV6.Domain.SchoolAggregate;
using MadreseV6.Domain.StudentAggregate;
using MadreseV6.Domain.TeacherAggregate;
using Microsoft.EntityFrameworkCore;

namespace MadreseV6.DataBase
{
    public class MadreseDbContext : DbContext
    {

        public MadreseDbContext(DbContextOptions<MadreseDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(s => s.SchoolId);

                entity.Property(s => s.SchoolName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.PhoneNumber)
                      .HasMaxLength(20);

                entity.Property(s => s.CreationDate)
                      .HasColumnType("date");

                entity.HasMany(s => s.Grades)
                       .WithOne(g => g.School)
                       .HasForeignKey(g => g.SchoolId)
                       .OnDelete(DeleteBehavior.Cascade);


                entity.HasMany(s => s.Teachers)
                      .WithOne(t => t.School)
                      .HasForeignKey(t => t.SchoolId)
                      .OnDelete(DeleteBehavior.Cascade);


                entity.HasMany(s => s.Students)
                      .WithOne(st => st.School)
                      .HasForeignKey(st => st.SchoolId)
                      .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Grade>(entity =>
            {

                entity.HasKey(s => s.GradeId);

                entity.Property(s => s.GradeName)
                .IsRequired()
                .HasMaxLength(15);

                entity.Property(s => s.GradePlace)
                .HasMaxLength(5);

                entity.HasMany(g => g.Courses)
                      .WithOne(c => c.Grade)
                      .HasForeignKey(c => c.GradeId);

                entity.HasMany(g => g.Students)
                      .WithOne(st => st.Grade)
                      .HasForeignKey(st => st.GradeId);




            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(s => s.CourseId);

                entity.Property(s => s.CourseName)
                .HasMaxLength(20);
                entity.Property(s => s.Duration);


                entity.HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(c => c.Students)
                      .WithOne(sc => sc.Course)
                      .HasForeignKey(sc => sc.CourseId)
                      .OnDelete(DeleteBehavior.Restrict);




            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(st => st.StudentId);

                entity.Property(st => st.StudentName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(st => st.StudentPhoneNumber)
                      .HasMaxLength(20);

                entity.HasMany(st => st.Courses)
                      .WithOne(sc => sc.Student)
                      .HasForeignKey(sc => sc.StudentId);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.TeacherId);

                entity.Property(t => t.TeacherName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(t => t.TeacherBornDay)
                      .HasColumnType("date");

                entity.HasMany(t => t.Grades)
                      .WithOne(tg => tg.Teacher)
                      .HasForeignKey(tg => tg.TeacherId)
                      .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<TeachersGrade>(entity =>
            {
                entity.HasKey(tg => new { tg.TeacherId, tg.GradeId });

                entity.HasOne(tg => tg.Teacher)
                      .WithMany(t => t.Grades)
                      .HasForeignKey(tg => tg.TeacherId).OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(tg => tg.Grade)
                      .WithMany(g => g.Teachers)
                      .HasForeignKey(tg => tg.GradeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentsCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                      .WithMany(st => st.Courses)
                      .HasForeignKey(sc => sc.StudentId).OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(sc => sc.Course)
                      .WithMany(c => c.Students)
                      .HasForeignKey(sc => sc.CourseId)
                      .OnDelete(DeleteBehavior.Restrict); 
            });

        }


        public DbSet<School> Schools { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeachersGrade> TeachersGrades { get; set; }
        public DbSet<StudentsCourse> StudentsCourse { get; set; }






    }
}
