namespace altr.Data.EntityModels;

public class Post
{
    public enum PostType { COMMUNITY, USER };

    public Guid PostId { get; set; }
    public string PostTitle { get; set; }
    public string Content { get; set; }
    public string[] Attachments { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public PostType Type { get; set; }
    public ICollection<Accolade> Accolades { get; set; }
    public string[]? Decorations { get; set; } 
    public Guid? CommunityId { get; set; }
}
