using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Giphy
{
    public class QueryBuilder
    {
        private readonly string urlPattern;
        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();
        private readonly Dictionary<string, string> urlSegments = new Dictionary<string, string>();

        public QueryBuilder(string urlPattern)
        {
            this.urlPattern = urlPattern;
        }

        public QueryBuilder AddParameter(string key, string value)
        {
            parameters[key] = value;
            return this;
        }

        public QueryBuilder AddUrlSegment(string segment, string value)
        {
            urlSegments[segment] = value;
            return this;
        }

        //public QueryBuilder AddPaginationParameter(IPaginationParameter paginationParameter)
        //{
        //    if (paginationParameter.Page.HasValue)
        //        AddParameter("page", paginationParameter.Page.ToString());

        //    if (paginationParameter.NumberOfItemPerPage.HasValue)
        //        AddParameter("per_page", paginationParameter.NumberOfItemPerPage.ToString());

        //    if (!string.IsNullOrEmpty(paginationParameter.Order))
        //        AddParameter("order", paginationParameter.Order);

        //    return this;
        //}
        
        public string Build()
        {
            var url = ReplaceUrlSegments(urlPattern);
            var stringBuilder = new StringBuilder(url);

            AppendParameters(stringBuilder);

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return Build();
        }

        private string ReplaceUrlSegments(string urlString)
        {
            var result = urlString.Substring(0);

            foreach (var urlSegment in urlSegments)
            {
                var qualifier = string.Concat("{", EncodeString(urlSegment.Key), "}");
                result = result.Replace(qualifier, EncodeString(urlSegment.Value));
            }

            return result;
        }

        private void AppendParameters(StringBuilder stringBuilder)
        {
            if (!string.IsNullOrEmpty(urlPattern) && !urlPattern.EndsWith("/") && parameters.Count > 0)
            {
                stringBuilder.Append("?");
            }

            if (parameters.Count > 0)
            {
                AppendParameter(stringBuilder, parameters.First());
            }

            if (parameters.Count > 1)
            {
                for (var index = 1; index < parameters.Count; index++)
                {
                    stringBuilder.Append("&");
                    AppendParameter(stringBuilder, parameters.ElementAt(index));
                }
            }
        }

        private static void AppendParameter(StringBuilder stringBuilder, KeyValuePair<string, string> keyValuePair)
        {
            stringBuilder.Append(EncodeString(keyValuePair.Key));
            stringBuilder.Append("=");
            stringBuilder.Append(EncodeString(keyValuePair.Value));
        }

        private static string EncodeString(string input)
        {
            return WebUtility.UrlEncode(input);
        }
    }
}