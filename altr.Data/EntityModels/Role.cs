namespace altr.Data.EntityModels;

public enum UserRoles { GUARDIAN, OWNER, DEV, USER };

public class Role
{
    public string Title { get; set; }
    public Guid? CommunityId { get; set; }
    public DateTime? AssignedAt { get; set; }
}
