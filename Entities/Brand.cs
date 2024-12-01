namespace ZayProject.Entities;

public class Brand : BaseEntity
{
    public string PhotoName { get; set; }
    public int OurPurposeId { get; set; }
    public OurPurpose OurPurpose { get; set; }
}
