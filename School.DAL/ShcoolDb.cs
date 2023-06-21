using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;

namespace School.DAL;

public class ShcoolDb : DbContext
{
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<ClassroomTeacher> ClassroomTeachers { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<School.DAL.Entities.School> Schools { get; set; }

    public ShcoolDb(
       DbContextOptions<ShcoolDb> options
       )
       : base(options) { }
}
