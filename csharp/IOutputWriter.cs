namespace csharp
{
    public interface IOutputWriter
    {
        void WriteLine(string line);
        void Write(string message);
    }
}
