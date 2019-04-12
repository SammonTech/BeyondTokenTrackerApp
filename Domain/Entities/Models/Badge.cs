namespace TokenTracker.Domain.Entities.Models
{
    public partial class Badge
    {
        public int BadgeId { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int TokensRequired { get; set; }
        public string ImgSrc { get; set; }

        public Group Group { get; set; }
    }
}
