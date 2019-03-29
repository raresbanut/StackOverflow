namespace StackOverflow.Response
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Question
    {
        [DataMember]
        public string Link { get; set; }
    }
}
