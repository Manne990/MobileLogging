using MobileLogging.Common.Interface;
using NLog;

namespace MobileLogging.Ios.Log
{
    public class NLogLogger : IManneLogger
    {
        private readonly Logger _log;

        public NLogLogger(Logger log)
        {
            _log = log;
        }

        public void Trace(string text, params object[] args)
        {
            var argOutput = string.Join(" ", args);
            _log.Trace($"{text} {argOutput}", args);
        }

        public void Debug(string text, params object[] args)
        {
            var argOutput = string.Join(" ", args);
            _log.Debug($"{text} {argOutput}", args);
        }

        public void Info(string text, params object[] args)
        {
            var argOutput = string.Join(" ", args);
            _log.Info($"{text} {argOutput}", args);
        }

        public void Warn(string text, params object[] args)
        {
            var argOutput = string.Join(" ", args);
            _log.Warn($"{text} {argOutput}", args);
        }

        public void Error(string text, params object[] args)
        {
            var argOutput = string.Join(" ", args);
            _log.Error($"{text} {argOutput}", args);
        }

        public void Fatal(string text, params object[] args)
        {
            var argOutput = string.Join(" ", args);
            _log.Fatal($"{text} {argOutput}", args);
        }
    }
}