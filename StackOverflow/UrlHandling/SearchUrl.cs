namespace StackOverflow.UrlHandling
{
    using System.Collections.Generic;
    using StackOverflow.Enums;

    public class SearchUrl
    {
        public SearchUrl()
        {
            Tags = new List<string>();
        }

        public ResponseOrder Order { get; set; }

        public string Title { get; set; }

        public ResponseSort Sort { get; set; }

        public int MinimumNumberOfAnswers { get; set; }

        public List<string> Tags { get; set; }

        public bool AcceptedAnswer { get; set; }

        public int MinimumNumberOfViews { get; set; }
    }
}
