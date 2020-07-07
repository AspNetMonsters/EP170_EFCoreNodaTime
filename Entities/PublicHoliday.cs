using NodaTime;

namespace EP170_EFCoreNodaTime.Entities
{
    public class PublicHoliday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocalDate Date { get; set; }
    }
}
