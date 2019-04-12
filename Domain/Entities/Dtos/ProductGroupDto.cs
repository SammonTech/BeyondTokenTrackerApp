namespace TokenTracker.Domain.Entities.Dtos
{
    public partial class ProductGroupDto
    {
        public int ProductGroupId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
