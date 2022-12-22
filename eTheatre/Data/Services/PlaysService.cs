using eTheatre.Data.Base;
using eTheatre.Data.ViewModels;
using eTheatre.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTheatre.Data.Services
{
    public class PlaysService:EntityBaseRepository<Play>, IPlaysService
    {
        private readonly AppDbContext _context;
        public PlaysService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddNewPlayAsync(NewPlayVM data)
        {
            var newPlay = new Play()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                TheatreId = data.TheatreId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                PlayCategory = data.PlayCategory,
                ProducerId = data.ProducerId
            };
            await _context.Plays.AddAsync(newPlay);
            await _context.SaveChangesAsync();

            //Add Play Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorPlay = new Actor_play()
                {
                    PlayId = newPlay.Id,
                    ActorId = actorId
                };
                await _context.Actors_Plays.AddAsync(newActorPlay);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewPlayDropdownVM> GetNewPlayDropdownsValues()
        {
            var response = new NewPlayDropdownVM();
            response.Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            response.Theatres = await _context.Theatres.OrderBy(n => n.Name).ToListAsync();
            response.Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync();
            return response;
        }

        public async Task<Play> GetPlayByIdAsync(int id)
        {
            var playDetails = await _context.Plays
                .Include(t => t.Theatre)
                .Include(p => p.Producer)
                .Include(ap => ap.Actors_Plays).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return playDetails;
        }

        public async Task UpdatePlayAsync(NewPlayVM data)
        {
            var dbPlay = await _context.Plays.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbPlay != null)
            {
                dbPlay.Name = data.Name;
                dbPlay.Description = data.Description;
                dbPlay.Price = data.Price;
                dbPlay.ImageURL = data.ImageURL;
                dbPlay.TheatreId = data.TheatreId;
                dbPlay.StartDate = data.StartDate;
                dbPlay.EndDate = data.EndDate;
                dbPlay.PlayCategory = data.PlayCategory;
                dbPlay.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Plays.Where(n => n.PlayId == data.Id).ToList();
            _context.Actors_Plays.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Play Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorPlay = new Actor_play()
                {
                    PlayId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Plays.AddAsync(newActorPlay);
            }
            await _context.SaveChangesAsync();
        }
    }
}
