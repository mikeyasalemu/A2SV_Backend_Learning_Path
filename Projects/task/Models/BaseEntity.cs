namespace Task.Models;
public class BaseEntity
{
    public int ID {set;get;}
    public DateTime CreatedAt {set;get; } = DateTime.UtcNow;

    
}