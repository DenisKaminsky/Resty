namespace Resty.Core.Interfaces.Types.Request
{
    public interface ISortedRequest
    {
        IEnumerable<ISort> Sortings { get; }
    }
}
