using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
<<<<<<< HEAD
=======
using FluentAvalonia.Core;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Input;
using System;
using System.Numerics;
using MouseButton = Ryujinx.Input.MouseButton;
using Size = System.Drawing.Size;

namespace Ryujinx.Ava.Input
{
    internal class AvaloniaMouseDriver : IGamepadDriver
    {
<<<<<<< HEAD
        private Control _widget;
        private bool _isDisposed;
        private Size _size;
        private readonly TopLevel _window;

        public bool[] PressedButtons { get; }
        public Vector2 CurrentPosition { get; private set; }
        public Vector2 Scroll { get; private set; }

        public string DriverName => "AvaloniaMouseDriver";
=======
        private Control           _widget;
        private bool              _isDisposed;
        private Size              _size;
        private readonly TopLevel _window;

        public bool[]  PressedButtons  { get; }
        public Vector2 CurrentPosition { get; private set; }
        public Vector2 Scroll          { get; private set; }

        public string               DriverName  => "AvaloniaMouseDriver";
>>>>>>> 1ec71635b (sync with main branch)
        public ReadOnlySpan<string> GamepadsIds => new[] { "0" };

        public AvaloniaMouseDriver(TopLevel window, Control parent)
        {
            _widget = parent;
            _window = window;

<<<<<<< HEAD
            _widget.PointerMoved += Parent_PointerMovedEvent;
            _widget.PointerPressed += Parent_PointerPressedEvent;
            _widget.PointerReleased += Parent_PointerReleasedEvent;
            _widget.PointerWheelChanged += Parent_PointerWheelChanged;

            _window.PointerMoved += Parent_PointerMovedEvent;
            _window.PointerPressed += Parent_PointerPressedEvent;
            _window.PointerReleased += Parent_PointerReleasedEvent;
            _window.PointerWheelChanged += Parent_PointerWheelChanged;
=======
            _widget.PointerMoved        += Parent_PointerMovedEvent;
            _widget.PointerPressed      += Parent_PointerPressEvent;
            _widget.PointerReleased     += Parent_PointerReleaseEvent;
            _widget.PointerWheelChanged += Parent_ScrollEvent;
            
            _window.PointerMoved        += Parent_PointerMovedEvent;
            _window.PointerPressed      += Parent_PointerPressEvent;
            _window.PointerReleased     += Parent_PointerReleaseEvent;
            _window.PointerWheelChanged += Parent_ScrollEvent;
>>>>>>> 1ec71635b (sync with main branch)

            PressedButtons = new bool[(int)MouseButton.Count];

            _size = new Size((int)parent.Bounds.Width, (int)parent.Bounds.Height);

            parent.GetObservable(Visual.BoundsProperty).Subscribe(Resized);
        }

        public event Action<string> OnGamepadConnected
        {
<<<<<<< HEAD
            add { }
=======
            add    { }
>>>>>>> 1ec71635b (sync with main branch)
            remove { }
        }

        public event Action<string> OnGamepadDisconnected
        {
<<<<<<< HEAD
            add { }
=======
            add    { }
>>>>>>> 1ec71635b (sync with main branch)
            remove { }
        }

        private void Resized(Rect rect)
        {
            _size = new Size((int)rect.Width, (int)rect.Height);
        }

<<<<<<< HEAD
        private void Parent_PointerWheelChanged(object o, PointerWheelEventArgs args)
=======
        private void Parent_ScrollEvent(object o, PointerWheelEventArgs args)
>>>>>>> 1ec71635b (sync with main branch)
        {
            Scroll = new Vector2((float)args.Delta.X, (float)args.Delta.Y);
        }

<<<<<<< HEAD
        private void Parent_PointerReleasedEvent(object o, PointerReleasedEventArgs args)
        {
            uint button = (uint)args.InitialPressMouseButton - 1;

            if ((uint)PressedButtons.Length > button)
            {
                PressedButtons[button] = false;
            }
        }
        private void Parent_PointerPressedEvent(object o, PointerPressedEventArgs args)
        {
            uint button = (uint)args.GetCurrentPoint(_widget).Properties.PointerUpdateKind;

            if ((uint)PressedButtons.Length > button)
=======
        private void Parent_PointerReleaseEvent(object o, PointerReleasedEventArgs args)
        {
            if (args.InitialPressMouseButton != Avalonia.Input.MouseButton.None)
            {
                int button = (int)args.InitialPressMouseButton;

                if (PressedButtons.Count() >= button)
                {
                    PressedButtons[button] = false;
                }
            }
        }

        private void Parent_PointerPressEvent(object o, PointerPressedEventArgs args)
        {
            int button = (int)args.GetCurrentPoint(_widget).Properties.PointerUpdateKind;

            if (PressedButtons.Count() >= button)
>>>>>>> 1ec71635b (sync with main branch)
            {
                PressedButtons[button] = true;
            }
        }

        private void Parent_PointerMovedEvent(object o, PointerEventArgs args)
        {
            Point position = args.GetPosition(_widget);

            CurrentPosition = new Vector2((float)position.X, (float)position.Y);
        }

        public void SetMousePressed(MouseButton button)
        {
<<<<<<< HEAD
            if ((uint)PressedButtons.Length > (uint)button)
            {
                PressedButtons[(uint)button] = true;
=======
            if (PressedButtons.Count() >= (int)button)
            {
                PressedButtons[(int)button] = true;
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public void SetMouseReleased(MouseButton button)
        {
<<<<<<< HEAD
            if ((uint)PressedButtons.Length > (uint)button)
            {
                PressedButtons[(uint)button] = false;
=======
            if (PressedButtons.Count() >= (int)button)
            {
                PressedButtons[(int)button] = false;
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public void SetPosition(double x, double y)
        {
            CurrentPosition = new Vector2((float)x, (float)y);
        }

        public bool IsButtonPressed(MouseButton button)
        {
<<<<<<< HEAD
            if ((uint)PressedButtons.Length > (uint)button)
            {
                return PressedButtons[(uint)button];
=======
            if (PressedButtons.Count() >= (int)button)
            {
                return PressedButtons[(int)button];
>>>>>>> 1ec71635b (sync with main branch)
            }

            return false;
        }

        public Size GetClientSize()
        {
            return _size;
        }

        public IGamepad GetGamepad(string id)
        {
            return new AvaloniaMouse(this);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;

<<<<<<< HEAD
            _widget.PointerMoved -= Parent_PointerMovedEvent;
            _widget.PointerPressed -= Parent_PointerPressedEvent;
            _widget.PointerReleased -= Parent_PointerReleasedEvent;
            _widget.PointerWheelChanged -= Parent_PointerWheelChanged;

            _window.PointerMoved -= Parent_PointerMovedEvent;
            _window.PointerPressed -= Parent_PointerPressedEvent;
            _window.PointerReleased -= Parent_PointerReleasedEvent;
            _window.PointerWheelChanged -= Parent_PointerWheelChanged;
=======
            _widget.PointerMoved        -= Parent_PointerMovedEvent;
            _widget.PointerPressed      -= Parent_PointerPressEvent;
            _widget.PointerReleased     -= Parent_PointerReleaseEvent;
            _widget.PointerWheelChanged -= Parent_ScrollEvent;

            _window.PointerMoved        -= Parent_PointerMovedEvent;
            _window.PointerPressed      -= Parent_PointerPressEvent;
            _window.PointerReleased     -= Parent_PointerReleaseEvent;
            _window.PointerWheelChanged -= Parent_ScrollEvent;
>>>>>>> 1ec71635b (sync with main branch)

            _widget = null;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
