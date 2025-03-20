using CommunityToolkit.Maui.Converters;

using System.Globalization;

namespace ICS_SIS.App.Converters;

public class TimeConverter : BaseConverterOneWay<DateTime, string>
{
    public override string ConvertFrom(DateTime value, CultureInfo? culture)
        =>value.ToString("dddd, dd MMMM yyyy HH:mm");
    public override string DefaultConvertReturnValue { get; set; } = string.Empty;
}