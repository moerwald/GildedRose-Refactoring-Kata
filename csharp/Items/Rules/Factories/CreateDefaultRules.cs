using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Items.Rules;

namespace csharp.Items.Rules.Factories
{
    public static class CreateDefaultRules
    {
        public static IUpdateRule Create()
        =>
            new DefaultQualityDecrement(
                new DefaultQualityIncrement(
                    new SellInDecrement(
                        new SellInReached(
                            new DoNothingRule()))));
    }
}
