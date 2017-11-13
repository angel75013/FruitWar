namespace FruitWar.Providers
{
    public interface ILogger
    {
        void Log(string message);
        void LogLine();
        void LogOnSameLine(string message);
        void Clear();
    }
}