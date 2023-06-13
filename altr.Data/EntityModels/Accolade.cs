namespace altr.Data.EntityModels;

public class Accolade
{
    public Guid accoladeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime AwardedAt { get; set; }
    public User UserFrom { get; set; }
    public User UserTo { get; set; }
}
