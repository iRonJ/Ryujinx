<<<<<<< HEAD
using Ryujinx.Common.Logging.Formatters;
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Logging
{
    internal class LogEventArgsJson
    {
        public LogLevel Level { get; }
        public TimeSpan Time { get; }
<<<<<<< HEAD
        public string ThreadName { get; }
=======
        public string   ThreadName { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public string Message { get; }
        public string Data { get; }

        [JsonConstructor]
        public LogEventArgsJson(LogLevel level, TimeSpan time, string threadName, string message, string data = null)
        {
<<<<<<< HEAD
            Level = level;
            Time = time;
            ThreadName = threadName;
            Message = message;
            Data = data;
=======
            Level      = level;
            Time       = time;
            ThreadName = threadName;
            Message    = message;
            Data       = data;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static LogEventArgsJson FromLogEventArgs(LogEventArgs args)
        {
            return new LogEventArgsJson(args.Level, args.Time, args.ThreadName, args.Message, DynamicObjectFormatter.Format(args.Data));
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
