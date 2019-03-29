namespace StackOverflow.Enums
{
    using System.ComponentModel;

    public enum ResponseSort
    {
        [Description("activity")]
        Activity,

        [Description("votes")]
        Votes,

        [Description("creation")]
        Creation,

        [Description("relevance")]
        Relevance
    }
}
