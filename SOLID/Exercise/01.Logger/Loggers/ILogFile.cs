namespace _01Logger.Loggers
{
    public interface ILogFile
    {
        public void Write(string message);

        public long Size { get; }
    }
}
