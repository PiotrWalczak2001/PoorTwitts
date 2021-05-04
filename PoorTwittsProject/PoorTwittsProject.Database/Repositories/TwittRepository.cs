using Microsoft.EntityFrameworkCore;
using PoorTwittsProject.Domain.Entities;
using PoorTwittsProject.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PoorTwittsProject.Database.Repositories
{
    public class TwittRepository : ITwittRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<TwittEntity> Twitts { get; set; }

        public TwittRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Twitts = dbContext.Twitts;
        }

        public List<TwittEntity> GetAllTwitts()
        {
            return Twitts.ToList();
        }

        public bool AddTwitt(TwittEntity twitt)
        {
            Twitts.Add(twitt);
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteTwitt(TwittEntity twitt)
        {
            Twitts.Remove(twitt);
            return _dbContext.SaveChanges() > 0;
        }

    }
}
