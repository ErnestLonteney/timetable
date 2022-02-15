using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimeTable.Data.Repositories;
using TimeTable.Models;
using AutoMapper;
using TimeTable.Data.Entities;
using System.Collections.Generic;

namespace TimeTable.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<ReservedTime> _repo;
        private readonly IMapper mapper;
        public ILogger<ReservationService> Logger { get; }

        public ReservationService(IRepository<ReservedTime> repo, ILogger<ReservationService> logger)
        {
            Logger = logger; 
            _repo = repo;
            mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<ReservetionRequest, ReservedTime>()));
        }

        public async Task<bool> CanReservOnThisTime(ReservetionRequest time)
        {
            var res = await _repo.GetAllAsync();
            
            var exists = res.Any(t => t.ReservetionFrom > time.ReservetionFrom && t.ReservationTo < time.ReservationTo && t.Course.Id == time.CourseId);

            return exists;
        }

        public async Task<ReservationResponse> MakeReservation(ReservetionRequest time)
        {
            var posibility = await CanReservOnThisTime(time);

            if (!posibility)
            {
                return new ReservationResponse { IsConfirmed = false, Variants = GetVariantsFor(time), ByRequest = time };
            }

            try
            {
                var timeDB = mapper.Map<ReservedTime>(time);
                await _repo.AddAsync(timeDB);

                return new ReservationResponse { IsConfirmed = true, ByRequest = time };
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new ReservationResponse { IsConfirmed = false, ByRequest = time };
            }
        }

        public async Task<List<ReservationResponse>> GetMyReservations(Guid clientId)
        {
            var reservations = await _repo.GetManyByFilterAsync(x => x.Client.Id == clientId);

            var times = mapper.Map<List<ReservetionRequest>>(reservations);

           return times.Select(x => new ReservationResponse 
                              { 
                                 ByRequest = x, 
                                 IsConfirmed = !x.IsCanceled, 
                                 Variants = x.IsCanceled ? GetVariantsFor(x) : null 
                              }).ToList();
        }

       
        public DateTime[] GetVariantsFor(ReservetionRequest time)
        {
            return new DateTime[3] { time.ReservetionFrom.AddDays(1),
                                             time.ReservetionFrom.AddDays(2),
                                             time.ReservetionFrom.AddDays(3) };
        }
    }
}
