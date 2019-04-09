using System;
using System.Linq;
using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class TokenService : ITokenService
    {
        #region Members

        private readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        #endregion

        public IQueryable<PointTransaction> GetTokens()
        {
            return _tokenRepository.Get();
        }

        public PointTransaction CreateToken(PointTransaction token)
        {
            return _tokenRepository.Create(token);
        }

        public PointTransaction UpdateToken(PointTransaction token)
        {
            return _tokenRepository.Update(token);
        }

        public TokenStatsDto GetTokensStats(int userId)
        {
            var amtEarnedLifeTime = 0;
            var amtEarnedPeriod = 0;
            var amtRedeemed = 0;
            var tokensGivenPeriod = 0;
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var tokensGivenList = _tokenRepository.Get()
                .Where(x => x.AwardFromId == userId || x.AwardToId == userId).ToList();
            
            foreach (var trans in tokensGivenList)
            {
                var points = 0;
                if (trans.AwardToId == userId)
                {
                    points = trans.Points * trans.PointTransactionType.AffectOnAwardTo;
                    amtEarnedLifeTime += points;
                    if (trans.TransactionDate.Month == currentMonth && trans.TransactionDate.Year == currentYear)
                    {
                        amtEarnedPeriod += points;
                    }
                }
                else if (trans.PointTransactionTypeId == (int)TransactionTypes.KudosGiveAdmin ||
                         trans.PointTransactionTypeId == (int)TransactionTypes.KudosGiveUser)
                {
                    if (trans.TransactionDate.Month == currentMonth && trans.TransactionDate.Year == currentYear)
                    {
                        tokensGivenPeriod += trans.Points * trans.PointTransactionType.AffectOnAwardFrom;
                    }
                }
                else if (trans.PointTransactionTypeId == (int) TransactionTypes.RedeemAdmin ||
                         trans.PointTransactionTypeId == (int) TransactionTypes.RedeemUser)
                {
                    amtRedeemed += trans.Points * trans.PointTransactionType.AffectOnAwardFrom;
                }
                else if (trans.PointTransactionTypeId == (int)TransactionTypes.CorrectionAdd ||
                         trans.PointTransactionTypeId == (int)TransactionTypes.CorrectionReduce)
                {
                    points = trans.Points * trans.PointTransactionType.AffectOnAwardTo;
                    amtEarnedLifeTime += points;
                    if (trans.TransactionDate.Month == currentMonth && trans.TransactionDate.Year == currentYear)
                    {
                        amtEarnedPeriod += points;
                    }
                }
            }

            var tokenStats = new TokenStatsDto()
            {
                AmtAllotedPeriod = 0,
                AmtAvailToGivePeriod = 0,
                AmtEarnedLifeTime = amtEarnedLifeTime,
                AmtEarnedPeriod = amtEarnedPeriod,
                AmtGivenPeriod = tokensGivenPeriod,
                AmtRedeemed = amtRedeemed,
                AmtAvailToRedeem = amtEarnedLifeTime + amtRedeemed
            };

            return tokenStats;
        }

        //todo: add new repo and service to handle configuration settings
        public int GetAllotedAmount(int roleId)
        {
            if (roleId == (int) Roles.Admin)
            {
                return (int) AllotedPoints.Admin;
            }
            else
            {
                return (int)AllotedPoints.User;
            }
        }

        public void SaveChanges()
        {
            _tokenRepository.SaveChanges();
        }
    }
}
