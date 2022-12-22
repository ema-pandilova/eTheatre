using eTheatre.Data.Base;
using eTheatre.Models;

namespace eTheatre.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {

        }
    }
}
