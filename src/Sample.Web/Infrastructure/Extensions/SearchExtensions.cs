using EPiServer.Find;
using EPiServer.Find.Api.Facets;
using EPiServer.Find.Api.Querying;
using EPiServer.Find.Api.Querying.Filters;
using EPiServer.Find.Api.Querying.Queries;
using EPiServer.Find.Framework.Statistics;
using System.Linq.Expressions;

namespace Sample.Web.Infrastructure.Extensions;

public static class SearchExtensions
{
    private static Lazy<IClient> _findClient = new Lazy<IClient>(() => ServiceLocator.Current.GetInstance<IClient>());
    private static Lazy<IUrlResolver> _urlResolver = new Lazy<IUrlResolver>(() => ServiceLocator.Current.GetInstance<IUrlResolver>());

    public static Expression<Func<T, object>> GetTermFacetForResult<T>(string fieldName)
    {
        var paramX = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(paramX, fieldName);
        Expression conversion = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<T, object>>(conversion, paramX);
    }

    public static ITypeSearch<TSource> NumericRangeFacetFor<TSource>(this ITypeSearch<TSource> search, string name,
        IEnumerable<NumericRange> range, Type backingType)
    {
        return search.RangeFacetFor(GetTermFacetForResult<TSource>(name),
            NumericRangfeFacetRequestAction(search.Client, name, range, backingType));
    }

    public static ITypeSearch<TSource> NumericRangeFacetFor<TSource>(this ITypeSearch<TSource> search,
        string name,
        IEnumerable<NumericRange> range)
    {
        return search.RangeFacetFor(GetTermFacetForResult<TSource>(name),
            NumericRangfeFacetRequestAction(search.Client, name, range, typeof(double)));
    }

    public static ITypeSearch<TSource> NumericRangeFacetFor<TSource>(this ITypeSearch<TSource> search,
        string name,
        double from,
        double to)
    {
        return search.RangeFacetFor(GetTermFacetForResult<TSource>(name),
            NumericRangfeFacetRequestAction(search.Client, name, from, to, typeof(double)));
    }

    public static ITypeSearch<TSource> TermsFacetFor<TSource>(this ITypeSearch<TSource> search,
        string name,
        int size) => search.TermsFacetFor(name, FacetRequestAction(search.Client, name, size));

    public static ITypeSearch<TSource> TermsFacetForArray<TSource>(this ITypeSearch<TSource> search,
        string name,
        int size) => search.TermsFacetFor(name, FacetRequestActionForField(name, size));

    public static ITypeSearch<TSource> RangeFacetFor<TSource>(this ITypeSearch<TSource> search,
        string name,
        IEnumerable<NumericRange> range,
        Type backingType)
    {
        var fieldName = search.Client.GetFullFieldName(name, backingType);
        ;
        var action = NumericRangfeFacetRequestAction(search.Client, name, range, backingType);
        return new Search<TSource, IQuery>(search, context =>
        {
            var facetRequest = new NumericRangeFacetRequest(name)
            {
                Field = fieldName
            };
            action(facetRequest);
            context.RequestBody.Facets.Add(facetRequest);
        });
    }

    private static Action<NumericRangeFacetRequest> NumericRangfeFacetRequestAction(IClient searchClient,
        string fieldName,
        IEnumerable<NumericRange> range,
        Type type)
    {
        var fullFieldName = GetFullFieldName(searchClient, fieldName, type);

        return x =>
        {
            x.Field = fullFieldName;
            x.Ranges.AddRange(range);
        };
    }

    private static Action<NumericRangeFacetRequest> NumericRangfeFacetRequestAction(IClient searchClient,
        string fieldName,
        double from,
        double to,
        Type type)
    {
        var range = new List<NumericRange>
        {
            new NumericRange(from, to)
        };
        return NumericRangfeFacetRequestAction(searchClient, fieldName, range, type);
    }

    private static Action<TermsFacetRequest> FacetRequestAction(IClient searchClient,
        string fieldName,
        int size)
    {
        var fullFieldName = GetFullFieldName(searchClient, fieldName);
        return FacetRequestActionForField(fullFieldName, size);
    }

    private static Action<TermsFacetRequest> FacetRequestActionForField(string fieldName,
        int size)
    {
        return x =>
        {
            x.Field = fieldName;
            x.Size = size;
        };
    }

    public static string GetFullFieldName(this IClient searchClient,
        string fieldName) => GetFullFieldName(searchClient, fieldName, typeof(string));

    public static string GetFullFieldName(this IClient searchClient,
        string fieldName,
        Type type)
    {
        if (type != null)
            return fieldName + searchClient.Conventions.FieldNameConvention.GetFieldName(
                       Expression.Variable(type, fieldName));


        return fieldName;
    }

    public static ITypeSearch<T> AddStringFilter<T>(this ITypeSearch<T> query,
        string stringFieldValue,
        string fieldName)
    {
        if (stringFieldValue == null)
        {
            throw new ArgumentNullException("stringFieldValue");
        }

        var fullFieldName = query.Client.GetFullFieldName(fieldName);
        return query.Filter(GetOrFilterForStringList<T>(new List<string>
        {
            stringFieldValue
        }, query.Client, fullFieldName));
    }

