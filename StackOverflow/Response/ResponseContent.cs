namespace StackOverflow.Response
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ResponseContent
    {
        public ResponseContent()
        {
            Items = new List<Question>();
        }

        [DataMember]
        public List<Question> Items { get; set; }
    }
}
