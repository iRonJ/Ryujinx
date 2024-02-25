<<<<<<< HEAD
using Ryujinx.Common.Logging.Targets;
=======
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.SystemInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.CompilerServices;
using System.Threading;

namespace Ryujinx.Common.Logging
{
    public static class Logger
    {
<<<<<<< HEAD
        private static readonly Stopwatch _time;

        private static readonly bool[] _enabledClasses;

        private static readonly List<ILogTarget> _logTargets;
=======
        private static readonly Stopwatch m_Time;

        private static readonly bool[] m_EnabledClasses;

        private static readonly List<ILogTarget> m_LogTargets;
>>>>>>> 1ec71635b (sync with main branch)

        private static readonly StdErrAdapter _stdErrAdapter;

        public static event EventHandler<LogEventArgs> Updated;

        public readonly struct Log
        {
<<<<<<< HEAD
            private static readonly string _homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            private static readonly string _homeDirRedacted = Path.Combine(Directory.GetParent(_homeDir).FullName, "[redacted]");

=======
>>>>>>> 1ec71635b (sync with main branch)
            internal readonly LogLevel Level;

            internal Log(LogLevel level)
            {
                Level = level;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void PrintMsg(LogClass logClass, string message)
            {
<<<<<<< HEAD
                if (_enabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, _time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, "", message)));
=======
                if (m_EnabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, m_Time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, "", message)));
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Print(LogClass logClass, string message, [CallerMemberName] string caller = "")
            {
<<<<<<< HEAD
                if (_enabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, _time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, message)));
=======
                if (m_EnabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, m_Time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, message)));
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Print(LogClass logClass, string message, object data, [CallerMemberName] string caller = "")
            {
<<<<<<< HEAD
                if (_enabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, _time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, message), data));
                }
            }

            [StackTraceHidden]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void PrintStack(LogClass logClass, string message, [CallerMemberName] string caller = "")
            {
                if (_enabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, _time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, message), new StackTrace(true)));
=======
                if (m_EnabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, m_Time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, message), data));
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void PrintStub(LogClass logClass, string message = "", [CallerMemberName] string caller = "")
            {
<<<<<<< HEAD
                if (_enabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, _time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, "Stubbed. " + message)));
=======
                if (m_EnabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, m_Time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, "Stubbed. " + message)));
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void PrintStub(LogClass logClass, object data, [CallerMemberName] string caller = "")
            {
<<<<<<< HEAD
                if (_enabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, _time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, "Stubbed."), data));
=======
                if (m_EnabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, m_Time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, "Stubbed."), data));
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void PrintStub(LogClass logClass, string message, object data, [CallerMemberName] string caller = "")
            {
<<<<<<< HEAD
                if (_enabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, _time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, "Stubbed. " + message), data));
