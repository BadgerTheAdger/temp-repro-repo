using Microsoft.AspNetCore.Identity;

namespace SpeakingClubApps.Data
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int Visits { get; set; }
        
        public int Score { get; set; }
        
        public bool IsParticipating { get; set; }
        
        public bool IsTalking {get; set; }
    }
}