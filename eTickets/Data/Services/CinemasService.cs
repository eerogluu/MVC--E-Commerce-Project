using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema>,ICınemasService
    {
        public CinemasService(AppDbContext context): base(context) { }
        
    }
}
