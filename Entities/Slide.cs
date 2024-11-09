namespace ZayProject.Entities;

public class Slide : BaseEntity
{
    public string Title { get; set; }
    public string MiniTitle { get; set; }
    public string Description { get; set; }
    public string PhotoPath { get; set; }
    public bool IsActive { get; set; }

}
