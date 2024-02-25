using Ryujinx.Common.Configuration.Hid;
using Ryujinx.Common.Configuration.Hid.Controller;
using Ryujinx.Common.Configuration.Hid.Keyboard;
using Ryujinx.HLE.HOS.Services.Hid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
<<<<<<< HEAD
using System.Linq;
using System.Runtime.CompilerServices;
using CemuHookClient = Ryujinx.Input.Motion.CemuHook.Client;
using ControllerType = Ryujinx.Common.Configuration.Hid.ControllerType;
using PlayerIndex = Ryujinx.HLE.HOS.Services.Hid.PlayerIndex;
=======
using System.Runtime.CompilerServices;
using CemuHookClient = Ryujinx.Input.Motion.CemuHook.Client;
>>>>>>> 1ec71635b (sync with main branch)
using Switch = Ryujinx.HLE.Switch;

namespace Ryujinx.Input.HLE
{
    public class NpadManager : IDisposable
    {
<<<<<<< HEAD
        private readonly CemuHookClient _cemuHookClient;

        private readonly object _lock = new();
=======
        private CemuHookClient _cemuHookClient;

        private object _lock = new object();
>>>>>>> 1ec71635b (sync with main branch)

        private bool _blockInputUpdates;

        private const int MaxControllers = 9;

<<<<<<< HEAD
        private readonly NpadController[] _controllers;
=======
        private NpadController[] _controllers;
>>>>>>> 1ec71635b (sync with main branch)

        private readonly IGamepadDriver _keyboardDriver;
        private readonly IGamepadDriver _gamepadDriver;
        private readonly IGamepadDriver _mouseDriver;
        private bool _isDisposed;

        private List<InputConfig> _inputConfig;
        private bool _enableKeyboard;
        private bool _enableMouse;
        private Switch _device;

        public NpadManager(IGamepadDriver keyboardDriver, IGamepadDriver gamepadDriver, IGamepadDriver mouseDriver)
        {
            _controllers = new NpadController[MaxControllers];
            _cemuHookClient = new CemuHookClient(this);

            _keyboardDriver = keyboardDriver;
            _gamepadDriver = gamepadDriver;
            _mouseDriver = mouseDriver;
            _inputConfig = new List<InputConfig>();

            _gamepadDriver.OnGamepadConnected += HandleOnGamepadConnected;
            _gamepadDriver.OnGamepadDisconnected += HandleOnGamepadDisconnected;
        }

        private void RefreshInputConfigForHLE()
        {
            lock (_lock)
            {
<<<<<<< HEAD
                List<InputConfig> validInputs = new();
=======
                List<InputConfig> validInputs = new List<InputConfig>();
>>>>>>> 1ec71635b (sync with main branch)
                foreach (var inputConfigEntry in _inputConfig)
                {
                    if (_controllers[(int)inputConfigEntry.PlayerIndex] != null)
                    {
                        validInputs.Add(inputConfigEntry);
                    }
                }

                _device.Hid.RefreshInputConfig(validInputs);
            }
        }

