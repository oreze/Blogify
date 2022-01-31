namespace Blogify.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
    public long AuthorId { get; set; }
    public virtual User Author { get; set; }
}