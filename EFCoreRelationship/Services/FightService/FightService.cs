using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationship.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DbContext _dbContext;

        public FightService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
