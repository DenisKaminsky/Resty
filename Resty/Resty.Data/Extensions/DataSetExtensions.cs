using Microsoft.EntityFrameworkCore;
using Resty.Data.Models.Base;

namespace Resty.Data.Extensions
{
    internal static class DataSetExtensions
    {
        internal static IQueryable<T> IncludeRange<T>(this IQueryable<T> dataSet, IEnumerable<string> properties) where T : BaseModel
        {
            return properties.Aggregate(dataSet, (query, property) => query.Include(property));
        }
    }
}
