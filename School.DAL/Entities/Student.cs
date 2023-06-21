namespace School.DAL.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual School School { get; set; }
    public virtual Director Director { get; set; }
    public virtual ClassRoom ClassRoom { get; set; }
    public virtual ClassroomTeacher ClassroomTeacher { get; set; }
    public virtual ICollection<Teacher> Teachers { get; set; }
    public virtual ICollection<Schedule> Schedules { get; set; }
    public virtual ICollection<Subject> Subjects { get; set; }
}
