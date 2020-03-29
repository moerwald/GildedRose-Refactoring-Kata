using System;

namespace csharp.Items.Rules
{
    public interface IUpdateRule
    {
        Action<Item> GetRule(Item item);
    }
}