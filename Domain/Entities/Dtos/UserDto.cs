using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dtos
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
        public GroupDto Group { get; set; }
        public RoleDto Role { get; set; }
    }
}
