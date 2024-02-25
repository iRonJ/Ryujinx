<<<<<<< HEAD
using Avalonia.Controls;
using Avalonia.Input;
=======
﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Input;
using System;
using System.Collections.Generic;
using AvaKey = Avalonia.Input.Key;
using Key = Ryujinx.Input.Key;

namespace Ryujinx.Ava.Input
{
    internal class AvaloniaKeyboardDriver : IGamepadDriver
    {
        private static readonly string[] _keyboardIdentifers = new string[1] { "0" };
<<<<<<< HEAD
        private readonly Control _control;
=======
        private readonly Control         _control;
>>>>>>> 1ec71635b (sync with main branch)
        private readonly HashSet<AvaKey> _pressedKeys;

        public event EventHandler<KeyEventArgs> KeyPressed;
        public event EventHandler<KeyEventArgs> KeyRelease;
<<<<<<< HEAD
        public event EventHandler<string> TextInput;

        public string DriverName => "AvaloniaKeyboardDriver";
=======
        public event EventHandler<string>       TextInput;

        public string               DriverName  => "AvaloniaKeyboardDriver";
>>>>>>> 1ec71635b (sync with main branch)
        public ReadOnlySpan<string> GamepadsIds => _keyboardIdentifers;

        public AvaloniaKeyboardDriver(Control control)
        {
<<<<<<< HEAD
            _control = control;
            _pressedKeys = new HashSet<AvaKey>();

            _control.KeyDown += OnKeyPress;
            _control.KeyUp += OnKeyRelease;
            _control.TextInput += Control_TextInput;
=======
            _control     = control;
            _pressedKeys = new HashSet<AvaKey>();

            _control.KeyDown   += OnKeyPress;
            _control.KeyUp     += OnKeyRelease;
            _control.TextInput += Control_TextInput;
            _control.AddHandler(InputElement.TextInputEvent, Control_LastChanceTextInput, RoutingStrategies.Bubble);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void Control_TextInput(object sender, TextInputEventArgs e)
        {
            TextInput?.Invoke(this, e.Text);
        }

<<<<<<< HEAD
        public event Action<string> OnGamepadConnected
        {
            add { }
=======
        private void Control_LastChanceTextInput(object sender, TextInputEventArgs e)
        {
            // Swallow event
            e.Handled = true;
        }

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
=======
            add    { }
>>>>>>> 1ec71635b (sync with main branch)
            remove { }
        }

        public IGamepad GetGamepad(string id)
        {
            if (!_keyboardIdentifers[0].Equals(id))
            {
                return null;
            }

            return new AvaloniaKeyboard(this, _keyboardIdentifers[0], LocaleManager.Instance[LocaleKeys.AllKeyboards]);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
<<<<<<< HEAD
                _control.KeyUp -= OnKeyPress;
=======
                _control.KeyUp   -= OnKeyPress;
>>>>>>> 1ec71635b (sync with main branch)
                _control.KeyDown -= OnKeyRelease;
            }
        }

        protected void OnKeyPress(object sender, KeyEventArgs args)
        {
            _pressedKeys.Add(args.Key);

            KeyPressed?.Invoke(this, args);
        }

        protected void OnKeyRelease(object sender, KeyEventArgs args)
        {
            _pressedKeys.Remove(args.Key);

            KeyRelease?.Invoke(this, args);
        }

        internal bool IsPressed(Key key)
        {
            if (key == Key.Unbound || key == Key.Unknown)
            {
                return false;
            }

            AvaloniaKeyboardMappingHelper.TryGetAvaKey(key, out var nativeKey);

            return _pressedKeys.Contains(nativeKey);
        }

        public void ResetKeys()
        {
            _pressedKeys.Clear();
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
