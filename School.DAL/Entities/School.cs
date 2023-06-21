namespace School.DAL.Entities;

public class School
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    public virtual ICollection<Teacher> Teachers { get; set; }
    public virtual ICollection<Subject> Subjects { get; set; }
}
