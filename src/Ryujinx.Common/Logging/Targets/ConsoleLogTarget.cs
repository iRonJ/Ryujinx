<<<<<<< HEAD
using Ryujinx.Common.Logging.Formatters;
using System;

namespace Ryujinx.Common.Logging.Targets
=======
﻿using System;

namespace Ryujinx.Common.Logging
>>>>>>> 1ec71635b (sync with main branch)
{
    public class ConsoleLogTarget : ILogTarget
    {
        private readonly ILogFormatter _formatter;

        private readonly string _name;

        string ILogTarget.Name { get => _name; }

<<<<<<< HEAD
        private static ConsoleColor GetLogColor(LogLevel level) => level switch
        {
            LogLevel.Info => ConsoleColor.White,
            LogLevel.Warning => ConsoleColor.Yellow,
            LogLevel.Error => ConsoleColor.Red,
            LogLevel.Stub => ConsoleColor.DarkGray,
            LogLevel.Notice => ConsoleColor.Cyan,
            LogLevel.Trace => ConsoleColor.DarkCyan,
            _ => ConsoleColor.Gray,
=======
        private static ConsoleColor GetLogColor(LogLevel level) => level switch {
            LogLevel.Info    => ConsoleColor.White,
            LogLevel.Warning => ConsoleColor.Yellow,
            LogLevel.Error   => ConsoleColor.Red,
            LogLevel.Stub    => ConsoleColor.DarkGray,
            LogLevel.Notice  => ConsoleColor.Cyan,
            LogLevel.Trace   => ConsoleColor.DarkCyan,
            _                => ConsoleColor.Gray,
>>>>>>> 1ec71635b (sync with main branch)
        };

        public ConsoleLogTarget(string name)
        {
            _formatter = new DefaultLogFormatter();
<<<<<<< HEAD
            _name = name;
=======
            _name      = name;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void Log(object sender, LogEventArgs args)
        {
            Console.ForegroundColor = GetLogColor(args.Level);
            Console.WriteLine(_formatter.Format(args));
            Console.ResetColor();
        }

        public void Dispose()
        {
<<<<<<< HEAD
            GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
            Console.ResetColor();
        }
    }
}
