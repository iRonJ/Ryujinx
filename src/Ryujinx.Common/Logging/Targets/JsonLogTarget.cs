<<<<<<< HEAD
using Ryujinx.Common.Utilities;
using System;
using System.IO;

namespace Ryujinx.Common.Logging.Targets
{
    public class JsonLogTarget : ILogTarget
    {
        private readonly Stream _stream;
        private readonly bool _leaveOpen;
        private readonly string _name;
=======
﻿using Ryujinx.Common.Utilities;
using System.IO;

namespace Ryujinx.Common.Logging
{
    public class JsonLogTarget : ILogTarget
    {
        private Stream _stream;
        private bool   _leaveOpen;
        private string _name;
>>>>>>> 1ec71635b (sync with main branch)

        string ILogTarget.Name { get => _name; }

        public JsonLogTarget(Stream stream, string name)
        {
            _stream = stream;
<<<<<<< HEAD
            _name = name;
=======
            _name   = name;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public JsonLogTarget(Stream stream, bool leaveOpen)
        {
<<<<<<< HEAD
            _stream = stream;
=======
            _stream    = stream;
>>>>>>> 1ec71635b (sync with main branch)
            _leaveOpen = leaveOpen;
        }

        public void Log(object sender, LogEventArgs e)
        {
            var logEventArgsJson = LogEventArgsJson.FromLogEventArgs(e);
            JsonHelper.SerializeToStream(_stream, logEventArgsJson, LogEventJsonSerializerContext.Default.LogEventArgsJson);
        }

        public void Dispose()
        {
<<<<<<< HEAD
            GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
            if (!_leaveOpen)
            {
                _stream.Dispose();
            }
        }
    }
}
