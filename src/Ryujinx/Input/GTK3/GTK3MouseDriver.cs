using Gdk;
using Gtk;
using System;
using System.Numerics;
using Size = System.Drawing.Size;

namespace Ryujinx.Input.GTK3
{
    public class GTK3MouseDriver : IGamepadDriver
    {
        private Widget _widget;
        private bool _isDisposed;

        public bool[] PressedButtons { get; }
<<<<<<< HEAD

        public Vector2 CurrentPosition { get; private set; }
        public Vector2 Scroll { get; private set; }
=======
        
        public Vector2 CurrentPosition { get; private set; }
        public Vector2 Scroll{ get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        public GTK3MouseDriver(Widget parent)
        {
            _widget = parent;

<<<<<<< HEAD
            _widget.MotionNotifyEvent += Parent_MotionNotifyEvent;
            _widget.ButtonPressEvent += Parent_ButtonPressEvent;
            _widget.ButtonReleaseEvent += Parent_ButtonReleaseEvent;
            _widget.ScrollEvent += Parent_ScrollEvent;
=======
            _widget.MotionNotifyEvent  += Parent_MotionNotifyEvent;
            _widget.ButtonPressEvent   += Parent_ButtonPressEvent;
            _widget.ButtonReleaseEvent += Parent_ButtonReleaseEvent;
            _widget.ScrollEvent        += Parent_ScrollEvent;
>>>>>>> 1ec71635b (sync with main branch)

            PressedButtons = new bool[(int)MouseButton.Count];
        }


        [GLib.ConnectBefore]
        private void Parent_ScrollEvent(object o, ScrollEventArgs args)
        {
            Scroll = new Vector2((float)args.Event.X, (float)args.Event.Y);
        }

        [GLib.ConnectBefore]
        private void Parent_ButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
        {
            PressedButtons[args.Event.Button - 1] = false;
        }

        [GLib.ConnectBefore]
        private void Parent_ButtonPressEvent(object o, ButtonPressEventArgs args)
        {
            PressedButtons[args.Event.Button - 1] = true;
        }

        [GLib.ConnectBefore]
        private void Parent_MotionNotifyEvent(object o, MotionNotifyEventArgs args)
        {
            if (args.Event.Device.InputSource == InputSource.Mouse)
            {
                CurrentPosition = new Vector2((float)args.Event.X, (float)args.Event.Y);
            }
        }

        public bool IsButtonPressed(MouseButton button)
        {
<<<<<<< HEAD
            return PressedButtons[(int)button];
=======
            return PressedButtons[(int) button];
>>>>>>> 1ec71635b (sync with main branch)
        }

        public Size GetClientSize()
        {
            return new Size(_widget.AllocatedWidth, _widget.AllocatedHeight);
        }

        public string DriverName => "GTK3";
<<<<<<< HEAD

        public event Action<string> OnGamepadConnected
        {
            add { }
=======
        
        public event Action<string> OnGamepadConnected
        {
            add    { }
>>>>>>> 1ec71635b (sync with main branch)
            remove { }
        }

        public event Action<string> OnGamepadDisconnected
        {
<<<<<<< HEAD
            add { }
            remove { }
        }

        public ReadOnlySpan<string> GamepadsIds => new[] { "0" };

=======
            add    { }
            remove { }
        }

        public ReadOnlySpan<string> GamepadsIds => new[] {"0"};
        
>>>>>>> 1ec71635b (sync with main branch)
        public IGamepad GetGamepad(string id)
        {
            return new GTK3Mouse(this);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

<<<<<<< HEAD
            GC.SuppressFinalize(this);

=======
>>>>>>> 1ec71635b (sync with main branch)
            _isDisposed = true;

            _widget.MotionNotifyEvent -= Parent_MotionNotifyEvent;
            _widget.ButtonPressEvent -= Parent_ButtonPressEvent;
            _widget.ButtonReleaseEvent -= Parent_ButtonReleaseEvent;

            _widget = null;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
