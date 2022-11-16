using Resty.Core.Interfaces.Enums.Request;

namespace Resty.Core.Interfaces.Types.Request.Default
{
    [Obsolete("DO NOT USE")]
    public class DataPagedAndFilteredAndSortedRequest : IPagedAndFilteredAndSortedRequest
    {
        private const int DefaultPageNumber = 1;
        private const int DefaultPageSize = 10;

        private readonly List<IFilter> _filters;
        private readonly List<ISort> _sorts;

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public FilterLogic Logic { get; set; }

        public IEnumerable<IFilter> Filters => _filters;

        public IEnumerable<ISort> Sortings => _sorts;

        public DataPagedAndFilteredAndSortedRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            _filters = new List<IFilter>();
            _sorts = new List<ISort>();
        }

        public DataPagedAndFilteredAndSortedRequest(IPagedAndFilteredAndSortedRequest request, List<IFilter> filters, List<ISort> sorts)
        {
            PageNumber = request?.PageNumber ?? DefaultPageNumber;
            PageSize = request?.PageSize ?? DefaultPageSize;

            _filters = request?.Filters?.Any() ?? false
                ? new List<IFilter>(request.Filters.Where(IsValidFilter))
                : new List<IFilter>();

            _sorts = request?.Sortings?.Any() ?? false
                ? new List<ISort>(request.Sortings.Where(IsValidSorting))
                : new List<ISort>();
        }

        public DataPagedAndFilteredAndSortedRequest AddFilter(IFilter filter)
        {
            _filters.Add(filter);

            return this;
        }

        public DataPagedAndFilteredAndSortedRequest AddSort(ISort sort)
        {
            _sorts.Add(sort);

            return this;
        }

        public DataPagedAndFilteredAndSortedRequest RemoveFilters(Predicate<IFilter> predicate)
        {
            _filters.RemoveAll(predicate);

            return this;
        }

        public DataPagedAndFilteredAndSortedRequest RemoveSorts(Predicate<ISort> predicate)
        {
            _sorts.RemoveAll(predicate);

            return this;
        }

        private bool IsValidFilter(IFilter? filter) => (
            filter != null &&
            !string.IsNullOrWhiteSpace(filter.Field) &&
            !string.IsNullOrWhiteSpace(filter.Value)
        );

        private bool IsValidSorting(ISort? sort) => (
            sort != null &&
            !string.IsNullOrWhiteSpace(sort.Field)
        );
    }
}
