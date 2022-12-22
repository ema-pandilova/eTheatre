using eTheatre.Data.Base;
using eTheatre.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTheatre.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>,  IActorsService
    {
       
        public ActorsService(AppDbContext context) : base(context) { }
        
       
    }
}
