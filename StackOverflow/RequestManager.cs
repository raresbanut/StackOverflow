namespace StackOverflow
{
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    using StackOverflow.Response;
    using StackOverflow.UrlHandling;

    public class RequestManager
    {
        private readonly IUrlManager urlManager;
        private readonly IHttpClientManager httpClientManager;

        public RequestManager()
        {
            urlManager = new UrlManager();
            httpClientManager = new HttpClientManager();
        }

        /// <summary>
        /// Query API based on given search parameters
        /// <param name="searchUrlParameters">Object with search parameters used in URL query string.</param>
        /// <returns>List of links with search results.</returns>
        public async Task<ResponseContent> Search(SearchUrl searchUrlParameters)
        {

            var httpClient = httpClientManager.GetHttpClient();
            var searchList = searchUrlParameters.Title.Split('\'');
            var parsetTitle = string.Empty;
            for (int i = 0; i < searchList.Length; i = i + 2)
            {
                parsetTitle = parsetTitle + searchList[i];
            }

            searchUrlParameters.Title = parsetTitle;

            var searchUrl = urlManager.GetUrl(searchUrlParameters);

            var response = httpClient.GetAsync(searchUrl).Result;
            var results = await response.Content.ReadAsStringAsync();
            var deserializedResults = JsonConvert.DeserializeObject<ResponseContent>(results);

            return deserializedResults;
        }
    }
}
