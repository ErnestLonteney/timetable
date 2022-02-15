using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeTable.Data;
using TimeTable.Models;
using TimeTable.Services;

namespace TimeTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService service;
        public ILogger<ReservationController> Logger { get; set; }

        public ReservationController(IReservationService service)
        {
            this.service = service;
        }

        [Route("MakeReservation")]
        [HttpPost]
        public async Task<ReservationResponse> MakeReservation(ReservetionRequest time)
        {
            if (ModelState.IsValid)
            {
                var res = await service.MakeReservation(time);
                return res;
            }

            return null;
        }


        [Route("MyReservations")]
        [HttpGet]
        public async Task<List<ReservationResponse>> GetMyReservations(Guid clientId)
        {
            if (clientId != Guid.Empty)
                await service.GetMyReservations(clientId);

            return new List<ReservationResponse>();
        }

        [Route("Test")]
        [HttpPost]
        public async Task TestReservation(ReservetionRequest time)
        {

        }
    }
}
