namespace CommandPromptArgs
{
    public class ParserConfiguration
    {
        public string[] KeyValueSeparators { get; set; }

        public static ParserConfiguration GetDefaultConfiguration()
        {
            var config = new ParserConfiguration();
            config.KeyValueSeparators = new string[] { ":", "=" };

            return config;
        }
    }
}