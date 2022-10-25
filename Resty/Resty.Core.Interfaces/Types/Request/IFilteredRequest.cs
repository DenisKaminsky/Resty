using Resty.Core.Interfaces.Enums.Request;

namespace Resty.Core.Interfaces.Types.Request
{
    public interface IFilteredRequest
    {
        IEnumerable<IFilter> Filters { get; }
        FilterLogic Logic { get; }
    }
}
