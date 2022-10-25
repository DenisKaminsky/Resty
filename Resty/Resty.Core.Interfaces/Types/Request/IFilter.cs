using Resty.Core.Interfaces.Enums.Request;

namespace Resty.Core.Interfaces.Types.Request
{
    public interface IFilter
    {
        FilterOperator Operator { get; }
        string Field { get; }
        string Value { get; }
    }
}
