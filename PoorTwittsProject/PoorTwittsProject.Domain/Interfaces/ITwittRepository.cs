using PoorTwittsProject.Domain.Entities;
using System.Collections.Generic;

namespace PoorTwittsProject.Domain.Interfaces
{
    public interface ITwittRepository
    {
        List<TwittEntity> GetAllTwitts();
        bool AddTwitt(TwittEntity twitt);
        bool DeleteTwitt(TwittEntity twitt);
    }
}
