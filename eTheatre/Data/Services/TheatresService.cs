using eTheatre.Data.Base;
using eTheatre.Models;

namespace eTheatre.Data.Services
{
    public class TheatresService:EntityBaseRepository<Theatre>,ITheatresService
    {
        public TheatresService(AppDbContext context) : base(context)
        {

        }
    }
}
