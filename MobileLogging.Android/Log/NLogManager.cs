using System;
using System.IO;
using MobileLogging.Common.Interface;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace MobileLogging.Android.Log
{
    public class NLogManager : IManneLogManager
    {
        public NLogManager()
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ConsoleTarget();
            consoleTarget.Layout = "${longdate} ${logger} ${level} ${message}";
            config.AddTarget("console", consoleTarget);

            var consoleRule = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(consoleRule);

            var fileTarget = new FileTarget();
            fileTarget.Layout = "${longdate} ${logger} ${level} ${message}";
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            System.Diagnostics.Debug.WriteLine(folder);

            fileTarget.FileName = Path.Combine(folder, "Log.txt");
            config.AddTarget("file", fileTarget);

            var fileRule = new LoggingRule("*", LogLevel.Warn, fileTarget);
            config.LoggingRules.Add(fileRule);

            LogManager.Configuration = config;
        }

        public IManneLogger GetLog([System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
        {
            if (callerFilePath.Contains("/"))
            {
                callerFilePath = callerFilePath.Substring(callerFilePath.LastIndexOf("/", StringComparison.CurrentCultureIgnoreCase) + 1);
            }

            return new NLogLogger(LogManager.GetLogger(callerFilePath));
        }
    }
}