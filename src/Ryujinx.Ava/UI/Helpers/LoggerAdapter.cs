<<<<<<< HEAD
using Avalonia.Logging;
using Avalonia.Utilities;
using Ryujinx.Common.Logging;
=======
using Avalonia.Utilities;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Text;

namespace Ryujinx.Ava.UI.Helpers
{
<<<<<<< HEAD
    using AvaLogger = Avalonia.Logging.Logger;
    using AvaLogLevel = LogEventLevel;
    using RyuLogClass = LogClass;
    using RyuLogger = Ryujinx.Common.Logging.Logger;

    internal class LoggerAdapter : ILogSink
=======
    using AvaLogger   = Avalonia.Logging.Logger;
    using AvaLogLevel = Avalonia.Logging.LogEventLevel;
    using RyuLogClass = Ryujinx.Common.Logging.LogClass;
    using RyuLogger   = Ryujinx.Common.Logging.Logger;

    internal class LoggerAdapter : Avalonia.Logging.ILogSink
>>>>>>> 1ec71635b (sync with main branch)
    {
        public static void Register()
        {
            AvaLogger.Sink = new LoggerAdapter();
        }

        private static RyuLogger.Log? GetLog(AvaLogLevel level)
        {
            return level switch
            {
<<<<<<< HEAD
                AvaLogLevel.Verbose => RyuLogger.Debug,
                AvaLogLevel.Debug => RyuLogger.Debug,
                AvaLogLevel.Information => RyuLogger.Debug,
                AvaLogLevel.Warning => RyuLogger.Debug,
                AvaLogLevel.Error => RyuLogger.Error,
                AvaLogLevel.Fatal => RyuLogger.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null),
=======
                AvaLogLevel.Verbose     => RyuLogger.Debug,
                AvaLogLevel.Debug       => RyuLogger.Debug,
                AvaLogLevel.Information => RyuLogger.Debug,
                AvaLogLevel.Warning     => RyuLogger.Debug,
                AvaLogLevel.Error       => RyuLogger.Error,
                AvaLogLevel.Fatal       => RyuLogger.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public bool IsEnabled(AvaLogLevel level, string area)
        {
            return GetLog(level) != null;
        }

        public void Log(AvaLogLevel level, string area, object source, string messageTemplate)
        {
<<<<<<< HEAD
            GetLog(level)?.PrintMsg(RyuLogClass.UI, Format(level, area, messageTemplate, source, null));
=======
            GetLog(level)?.PrintMsg(RyuLogClass.Ui, Format(level, area, messageTemplate, source, null));
        }

        public void Log<T0>(AvaLogLevel level, string area, object source, string messageTemplate, T0 propertyValue0)
        {
            GetLog(level)?.PrintMsg(RyuLogClass.Ui, Format(level, area, messageTemplate, source, new object[] { propertyValue0 }));
        }

        public void Log<T0, T1>(AvaLogLevel level, string area, object source, string messageTemplate, T0 propertyValue0,  T1 propertyValue1)
        {
            GetLog(level)?.PrintMsg(RyuLogClass.Ui, Format(level, area, messageTemplate, source, new object[] { propertyValue0, propertyValue1 }));
        }

        public void Log<T0, T1, T2>(AvaLogLevel level, string area, object source, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            GetLog(level)?.PrintMsg(RyuLogClass.Ui, Format(level, area, messageTemplate, source, new object[] { propertyValue0, propertyValue1, propertyValue2 }));
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void Log(AvaLogLevel level, string area, object source, string messageTemplate, params object[] propertyValues)
        {
<<<<<<< HEAD
            GetLog(level)?.PrintMsg(RyuLogClass.UI, Format(level, area, messageTemplate, source, propertyValues));
=======
            GetLog(level)?.PrintMsg(RyuLogClass.Ui, Format(level, area, messageTemplate, source, propertyValues));
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static string Format(AvaLogLevel level, string area, string template, object source, object[] v)
        {
            var result = new StringBuilder();
            var r = new CharacterReader(template.AsSpan());
            int i = 0;

            result.Append('[');
            result.Append(level);
            result.Append("] ");

            result.Append('[');
            result.Append(area);
            result.Append("] ");

            while (!r.End)
            {
                var c = r.Take();

                if (c != '{')
                {
                    result.Append(c);
                }
                else
                {
                    if (r.Peek != '{')
                    {
                        result.Append('\'');
                        result.Append(i < v.Length ? v[i++] : null);
                        result.Append('\'');
                        r.TakeUntil('}');
                        r.Take();
                    }
                    else
                    {
                        result.Append('{');
                        r.Take();
                    }
                }
            }

            if (source != null)
            {
                result.Append(" (");
                result.Append(source.GetType().Name);
                result.Append(" #");
                result.Append(source.GetHashCode());
                result.Append(')');
            }

            return result.ToString();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
