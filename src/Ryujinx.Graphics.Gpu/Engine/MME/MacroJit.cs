<<<<<<< HEAD
using Ryujinx.Graphics.Device;
=======
﻿using Ryujinx.Graphics.Device;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;

namespace Ryujinx.Graphics.Gpu.Engine.MME
{
    /// <summary>
    /// Represents a execution engine that uses a Just-in-Time compiler for fast execution.
    /// </summary>
    class MacroJit : IMacroEE
    {
<<<<<<< HEAD
        private readonly MacroJitContext _context = new();
=======
        private readonly MacroJitContext _context = new MacroJitContext();
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Arguments FIFO.
        /// </summary>
        public Queue<FifoWord> Fifo => _context.Fifo;

        private MacroJitCompiler.MacroExecute _execute;

        /// <summary>
        /// Executes a macro program until it exits.
        /// </summary>
        /// <param name="code">Code of the program to execute</param>
        /// <param name="state">Current GPU state</param>
        /// <param name="arg0">Optional argument passed to the program, 0 if not used</param>
        public void Execute(ReadOnlySpan<int> code, IDeviceState state, int arg0)
        {
            if (_execute == null)
            {
<<<<<<< HEAD
                MacroJitCompiler compiler = new();
=======
                MacroJitCompiler compiler = new MacroJitCompiler();
>>>>>>> 1ec71635b (sync with main branch)

                _execute = compiler.Compile(code);
            }

            _execute(_context, state, arg0);
        }
    }
}
