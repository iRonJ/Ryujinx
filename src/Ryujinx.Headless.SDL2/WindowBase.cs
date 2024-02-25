<<<<<<< HEAD
=======
﻿using ARMeilleure.Translation;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Configuration;
using Ryujinx.Common.Configuration.Hid;
using Ryujinx.Common.Logging;
using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.GAL.Multithreading;
<<<<<<< HEAD
using Ryujinx.Graphics.Gpu;
using Ryujinx.Graphics.OpenGL;
using Ryujinx.HLE.HOS.Applets;
using Ryujinx.HLE.HOS.Services.Am.AppletOE.ApplicationProxyService.ApplicationProxy.Types;
using Ryujinx.HLE.UI;
=======
using Ryujinx.HLE.HOS.Applets;
using Ryujinx.HLE.HOS.Services.Am.AppletOE.ApplicationProxyService.ApplicationProxy.Types;
using Ryujinx.HLE.Ui;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Input;
using Ryujinx.Input.HLE;
using Ryujinx.SDL2.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
<<<<<<< HEAD
using System.Runtime.InteropServices;
using System.Threading;
using static SDL2.SDL;
using AntiAliasing = Ryujinx.Common.Configuration.AntiAliasing;
using ScalingFilter = Ryujinx.Common.Configuration.ScalingFilter;
=======
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using static SDL2.SDL;
>>>>>>> 1ec71635b (sync with main branch)
using Switch = Ryujinx.HLE.Switch;

namespace Ryujinx.Headless.SDL2
{
<<<<<<< HEAD
    abstract partial class WindowBase : IHostUIHandler, IDisposable
    {
        protected const int DefaultWidth = 1280;
        protected const int DefaultHeight = 720;
        private const int TargetFps = 60;
        private SDL_WindowFlags DefaultFlags = SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI | SDL_WindowFlags.SDL_WINDOW_RESIZABLE | SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS | SDL_WindowFlags.SDL_WINDOW_SHOWN;
        private SDL_WindowFlags FullscreenFlag = 0;

        private static readonly ConcurrentQueue<Action> _mainThreadActions = new();
=======
    abstract partial class WindowBase : IHostUiHandler, IDisposable
    {
        protected const int DefaultWidth = 1280;
        protected const int DefaultHeight = 720;
        private const SDL_WindowFlags DefaultFlags = SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI | SDL_WindowFlags.SDL_WINDOW_RESIZABLE | SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS | SDL_WindowFlags.SDL_WINDOW_SHOWN;
        private const int TargetFps = 60;

        private static ConcurrentQueue<Action> MainThreadActions = new ConcurrentQueue<Action>();
>>>>>>> 1ec71635b (sync with main branch)

        [LibraryImport("SDL2")]
        // TODO: Remove this as soon as SDL2-CS was updated to expose this method publicly
        private static partial IntPtr SDL_LoadBMP_RW(IntPtr src, int freesrc);

