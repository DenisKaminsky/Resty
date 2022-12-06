using Resty.Core.Interfaces.Constraints;

namespace Resty.Web.Formatters.Blog
{
    public static class BlogFormatter
    {
        public static string FormatCreatedDateUtc(DateTime createdDateUtc)
        {
            var now = DateTime.UtcNow;
            var difference = now - createdDateUtc;
            var differenceInDays = difference.TotalDays;
            var differenceInHours = difference.TotalHours;
            var differenceInMinutes = difference.TotalMinutes;

            if (differenceInDays > 30)
            {
                return createdDateUtc.ToString($"{SiteSettings.DateTimeFormat}");
            }
            else if (differenceInDays is <= 30 and >= 1)
            {
                return $"{(int)differenceInDays} day(s) ago - {createdDateUtc.ToString(SiteSettings.TimeFormat)}";
            }
            else if (differenceInHours is <= 24 and >= 1)
            {
                return $"{(int)differenceInHours} hour(s) ago";
            }
            else
            {
                return $"{(int)differenceInMinutes} minute(s) ago";
            }
        }
    }
}
