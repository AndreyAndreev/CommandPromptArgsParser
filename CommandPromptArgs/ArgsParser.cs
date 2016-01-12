using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPromptArgs
{
    public class ArgsParser
    {
        private readonly ParserConfiguration configuration;
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

        public int Count => argsDict.Count;

        public void Parse(string[] cmdArguments)
        {
            originalArgs = cmdArguments;

            argsDict = cmdArguments.Select(x =>
                {
                    string key = string.Empty;
                    string value = string.Empty;

                    string[] split = x.Split(configuration.KeyValueSeparators, StringSplitOptions.RemoveEmptyEntries);

                    if (split.Any())
                    {
                        key = split.First().Trim().ToLowerInvariant();
                    }

                    if (split.Count() == 1)
                    {
                        value = key;
                    }
                    else if (split.Count() > 1)
                    {
                        value = split.ElementAt(1).Trim();
                    }

                    return new {Key = key, Value = value};
                })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public string GetValue(string argName)
        {
            return argsDict[argName.ToLowerInvariant()];
        }

        public string GetValue(int index)
        {
            return argsDict.ElementAt(index).Value;
        }

        public bool GetBoolValue(string argName)
        {
            bool value;

            bool.TryParse(GetValue(argName), out value);

            return value;
        }

        public int GetIntValue(string argName)
        {
            int value;

            int.TryParse(GetValue(argName), out value);

            return value;
        }

        public bool IsSpecified(string argName)
        {
            return argsDict.ContainsKey(argName.ToLowerInvariant());
        }
    }
}