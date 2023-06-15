using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace altr_server.data;

//public enum CommunityMode { PUBLIC, PRIVATE, RESTRICTED };

[Table("community")]
public class Community
{
    [Key]   
    public Guid CommunityId { get; set; }

    [Required, MaxLength(30)]
    public string CommunityName { get; set; }

    public virtual ICollection<Post>? Posts { get; set; }

    public Guid OwnerId { get; set; }

    public Community()
    {
        Posts = new List<Post>();
    }
}
