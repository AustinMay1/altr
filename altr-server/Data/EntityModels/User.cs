using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace altr_server.data;

[Table("user")]
public class User
{
    [Key]
    public Guid UserId { get; set; }

    [Required, MinLength(2), MaxLength(24)]
    public string Username { get; set; }

    [Required, MinLength(12)]
    public string Password { get; set; }
}
