using System.IO;

namespace Civil_Construction_Management.Exceptions
{
    public class DataAccessException : Exception
    {

        private string _logFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Logs");

        public DataAccessException(string message) : base(message)
        {

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            _logFile = Path.Combine(_basePath, "logs.txt");

            if (!File.Exists(_logFile))
                File.WriteAllText(_logFile, string.Empty);

            LogError(message);
        }

        private void LogError(string message)
        {

            string finalMessage = $"{DateTime.Now:G} - {message}{Environment.NewLine}";
            File.AppendAllText(_logFile, finalMessage);
        }
    }
}
