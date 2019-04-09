using System;
using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public partial class PointTransaction
    {
        public int PointTransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int PointTransactionTypeId { get; set; }
        public int? ProductId { get; set; }
        public int Points { get; set; }
        public int AwardToId { get; set; }
        public int AwardFromId { get; set; }
        public string AwardMessage { get; set; }

        public PointTransactionType PointTransactionType { get; set; }
        public Product Product { get; set; }
        public User AwardFrom { get; set; }
        public User AwardTo { get; set; }
    }
}
