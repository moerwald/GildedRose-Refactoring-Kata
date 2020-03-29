using System;
using System.Dynamic;

namespace csharp.Items.Rules
{
    public class DoNothingRule : IUpdateRule
    {
        private static DoNothingRule instance;
        public static DoNothingRule Instance => instance ?? (instance = new DoNothingRule());

        public Action<Item> GetRule(Item item) => i => { };
    }
}