    public static ITypeSearch<T> AddStringFilter<T>(this ITypeSearch<T> query,
        List<string> stringFieldValues,
        string fieldName)
    {
        var fullFieldName = query.Client.GetFullFieldName(fieldName);

        if (stringFieldValues != null && stringFieldValues.Any())
        {
            return query.Filter(GetOrFilterForStringList<T>(stringFieldValues, query.Client, fullFieldName));
        }

        return query;
    }

    public static ITypeSearch<T> AddStringListFilter<T>(this ITypeSearch<T> query,
        List<string> stringFieldValues,
        string fieldName)
    {
        if (stringFieldValues != null && stringFieldValues.Any())
        {
            return query.Filter(GetOrFilterForStringList<T>(stringFieldValues, query.Client, fieldName));
        }

        return query;
    }

    private static FilterBuilder<T> GetOrFilterForStringList<T>(IEnumerable<string> fieldValues,
        IClient client,
        string fieldName)
    {
        var filters = fieldValues.Select(s => new TermFilter(fieldName, s)).Cast<Filter>().ToList();

        if (filters.Count == 1)
        {
            return new FilterBuilder<T>(client, filters[0]);
        }

        var orFilter = new OrFilter(filters);
        return new FilterBuilder<T>(client, orFilter);
    }

    public static ITypeSearch<T> AddFilterForIntList<T>(this ITypeSearch<T> query,
        List<int> categories,
        string fieldName) => categories.Any() ? query.Filter(GetOrFilterForIntList(query, categories, fieldName, null)) : query;

    public static FilterBuilder<T> GetOrFilterForIntList<T>(this ITypeSearch<T> query,
        IEnumerable<int> values,
        string fieldName,
        Type type)
    {
        var client = query.Client;
        var fullFieldName = client.GetFullFieldName(fieldName, type);

        var filters = values.Select(value => new TermFilter(fullFieldName, value)).Cast<Filter>().ToList();

        FilterBuilder<T> filterBuilder;
        if (filters.Count > 1)
        {
            var orFilter = new OrFilter(filters);
            filterBuilder = new FilterBuilder<T>(client, orFilter);
        }
        else
        {
            filterBuilder = new FilterBuilder<T>(client, filters[0]);
        }

        return filterBuilder;
    }

    public static DelegateFilterBuilder Prefix(this IEnumerable<string> value, string prefix) => new DelegateFilterBuilder(field => new PrefixFilter(field, prefix));

    public static DelegateFilterBuilder PrefixCaseInsensitive(this IEnumerable<string> value, string prefix)
    {
        return new DelegateFilterBuilder(field => new PrefixFilter(field, prefix.ToLowerInvariant()))
        {
            FieldNameMethod =
                (expression, conventions) =>
                    conventions.FieldNameConvention.GetFieldNameForLowercase(expression)
        };
    }

    public static DelegateFilterBuilder Prefix<T>(this IEnumerable<T> value,
        Expression<Func<T, string>> fieldSelector,
        string prefix) => new DelegateFilterBuilder(field => new PrefixFilter(field, prefix))
        {
            FieldNameMethod = (expression, conventions) =>
            {
                return string.Format("{0}.{1}",
                              conventions.FieldNameConvention.GetFieldName(expression),
                              conventions.FieldNameConvention.GetFieldName(fieldSelector));
            }
        };

    public static DelegateFilterBuilder PrefixCaseInsensitive<T>(this IEnumerable<T> value,
        Expression<Func<T, string>> fieldSelector,
        string prefix)
    {
        return new DelegateFilterBuilder(field => new PrefixFilter(field, prefix.ToLowerInvariant()))
        {
            FieldNameMethod = (expression, conventions) =>
            {
                return string.Format("{0}.{1}",
                              conventions.FieldNameConvention.GetFieldName(expression),
                              conventions.FieldNameConvention.GetFieldNameForLowercase(fieldSelector));
            }
        };
    }

    public static ITypeSearch<T> AddWildCardQuery<T>(this ITypeSearch<T> search,
        string query, Expression<Func<T, string>> fieldSelector)
    {
        var fieldName = search.Client.Conventions.FieldNameConvention
            .GetFieldNameForAnalyzed(fieldSelector);
        var wildcardQuery = new WildcardQuery(fieldName, query.ToLowerInvariant());

        return new Search<T, WildcardQuery>(search, context =>
        {
            if (context.RequestBody.Query != null)
            {
                var boolQuery = new BoolQuery();
                boolQuery.Should.Add(context.RequestBody.Query);
                boolQuery.Should.Add(wildcardQuery);
                boolQuery.MinimumNumberShouldMatch = 1;
                context.RequestBody.Query = boolQuery;
            }
            else
            {
                context.RequestBody.Query = wildcardQuery;
            }
        });
    }

    public static ITypeSearch<T> ApplyFilters<T>(this ITypeSearch<T> query,
        IEnumerable<Filter> filters) where T : class
    {
        if (filters == null || !filters.Any())
        {
            return query;
        }

        foreach (var filter in filters)
        {
            query = query.Filter(filter);
        }
        return query;
    }

    public static ITypeSearch<T> ApplyTermFilter<T>(this ITypeSearch<T> query, string searchTerm) where T : class
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return query;
        }

        query = query.For(searchTerm).UsingSynonyms();
        query = query.Track();
        return query;
    }
}