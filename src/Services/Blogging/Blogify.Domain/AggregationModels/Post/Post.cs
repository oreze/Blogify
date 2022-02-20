using Blogify.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Blogify.Domain.AggregationModels.Post;

public class Post
{
    public Guid Id { get; private set; }
    public string Subject { get; private set; }
    public string Description { get; private set; }
    public string Content { get; private set; }

    public DateTime CreatedAt { get; private set; }
    private DateTime LastUpdatedAt { get; set; }
    public User Author { get; private set; }

    public static Post NewPost(string subject, string description, string content, User author)
    {
        return new Post(subject, description, content, DateTime.UtcNow, author);
    }
    
    // For EF purposes
    protected Post() {}
    
    /// <summary>
    /// Create existing post
    /// </summary>
    public Post(Guid id, string subject, string description, string content, DateTime createdAt, User author)
    {
        ValidateGuid(id);
        ValidateSubject(subject);
        ValidateDescription(description);
        ValidateContent(content);
        ValidateCreatedAt(createdAt);
        ValidateAuthor(author);
        
        Id = id;
        Subject = subject;
        Description = description;
        Content = content;
        CreatedAt = createdAt;
        Author = author;
    }

    /// <summary>
    /// Create new post
    /// </summary>
    protected Post(string subject, string description, string content, DateTime createdAt, User author)
    {
        ValidateSubject(subject);
        ValidateDescription(description);
        ValidateContent(content);
        ValidateCreatedAt(createdAt);
        ValidateAuthor(author);
        
        Subject = subject;
        Description = description;
        Content = content;
        CreatedAt = createdAt;
        Author = author;
    }

    public void UpdateData(string? newSubject, string? newDescription, string? newContent)
    {
        if (newSubject != null)
            ValidateContent(newSubject);
        if (newDescription != null)
            ValidateContent(newDescription);
        if (newContent != null)
            ValidateContent(newContent);
        
        Subject = newSubject;
        Description = newDescription;
        Content = newContent;
        LastUpdatedAt = DateTime.UtcNow;
    }

    protected void ValidateGuid(Guid guid)
    {
        if (guid == Guid.Empty)
            throw new ArgumentException("Guid cannot be empty.");
    }

    protected void ValidateSubject(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
            throw new ArgumentException("Subject cannot be null or whitespace.");
    }
    
    protected void ValidateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description)) 
            throw new ArgumentException("Description cannot be null or whitespace.");
    }
    
    protected void ValidateContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content)) 
            throw new ArgumentException("Content cannot be null or whitespace.");
    }

    protected void ValidateCreatedAt(DateTime createdAt)
    {
        if (createdAt == null || createdAt == DateTime.MinValue || createdAt == DateTime.MaxValue)
            throw new ArgumentException("Created date is invalid.");
    }
    
    protected void ValidateLastUpdated(DateTime lastUpdatedAt)
    {
        if (lastUpdatedAt == null || lastUpdatedAt == DateTime.MinValue || lastUpdatedAt == DateTime.MaxValue)
            throw new ArgumentException("Last updated date is invalid.");
    }

    protected void ValidateAuthor(User author)
    {
        if (author == null || author.Id == 0)
            throw new ArgumentException("Author of the post is invalid.");
    }

}