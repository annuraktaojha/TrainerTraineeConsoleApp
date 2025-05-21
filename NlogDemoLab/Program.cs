using NLog;

namespace NlogDemoLab
{
    internal class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            // add log statements
            logger.Trace("Trace log message");

            logger.Debug("Debug log message");

            logger.Info("Info log message");

            logger.Warn("Warn log message");

            logger.Error("Error log message");

            logger.Fatal("Fatal log message");

            
            // add log statements with exception
            try
            {
                int a = 10;
                int b = 0;
                int c = a / b;
            }
            catch (System.Exception ex)
            {
                logger.Error(ex, "Exception occurred");
            }

            // add log statements with exception

            try
            {
                int a = 10;
                int b = 0;
                int c = a / b;
            }
            catch (System.Exception ex)
            {
                logger.Fatal(ex, "Fatal exception occurred");
            }
            Console.WriteLine("Log messages are written to the log file");
            LogEventInfo logEvent =
                new LogEventInfo(LogLevel.Info, logger.Name, "Log message with log event");
            logEvent.Properties["UserId"] = 101;
            logger.Log(logEvent);
        }
    }
}
