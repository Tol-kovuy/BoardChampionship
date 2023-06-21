namespace School.DAL.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Subject> Lessons { get; set; }
    public virtual Director Director { get; set; }
    public virtual ClassroomTeacher ClassroomTeacher { get; set; }
    public virtual ICollection<Schedule> Schedules { get; set; }
}
