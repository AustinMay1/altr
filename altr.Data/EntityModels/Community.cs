namespace altr.Data.EntityModels;

public enum CommunityMode { PUBLIC, PRIVATE, RESTRICTED };

public class Community
{
    public Guid CommunityId { get; set; }
    public string CommunityName { get; set; }
    public ICollection<Post> Posts { get; set; }
    public Guid[] Members { get; set; }
    public Guid[] Guardians { get; set; }
    public string[] Tags { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Accolade> Accolades { get; set; }
    public int CommunityHonor { get; set; }
    public string[] CommunityLinks { get; set; }
    public string[] Rules { get; set; }
    public string[]? PostDecorations { get; set; }
    public Guid OwnerId { get; set; }
}
