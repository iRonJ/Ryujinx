<<<<<<< HEAD
using Gdk;
=======
﻿using Gdk;
>>>>>>> 1ec71635b (sync with main branch)
using Gtk;
using System;
using System.Collections.Generic;
using GtkKey = Gdk.Key;

namespace Ryujinx.Input.GTK3
{
    public class GTK3KeyboardDriver : IGamepadDriver
    {
        private readonly Widget _widget;
<<<<<<< HEAD
        private readonly HashSet<GtkKey> _pressedKeys;
=======
        private HashSet<GtkKey> _pressedKeys;
>>>>>>> 1ec71635b (sync with main branch)

        public GTK3KeyboardDriver(Widget widget)
        {
            _widget = widget;
            _pressedKeys = new HashSet<GtkKey>();

            _widget.KeyPressEvent += OnKeyPress;
            _widget.KeyReleaseEvent += OnKeyRelease;
        }

        public string DriverName => "GTK3";

        private static readonly string[] _keyboardIdentifers = new string[1] { "0" };

        public ReadOnlySpan<string> GamepadsIds => _keyboardIdentifers;

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

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _widget.KeyPressEvent -= OnKeyPress;
                _widget.KeyReleaseEvent -= OnKeyRelease;
            }
        }

        public void Dispose()
        {
<<<<<<< HEAD
            GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
            Dispose(true);
        }

        [GLib.ConnectBefore]
        protected void OnKeyPress(object sender, KeyPressEventArgs args)
        {
            GtkKey key = (GtkKey)Keyval.ToLower((uint)args.Event.Key);

            _pressedKeys.Add(key);
        }

        [GLib.ConnectBefore]
        protected void OnKeyRelease(object sender, KeyReleaseEventArgs args)
        {
            GtkKey key = (GtkKey)Keyval.ToLower((uint)args.Event.Key);

            _pressedKeys.Remove(key);
        }

        internal bool IsPressed(Key key)
        {
            if (key == Key.Unbound || key == Key.Unknown)
            {
                return false;
            }

            GtkKey nativeKey = GTK3MappingHelper.ToGtkKey(key);

            return _pressedKeys.Contains(nativeKey);
        }

        public IGamepad GetGamepad(string id)
        {
            if (!_keyboardIdentifers[0].Equals(id))
            {
                return null;
            }

            return new GTK3Keyboard(this, _keyboardIdentifers[0], "All keyboards");
        }
    }
}
