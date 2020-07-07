using EP170_EFCoreNodaTime.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using System;
using System.Linq;

namespace EP170_EFCoreNodaTime
{
    public class HolidaysDbContext : DbContext
    {
        public HolidaysDbContext(DbContextOptions<HolidaysDbContext> options)
    : base(options)
        {
            //NOTE: Never do this in production. This is just a convenient way of seeding my database for a demo project
            Database.EnsureCreated();
            if (!PublicHolidays.Any()) 
            {
                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "New Year's Day",
                    Date = new LocalDate(2020, 1, 1)
                });
                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Family Day",
                    Date = new LocalDate(2020, 2, 17)
                });
                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Good Friday",
                    Date = new LocalDate(2020, 4, 10)
                });

                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Victoria Day",
                    Date = new LocalDate(2020, 5, 18)
                });

                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "James Chambers Day",
                    Date = new LocalDate(2020, 7, 1)
                });

                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Random August Day Off",
                    Date = new LocalDate(2020, 8, 3)
                });

                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Labour Day",
                    Date = new LocalDate(2020, 9, 7)
                });

                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Thanksgiving",
                    Date = new LocalDate(2020, 10, 12)
                });

                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Remembrance Day",
                    Date = new LocalDate(2020, 11, 11)
                });

                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Christmas Day",
                    Date = new LocalDate(2020, 12, 25)
                });

                PublicHolidays.Add(new PublicHoliday
                {
                    Name = "Boxing Day",
                    Date = new LocalDate(2020, 12, 26)
                });
            }
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var localDateConverter = new ValueConverter<LocalDate, DateTime>(l => l.ToDateTimeUnspecified(),
                                d => LocalDate.FromDateTime(d));

            modelBuilder.Entity<PublicHoliday>()
                    .Property(p => p.Date)
                    .HasConversion(localDateConverter)
                    .HasColumnType("date");
        }

        public DbSet<PublicHoliday> PublicHolidays { get; set; }

    }
}
