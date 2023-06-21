namespace School.DAL.Entities;

public class Schedule
{
    public int Id { get; set; }
    public DateTime DayOfWeak { get; set; }
    public virtual ICollection<Subject> Subjects { get; set; }
    public virtual ClassRoom ClassRoom { get; set; }
    public virtual ICollection<Teacher> Teachers { get; set; }
}
