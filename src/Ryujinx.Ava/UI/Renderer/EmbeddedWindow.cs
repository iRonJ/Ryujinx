using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform;
using Ryujinx.Common.Configuration;
<<<<<<< HEAD
using Ryujinx.UI.Common.Configuration;
using Ryujinx.UI.Common.Helper;
=======
using Ryujinx.Ui.Common.Configuration;
using Ryujinx.Ui.Common.Helper;
>>>>>>> 1ec71635b (sync with main branch)
using SPB.Graphics;
using SPB.Platform;
using SPB.Platform.GLX;
using SPB.Platform.X11;
using SPB.Windowing;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using static Ryujinx.Ava.UI.Helpers.Win32NativeInterop;

namespace Ryujinx.Ava.UI.Renderer
{
    public class EmbeddedWindow : NativeControlHost
    {
        private WindowProc _wndProcDelegate;
<<<<<<< HEAD
        private string _className;
=======
        private string     _className;
>>>>>>> 1ec71635b (sync with main branch)

        protected GLXWindow X11Window { get; set; }

        protected IntPtr WindowHandle { get; set; }
<<<<<<< HEAD
        protected IntPtr X11Display { get; set; }
        protected IntPtr NsView { get; set; }
        protected IntPtr MetalLayer { get; set; }
=======
        protected IntPtr X11Display   { get; set; }
        protected IntPtr NsView       { get; set; }
        protected IntPtr MetalLayer   { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        public delegate void UpdateBoundsCallbackDelegate(Rect rect);
        private UpdateBoundsCallbackDelegate _updateBoundsCallback;

        public event EventHandler<IntPtr> WindowCreated;
<<<<<<< HEAD
        public event EventHandler<Size> BoundsChanged;
=======
        public event EventHandler<Size>   SizeChanged;
>>>>>>> 1ec71635b (sync with main branch)

        public EmbeddedWindow()
        {
            this.GetObservable(BoundsProperty).Subscribe(StateChanged);

            Initialized += OnNativeEmbeddedWindowCreated;
        }

        public virtual void OnWindowCreated() { }

        protected virtual void OnWindowDestroyed() { }

        protected virtual void OnWindowDestroying()
        {
            WindowHandle = IntPtr.Zero;
<<<<<<< HEAD
            X11Display = IntPtr.Zero;
            NsView = IntPtr.Zero;
            MetalLayer = IntPtr.Zero;
=======
            X11Display   = IntPtr.Zero;
            NsView       = IntPtr.Zero;
            MetalLayer   = IntPtr.Zero;
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void OnNativeEmbeddedWindowCreated(object sender, EventArgs e)
        {
            OnWindowCreated();

            Task.Run(() =>
            {
                WindowCreated?.Invoke(this, WindowHandle);
            });
        }

        private void StateChanged(Rect rect)
        {
<<<<<<< HEAD
            BoundsChanged?.Invoke(this, rect.Size);
=======
            SizeChanged?.Invoke(this, rect.Size);
>>>>>>> 1ec71635b (sync with main branch)
            _updateBoundsCallback?.Invoke(rect);
        }

        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle control)
        {
            if (OperatingSystem.IsLinux())
            {
                return CreateLinux(control);
            }
<<<<<<< HEAD

            if (OperatingSystem.IsWindows())
            {
                return CreateWin32(control);
            }

            if (OperatingSystem.IsMacOS())
=======
            else if (OperatingSystem.IsWindows())
            {
                return CreateWin32(control);
            }
            else if (OperatingSystem.IsMacOS())
>>>>>>> 1ec71635b (sync with main branch)
            {
                return CreateMacOS();
            }

            return base.CreateNativeControlCore(control);
        }

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
            OnWindowDestroying();

            if (OperatingSystem.IsLinux())
            {
                DestroyLinux();
            }
            else if (OperatingSystem.IsWindows())
            {
                DestroyWin32(control);
            }
            else if (OperatingSystem.IsMacOS())
            {
                DestroyMacOS();
            }
            else
            {
                base.DestroyNativeControlCore(control);
            }

            OnWindowDestroyed();
        }

