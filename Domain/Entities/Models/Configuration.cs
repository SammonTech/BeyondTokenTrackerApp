using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class Configuration
    {
        public int ConfigurationId { get; set; }
        public string Name { get; set; }
        public int? ValueNumber { get; set; }
        public string ValueString { get; set; }
        public DateTime? ValueDate { get; set; }

    }
}
