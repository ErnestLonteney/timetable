using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimeTable.Data.Repositories;
using TimeTable.Models;

namespace TimeTable.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<ReservedTime> _repo;
        private readonly ILogger<CourseService> _logger;

        public ReservationService(IRepository<ReservedTime> repo)
        {
            // _logger = LoggerFactory.Create(); 
            _repo = repo;
        }

        public Task<bool> CanReservOnThisTime(ReservedTime time)
        {
            var res = _repo.GetAll().Any(t => t.ReservetionFrom > time.ReservetionFrom && t.ReservationTo < time.ReservationTo && t.Course.Id == time.Course.Id);

            return Task.FromResult(res);
        }

        public async Task<ReservationResponse> CreateReservation(ReservedTime time)
        {
            var posibility = await CanReservOnThisTime(time);

            if (!posibility)
            {
                return await GetVariantsFor(time);
            }

            try
            {
                await _repo.AddAsync(time);

                return new ReservationResponse { IsConfirmed = true };
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new ReservationResponse { IsConfirmed = false };
            }
        }

       
        public Task<ReservationResponse> GetVariantsFor(ReservedTime time)
        {
            var p = new ReservationResponse
            {
                IsConfirmed = false,
                Variants = new DateTime[3] { time.ReservetionFrom.AddDays(1), time.ReservetionFrom.AddDays(2), time.ReservetionFrom.AddDays(3) }
            };

            return Task.FromResult(p);
        }
    }
}
