using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dtos
{
    public partial class BadgeDto
    {
        public int BadgeId { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int TokensRequired { get; set; }
        public string ImgSrc { get; set; }
    }
}
