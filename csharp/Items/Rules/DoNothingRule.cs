using System;

namespace csharp.Items.Rules
{
    public class DoNothingRule : IUpdateRule
    {
        private static DoNothingRule _instance;
        public static DoNothingRule Instance => _instance ?? (_instance = new DoNothingRule());

        public Action<Item> GetRule(Item item) => i => { };
    }
}