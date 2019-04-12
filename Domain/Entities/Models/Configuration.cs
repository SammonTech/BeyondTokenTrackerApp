using System;

namespace TokenTracker.Domain.Entities.Models
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