        private void HandleOnGamepadDisconnected(string obj)
        {
            // Force input reload
<<<<<<< HEAD
            lock (_lock)
            {
                // Forcibly disconnect any controllers with this ID.
                for (int i = 0; i < _controllers.Length; i++)
                {
                    if (_controllers[i]?.Id == obj)
                    {
                        _controllers[i]?.Dispose();
                        _controllers[i] = null;
                    }
                }

                ReloadConfiguration(_inputConfig, _enableKeyboard, _enableMouse);
            }
=======
            ReloadConfiguration(_inputConfig, _enableKeyboard, _enableMouse);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void HandleOnGamepadConnected(string id)
        {
            // Force input reload
            ReloadConfiguration(_inputConfig, _enableKeyboard, _enableMouse);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool DriverConfigurationUpdate(ref NpadController controller, InputConfig config)
        {
            IGamepadDriver targetDriver = _gamepadDriver;

            if (config is StandardControllerInputConfig)
            {
                targetDriver = _gamepadDriver;
            }
            else if (config is StandardKeyboardInputConfig)
            {
                targetDriver = _keyboardDriver;
            }

            Debug.Assert(targetDriver != null, "Unknown input configuration!");

            if (controller.GamepadDriver != targetDriver || controller.Id != config.Id)
            {
                return controller.UpdateDriverConfiguration(targetDriver, config);
            }
<<<<<<< HEAD

            return controller.GamepadDriver != null;
=======
            else
            {
                return controller.GamepadDriver != null;
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void ReloadConfiguration(List<InputConfig> inputConfig, bool enableKeyboard, bool enableMouse)
        {
            lock (_lock)
            {
<<<<<<< HEAD
                NpadController[] oldControllers = _controllers.ToArray();

                List<InputConfig> validInputs = new();

                foreach (InputConfig inputConfigEntry in inputConfig)
                {
                    NpadController controller;
                    int index = (int)inputConfigEntry.PlayerIndex;

                    if (oldControllers[index] != null)
                    {
                        // Try reuse the existing controller.
                        controller = oldControllers[index];
                        oldControllers[index] = null;
                    }
                    else
                    {
                        controller = new(_cemuHookClient);
                    }
=======
                for (int i = 0; i < _controllers.Length; i++)
                {
                    _controllers[i]?.Dispose();
                    _controllers[i] = null;
                }

                List<InputConfig> validInputs = new List<InputConfig>();

                foreach (InputConfig inputConfigEntry in inputConfig)
                {
                    NpadController controller = new NpadController(_cemuHookClient);
>>>>>>> 1ec71635b (sync with main branch)

                    bool isValid = DriverConfigurationUpdate(ref controller, inputConfigEntry);

                    if (!isValid)
                    {
<<<<<<< HEAD
                        _controllers[index] = null;
=======
>>>>>>> 1ec71635b (sync with main branch)
                        controller.Dispose();
                    }
                    else
                    {
<<<<<<< HEAD
                        _controllers[index] = controller;
=======
                        _controllers[(int)inputConfigEntry.PlayerIndex] = controller;
>>>>>>> 1ec71635b (sync with main branch)
                        validInputs.Add(inputConfigEntry);
                    }
                }

<<<<<<< HEAD
                for (int i = 0; i < oldControllers.Length; i++)
                {
                    // Disconnect any controllers that weren't reused by the new configuration.

                    oldControllers[i]?.Dispose();
                    oldControllers[i] = null;
                }

                _inputConfig = inputConfig;
                _enableKeyboard = enableKeyboard;
                _enableMouse = enableMouse;
=======
                _inputConfig    = inputConfig;
                _enableKeyboard = enableKeyboard;
                _enableMouse    = enableMouse;
>>>>>>> 1ec71635b (sync with main branch)

                _device.Hid.RefreshInputConfig(validInputs);
            }
        }

        public void UnblockInputUpdates()
        {
            lock (_lock)
            {
                _blockInputUpdates = false;
            }
        }

        public void BlockInputUpdates()
        {
            lock (_lock)
            {
                _blockInputUpdates = true;
            }
        }

        public void Initialize(Switch device, List<InputConfig> inputConfig, bool enableKeyboard, bool enableMouse)
        {
            _device = device;
            _device.Configuration.RefreshInputConfig = RefreshInputConfigForHLE;

            ReloadConfiguration(inputConfig, enableKeyboard, enableMouse);
        }

        public void Update(float aspectRatio = 1)
        {
            lock (_lock)
            {
<<<<<<< HEAD
                List<GamepadInput> hleInputStates = new();
                List<SixAxisInput> hleMotionStates = new(NpadDevices.MaxControllers);
=======
                List<GamepadInput> hleInputStates = new List<GamepadInput>();
                List<SixAxisInput> hleMotionStates = new List<SixAxisInput>(NpadDevices.MaxControllers);
>>>>>>> 1ec71635b (sync with main branch)

                KeyboardInput? hleKeyboardInput = null;

                foreach (InputConfig inputConfig in _inputConfig)
                {
                    GamepadInput inputState = default;
                    (SixAxisInput, SixAxisInput) motionState = default;

                    NpadController controller = _controllers[(int)inputConfig.PlayerIndex];
<<<<<<< HEAD
                    PlayerIndex playerIndex = (PlayerIndex)inputConfig.PlayerIndex;
=======
                    Ryujinx.HLE.HOS.Services.Hid.PlayerIndex playerIndex = (Ryujinx.HLE.HOS.Services.Hid.PlayerIndex)inputConfig.PlayerIndex;
>>>>>>> 1ec71635b (sync with main branch)

                    bool isJoyconPair = false;

                    // Do we allow input updates and is a controller connected?
                    if (!_blockInputUpdates && controller != null)
                    {
                        DriverConfigurationUpdate(ref controller, inputConfig);

                        controller.UpdateUserConfiguration(inputConfig);
                        controller.Update();
                        controller.UpdateRumble(_device.Hid.Npads.GetRumbleQueue(playerIndex));

                        inputState = controller.GetHLEInputState();

                        inputState.Buttons |= _device.Hid.UpdateStickButtons(inputState.LStick, inputState.RStick);

<<<<<<< HEAD
                        isJoyconPair = inputConfig.ControllerType == ControllerType.JoyconPair;
=======
                        isJoyconPair = inputConfig.ControllerType == Common.Configuration.Hid.ControllerType.JoyconPair;
>>>>>>> 1ec71635b (sync with main branch)

                        var altMotionState = isJoyconPair ? controller.GetHLEMotionState(true) : default;

                        motionState = (controller.GetHLEMotionState(), altMotionState);

                        if (_enableKeyboard)
                        {
                            hleKeyboardInput = controller.GetHLEKeyboardInput();
                        }
                    }
                    else
                    {
                        // Ensure that orientation isn't null
                        motionState.Item1.Orientation = new float[9];
                    }

                    inputState.PlayerId = playerIndex;
                    motionState.Item1.PlayerId = playerIndex;

                    hleInputStates.Add(inputState);
                    hleMotionStates.Add(motionState.Item1);

                    if (isJoyconPair && !motionState.Item2.Equals(default))
                    {
                        motionState.Item2.PlayerId = playerIndex;

                        hleMotionStates.Add(motionState.Item2);
                    }
                }

                _device.Hid.Npads.Update(hleInputStates);
                _device.Hid.Npads.UpdateSixAxis(hleMotionStates);

                if (hleKeyboardInput.HasValue)
                {
                    _device.Hid.Keyboard.Update(hleKeyboardInput.Value);
                }

                if (_enableMouse)
                {
                    var mouse = _mouseDriver.GetGamepad("0") as IMouse;

                    var mouseInput = IMouse.GetMouseStateSnapshot(mouse);

                    uint buttons = 0;

                    if (mouseInput.IsPressed(MouseButton.Button1))
                    {
                        buttons |= 1 << 0;
                    }

                    if (mouseInput.IsPressed(MouseButton.Button2))
                    {
                        buttons |= 1 << 1;
                    }

                    if (mouseInput.IsPressed(MouseButton.Button3))
                    {
                        buttons |= 1 << 2;
                    }

                    if (mouseInput.IsPressed(MouseButton.Button4))
                    {
                        buttons |= 1 << 3;
                    }

                    if (mouseInput.IsPressed(MouseButton.Button5))
                    {
                        buttons |= 1 << 4;
                    }

                    var position = IMouse.GetScreenPosition(mouseInput.Position, mouse.ClientSize, aspectRatio);

                    _device.Hid.Mouse.Update((int)position.X, (int)position.Y, buttons, (int)mouseInput.Scroll.X, (int)mouseInput.Scroll.Y, true);
                }
<<<<<<< HEAD
                else
=======
                else 
>>>>>>> 1ec71635b (sync with main branch)
                {
                    _device.Hid.Mouse.Update(0, 0);
                }

                _device.TamperMachine.UpdateInput(hleInputStates);
            }
        }

        internal InputConfig GetPlayerInputConfigByIndex(int index)
        {
            lock (_lock)
            {
<<<<<<< HEAD
                return _inputConfig.Find(x => x.PlayerIndex == (Common.Configuration.Hid.PlayerIndex)index);
=======
                return _inputConfig.Find(x => x.PlayerIndex == (Ryujinx.Common.Configuration.Hid.PlayerIndex)index);
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (_lock)
                {
                    if (!_isDisposed)
                    {
                        _cemuHookClient.Dispose();

                        _gamepadDriver.OnGamepadConnected -= HandleOnGamepadConnected;
                        _gamepadDriver.OnGamepadDisconnected -= HandleOnGamepadDisconnected;

                        for (int i = 0; i < _controllers.Length; i++)
                        {
                            _controllers[i]?.Dispose();
                        }

                        _isDisposed = true;
                    }
                }
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
    }
}
