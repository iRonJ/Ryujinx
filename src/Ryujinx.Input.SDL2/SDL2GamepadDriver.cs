<<<<<<< HEAD
using Ryujinx.SDL2.Common;
=======
﻿using Ryujinx.SDL2.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;
using static SDL2.SDL;

namespace Ryujinx.Input.SDL2
{
    public class SDL2GamepadDriver : IGamepadDriver
    {
<<<<<<< HEAD
        private readonly Dictionary<int, string> _gamepadsInstanceIdsMapping;
        private readonly List<string> _gamepadsIds;
        private readonly object _lock = new object();

        public ReadOnlySpan<string> GamepadsIds
        {
            get
            {
                lock (_lock)
                {
                    return _gamepadsIds.ToArray();
                }
            }
        }
=======
        private Dictionary<int, string> _gamepadsInstanceIdsMapping;
        private List<string> _gamepadsIds;

        public ReadOnlySpan<string> GamepadsIds => _gamepadsIds.ToArray();
>>>>>>> 1ec71635b (sync with main branch)

        public string DriverName => "SDL2";

        public event Action<string> OnGamepadConnected;
        public event Action<string> OnGamepadDisconnected;

        public SDL2GamepadDriver()
        {
            _gamepadsInstanceIdsMapping = new Dictionary<int, string>();
            _gamepadsIds = new List<string>();

            SDL2Driver.Instance.Initialize();
            SDL2Driver.Instance.OnJoyStickConnected += HandleJoyStickConnected;
            SDL2Driver.Instance.OnJoystickDisconnected += HandleJoyStickDisconnected;

            // Add already connected gamepads
            int numJoysticks = SDL_NumJoysticks();

            for (int joystickIndex = 0; joystickIndex < numJoysticks; joystickIndex++)
            {
                HandleJoyStickConnected(joystickIndex, SDL_JoystickGetDeviceInstanceID(joystickIndex));
            }
        }

        private string GenerateGamepadId(int joystickIndex)
        {
            Guid guid = SDL_JoystickGetDeviceGUID(joystickIndex);

<<<<<<< HEAD
            // Add a unique identifier to the start of the GUID in case of duplicates.

=======
>>>>>>> 1ec71635b (sync with main branch)
            if (guid == Guid.Empty)
            {
                return null;
            }

<<<<<<< HEAD
            string id;

            lock (_lock)
            {
                int guidIndex = 0;
                id = guidIndex + "-" + guid;

                while (_gamepadsIds.Contains(id))
                {
                    id = (++guidIndex) + "-" + guid;
                }
            }

            return id;
=======
            return joystickIndex + "-" + guid.ToString();
>>>>>>> 1ec71635b (sync with main branch)
        }

        private int GetJoystickIndexByGamepadId(string id)
        {
<<<<<<< HEAD
            lock (_lock)
            {
                return _gamepadsIds.IndexOf(id);
            }
=======
            string[] data = id.Split("-");

            if (data.Length != 6 || !int.TryParse(data[0], out int joystickIndex))
            {
                return -1;
            }

            return joystickIndex;
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void HandleJoyStickDisconnected(int joystickInstanceId)
        {
            if (_gamepadsInstanceIdsMapping.TryGetValue(joystickInstanceId, out string id))
            {
                _gamepadsInstanceIdsMapping.Remove(joystickInstanceId);
<<<<<<< HEAD

                lock (_lock)
                {
                    _gamepadsIds.Remove(id);
                }
=======
                _gamepadsIds.Remove(id);
>>>>>>> 1ec71635b (sync with main branch)

                OnGamepadDisconnected?.Invoke(id);
            }
        }

        private void HandleJoyStickConnected(int joystickDeviceId, int joystickInstanceId)
        {
            if (SDL_IsGameController(joystickDeviceId) == SDL_bool.SDL_TRUE)
            {
<<<<<<< HEAD
                if (_gamepadsInstanceIdsMapping.ContainsKey(joystickInstanceId))
                {
                    // Sometimes a JoyStick connected event fires after the app starts even though it was connected before
                    // so it is rejected to avoid doubling the entries.
                    return;
                }

=======
>>>>>>> 1ec71635b (sync with main branch)
                string id = GenerateGamepadId(joystickDeviceId);

                if (id == null)
                {
                    return;
                }

<<<<<<< HEAD
                if (_gamepadsInstanceIdsMapping.TryAdd(joystickInstanceId, id))
                {
                    lock (_lock)
                    {
                        _gamepadsIds.Add(id);
                    }
=======
                // Sometimes a JoyStick connected event fires after the app starts even though it was connected before
                // so it is rejected to avoid doubling the entries.
                if (_gamepadsIds.Contains(id))
                {
                    return;
                }

                if (_gamepadsInstanceIdsMapping.TryAdd(joystickInstanceId, id))
                {
                    _gamepadsIds.Add(id);
>>>>>>> 1ec71635b (sync with main branch)

                    OnGamepadConnected?.Invoke(id);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                SDL2Driver.Instance.OnJoyStickConnected -= HandleJoyStickConnected;
                SDL2Driver.Instance.OnJoystickDisconnected -= HandleJoyStickDisconnected;

                // Simulate a full disconnect when disposing
                foreach (string id in _gamepadsIds)
                {
                    OnGamepadDisconnected?.Invoke(id);
                }

<<<<<<< HEAD
                lock (_lock)
                {
                    _gamepadsIds.Clear();
                }
=======
                _gamepadsIds.Clear();
>>>>>>> 1ec71635b (sync with main branch)

                SDL2Driver.Instance.Dispose();
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

        public IGamepad GetGamepad(string id)
        {
            int joystickIndex = GetJoystickIndexByGamepadId(id);

            if (joystickIndex == -1)
            {
                return null;
            }

<<<<<<< HEAD
=======
            if (id != GenerateGamepadId(joystickIndex))
            {
                return null;
            }

>>>>>>> 1ec71635b (sync with main branch)
            IntPtr gamepadHandle = SDL_GameControllerOpen(joystickIndex);

            if (gamepadHandle == IntPtr.Zero)
            {
                return null;
            }

            return new SDL2Gamepad(gamepadHandle, id);
        }
    }
}
