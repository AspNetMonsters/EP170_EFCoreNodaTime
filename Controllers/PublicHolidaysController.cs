﻿using System.Linq;
using System.Threading.Tasks;
using EP170_EFCoreNodaTime.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace EP170_EFCoreNodaTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicHolidaysController : Controller
    {
        private readonly HolidaysDbContext _dbContext;

        public PublicHolidaysController(HolidaysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(LocalDate? after)
        {
            var publicHolidays = await _dbContext.PublicHolidays
                .Where(p => after == null || p.Date >= after)
                .ToListAsync();
            return Json(publicHolidays);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PublicHoliday holiday)
        {
            _dbContext.PublicHolidays.Add(holiday);
            await _dbContext.SaveChangesAsync();
            return Json(holiday);
        }
    }
}
