using Resty.Core.Interfaces.Enums.Request;
using Resty.Core.Interfaces.Types.Request;

namespace Resty.Data.DTO.Request
{
    public class DataSort : ISort
    {
        public SortDirection Direction { get; set; }

        public string Field { get; set; }

        public DataSort(string field, SortDirection direction)
        {
            Field = field;
            Direction = direction;
        }
    }
}
