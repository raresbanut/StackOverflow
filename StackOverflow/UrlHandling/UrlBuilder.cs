namespace StackOverflow.UrlHandling
{
    using System.Collections.Generic;

    using StackOverflow.Constants;

    public class UrlBuilder : IUrlBuilder
    {

        /// <summary>
        /// Custom construct the query string URL
        /// <param name="searchUrlParameters">Object with search parameters used in URL query string.</param>
        /// <returns>The URL query string.</returns>
        public string ConstructUrl(SearchUrl searchUrlParameters)
        {
            var searchUrl = UrlAddressConstants.SearchBaseUrl;

            searchUrl = AddToUrl(
                SearchParameterConstants.OrderParameter,
                searchUrlParameters.Order.ToDescriptionString(),
                searchUrl);

            if (!searchUrlParameters.Title.Equals(string.Empty))
            {
                searchUrl = AddToUrl(SearchParameterConstants.TitleParameter, searchUrlParameters.Title, searchUrl);
            }

            if (searchUrlParameters.MinimumNumberOfAnswers != 0)
            {
                searchUrl = AddToUrl(
                    SearchParameterConstants.MinimumNumberfAnswersParameter,
                    searchUrlParameters.MinimumNumberOfAnswers.ToString(),
                    searchUrl);
            }

            searchUrl = AddToUrl(
                SearchParameterConstants.SortOrderParameter,
                searchUrlParameters.Sort.ToDescriptionString(),
                searchUrl);

            if (searchUrlParameters.Tags.Count > 0)
            {
                searchUrl = AddTagToUrl(SearchParameterConstants.TagParameter, searchUrlParameters.Tags, searchUrl);
            }

            if (searchUrlParameters.AcceptedAnswer)
            {
                searchUrl = AddToUrl(
                    SearchParameterConstants.AcceptedParameter,
                    searchUrlParameters.AcceptedAnswer.ToString(),
                    searchUrl);
            }

            if (searchUrlParameters.MinimumNumberOfViews > 0)
            {
                searchUrl = AddToUrl(
                    SearchParameterConstants.MinimumNumberOfViewsParameter,
                    searchUrlParameters.MinimumNumberOfViews.ToString(),
                    searchUrl);
            }

            return searchUrl;
        }

        /// <summary>
        /// Add search parameter in url
        /// <param name="parameter">Search parameter name.</param>
        /// <param name="value">Search parameter value.</param>
        /// <param name="url">Current url.</param>
        /// <returns>Url containg the search parameter.</returns>
        private string AddToUrl(string parameter, string value, string url)
        {
            return url + UrlSpecialCharacterConstants.QueryStringConnector + parameter
                   + UrlSpecialCharacterConstants.EqualsSign + value;
        }

        /// <summary>
        /// Add search tag in url
        /// <param name="parameter">Search tag name.</param>
        /// <param name="tags">List of Search tag value.</param>
        /// <param name="url">Current url.</param>
        /// <returns>Url containg the search tag.</returns>
        private string AddTagToUrl(string parameter, List<string> tags, string url)
        {
            url = url + UrlSpecialCharacterConstants.QueryStringConnector + parameter
                  + UrlSpecialCharacterConstants.EqualsSign;

            foreach (var tag in tags)
            {
                url = url + tag + UrlSpecialCharacterConstants.TagSeparator;
            }

            return url;
        }
    }
}