        public static void QueueMainThreadAction(Action action)
        {
<<<<<<< HEAD
            _mainThreadActions.Enqueue(action);
=======
            MainThreadActions.Enqueue(action);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public NpadManager NpadManager { get; }
        public TouchScreenManager TouchScreenManager { get; }
        public Switch Device { get; private set; }
        public IRenderer Renderer { get; private set; }

        public event EventHandler<StatusUpdatedEventArgs> StatusUpdatedEvent;

        protected IntPtr WindowHandle { get; set; }

<<<<<<< HEAD
        public IHostUITheme HostUITheme { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int DisplayId { get; set; }
        public bool IsFullscreen { get; set; }
        public bool IsExclusiveFullscreen { get; set; }
        public int ExclusiveFullscreenWidth { get; set; }
        public int ExclusiveFullscreenHeight { get; set; }
        public AntiAliasing AntiAliasing { get; set; }
        public ScalingFilter ScalingFilter { get; set; }
        public int ScalingFilterLevel { get; set; }

        protected SDL2MouseDriver MouseDriver;
        private readonly InputManager _inputManager;
        private readonly IKeyboard _keyboardInterface;
        private readonly GraphicsDebugLevel _glLogLevel;
=======
        public IHostUiTheme HostUiTheme { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        protected SDL2MouseDriver MouseDriver;
        private InputManager _inputManager;
        private IKeyboard _keyboardInterface;
        private GraphicsDebugLevel _glLogLevel;
>>>>>>> 1ec71635b (sync with main branch)
        private readonly Stopwatch _chrono;
        private readonly long _ticksPerFrame;
        private readonly CancellationTokenSource _gpuCancellationTokenSource;
        private readonly ManualResetEvent _exitEvent;
<<<<<<< HEAD
        private readonly ManualResetEvent _gpuDoneEvent;
=======
>>>>>>> 1ec71635b (sync with main branch)

        private long _ticks;
        private bool _isActive;
        private bool _isStopped;
        private uint _windowId;

<<<<<<< HEAD
        private string _gpuDriverName;

        private readonly AspectRatio _aspectRatio;
        private readonly bool _enableMouse;
=======
        private string _gpuVendorName;

        private AspectRatio _aspectRatio;
        private bool _enableMouse;
>>>>>>> 1ec71635b (sync with main branch)

        public WindowBase(
            InputManager inputManager,
            GraphicsDebugLevel glLogLevel,
            AspectRatio aspectRatio,
            bool enableMouse,
            HideCursorMode hideCursorMode)
        {
            MouseDriver = new SDL2MouseDriver(hideCursorMode);
            _inputManager = inputManager;
            _inputManager.SetMouseDriver(MouseDriver);
            NpadManager = _inputManager.CreateNpadManager();
            TouchScreenManager = _inputManager.CreateTouchScreenManager();
            _keyboardInterface = (IKeyboard)_inputManager.KeyboardDriver.GetGamepad("0");
            _glLogLevel = glLogLevel;
            _chrono = new Stopwatch();
            _ticksPerFrame = Stopwatch.Frequency / TargetFps;
            _gpuCancellationTokenSource = new CancellationTokenSource();
            _exitEvent = new ManualResetEvent(false);
<<<<<<< HEAD
            _gpuDoneEvent = new ManualResetEvent(false);
            _aspectRatio = aspectRatio;
            _enableMouse = enableMouse;
            HostUITheme = new HeadlessHostUiTheme();
=======
            _aspectRatio = aspectRatio;
            _enableMouse = enableMouse;
            HostUiTheme = new HeadlessHostUiTheme();
>>>>>>> 1ec71635b (sync with main branch)

            SDL2Driver.Instance.Initialize();
        }

        public void Initialize(Switch device, List<InputConfig> inputConfigs, bool enableKeyboard, bool enableMouse)
        {
            Device = device;

            IRenderer renderer = Device.Gpu.Renderer;

            if (renderer is ThreadedRenderer tr)
            {
                renderer = tr.BaseRenderer;
            }

            Renderer = renderer;

            NpadManager.Initialize(device, inputConfigs, enableKeyboard, enableMouse);
            TouchScreenManager.Initialize(device);
        }

        private void SetWindowIcon()
        {
<<<<<<< HEAD
            Stream iconStream = typeof(WindowBase).Assembly.GetManifestResourceStream("Ryujinx.Headless.SDL2.Ryujinx.bmp");
=======
            Stream iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Ryujinx.Headless.SDL2.Ryujinx.bmp");
>>>>>>> 1ec71635b (sync with main branch)
            byte[] iconBytes = new byte[iconStream!.Length];

            if (iconStream.Read(iconBytes, 0, iconBytes.Length) != iconBytes.Length)
            {
                Logger.Error?.Print(LogClass.Application, "Failed to read icon to byte array.");
                iconStream.Close();

                return;
            }

            iconStream.Close();

            unsafe
            {
                fixed (byte* iconPtr = iconBytes)
                {
                    IntPtr rwOpsStruct = SDL_RWFromConstMem((IntPtr)iconPtr, iconBytes.Length);
                    IntPtr iconHandle = SDL_LoadBMP_RW(rwOpsStruct, 1);

                    SDL_SetWindowIcon(WindowHandle, iconHandle);
                    SDL_FreeSurface(iconHandle);
                }
            }
        }

        private void InitializeWindow()
        {
            var activeProcess = Device.Processes.ActiveApplication;
            var nacp = activeProcess.ApplicationControlProperties;
            int desiredLanguage = (int)Device.System.State.DesiredTitleLanguage;

            string titleNameSection = string.IsNullOrWhiteSpace(nacp.Title[desiredLanguage].NameString.ToString()) ? string.Empty : $" - {nacp.Title[desiredLanguage].NameString.ToString()}";
            string titleVersionSection = string.IsNullOrWhiteSpace(nacp.DisplayVersionString.ToString()) ? string.Empty : $" v{nacp.DisplayVersionString.ToString()}";
            string titleIdSection = string.IsNullOrWhiteSpace(activeProcess.ProgramIdText) ? string.Empty : $" ({activeProcess.ProgramIdText.ToUpper()})";
            string titleArchSection = activeProcess.Is64Bit ? " (64-bit)" : " (32-bit)";

<<<<<<< HEAD
            Width = DefaultWidth;
            Height = DefaultHeight;

            if (IsExclusiveFullscreen)
            {
                Width = ExclusiveFullscreenWidth;
                Height = ExclusiveFullscreenHeight;

                DefaultFlags = SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI;
                FullscreenFlag = SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;
            }
            else if (IsFullscreen)
            {
                DefaultFlags = SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI;
                FullscreenFlag = SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP;
            }

            WindowHandle = SDL_CreateWindow($"Ryujinx {Program.Version}{titleNameSection}{titleVersionSection}{titleIdSection}{titleArchSection}", SDL_WINDOWPOS_CENTERED_DISPLAY(DisplayId), SDL_WINDOWPOS_CENTERED_DISPLAY(DisplayId), Width, Height, DefaultFlags | FullscreenFlag | GetWindowFlags());
=======
            WindowHandle = SDL_CreateWindow($"Ryujinx {Program.Version}{titleNameSection}{titleVersionSection}{titleIdSection}{titleArchSection}", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, DefaultWidth, DefaultHeight, DefaultFlags | GetWindowFlags());
>>>>>>> 1ec71635b (sync with main branch)

            if (WindowHandle == IntPtr.Zero)
            {
                string errorMessage = $"SDL_CreateWindow failed with error \"{SDL_GetError()}\"";

                Logger.Error?.Print(LogClass.Application, errorMessage);

                throw new Exception(errorMessage);
            }

            SetWindowIcon();

            _windowId = SDL_GetWindowID(WindowHandle);
            SDL2Driver.Instance.RegisterWindow(_windowId, HandleWindowEvent);
<<<<<<< HEAD
=======

            Width = DefaultWidth;
            Height = DefaultHeight;
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void HandleWindowEvent(SDL_Event evnt)
        {
            if (evnt.type == SDL_EventType.SDL_WINDOWEVENT)
            {
                switch (evnt.window.windowEvent)
                {
                    case SDL_WindowEventID.SDL_WINDOWEVENT_SIZE_CHANGED:
<<<<<<< HEAD
                        // Unlike on Windows, this event fires on macOS when triggering fullscreen mode.
                        // And promptly crashes the process because `Renderer?.window.SetSize` is undefined.
                        // As we don't need this to fire in either case we can test for fullscreen.
                        if (!IsFullscreen && !IsExclusiveFullscreen)
                        {
                            Width = evnt.window.data1;
                            Height = evnt.window.data2;
                            Renderer?.Window.SetSize(Width, Height);
                            MouseDriver.SetClientSize(Width, Height);
                        }
=======
                        Width = evnt.window.data1;
                        Height = evnt.window.data2;
                        Renderer?.Window.SetSize(Width, Height);
                        MouseDriver.SetClientSize(Width, Height);
>>>>>>> 1ec71635b (sync with main branch)
                        break;

                    case SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE:
                        Exit();
                        break;
<<<<<<< HEAD
=======

                    default:
                        break;
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
            else
            {
                MouseDriver.Update(evnt);
            }
        }

        protected abstract void InitializeWindowRenderer();

        protected abstract void InitializeRenderer();

        protected abstract void FinalizeWindowRenderer();

        protected abstract void SwapBuffers();

        public abstract SDL_WindowFlags GetWindowFlags();

<<<<<<< HEAD
        private string GetGpuDriverName()
        {
            return Renderer.GetHardwareInfo().GpuDriver;
        }

        private void SetAntiAliasing()
        {
            Renderer?.Window.SetAntiAliasing((Graphics.GAL.AntiAliasing)AntiAliasing);
        }

        private void SetScalingFilter()
        {
            Renderer?.Window.SetScalingFilter((Graphics.GAL.ScalingFilter)ScalingFilter);
            Renderer?.Window.SetScalingFilterLevel(ScalingFilterLevel);
=======
        private string GetGpuVendorName()
        {
            return Renderer.GetHardwareInfo().GpuVendor;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void Render()
        {
            InitializeWindowRenderer();

            Device.Gpu.Renderer.Initialize(_glLogLevel);

            InitializeRenderer();

<<<<<<< HEAD
            SetAntiAliasing();

            SetScalingFilter();

            _gpuDriverName = GetGpuDriverName();
=======
            _gpuVendorName = GetGpuVendorName();
>>>>>>> 1ec71635b (sync with main branch)

            Device.Gpu.Renderer.RunLoop(() =>
            {
                Device.Gpu.SetGpuThread();
                Device.Gpu.InitializeShaderCache(_gpuCancellationTokenSource.Token);
<<<<<<< HEAD
=======
                Translator.IsReadyForTranslation.Set();
>>>>>>> 1ec71635b (sync with main branch)

                while (_isActive)
                {
                    if (_isStopped)
                    {
                        return;
                    }

                    _ticks += _chrono.ElapsedTicks;

                    _chrono.Restart();

                    if (Device.WaitFifo())
                    {
                        Device.Statistics.RecordFifoStart();
                        Device.ProcessFrame();
                        Device.Statistics.RecordFifoEnd();
                    }

                    while (Device.ConsumeFrameAvailable())
                    {
                        Device.PresentFrame(SwapBuffers);
                    }

                    if (_ticks >= _ticksPerFrame)
                    {
                        string dockedMode = Device.System.State.DockedMode ? "Docked" : "Handheld";
<<<<<<< HEAD
                        float scale = GraphicsConfig.ResScale;
=======
                        float scale = Graphics.Gpu.GraphicsConfig.ResScale;
>>>>>>> 1ec71635b (sync with main branch)
                        if (scale != 1)
                        {
                            dockedMode += $" ({scale}x)";
                        }

                        StatusUpdatedEvent?.Invoke(this, new StatusUpdatedEventArgs(
                            Device.EnableDeviceVsync,
                            dockedMode,
                            Device.Configuration.AspectRatio.ToText(),
                            $"Game: {Device.Statistics.GetGameFrameRate():00.00} FPS ({Device.Statistics.GetGameFrameTime():00.00} ms)",
                            $"FIFO: {Device.Statistics.GetFifoPercent():0.00} %",
<<<<<<< HEAD
                            $"GPU: {_gpuDriverName}"));
=======
                            $"GPU: {_gpuVendorName}"));
>>>>>>> 1ec71635b (sync with main branch)

                        _ticks = Math.Min(_ticks - _ticksPerFrame, _ticksPerFrame);
                    }
                }
<<<<<<< HEAD

                // Make sure all commands in the run loop are fully executed before leaving the loop.
                if (Device.Gpu.Renderer is ThreadedRenderer threaded)
                {
                    threaded.FlushThreadedCommands();
                }

                _gpuDoneEvent.Set();
=======
>>>>>>> 1ec71635b (sync with main branch)
            });

            FinalizeWindowRenderer();
        }

        public void Exit()
        {
            TouchScreenManager?.Dispose();
            NpadManager?.Dispose();

            if (_isStopped)
            {
                return;
            }

            _gpuCancellationTokenSource.Cancel();

            _isStopped = true;
            _isActive = false;

            _exitEvent.WaitOne();
            _exitEvent.Dispose();
        }

<<<<<<< HEAD
        public static void ProcessMainThreadQueue()
        {
            while (_mainThreadActions.TryDequeue(out Action action))
=======
        public void ProcessMainThreadQueue()
        {
            while (MainThreadActions.TryDequeue(out Action action))
>>>>>>> 1ec71635b (sync with main branch)
            {
                action();
            }
        }

        public void MainLoop()
        {
            while (_isActive)
            {
                UpdateFrame();

                SDL_PumpEvents();

                ProcessMainThreadQueue();

                // Polling becomes expensive if it's not slept
                Thread.Sleep(1);
            }

            _exitEvent.Set();
        }

<<<<<<< HEAD
        private void NvidiaStutterWorkaround()
=======
        private void NVStutterWorkaround()
>>>>>>> 1ec71635b (sync with main branch)
        {
            while (_isActive)
            {
                // When NVIDIA Threaded Optimization is on, the driver will snapshot all threads in the system whenever the application creates any new ones.
                // The ThreadPool has something called a "GateThread" which terminates itself after some inactivity.
                // However, it immediately starts up again, since the rules regarding when to terminate and when to start differ.
                // This creates a new thread every second or so.
                // The main problem with this is that the thread snapshot can take 70ms, is on the OpenGL thread and will delay rendering any graphics.
                // This is a little over budget on a frame time of 16ms, so creates a large stutter.
                // The solution is to keep the ThreadPool active so that it never has a reason to terminate the GateThread.

                // TODO: This should be removed when the issue with the GateThread is resolved.

<<<<<<< HEAD
                ThreadPool.QueueUserWorkItem(state => { });
=======
                ThreadPool.QueueUserWorkItem((state) => { });
>>>>>>> 1ec71635b (sync with main branch)
                Thread.Sleep(300);
            }
        }

        private bool UpdateFrame()
        {
            if (!_isActive)
            {
                return true;
            }

            if (_isStopped)
            {
                return false;
            }

            NpadManager.Update();

            // Touchscreen
            bool hasTouch = false;

            // Get screen touch position
            if (!_enableMouse)
            {
                hasTouch = TouchScreenManager.Update(true, (_inputManager.MouseDriver as SDL2MouseDriver).IsButtonPressed(MouseButton.Button1), _aspectRatio.ToFloat());
            }

            if (!hasTouch)
            {
                TouchScreenManager.Update(false);
            }

            Device.Hid.DebugPad.Update();

            // TODO: Replace this with MouseDriver.CheckIdle() when mouse motion events are received on every supported platform.
            MouseDriver.UpdatePosition();

            return true;
        }

        public void Execute()
        {
            _chrono.Restart();
            _isActive = true;

            InitializeWindow();

<<<<<<< HEAD
            Thread renderLoopThread = new(Render)
            {
                Name = "GUI.RenderLoop",
            };
            renderLoopThread.Start();

            Thread nvidiaStutterWorkaround = null;
            if (Renderer is OpenGLRenderer)
            {
                nvidiaStutterWorkaround = new Thread(NvidiaStutterWorkaround)
                {
                    Name = "GUI.NvidiaStutterWorkaround",
                };
                nvidiaStutterWorkaround.Start();
=======
            Thread renderLoopThread = new Thread(Render)
            {
                Name = "GUI.RenderLoop"
            };
            renderLoopThread.Start();

            Thread nvStutterWorkaround = null;
            if (Renderer is Graphics.OpenGL.OpenGLRenderer)
            {
                nvStutterWorkaround = new Thread(NVStutterWorkaround)
                {
                    Name = "GUI.NVStutterWorkaround"
                };
                nvStutterWorkaround.Start();
>>>>>>> 1ec71635b (sync with main branch)
            }

            MainLoop();

<<<<<<< HEAD
            // NOTE: The render loop is allowed to stay alive until the renderer itself is disposed, as it may handle resource dispose.
            // We only need to wait for all commands submitted during the main gpu loop to be processed.
            _gpuDoneEvent.WaitOne();
            _gpuDoneEvent.Dispose();
            nvidiaStutterWorkaround?.Join();
=======
            renderLoopThread.Join();
            nvStutterWorkaround?.Join();
>>>>>>> 1ec71635b (sync with main branch)

            Exit();
        }

<<<<<<< HEAD
        public bool DisplayInputDialog(SoftwareKeyboardUIArgs args, out string userText)
=======
        public bool DisplayInputDialog(SoftwareKeyboardUiArgs args, out string userText)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // SDL2 doesn't support input dialogs
            userText = "Ryujinx";

            return true;
        }

        public bool DisplayMessageDialog(string title, string message)
        {
            SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION, title, message, WindowHandle);

            return true;
        }

<<<<<<< HEAD
        public bool DisplayMessageDialog(ControllerAppletUIArgs args)
=======
        public bool DisplayMessageDialog(ControllerAppletUiArgs args)
>>>>>>> 1ec71635b (sync with main branch)
        {
            string playerCount = args.PlayerCountMin == args.PlayerCountMax ? $"exactly {args.PlayerCountMin}" : $"{args.PlayerCountMin}-{args.PlayerCountMax}";

            string message = $"Application requests {playerCount} player(s) with:\n\n"
                           + $"TYPES: {args.SupportedStyles}\n\n"
                           + $"PLAYERS: {string.Join(", ", args.SupportedPlayers)}\n\n"
                           + (args.IsDocked ? "Docked mode set. Handheld is also invalid.\n\n" : "")
                           + "Please reconfigure Input now and then press OK.";

            return DisplayMessageDialog("Controller Applet", message);
        }

        public IDynamicTextInputHandler CreateDynamicTextInputHandler()
        {
            return new HeadlessDynamicTextInputHandler();
        }

        public void ExecuteProgram(Switch device, ProgramSpecifyKind kind, ulong value)
        {
            device.Configuration.UserChannelPersistence.ExecuteProgram(kind, value);

            Exit();
        }

        public bool DisplayErrorAppletDialog(string title, string message, string[] buttonsText)
        {
<<<<<<< HEAD
            SDL_MessageBoxData data = new()
=======
            SDL_MessageBoxData data = new SDL_MessageBoxData
>>>>>>> 1ec71635b (sync with main branch)
            {
                title = title,
                message = message,
                buttons = new SDL_MessageBoxButtonData[buttonsText.Length],
                numbuttons = buttonsText.Length,
<<<<<<< HEAD
                window = WindowHandle,
=======
                window = WindowHandle
>>>>>>> 1ec71635b (sync with main branch)
            };

            for (int i = 0; i < buttonsText.Length; i++)
            {
                data.buttons[i] = new SDL_MessageBoxButtonData
                {
                    buttonid = i,
<<<<<<< HEAD
                    text = buttonsText[i],
=======
                    text = buttonsText[i]
>>>>>>> 1ec71635b (sync with main branch)
                };
            }

            SDL_ShowMessageBox(ref data, out int _);

            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _isActive = false;
                TouchScreenManager?.Dispose();
                NpadManager.Dispose();

                SDL2Driver.Instance.UnregisterWindow(_windowId);

                SDL_DestroyWindow(WindowHandle);

                SDL2Driver.Instance.Dispose();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
