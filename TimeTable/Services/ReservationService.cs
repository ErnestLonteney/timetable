using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TimeTable.Data;
using TimeTable.Models;

namespace TimeTable.Services
{
    public class ReservationService : IReservationService
    {
        private readonly TimeTableDataContext dataContext;
        private readonly ILogger<CourseService> logger;

        public ReservationService()
        {
            dataContext = new TimeTableDataContext();
            // logger = LoggerFactory.Create(); 
        }

        public Task<bool> CanReservOnThisTime(ReservedTime time)
        {
            return Task.FromResult(true);
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
                await dataContext.Times.AddAsync(time);
                await dataContext.SaveChangesAsync();

                return new ReservationResponse { IsConfirmed = true };
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
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
