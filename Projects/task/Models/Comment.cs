namespace Task.Models;
public class Comment : BaseEntity
{
    public int PostId { get; set; }

    public string? Text {set;get;}

    public virtual Post? Post {set;get;}

}