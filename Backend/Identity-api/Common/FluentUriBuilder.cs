using System.Collections.Specialized;
using System.Web;

namespace Identity_api.Common;

public class FluentUriBuilder(string uri)
{
    private readonly List<string> _pathParams = [];
    private readonly NameValueCollection _queryParams = new();

    public Uri Build()
    {
        // Build query string
        var pairs = from key in _queryParams.AllKeys
            from value in _queryParams.GetValues(key)
            select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}";
        var queryString = string.Join("&", pairs);
        var queryPath = string.Join("/", _pathParams);
        if (!string.IsNullOrEmpty(queryPath))
        {
            queryPath = queryPath.Insert(0, "/");
        }

        // Build complete uri
        var builder = new UriBuilder(uri + queryPath);
        builder.Query = queryString;

        return builder.Uri;
    }

    public new string ToString()
    {
        // Build query string
        var pairs = from key in _queryParams.AllKeys
            from value in _queryParams.GetValues(key)
            select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}";
        var queryString = string.Join("&", pairs);
        var queryPath = string.Join("/", _pathParams);
        if (!string.IsNullOrEmpty(queryPath))
        {
            queryPath = queryPath.Insert(0, "/");
        }

        return $"{uri}{queryPath}?{queryString}";
    }

    public FluentUriBuilder AppendQueryParam(string name, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            _queryParams.Add(name, value);
        }

        return this;
    }

    public FluentUriBuilder AppendPathParam(string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            _pathParams.Add(value);
        }

        return this;
    }
}