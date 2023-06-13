namespace altr.Data.EntityModels;

public class User
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Honor { get; set; }
    public ICollection<Accolade> Accolades { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Community> Communities { get; set; }
    public ICollection<Role> Roles { get; set; }
}
