<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Configuration;
using Ryujinx.Graphics.GAL.Multithreading.Commands;
using Ryujinx.Graphics.GAL.Multithreading.Commands.Buffer;
using Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer;
using Ryujinx.Graphics.GAL.Multithreading.Model;
using Ryujinx.Graphics.GAL.Multithreading.Resources;
using Ryujinx.Graphics.GAL.Multithreading.Resources.Programs;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Ryujinx.Graphics.GAL.Multithreading
{
    /// <summary>
    /// The ThreadedRenderer is a layer that can be put in front of any Renderer backend to make
    /// its processing happen on a separate thread, rather than intertwined with the GPU emulation.
    /// A new thread is created to handle the GPU command processing, separate from the renderer thread.
    /// Calls to the renderer, pipeline and resources are queued to happen on the renderer thread.
    /// </summary>
    public class ThreadedRenderer : IRenderer
    {
        private const int SpanPoolBytes = 4 * 1024 * 1024;
        private const int MaxRefsPerCommand = 2;
        private const int QueueCount = 10000;

<<<<<<< HEAD
        private readonly int _elementSize;
        private readonly IRenderer _baseRenderer;
        private Thread _gpuThread;
        private Thread _backendThread;
        private bool _running;

        private readonly AutoResetEvent _frameComplete = new(true);

        private readonly ManualResetEventSlim _galWorkAvailable;
        private readonly CircularSpanPool _spanPool;

        private readonly ManualResetEventSlim _invokeRun;
        private readonly AutoResetEvent _interruptRun;

        private bool _lastSampleCounterClear = true;

        private readonly byte[] _commandQueue;
        private readonly object[] _refQueue;
=======
        private int _elementSize;
        private IRenderer _baseRenderer;
        private Thread _gpuThread;
        private Thread _backendThread;
        private bool _disposed;
        private bool _running;

        private AutoResetEvent _frameComplete = new AutoResetEvent(true);

        private ManualResetEventSlim _galWorkAvailable;
        private CircularSpanPool _spanPool;

        private ManualResetEventSlim _invokeRun;
        private AutoResetEvent _interruptRun;

        private bool _lastSampleCounterClear = true;

        private byte[] _commandQueue;
        private object[] _refQueue;
>>>>>>> 1ec71635b (sync with main branch)

        private int _consumerPtr;
        private int _commandCount;

        private int _producerPtr;
        private int _lastProducedPtr;
        private int _invokePtr;

        private int _refProducerPtr;
        private int _refConsumerPtr;

        private Action _interruptAction;
<<<<<<< HEAD
        private readonly object _interruptLock = new();
=======
        private object _interruptLock = new();
>>>>>>> 1ec71635b (sync with main branch)

        public event EventHandler<ScreenCaptureImageInfo> ScreenCaptured;

        internal BufferMap Buffers { get; }
        internal SyncMap Sync { get; }
        internal CircularSpanPool SpanPool { get; }
        internal ProgramQueue Programs { get; }

        public IPipeline Pipeline { get; }
        public IWindow Window { get; }

        public IRenderer BaseRenderer => _baseRenderer;

        public bool PreferThreading => _baseRenderer.PreferThreading;

        public ThreadedRenderer(IRenderer renderer)
        {
            _baseRenderer = renderer;

            renderer.ScreenCaptured += (sender, info) => ScreenCaptured?.Invoke(this, info);
            renderer.SetInterruptAction(Interrupt);

<<<<<<< HEAD
            Pipeline = new ThreadedPipeline(this);
=======
            Pipeline = new ThreadedPipeline(this, renderer.Pipeline);
>>>>>>> 1ec71635b (sync with main branch)
            Window = new ThreadedWindow(this, renderer);
            Buffers = new BufferMap();
            Sync = new SyncMap();
            Programs = new ProgramQueue(renderer);

            _galWorkAvailable = new ManualResetEventSlim(false);
            _invokeRun = new ManualResetEventSlim();
            _interruptRun = new AutoResetEvent(false);
            _spanPool = new CircularSpanPool(this, SpanPoolBytes);
            SpanPool = _spanPool;

            _elementSize = BitUtils.AlignUp(CommandHelper.GetMaxCommandSize(), 4);

            _commandQueue = new byte[_elementSize * QueueCount];
            _refQueue = new object[MaxRefsPerCommand * QueueCount];
        }

<<<<<<< HEAD
        public void RunLoop(ThreadStart gpuLoop)
=======
        public void RunLoop(Action gpuLoop)
>>>>>>> 1ec71635b (sync with main branch)
        {
            _running = true;

            _backendThread = Thread.CurrentThread;

<<<<<<< HEAD
            _gpuThread = new Thread(gpuLoop)
            {
                Name = "GPU.MainThread",
            };

=======
            _gpuThread = new Thread(() => {
                gpuLoop();
                _running = false;
                _galWorkAvailable.Set();
            });

            _gpuThread.Name = "GPU.MainThread";
>>>>>>> 1ec71635b (sync with main branch)
            _gpuThread.Start();

            RenderLoop();
        }

        public void RenderLoop()
        {
            // Power through the render queue until the Gpu thread work is done.

<<<<<<< HEAD
            while (_running)
=======
            while (_running && !_disposed)
>>>>>>> 1ec71635b (sync with main branch)
            {
                _galWorkAvailable.Wait();
                _galWorkAvailable.Reset();

                if (Volatile.Read(ref _interruptAction) != null)
                {
                    _interruptAction();
                    _interruptRun.Set();

                    Interlocked.Exchange(ref _interruptAction, null);
                }

                // The other thread can only increase the command count.
                // We can assume that if it is above 0, it will stay there or get higher.

                while (Volatile.Read(ref _commandCount) > 0 && Volatile.Read(ref _interruptAction) == null)
                {
                    int commandPtr = _consumerPtr;

<<<<<<< HEAD
                    Span<byte> command = new(_commandQueue, commandPtr * _elementSize, _elementSize);
=======
                    Span<byte> command = new Span<byte>(_commandQueue, commandPtr * _elementSize, _elementSize);
>>>>>>> 1ec71635b (sync with main branch)

                    // Run the command.

                    CommandHelper.RunCommand(command, this, _baseRenderer);

                    if (Interlocked.CompareExchange(ref _invokePtr, -1, commandPtr) == commandPtr)
                    {
                        _invokeRun.Set();
                    }

                    _consumerPtr = (_consumerPtr + 1) % QueueCount;

                    Interlocked.Decrement(ref _commandCount);
                }
            }
        }

        internal SpanRef<T> CopySpan<T>(ReadOnlySpan<T> data) where T : unmanaged
        {
            return _spanPool.Insert(data);
        }

        private TableRef<T> Ref<T>(T reference)
        {
            return new TableRef<T>(this, reference);
        }

        internal ref T New<T>() where T : struct
        {
            while (_producerPtr == (Volatile.Read(ref _consumerPtr) + QueueCount - 1) % QueueCount)
            {
                // If incrementing the producer pointer would overflow, we need to wait.
                // _consumerPtr can only move forward, so there's no race to worry about here.

                Thread.Sleep(1);
            }

            int taken = _producerPtr;
            _lastProducedPtr = taken;

            _producerPtr = (_producerPtr + 1) % QueueCount;

<<<<<<< HEAD
            Span<byte> memory = new(_commandQueue, taken * _elementSize, _elementSize);
            ref T result = ref Unsafe.As<byte, T>(ref MemoryMarshal.GetReference(memory));

            memory[^1] = (byte)((IGALCommand)result).CommandType;
=======
            Span<byte> memory = new Span<byte>(_commandQueue, taken * _elementSize, _elementSize);
            ref T result = ref Unsafe.As<byte, T>(ref MemoryMarshal.GetReference(memory));

            memory[memory.Length - 1] = (byte)((IGALCommand)result).CommandType;
>>>>>>> 1ec71635b (sync with main branch)

            return ref result;
        }

        internal int AddTableRef(object obj)
        {
            // The reference table is sized so that it will never overflow, so long as the references are taken after the command is allocated.

            int index = _refProducerPtr;

            _refQueue[index] = obj;

            _refProducerPtr = (_refProducerPtr + 1) % _refQueue.Length;

            return index;
        }

        internal object RemoveTableRef(int index)
        {
            Debug.Assert(index == _refConsumerPtr);

            object result = _refQueue[_refConsumerPtr];
            _refQueue[_refConsumerPtr] = null;

            _refConsumerPtr = (_refConsumerPtr + 1) % _refQueue.Length;

            return result;
        }

        internal void QueueCommand()
        {
            int result = Interlocked.Increment(ref _commandCount);

            if (result == 1)
            {
                _galWorkAvailable.Set();
            }
        }

        internal void InvokeCommand()
        {
            _invokeRun.Reset();
            _invokePtr = _lastProducedPtr;

            QueueCommand();

            // Wait for the command to complete.
            _invokeRun.Wait();
        }

        internal void WaitForFrame()
        {
            _frameComplete.WaitOne();
        }

        internal void SignalFrame()
        {
            _frameComplete.Set();
        }

        internal bool IsGpuThread()
        {
            return Thread.CurrentThread == _gpuThread;
        }

        public void BackgroundContextAction(Action action, bool alwaysBackground = false)
        {
            if (IsGpuThread() && !alwaysBackground)
            {
                // The action must be performed on the render thread.
                New<ActionCommand>().Set(Ref(action));
                InvokeCommand();
            }
            else
            {
                _baseRenderer.BackgroundContextAction(action, true);
            }
        }

<<<<<<< HEAD
        public BufferHandle CreateBuffer(int size, BufferAccess access)
        {
            BufferHandle handle = Buffers.CreateBufferHandle();
            New<CreateBufferAccessCommand>().Set(handle, size, access);
            QueueCommand();

            return handle;
        }

        public BufferHandle CreateBuffer(int size, BufferAccess access, BufferHandle storageHint)
        {
            BufferHandle handle = Buffers.CreateBufferHandle();
            New<CreateBufferCommand>().Set(handle, size, access, storageHint);
=======
        public BufferHandle CreateBuffer(int size, BufferHandle storageHint)
        {
            BufferHandle handle = Buffers.CreateBufferHandle();
            New<CreateBufferCommand>().Set(handle, size, storageHint);
>>>>>>> 1ec71635b (sync with main branch)
            QueueCommand();

            return handle;
        }

        public BufferHandle CreateBuffer(nint pointer, int size)
        {
            BufferHandle handle = Buffers.CreateBufferHandle();
            New<CreateHostBufferCommand>().Set(handle, pointer, size);
            QueueCommand();

            return handle;
        }

<<<<<<< HEAD
        public BufferHandle CreateBufferSparse(ReadOnlySpan<BufferRange> storageBuffers)
        {
            BufferHandle handle = Buffers.CreateBufferHandle();
            New<CreateBufferSparseCommand>().Set(handle, CopySpan(storageBuffers));
=======
        public BufferHandle CreateBuffer(int size, BufferAccess access)
        {
            BufferHandle handle = Buffers.CreateBufferHandle();
            New<CreateBufferAccessCommand>().Set(handle, size, access);
>>>>>>> 1ec71635b (sync with main branch)
            QueueCommand();

            return handle;
        }

        public IProgram CreateProgram(ShaderSource[] shaders, ShaderInfo info)
        {
            var program = new ThreadedProgram(this);

<<<<<<< HEAD
            SourceProgramRequest request = new(program, shaders, info);
=======
            SourceProgramRequest request = new SourceProgramRequest(program, shaders, info);
>>>>>>> 1ec71635b (sync with main branch)

            Programs.Add(request);

            New<CreateProgramCommand>().Set(Ref((IProgramRequest)request));
            QueueCommand();

            return program;
        }

        public ISampler CreateSampler(SamplerCreateInfo info)
        {
            var sampler = new ThreadedSampler(this);
            New<CreateSamplerCommand>().Set(Ref(sampler), info);
            QueueCommand();

            return sampler;
        }

        public void CreateSync(ulong id, bool strict)
        {
            Sync.CreateSyncHandle(id);
            New<CreateSyncCommand>().Set(id, strict);
            QueueCommand();
        }

<<<<<<< HEAD
        public ITexture CreateTexture(TextureCreateInfo info)
        {
            if (IsGpuThread())
            {
                var texture = new ThreadedTexture(this, info);
                New<CreateTextureCommand>().Set(Ref(texture), info);
=======
        public ITexture CreateTexture(TextureCreateInfo info, float scale)
        {
            if (IsGpuThread())
            {
                var texture = new ThreadedTexture(this, info, scale);
                New<CreateTextureCommand>().Set(Ref(texture), info, scale);
>>>>>>> 1ec71635b (sync with main branch)
                QueueCommand();

                return texture;
            }
            else
            {
<<<<<<< HEAD
                var texture = new ThreadedTexture(this, info)
                {
                    Base = _baseRenderer.CreateTexture(info),
                };
=======
                var texture = new ThreadedTexture(this, info, scale);
                texture.Base = _baseRenderer.CreateTexture(info, scale);
>>>>>>> 1ec71635b (sync with main branch)

                return texture;
            }
        }

        public void DeleteBuffer(BufferHandle buffer)
        {
            New<BufferDisposeCommand>().Set(buffer);
            QueueCommand();
        }

        public PinnedSpan<byte> GetBufferData(BufferHandle buffer, int offset, int size)
        {
            if (IsGpuThread())
            {
<<<<<<< HEAD
                ResultBox<PinnedSpan<byte>> box = new();
=======
                ResultBox<PinnedSpan<byte>> box = new ResultBox<PinnedSpan<byte>>();
>>>>>>> 1ec71635b (sync with main branch)
                New<BufferGetDataCommand>().Set(buffer, offset, size, Ref(box));
                InvokeCommand();

                return box.Result;
            }
            else
            {
                return _baseRenderer.GetBufferData(Buffers.MapBufferBlocking(buffer), offset, size);
            }
        }

        public Capabilities GetCapabilities()
        {
<<<<<<< HEAD
            ResultBox<Capabilities> box = new();
=======
            ResultBox<Capabilities> box = new ResultBox<Capabilities>();
>>>>>>> 1ec71635b (sync with main branch)
            New<GetCapabilitiesCommand>().Set(Ref(box));
            InvokeCommand();

            return box.Result;
        }

        public ulong GetCurrentSync()
        {
            return _baseRenderer.GetCurrentSync();
        }

        public HardwareInfo GetHardwareInfo()
        {
            return _baseRenderer.GetHardwareInfo();
        }

        /// <summary>
        /// Initialize the base renderer. Must be called on the render thread.
        /// </summary>
        /// <param name="logLevel">Log level to use</param>
        public void Initialize(GraphicsDebugLevel logLevel)
        {
            _baseRenderer.Initialize(logLevel);
        }

        public IProgram LoadProgramBinary(byte[] programBinary, bool hasFragmentShader, ShaderInfo info)
        {
            var program = new ThreadedProgram(this);

<<<<<<< HEAD
            BinaryProgramRequest request = new(program, programBinary, hasFragmentShader, info);
=======
            BinaryProgramRequest request = new BinaryProgramRequest(program, programBinary, hasFragmentShader, info);
>>>>>>> 1ec71635b (sync with main branch)
            Programs.Add(request);

            New<CreateProgramCommand>().Set(Ref((IProgramRequest)request));
            QueueCommand();

            return program;
        }

        public void PreFrame()
        {
            New<PreFrameCommand>();
            QueueCommand();
        }

<<<<<<< HEAD
        public ICounterEvent ReportCounter(CounterType type, EventHandler<ulong> resultHandler, float divisor, bool hostReserved)
        {
            ThreadedCounterEvent evt = new(this, type, _lastSampleCounterClear);
            New<ReportCounterCommand>().Set(Ref(evt), type, Ref(resultHandler), divisor, hostReserved);
=======
        public ICounterEvent ReportCounter(CounterType type, EventHandler<ulong> resultHandler, bool hostReserved)
        {
            ThreadedCounterEvent evt = new ThreadedCounterEvent(this, type, _lastSampleCounterClear);
            New<ReportCounterCommand>().Set(Ref(evt), type, Ref(resultHandler), hostReserved);
>>>>>>> 1ec71635b (sync with main branch)
            QueueCommand();

            if (type == CounterType.SamplesPassed)
            {
                _lastSampleCounterClear = false;
            }

            return evt;
        }

        public void ResetCounter(CounterType type)
        {
            New<ResetCounterCommand>().Set(type);
            QueueCommand();
            _lastSampleCounterClear = true;
        }

        public void Screenshot()
        {
            _baseRenderer.Screenshot();
        }

        public void SetBufferData(BufferHandle buffer, int offset, ReadOnlySpan<byte> data)
        {
            New<BufferSetDataCommand>().Set(buffer, offset, CopySpan(data));
            QueueCommand();
        }

        public void UpdateCounters()
        {
            New<UpdateCountersCommand>();
            QueueCommand();
        }

        public void WaitSync(ulong id)
        {
            Sync.WaitSyncAvailability(id);

            _baseRenderer.WaitSync(id);
        }

        private void Interrupt(Action action)
        {
            // Interrupt the backend thread from any external thread and invoke the given action.

            if (Thread.CurrentThread == _backendThread)
            {
                // If this is called from the backend thread, the action can run immediately.
                action();
            }
            else
            {
                lock (_interruptLock)
                {
<<<<<<< HEAD
                    while (Interlocked.CompareExchange(ref _interruptAction, action, null) != null)
                    {
                    }
=======
                    while (Interlocked.CompareExchange(ref _interruptAction, action, null) != null) { }
>>>>>>> 1ec71635b (sync with main branch)

                    _galWorkAvailable.Set();

                    _interruptRun.WaitOne();
                }
            }
        }

        public void SetInterruptAction(Action<Action> interruptAction)
        {
            // Threaded renderer ignores given interrupt action, as it provides its own to the child renderer.
        }

        public bool PrepareHostMapping(nint address, ulong size)
        {
            return _baseRenderer.PrepareHostMapping(address, size);
        }

<<<<<<< HEAD
        public void FlushThreadedCommands()
        {
            SpinWait wait = new();

            while (Volatile.Read(ref _commandCount) > 0)
            {
                wait.SpinOnce();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            // Dispose must happen from the render thread, after all commands have completed.

            // Stop the GPU thread.
            _running = false;
            _galWorkAvailable.Set();
=======
        public void Dispose()
        {
            // Dispose must happen from the render thread, after all commands have completed.

            // Stop the GPU thread.
            _disposed = true;
>>>>>>> 1ec71635b (sync with main branch)

            if (_gpuThread != null && _gpuThread.IsAlive)
            {
                _gpuThread.Join();
            }

            // Dispose the renderer.
            _baseRenderer.Dispose();

            // Dispose events.
            _frameComplete.Dispose();
            _galWorkAvailable.Dispose();
            _invokeRun.Dispose();
            _interruptRun.Dispose();

            Sync.Dispose();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
