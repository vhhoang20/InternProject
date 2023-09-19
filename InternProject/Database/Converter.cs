using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InternProject.Database
{
    public class Converter : ValueConverter<DateOnly, DateTime>
    {
        public Converter() : base(
             d => d.ToDateTime(TimeOnly.MinValue),
             dt => DateOnly.FromDateTime(dt))
        { }
    }
}
