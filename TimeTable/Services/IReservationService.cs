using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTable.Data.Entities;
using TimeTable.Models;

namespace TimeTable.Services
{
    public interface IReservationService
    {
        Task<ReservationResponse> MakeReservation(ReservetionRequest time);
        Task<bool> CanReservOnThisTime(ReservetionRequest time);
        DateTime[] GetVariantsFor(ReservetionRequest time);
        Task<List<ReservationResponse>> GetMyReservations(Guid clientId);
    }
}
