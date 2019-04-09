using System;
using System.Collections.Generic;

namespace Domain.Entities.Dtos
{
    public partial class TransactionDto
    {
        public int PointTransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int PointTransactionTypeId { get; set; }
        public int? ProductId { get; set; }
        public int Points { get; set; }
        public int AwardToId { get; set; }
        public int AwardFromId { get; set; }
        public string AwardMessage { get; set; }

        public TransactionTypeDto TransactionType { get; set; }
        public ProductDto Product { get; set; }
        public UserDto AwardFrom { get; set; }
        public UserDto AwardTo { get; set; }
    }
}
