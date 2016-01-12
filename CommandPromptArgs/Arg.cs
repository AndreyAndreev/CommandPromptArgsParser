using System;

namespace CommandPromptArgs
{
    public class Arg
    {
        public string Name { get; } 
        public string Value { get; }
        public Type Type { get; }

        public void Parse(string arg)
        {
            
        }
    }

    public class Arg<T> : Arg
    {
        public new T Value { get; }
    }
}