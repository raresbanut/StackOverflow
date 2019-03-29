namespace StackOverflow.UrlHandling
{
    public class UrlManager : IUrlManager
    {
        private IUrlBuilder urlBuilder;

        public UrlManager()
        {
            urlBuilder = new UrlBuilder();
        }

        public string GetUrl(SearchUrl searchUrlParameters)
        {
            return urlBuilder.ConstructUrl(searchUrlParameters);
        }
    }
}
