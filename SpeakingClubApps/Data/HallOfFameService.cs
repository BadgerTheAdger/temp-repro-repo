using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpeakingClubApps.Data
{
    public class HallOfFameService
    {
        private readonly ApplicationDbContext _ctx;

        public HallOfFameService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<Person[]> GetPeopleAsync()
        {
            var people = _ctx.Users.OrderByDescending(i => i.Score).ToArrayAsync();

            return await people;
        }

        public async Task UpdateParticipants(IEnumerable<Person> ppl)
        {
            _ctx.Users.UpdateRange(ppl);

            await _ctx.SaveChangesAsync();
        }
    }
}