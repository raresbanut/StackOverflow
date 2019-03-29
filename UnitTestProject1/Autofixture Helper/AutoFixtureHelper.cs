namespace UnitTests.Autofixture_Helper
{
    using AutoFixture;
    public static class AutoFixtureHelper
    {
        static AutoFixtureHelper()
        {
            Generator = new Fixture();
        }

        /// <summary>
        /// Gets or sets the generator.
        /// This property is used to instantiate objects with random data
        /// </summary>
        internal static Fixture Generator { get; set; }

        /// <summary>
        /// This method sets static string instead of a random generated string.
        /// Useful when a custom string is needed: an email address, an encoding string, etc.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void SetGeneratedValue(string value)
        {
            Generator.Register(() => value);
        }
    }
}
