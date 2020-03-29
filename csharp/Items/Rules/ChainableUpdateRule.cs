namespace csharp.Items.Rules
{
    public abstract class ChainableUpdateRule : IUpdateRule
    {
        private readonly IUpdateRule _next;

        protected ChainableUpdateRule(IUpdateRule next)
        {
            _next = next;
        }

        public void Execute(Item item)
        {
            this.HandleExecute(item);
            this._next.Execute(item);
        }

        protected abstract void HandleExecute(Item item);
    }
}