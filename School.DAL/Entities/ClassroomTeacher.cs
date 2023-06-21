namespace School.DAL.Entities;

public class ClassroomTeacher
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ClassRoom ClassRoom { get; set; }
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Subject> Subjects { get; set; }
    public virtual Director Director { get; set; }
    public virtual ICollection<Schedule> Schedules { get; set; }
}
