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
        public async Task<ReservationResponse> MakeReservation(ReservedTimeDTO time)
        {
            if (ModelState.IsValid)
            {
                var res = await service.CreateReservation(time);
                return res;
            }

            return null; 
        }
    }
}
