using System;

namespace Ryujinx.Common.Logging
{
    public class LogEventArgs : EventArgs
    {
        public readonly LogLevel Level;
        public readonly TimeSpan Time;
<<<<<<< HEAD
        public readonly string ThreadName;
=======
        public readonly string   ThreadName;
>>>>>>> 1ec71635b (sync with main branch)

        public readonly string Message;
        public readonly object Data;

        public LogEventArgs(LogLevel level, TimeSpan time, string threadName, string message, object data = null)
        {
<<<<<<< HEAD
            Level = level;
            Time = time;
            ThreadName = threadName;
            Message = message;
            Data = data;
        }
    }
}
=======
            Level      = level;
            Time       = time;
            ThreadName = threadName;
            Message    = message;
            Data       = data;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
