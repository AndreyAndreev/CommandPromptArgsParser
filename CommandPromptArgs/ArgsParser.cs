using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPromptArgs
{
    public class ArgsParser
    {
        private ParserConfiguration configuration;
        private Dictionary<string, string> argsDict;
        private List<Arg> args;
        private string[] originalArgs;

        public ArgsParser()
        {
            configuration = ParserConfiguration.GetDefaultConfiguration();
        }

        public ArgsParser(ParserConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public int Count
        {
            get { return argsDict.Count; }
        }

        public void Parse(string[] cmdArguments)
        {
            originalArgs = cmdArguments;

            argsDict = cmdArguments.Select(x =>
                {
                    string key = string.Empty;
                    string value = string.Empty;

                    string[] split = x.Split(configuration.KeyValueSeparators, StringSplitOptions.RemoveEmptyEntries);

                    if (split.Count() == 1)
                    {
                        key = split.First().Trim();
                        value = key;
                    }
                    else if (split.Count() > 1)
                    {
                        key = split.First().Trim();
                        value = split.ElementAt(1).Trim();
                    }

                    return new {Key = key, Value = value};
                })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public string GetValue(string argName)
        {
            return argsDict[argName];
        }

        public string GetValue(int index)
        {
            return argsDict.ElementAt(index).Value;
        }
    }
}