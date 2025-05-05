using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Converters;

public class TimeSpanToSecondsConverter : ValueConverter<TimeSpan?, double?>
{
    public TimeSpanToSecondsConverter() 
        : base(
            v => v.HasValue ? v.Value.TotalSeconds : (double?)null, // сохраняем в БД
            v => v.HasValue ? TimeSpan.FromSeconds(v.Value) : (TimeSpan?)null // читаем из БД
        )
    { }
}