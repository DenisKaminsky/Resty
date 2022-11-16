using System.Linq.Expressions;
using Resty.Core.Interfaces.Enums.Request;
using Resty.Core.Interfaces.Types.Request;
using Resty.Data.Utilities;

namespace Resty.Data.Extensions
{
	public static class RequestExtensions
	{
        public static IQueryable<T> ApplyPaging<T>(this IOrderedQueryable<T> source, IPagedRequest request)
        {
            return source
                .Skip(request.GetSkip())
                .Take(request.PageSize);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> source, IPagedRequest request)
        {
            return source
                .Skip(request.GetSkip())
                .Take(request.PageSize);
        }

		public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> source, IFilteredRequest request)
		{
			return source.ApplyFiltering(request.Filters, request.Logic);
		}

		public static IOrderedQueryable<T> ApplySorting<T>(this IQueryable<T> source, ISortedRequest request, ISort defaultSort)
		{
			return source.ApplySorting(request.Sortings, defaultSort);
		}

		public static IOrderedQueryable<T> ApplySorting<T>(this IQueryable<T> source, IEnumerable<ISort> requestSortings, ISort defaultSort)
		{
            IOrderedQueryable<T> result = null;
            var isOrdered = source.Expression.Type == typeof(IOrderedQueryable<T>);
            var parameterType = typeof(T);
            var parameterExpression = Expression.Parameter(parameterType, "item");

            var sortings = requestSortings?.ToList() ?? new List<ISort>();
            if (!sortings.Any())
            {
                sortings.Add(defaultSort);
            }
			foreach (var sorting in sortings)
			{
                if (PropertyExpressionBuilder.ValidatePropertyAndBuildPropertyExpression(sorting.Field, parameterExpression, out var propertyExpression))
                {
                    var sortExpression = Expression.Lambda(propertyExpression, parameterExpression);
                    MethodCallExpression methodCallExpression;

                    var query = result ?? source;
                    switch (sorting.Direction)
                    {
                        case SortDirection.Ascending:
                            methodCallExpression = !isOrdered
                                ? Expression.Call(typeof(Queryable), "OrderBy", new[] { parameterType, propertyExpression.Type }, query.Expression, Expression.Quote(sortExpression))
                                : Expression.Call(typeof(Queryable), "ThenBy", new[] { parameterType, propertyExpression.Type }, query.Expression, Expression.Quote(sortExpression));
                            break;

                        case SortDirection.Descending:
                            methodCallExpression = !isOrdered
                                ? Expression.Call(typeof(Queryable), "OrderByDescending", new[] { parameterType, propertyExpression.Type }, query.Expression, Expression.Quote(sortExpression))
                                : Expression.Call(typeof(Queryable), "ThenByDescending", new[] { parameterType, propertyExpression.Type }, query.Expression, Expression.Quote(sortExpression));
                            break;

                        default:
                            throw new NotImplementedException($"Unsupported sort direction: {sorting.Direction}");
                    }

                    result = query.Provider.CreateQuery<T>(methodCallExpression) as IOrderedQueryable<T>;
                    isOrdered = true;
				}
			}

			return result;
		}

        private static int GetSkip(this IPagedRequest request)
        {
            var pageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;

            return (pageNumber - 1) * request.PageSize;
        }

        private static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> source, IEnumerable<IFilter> requestFilters, FilterLogic logic = FilterLogic.And)
        {
            var filters = requestFilters?.ToArray() ?? Array.Empty<IFilter>();
            if (filters.Any())
            {
                var expression = FilterExpressionBuilder.GetExpression<T>(filters, logic);
                return source.Where(expression);
            }

            return source;
        }
	}
}
