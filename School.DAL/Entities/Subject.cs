namespace School.DAL.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartLessonTime { get; set; }
    public virtual Teacher Teacher { get; set; } 
}
// Вопрос... Репозиторий нужен к каждой сущности или можно ложить значения через другую сущность?