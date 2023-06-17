using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace altr_server.data;

//public enum PostType { COMMUNITY, USER };

[Table("post")]
public class Post
{
    [Key]
    public Guid PostId { get; set; }

    [Required, MaxLength(120)]
    public string PostTitle { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