        [SupportedOSPlatform("linux")]
        private IPlatformHandle CreateLinux(IPlatformHandle control)
        {
            if (ConfigurationState.Instance.Graphics.GraphicsBackend.Value == GraphicsBackend.Vulkan)
            {
                X11Window = new GLXWindow(new NativeHandle(X11.DefaultDisplay), new NativeHandle(control.Handle));
                X11Window.Hide();
            }
            else
            {
<<<<<<< HEAD
                X11Window = PlatformHelper.CreateOpenGLWindow(new FramebufferFormat(new ColorFormat(8, 8, 8, 0), 16, 0, ColorFormat.Zero, 0, 2, false), 0, 0, 100, 100) as GLXWindow;
            }

            WindowHandle = X11Window.WindowHandle.RawHandle;
            X11Display = X11Window.DisplayHandle.RawHandle;
=======
                X11Window = PlatformHelper.CreateOpenGLWindow(FramebufferFormat.Default, 0, 0, 100, 100) as GLXWindow;
            }

            WindowHandle = X11Window.WindowHandle.RawHandle;
            X11Display   = X11Window.DisplayHandle.RawHandle;
>>>>>>> 1ec71635b (sync with main branch)

            return new PlatformHandle(WindowHandle, "X11");
        }

        [SupportedOSPlatform("windows")]
        IPlatformHandle CreateWin32(IPlatformHandle control)
        {
            _className = "NativeWindow-" + Guid.NewGuid();

            _wndProcDelegate = delegate (IntPtr hWnd, WindowsMessages msg, IntPtr wParam, IntPtr lParam)
            {
                if (VisualRoot != null)
                {
<<<<<<< HEAD
                    if (msg == WindowsMessages.Lbuttondown ||
                        msg == WindowsMessages.Rbuttondown ||
                        msg == WindowsMessages.Lbuttonup ||
                        msg == WindowsMessages.Rbuttonup ||
                        msg == WindowsMessages.Mousemove)
                    {
                        Point rootVisualPosition = this.TranslatePoint(new Point((long)lParam & 0xFFFF, (long)lParam >> 16 & 0xFFFF), this).Value;
                        Pointer pointer = new(0, PointerType.Mouse, true);

#pragma warning disable CS0618 // Type or member is obsolete (As of Avalonia 11, the constructors for PointerPressedEventArgs & PointerEventArgs are marked as obsolete)
                        switch (msg)
                        {
                            case WindowsMessages.Lbuttondown:
                            case WindowsMessages.Rbuttondown:
                                {
                                    bool isLeft = msg == WindowsMessages.Lbuttondown;
                                    RawInputModifiers pointerPointModifier = isLeft ? RawInputModifiers.LeftMouseButton : RawInputModifiers.RightMouseButton;
                                    PointerPointProperties properties = new(pointerPointModifier, isLeft ? PointerUpdateKind.LeftButtonPressed : PointerUpdateKind.RightButtonPressed);
=======
                    if (msg == WindowsMessages.LBUTTONDOWN ||
                        msg == WindowsMessages.RBUTTONDOWN ||
                        msg == WindowsMessages.LBUTTONUP   ||
                        msg == WindowsMessages.RBUTTONUP   ||
                        msg == WindowsMessages.MOUSEMOVE)
                    {
                        Point   rootVisualPosition = this.TranslatePoint(new Point((long)lParam & 0xFFFF, (long)lParam >> 16 & 0xFFFF), VisualRoot).Value;
                        Pointer pointer            = new(0, PointerType.Mouse, true);

                        switch (msg)
                        {
                            case WindowsMessages.LBUTTONDOWN:
                            case WindowsMessages.RBUTTONDOWN:
                                {
                                    bool                   isLeft               = msg == WindowsMessages.LBUTTONDOWN;
                                    RawInputModifiers      pointerPointModifier = isLeft ? RawInputModifiers.LeftMouseButton : RawInputModifiers.RightMouseButton;
                                    PointerPointProperties properties           = new(pointerPointModifier, isLeft ? PointerUpdateKind.LeftButtonPressed : PointerUpdateKind.RightButtonPressed);
>>>>>>> 1ec71635b (sync with main branch)

                                    var evnt = new PointerPressedEventArgs(
                                        this,
                                        pointer,
<<<<<<< HEAD
                                        this,
=======
                                        VisualRoot,
>>>>>>> 1ec71635b (sync with main branch)
                                        rootVisualPosition,
                                        (ulong)Environment.TickCount64,
                                        properties,
                                        KeyModifiers.None);

                                    RaiseEvent(evnt);

                                    break;
                                }
<<<<<<< HEAD
                            case WindowsMessages.Lbuttonup:
                            case WindowsMessages.Rbuttonup:
                                {
                                    bool isLeft = msg == WindowsMessages.Lbuttonup;
                                    RawInputModifiers pointerPointModifier = isLeft ? RawInputModifiers.LeftMouseButton : RawInputModifiers.RightMouseButton;
                                    PointerPointProperties properties = new(pointerPointModifier, isLeft ? PointerUpdateKind.LeftButtonReleased : PointerUpdateKind.RightButtonReleased);
=======
                            case WindowsMessages.LBUTTONUP:
                            case WindowsMessages.RBUTTONUP:
                                {
                                    bool                   isLeft               = msg == WindowsMessages.LBUTTONUP;
                                    RawInputModifiers      pointerPointModifier = isLeft ? RawInputModifiers.LeftMouseButton : RawInputModifiers.RightMouseButton;
                                    PointerPointProperties properties           = new(pointerPointModifier, isLeft ? PointerUpdateKind.LeftButtonReleased : PointerUpdateKind.RightButtonReleased);
>>>>>>> 1ec71635b (sync with main branch)

                                    var evnt = new PointerReleasedEventArgs(
                                        this,
                                        pointer,
<<<<<<< HEAD
                                        this,
=======
                                        VisualRoot,
>>>>>>> 1ec71635b (sync with main branch)
                                        rootVisualPosition,
                                        (ulong)Environment.TickCount64,
                                        properties,
                                        KeyModifiers.None,
                                        isLeft ? MouseButton.Left : MouseButton.Right);

                                    RaiseEvent(evnt);

                                    break;
                                }
<<<<<<< HEAD
                            case WindowsMessages.Mousemove:
=======
                            case WindowsMessages.MOUSEMOVE:
>>>>>>> 1ec71635b (sync with main branch)
                                {
                                    var evnt = new PointerEventArgs(
                                        PointerMovedEvent,
                                        this,
                                        pointer,
<<<<<<< HEAD
                                        this,
=======
                                        VisualRoot,
>>>>>>> 1ec71635b (sync with main branch)
                                        rootVisualPosition,
                                        (ulong)Environment.TickCount64,
                                        new PointerPointProperties(RawInputModifiers.None, PointerUpdateKind.Other),
                                        KeyModifiers.None);

                                    RaiseEvent(evnt);

                                    break;
                                }
                        }
<<<<<<< HEAD
#pragma warning restore CS0618
=======
>>>>>>> 1ec71635b (sync with main branch)
                    }
                }

                return DefWindowProc(hWnd, msg, wParam, lParam);
            };

<<<<<<< HEAD
            WndClassEx wndClassEx = new()
            {
                cbSize = Marshal.SizeOf<WndClassEx>(),
                hInstance = GetModuleHandle(null),
                lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProcDelegate),
                style = ClassStyles.CsOwndc,
                lpszClassName = Marshal.StringToHGlobalUni(_className),
                hCursor = CreateArrowCursor(),
=======
            WNDCLASSEX wndClassEx = new()
            {
                cbSize        = Marshal.SizeOf<WNDCLASSEX>(),
                hInstance     = GetModuleHandle(null),
                lpfnWndProc   = Marshal.GetFunctionPointerForDelegate(_wndProcDelegate),
                style         = ClassStyles.CS_OWNDC,
                lpszClassName = Marshal.StringToHGlobalUni(_className),
                hCursor       = CreateArrowCursor()
>>>>>>> 1ec71635b (sync with main branch)
            };

            RegisterClassEx(ref wndClassEx);

<<<<<<< HEAD
            WindowHandle = CreateWindowEx(0, _className, "NativeWindow", WindowStyles.WsChild, 0, 0, 640, 480, control.Handle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
=======
            WindowHandle = CreateWindowEx(0, _className, "NativeWindow", WindowStyles.WS_CHILD, 0, 0, 640, 480, control.Handle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
>>>>>>> 1ec71635b (sync with main branch)

            Marshal.FreeHGlobal(wndClassEx.lpszClassName);

            return new PlatformHandle(WindowHandle, "HWND");
        }

        [SupportedOSPlatform("macos")]
        IPlatformHandle CreateMacOS()
        {
            // Create a new CAMetalLayer.
<<<<<<< HEAD
            ObjectiveC.Object layerObject = new("CAMetalLayer");
            ObjectiveC.Object metalLayer = layerObject.GetFromMessage("alloc");
            metalLayer.SendMessage("init");

            // Create a child NSView to render into.
            ObjectiveC.Object nsViewObject = new("NSView");
            ObjectiveC.Object child = nsViewObject.GetFromMessage("alloc");
            child.SendMessage("init", new ObjectiveC.NSRect(0, 0, 0, 0));

            // Make its renderer our metal layer.
            child.SendMessage("setWantsLayer:", 1);
            child.SendMessage("setLayer:", metalLayer);
            metalLayer.SendMessage("setContentsScale:", Program.DesktopScaleFactor);
=======
            IntPtr layerClass = ObjectiveC.objc_getClass("CAMetalLayer");
            IntPtr metalLayer = ObjectiveC.IntPtr_objc_msgSend(layerClass, "alloc");
            ObjectiveC.objc_msgSend(metalLayer, "init");

            // Create a child NSView to render into.
            IntPtr nsViewClass = ObjectiveC.objc_getClass("NSView");
            IntPtr child = ObjectiveC.IntPtr_objc_msgSend(nsViewClass, "alloc");
            ObjectiveC.objc_msgSend(child, "init", new ObjectiveC.NSRect(0, 0, 0, 0));

            // Make its renderer our metal layer.
            ObjectiveC.objc_msgSend(child, "setWantsLayer:", 1);
            ObjectiveC.objc_msgSend(child, "setLayer:", metalLayer);
            ObjectiveC.objc_msgSend(metalLayer, "setContentsScale:", Program.DesktopScaleFactor);
>>>>>>> 1ec71635b (sync with main branch)

            // Ensure the scale factor is up to date.
            _updateBoundsCallback = rect =>
            {
<<<<<<< HEAD
                metalLayer.SendMessage("setContentsScale:", Program.DesktopScaleFactor);
            };

            IntPtr nsView = child.ObjPtr;
            MetalLayer = metalLayer.ObjPtr;
=======
                ObjectiveC.objc_msgSend(metalLayer, "setContentsScale:", Program.DesktopScaleFactor);
            };

            IntPtr nsView = child;
            MetalLayer = metalLayer;
>>>>>>> 1ec71635b (sync with main branch)
            NsView = nsView;

            return new PlatformHandle(nsView, "NSView");
        }

        [SupportedOSPlatform("Linux")]
        void DestroyLinux()
        {
            X11Window?.Dispose();
        }

        [SupportedOSPlatform("windows")]
        void DestroyWin32(IPlatformHandle handle)
        {
            DestroyWindow(handle.Handle);
            UnregisterClass(_className, GetModuleHandle(null));
        }

        [SupportedOSPlatform("macos")]
<<<<<<< HEAD
#pragma warning disable CA1822 // Mark member as static
=======
>>>>>>> 1ec71635b (sync with main branch)
        void DestroyMacOS()
        {
            // TODO
        }
<<<<<<< HEAD
#pragma warning restore CA1822
    }
}
=======
    }
}
>>>>>>> 1ec71635b (sync with main branch)
