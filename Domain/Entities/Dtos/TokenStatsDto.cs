namespace TokenTracker.Domain.Entities.Dtos
{
    public partial class TokenStatsDto
    {
        public int AmtEarnedPeriod { get; set; }
        public int AmtEarnedLifeTime { get; set; }
        public int AmtGivenPeriod { get; set; }
        public int AmtAvailToGivePeriod { get; set; }
        public int AmtAllotedPeriod { get; set; }
        public int AmtRedeemed { get; set; }
        public int AmtAvailToRedeem { get; set; }
    }
}
