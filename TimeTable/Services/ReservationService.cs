using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimeTable.Data.Repositories;
using TimeTable.Models;
using AutoMapper;
using TimeTable.Data.Entities;

namespace TimeTable.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<ReservedTime> _repo;
        private readonly ILogger<CourseService> _logger;
        private readonly IMapper mapper;

        public ReservationService(IRepository<ReservedTime> repo)
        {
            // _logger = LoggerFactory.Create(); 
            _repo = repo;
            mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<ReservedTimeDTO, ReservedTime>()));
        }

        public Task<bool> CanReservOnThisTime(ReservedTimeDTO time)
        {
            var res = _repo.GetAll().Any(t => t.ReservetionFrom > time.ReservetionFrom && t.ReservationTo < time.ReservationTo && t.Course.Id == time.CourseId);

            return Task.FromResult(res);
        }

        public async Task<ReservationResponse> CreateReservation(ReservedTimeDTO time)
        {
            var posibility = await CanReservOnThisTime(time);

            if (!posibility)
            {
                return await GetVariantsFor(time);
            }



            try
            {
                var timeDB = mapper.Map<ReservedTime>(time);
                await _repo.AddAsync(timeDB);

                return new ReservationResponse { IsConfirmed = true };
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new ReservationResponse { IsConfirmed = false };
            }
        }

       
        public Task<ReservationResponse> GetVariantsFor(ReservedTimeDTO time)
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
