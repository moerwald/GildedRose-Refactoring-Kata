namespace csharp.Items.Rules.Factories
{
    public static class CreateDefaultRules
    {
        public static IUpdateRule Create()
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
    }
}
