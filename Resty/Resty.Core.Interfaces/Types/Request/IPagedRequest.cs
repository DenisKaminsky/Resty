namespace Resty.Core.Interfaces.Types.Request
{
    public interface IPagedRequest
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}
