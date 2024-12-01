namespace ZayProject.Entities;

public class OurPurpose : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Brand> Brands { get; set; }
}
