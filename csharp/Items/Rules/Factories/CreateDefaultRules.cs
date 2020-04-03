namespace csharp.Items.Rules.Factories
{
    public static class CreateDefaultRules
    {
        private static IUpdateRule Create()
        =>
            new UpdateSulfuras(
                new UpdateAgedBrie(
                    new UpdateBackStagePass(
                        new UpdateDefaultImplementation(
                            DoNothingRule.Instance
                            )
                        )
                    )
                );

        public static IUpdateRule CreateWithConjuredRule() => new UpdateConjuredItem(Create());

    }
}
