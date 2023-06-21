namespace School.DAL.Entities;

public class Director
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual School School { get; set; }
    public virtual ICollection<Teacher> Teachers { get; set; } 
    public virtual ICollection<Student> Students { get; set; }
}
