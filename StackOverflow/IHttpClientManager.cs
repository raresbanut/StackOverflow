namespace StackOverflow
{
    using System.Net.Http;

    public interface IHttpClientManager
    {
        HttpClient GetHttpClient();
    }
}
