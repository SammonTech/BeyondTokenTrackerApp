namespace TokenTracker.Domain.Entities.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string ImgSrc { get; set; }
        public bool IsActive { get; set; }
        public GroupDto Group { get; set; }
        public RoleDto Role { get; set; }
    }
}
