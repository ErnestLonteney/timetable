using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Services
{
    public interface IReservationService
    {
        Task<ReservationResponse> CreateReservation(ReservedTime time);
        Task<bool> CanReservOnThisTime(ReservedTime time);
        Task<ReservationResponse> GetVariantsFor(ReservedTime time);
    }
}