=======
                if (m_EnabledClasses[(int)logClass])
                {
                    Updated?.Invoke(null, new LogEventArgs(Level, m_Time.Elapsed, Thread.CurrentThread.Name, FormatMessage(logClass, caller, "Stubbed. " + message), data));
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void PrintRawMsg(string message)
            {
<<<<<<< HEAD
                Updated?.Invoke(null, new LogEventArgs(Level, _time.Elapsed, Thread.CurrentThread.Name, message));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static string FormatMessage(LogClass logClass, string caller, string message)
            {
                message = message.Replace(_homeDir, _homeDirRedacted);

                return $"{logClass} {caller}: {message}";
            }
        }

        public static Log? Debug { get; private set; }
        public static Log? Info { get; private set; }
        public static Log? Warning { get; private set; }
        public static Log? Error { get; private set; }
        public static Log? Guest { get; private set; }
        public static Log? AccessLog { get; private set; }
        public static Log? Stub { get; private set; }
        public static Log? Trace { get; private set; }
        public static Log Notice { get; } // Always enabled

        static Logger()
        {
            _enabledClasses = new bool[Enum.GetNames<LogClass>().Length];

            for (int index = 0; index < _enabledClasses.Length; index++)
            {
                _enabledClasses[index] = true;
            }

            _logTargets = new List<ILogTarget>();

            _time = Stopwatch.StartNew();
=======
                Updated?.Invoke(null, new LogEventArgs(Level, m_Time.Elapsed, Thread.CurrentThread.Name, message));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static string FormatMessage(LogClass Class, string Caller, string Message) => $"{Class} {Caller}: {Message}";
        }

        public static Log? Debug     { get; private set; }
        public static Log? Info      { get; private set; }
        public static Log? Warning   { get; private set; }
        public static Log? Error     { get; private set; }
        public static Log? Guest     { get; private set; }
        public static Log? AccessLog { get; private set; }
        public static Log? Stub      { get; private set; }
        public static Log? Trace     { get; private set; }
        public static Log  Notice    { get; } // Always enabled

        static Logger()
        {
            m_EnabledClasses = new bool[Enum.GetNames<LogClass>().Length];

            for (int index = 0; index < m_EnabledClasses.Length; index++)
            {
                m_EnabledClasses[index] = true;
            }

            m_LogTargets = new List<ILogTarget>();

            m_Time = Stopwatch.StartNew();
>>>>>>> 1ec71635b (sync with main branch)

            // Logger should log to console by default
            AddTarget(new AsyncLogTargetWrapper(
                new ConsoleLogTarget("console"),
                1000,
                AsyncLogTargetOverflowAction.Discard));

            Notice = new Log(LogLevel.Notice);
<<<<<<< HEAD

=======
            
>>>>>>> 1ec71635b (sync with main branch)
            // Enable important log levels before configuration is loaded
            Error = new Log(LogLevel.Error);
            Warning = new Log(LogLevel.Warning);
            Info = new Log(LogLevel.Info);
            Trace = new Log(LogLevel.Trace);

            _stdErrAdapter = new StdErrAdapter();
        }

        public static void RestartTime()
        {
<<<<<<< HEAD
            _time.Restart();
=======
            m_Time.Restart();
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static ILogTarget GetTarget(string targetName)
        {
<<<<<<< HEAD
            foreach (var target in _logTargets)
=======
            foreach (var target in m_LogTargets)
>>>>>>> 1ec71635b (sync with main branch)
            {
                if (target.Name.Equals(targetName))
                {
                    return target;
                }
            }

            return null;
        }

        public static void AddTarget(ILogTarget target)
        {
<<<<<<< HEAD
            _logTargets.Add(target);
=======
            m_LogTargets.Add(target);
>>>>>>> 1ec71635b (sync with main branch)

            Updated += target.Log;
        }

        public static void RemoveTarget(string target)
        {
            ILogTarget logTarget = GetTarget(target);

            if (logTarget != null)
            {
                Updated -= logTarget.Log;

<<<<<<< HEAD
                _logTargets.Remove(logTarget);
=======
                m_LogTargets.Remove(logTarget);
>>>>>>> 1ec71635b (sync with main branch)

                logTarget.Dispose();
            }
        }

        public static void Shutdown()
        {
            Updated = null;

            _stdErrAdapter.Dispose();

<<<<<<< HEAD
            foreach (var target in _logTargets)
=======
            foreach (var target in m_LogTargets)
>>>>>>> 1ec71635b (sync with main branch)
            {
                target.Dispose();
            }

<<<<<<< HEAD
            _logTargets.Clear();
=======
            m_LogTargets.Clear();
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static IReadOnlyCollection<LogLevel> GetEnabledLevels()
        {
<<<<<<< HEAD
            var logs = new[] { Debug, Info, Warning, Error, Guest, AccessLog, Stub, Trace };
            List<LogLevel> levels = new(logs.Length);
=======
            var logs = new Log?[] { Debug, Info, Warning, Error, Guest, AccessLog, Stub, Trace };
            List<LogLevel> levels = new List<LogLevel>(logs.Length);
>>>>>>> 1ec71635b (sync with main branch)
            foreach (var log in logs)
            {
                if (log.HasValue)
                {
                    levels.Add(log.Value.Level);
                }
            }

            return levels;
        }

        public static void SetEnable(LogLevel logLevel, bool enabled)
        {
            switch (logLevel)
            {
<<<<<<< HEAD
#pragma warning disable IDE0055 // Disable formatting
                case LogLevel.Debug     : Debug     = enabled ? new Log(LogLevel.Debug)     : new Log?(); break;
                case LogLevel.Info      : Info      = enabled ? new Log(LogLevel.Info)      : new Log?(); break;
                case LogLevel.Warning   : Warning   = enabled ? new Log(LogLevel.Warning)   : new Log?(); break;
                case LogLevel.Error     : Error     = enabled ? new Log(LogLevel.Error)     : new Log?(); break;
                case LogLevel.Guest     : Guest     = enabled ? new Log(LogLevel.Guest)     : new Log?(); break;
                case LogLevel.AccessLog : AccessLog = enabled ? new Log(LogLevel.AccessLog) : new Log?(); break;
                case LogLevel.Stub      : Stub      = enabled ? new Log(LogLevel.Stub)      : new Log?(); break;
                case LogLevel.Trace     : Trace     = enabled ? new Log(LogLevel.Trace)     : new Log?(); break;
                default: throw new ArgumentException("Unknown Log Level");
#pragma warning restore IDE0055
=======
                case LogLevel.Debug     : Debug     = enabled ? new Log(LogLevel.Debug)    : new Log?(); break;
                case LogLevel.Info      : Info      = enabled ? new Log(LogLevel.Info)     : new Log?(); break;
                case LogLevel.Warning   : Warning   = enabled ? new Log(LogLevel.Warning)  : new Log?(); break;
                case LogLevel.Error     : Error     = enabled ? new Log(LogLevel.Error)    : new Log?(); break;
                case LogLevel.Guest     : Guest     = enabled ? new Log(LogLevel.Guest)    : new Log?(); break;
                case LogLevel.AccessLog : AccessLog = enabled ? new Log(LogLevel.AccessLog): new Log?(); break;
                case LogLevel.Stub      : Stub      = enabled ? new Log(LogLevel.Stub)     : new Log?(); break;
                case LogLevel.Trace     : Trace     = enabled ? new Log(LogLevel.Trace)    : new Log?(); break;
                default: throw new ArgumentException("Unknown Log Level");
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public static void SetEnable(LogClass logClass, bool enabled)
        {
<<<<<<< HEAD
            _enabledClasses[(int)logClass] = enabled;
=======
            m_EnabledClasses[(int)logClass] = enabled;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
