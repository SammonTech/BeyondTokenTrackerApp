using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum TransactionTypes
    {
    	KudosGiveAdmin = 8,
    	KudosGiveUser = 9,
    	SpotAward = 10,
    	RedeemAdmin = 11,
    	RedeemUser = 12,
    	CorrectionAdd = 13,
    	CorrectionReduce = 14
    }

    public enum AllotedPoints
    {
        Admin = 1000,
        User = 25
    }

    public enum Roles
    {
        Admin = 1,
        User = 2
    }

    public enum ProductGroups
    {
        NonRedeemable = 1,
        Apparel = 2,
        MiscItems = 6,
        PTO = 7
    }
}
