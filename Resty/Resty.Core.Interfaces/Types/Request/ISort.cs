using Resty.Core.Interfaces.Enums.Request;

namespace Resty.Core.Interfaces.Types.Request
{
    public interface ISort
    {
        SortDirection Direction { get; }
        string Field { get; }
    }
}
