namespace StackOverflow
{
    using System.Net;
    using System.Net.Http;

    public class HttpClientManager : IHttpClientManager
    {
        public HttpClient GetHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            return new HttpClient(handler);
        }
    }
}
