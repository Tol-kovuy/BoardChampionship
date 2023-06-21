using System.Data.SqlTypes;

namespace School.DAL.Entities;

public class ClassRoom // 11-B for exemple
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual School School { get; set; }
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Subject> Lessons { get; set; }
}
