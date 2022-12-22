using eTheatre.Data.Base;
using eTheatre.Data.ViewModels;
using eTheatre.Models;
using System.Threading.Tasks;

namespace eTheatre.Data.Services
{
    public interface IPlaysService:IEntityBaseRepository<Play>
    {
        Task<Play> GetPlayByIdAsync(int id);
        Task<NewPlayDropdownVM> GetNewPlayDropdownsValues();
        Task AddNewPlayAsync(NewPlayVM data);
        Task UpdatePlayAsync(NewPlayVM data);
    }
}
