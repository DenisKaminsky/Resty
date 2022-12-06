namespace Resty.Core.Interfaces.Constraints
{
    public static class SiteSettings
    {
        public const string DateFormat = "MM/dd/yyyy";
        public const string TimeFormat = "h:mm tt";

        public static string DateTimeFormat => $"{DateFormat} {TimeFormat}";
    }
}
