using System.Threading.Tasks;
using TimeTable.Data.Entities;
using TimeTable.Models;

namespace TimeTable.Services
{
    public interface IReservationService
    {
        Task<ReservationResponse> CreateReservation(ReservedTimeDTO time);
        Task<bool> CanReservOnThisTime(ReservedTimeDTO time);
        Task<ReservationResponse> GetVariantsFor(ReservedTimeDTO time);
    }
}
