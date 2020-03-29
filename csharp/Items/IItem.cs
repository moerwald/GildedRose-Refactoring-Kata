using csharp.Items.Rules;

namespace csharp.Items
{
    public interface IItem
    {
        void Update(IUpdateRule rule);
    }
}