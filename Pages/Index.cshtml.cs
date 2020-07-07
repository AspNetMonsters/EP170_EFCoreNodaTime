using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP170_EFCoreNodaTime.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NodaTime;

namespace EP170_EFCoreNodaTime.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HolidaysDbContext _dbContext;


        public IEnumerable<PublicHoliday> PublicHolidays;

        public IndexModel( HolidaysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGet()
        {
            var today = LocalDate.FromDateTime(DateTime.Today);
            PublicHolidays = await _dbContext.PublicHolidays
                .Where(p => p.Date >= today && p.Date <= today.PlusDays(90))
                .ToListAsync();
        }
    }
}
