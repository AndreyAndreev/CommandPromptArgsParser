using System;

namespace CommandPromptArgs
{
    public class Arg
    {
        public string Name { get; }
        public string Value { get; private set; }

        public Type Type { get; }

        public virtual void ParseValue(string arg)
        {
            Value = arg;
        }
    }

    public class Arg<T> : Arg
    {
        protected T value;

        public new virtual T Value => value;
    }

    public class BoolArg : Arg<bool>
    {
        public override void ParseValue(string arg)
        {
            bool.TryParse(arg, out value);
        }
    }
}