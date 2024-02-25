using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Common.Configuration.Hid;
using Ryujinx.Common.Configuration.Hid.Controller;
using Ryujinx.Common.Configuration.Hid.Controller.Motion;
using Ryujinx.Common.Configuration.Hid.Keyboard;
using System;

namespace Ryujinx.Ava.UI.Models
{
<<<<<<< HEAD
    internal class InputConfiguration<TKey, TStick> : BaseModel
=======
    internal class InputConfiguration<Key, Stick> : BaseModel
>>>>>>> 1ec71635b (sync with main branch)
    {
        private float _deadzoneRight;
        private float _triggerThreshold;
        private float _deadzoneLeft;
        private double _gyroDeadzone;
        private int _sensitivity;
<<<<<<< HEAD
        private bool _enableMotion;
        private float _weakRumble;
        private float _strongRumble;
=======
        private bool enableMotion;
        private float weakRumble;
        private float strongRumble;
>>>>>>> 1ec71635b (sync with main branch)
        private float _rangeLeft;
        private float _rangeRight;

        public InputBackendType Backend { get; set; }

        /// <summary>
        /// Controller id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///  Controller's Type
        /// </summary>
        public ControllerType ControllerType { get; set; }

        /// <summary>
        ///  Player's Index for the controller
        /// </summary>
        public PlayerIndex PlayerIndex { get; set; }

<<<<<<< HEAD
        public TStick LeftJoystick { get; set; }
        public bool LeftInvertStickX { get; set; }
        public bool LeftInvertStickY { get; set; }
        public bool RightRotate90 { get; set; }
        public TKey LeftControllerStickButton { get; set; }

        public TStick RightJoystick { get; set; }
        public bool RightInvertStickX { get; set; }
        public bool RightInvertStickY { get; set; }
        public bool LeftRotate90 { get; set; }
        public TKey RightControllerStickButton { get; set; }
=======
        public Stick LeftJoystick { get; set; }
        public bool LeftInvertStickX { get; set; }
        public bool LeftInvertStickY { get; set; }
        public bool RightRotate90 { get; set; }
        public Key LeftControllerStickButton { get; set; }

        public Stick RightJoystick { get; set; }
        public bool RightInvertStickX { get; set; }
        public bool RightInvertStickY { get; set; }
        public bool LeftRotate90 { get; set; }
        public Key RightControllerStickButton { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        public float DeadzoneLeft
        {
            get => _deadzoneLeft;
            set
            {
                _deadzoneLeft = MathF.Round(value, 3);

                OnPropertyChanged();
            }
        }

        public float RangeLeft
        {
            get => _rangeLeft;
            set
            {
                _rangeLeft = MathF.Round(value, 3);

                OnPropertyChanged();
            }
        }

        public float DeadzoneRight
        {
            get => _deadzoneRight;
            set
            {
                _deadzoneRight = MathF.Round(value, 3);

                OnPropertyChanged();
            }
        }

        public float RangeRight
        {
            get => _rangeRight;
            set
            {
                _rangeRight = MathF.Round(value, 3);

                OnPropertyChanged();
            }
        }

        public float TriggerThreshold
        {
            get => _triggerThreshold;
            set
            {
                _triggerThreshold = MathF.Round(value, 3);

                OnPropertyChanged();
            }
        }

        public MotionInputBackendType MotionBackend { get; set; }

<<<<<<< HEAD
        public TKey ButtonMinus { get; set; }
        public TKey ButtonL { get; set; }
        public TKey ButtonZl { get; set; }
        public TKey LeftButtonSl { get; set; }
        public TKey LeftButtonSr { get; set; }
        public TKey DpadUp { get; set; }
        public TKey DpadDown { get; set; }
        public TKey DpadLeft { get; set; }
        public TKey DpadRight { get; set; }

        public TKey ButtonPlus { get; set; }
        public TKey ButtonR { get; set; }
        public TKey ButtonZr { get; set; }
        public TKey RightButtonSl { get; set; }
        public TKey RightButtonSr { get; set; }
        public TKey ButtonX { get; set; }
        public TKey ButtonB { get; set; }
        public TKey ButtonY { get; set; }
        public TKey ButtonA { get; set; }

        public TKey LeftStickUp { get; set; }
        public TKey LeftStickDown { get; set; }
        public TKey LeftStickLeft { get; set; }
        public TKey LeftStickRight { get; set; }
        public TKey LeftKeyboardStickButton { get; set; }

        public TKey RightStickUp { get; set; }
        public TKey RightStickDown { get; set; }
        public TKey RightStickLeft { get; set; }
        public TKey RightStickRight { get; set; }
        public TKey RightKeyboardStickButton { get; set; }
=======
        public Key ButtonMinus { get; set; }
        public Key ButtonL { get; set; }
        public Key ButtonZl { get; set; }
        public Key LeftButtonSl { get; set; }
        public Key LeftButtonSr { get; set; }
        public Key DpadUp { get; set; }
        public Key DpadDown { get; set; }
        public Key DpadLeft { get; set; }
        public Key DpadRight { get; set; }

        public Key ButtonPlus { get; set; }
        public Key ButtonR { get; set; }
        public Key ButtonZr { get; set; }
        public Key RightButtonSl { get; set; }
        public Key RightButtonSr { get; set; }
        public Key ButtonX { get; set; }
        public Key ButtonB { get; set; }
        public Key ButtonY { get; set; }
        public Key ButtonA { get; set; }


        public Key LeftStickUp { get; set; }
        public Key LeftStickDown { get; set; }
        public Key LeftStickLeft { get; set; }
        public Key LeftStickRight { get; set; }
        public Key LeftKeyboardStickButton { get; set; }

        public Key RightStickUp { get; set; }
        public Key RightStickDown { get; set; }
        public Key RightStickLeft { get; set; }
        public Key RightStickRight { get; set; }
        public Key RightKeyboardStickButton { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        public int Sensitivity
        {
            get => _sensitivity;
            set
            {
                _sensitivity = value;

                OnPropertyChanged();
            }
        }

        public double GyroDeadzone
        {
            get => _gyroDeadzone;
            set
            {
                _gyroDeadzone = Math.Round(value, 3);

                OnPropertyChanged();
            }
        }

        public bool EnableMotion
        {
<<<<<<< HEAD
            get => _enableMotion; set
            {
                _enableMotion = value;
=======
            get => enableMotion; set
            {
                enableMotion = value;
>>>>>>> 1ec71635b (sync with main branch)

                OnPropertyChanged();
            }
        }

        public bool EnableCemuHookMotion { get; set; }
        public int Slot { get; set; }
        public int AltSlot { get; set; }
        public bool MirrorInput { get; set; }
        public string DsuServerHost { get; set; }
        public int DsuServerPort { get; set; }

        public bool EnableRumble { get; set; }
        public float WeakRumble
        {
<<<<<<< HEAD
            get => _weakRumble; set
            {
                _weakRumble = value;
=======
            get => weakRumble; set
            {
                weakRumble = value;
>>>>>>> 1ec71635b (sync with main branch)

                OnPropertyChanged();
            }
        }
        public float StrongRumble
        {
<<<<<<< HEAD
            get => _strongRumble; set
            {
                _strongRumble = value;
=======
            get => strongRumble; set
            {
                strongRumble = value;
>>>>>>> 1ec71635b (sync with main branch)

                OnPropertyChanged();
            }
        }

        public InputConfiguration(InputConfig config)
        {
            if (config != null)
            {
                Backend = config.Backend;
                Id = config.Id;
                ControllerType = config.ControllerType;
                PlayerIndex = config.PlayerIndex;

                if (config is StandardKeyboardInputConfig keyboardConfig)
                {
<<<<<<< HEAD
                    LeftStickUp = (TKey)(object)keyboardConfig.LeftJoyconStick.StickUp;
                    LeftStickDown = (TKey)(object)keyboardConfig.LeftJoyconStick.StickDown;
                    LeftStickLeft = (TKey)(object)keyboardConfig.LeftJoyconStick.StickLeft;
                    LeftStickRight = (TKey)(object)keyboardConfig.LeftJoyconStick.StickRight;
                    LeftKeyboardStickButton = (TKey)(object)keyboardConfig.LeftJoyconStick.StickButton;

                    RightStickUp = (TKey)(object)keyboardConfig.RightJoyconStick.StickUp;
                    RightStickDown = (TKey)(object)keyboardConfig.RightJoyconStick.StickDown;
                    RightStickLeft = (TKey)(object)keyboardConfig.RightJoyconStick.StickLeft;
                    RightStickRight = (TKey)(object)keyboardConfig.RightJoyconStick.StickRight;
                    RightKeyboardStickButton = (TKey)(object)keyboardConfig.RightJoyconStick.StickButton;

                    ButtonA = (TKey)(object)keyboardConfig.RightJoycon.ButtonA;
                    ButtonB = (TKey)(object)keyboardConfig.RightJoycon.ButtonB;
                    ButtonX = (TKey)(object)keyboardConfig.RightJoycon.ButtonX;
                    ButtonY = (TKey)(object)keyboardConfig.RightJoycon.ButtonY;
                    ButtonR = (TKey)(object)keyboardConfig.RightJoycon.ButtonR;
                    RightButtonSl = (TKey)(object)keyboardConfig.RightJoycon.ButtonSl;
                    RightButtonSr = (TKey)(object)keyboardConfig.RightJoycon.ButtonSr;
                    ButtonZr = (TKey)(object)keyboardConfig.RightJoycon.ButtonZr;
                    ButtonPlus = (TKey)(object)keyboardConfig.RightJoycon.ButtonPlus;

                    DpadUp = (TKey)(object)keyboardConfig.LeftJoycon.DpadUp;
                    DpadDown = (TKey)(object)keyboardConfig.LeftJoycon.DpadDown;
                    DpadLeft = (TKey)(object)keyboardConfig.LeftJoycon.DpadLeft;
                    DpadRight = (TKey)(object)keyboardConfig.LeftJoycon.DpadRight;
                    ButtonMinus = (TKey)(object)keyboardConfig.LeftJoycon.ButtonMinus;
                    LeftButtonSl = (TKey)(object)keyboardConfig.LeftJoycon.ButtonSl;
                    LeftButtonSr = (TKey)(object)keyboardConfig.LeftJoycon.ButtonSr;
                    ButtonZl = (TKey)(object)keyboardConfig.LeftJoycon.ButtonZl;
                    ButtonL = (TKey)(object)keyboardConfig.LeftJoycon.ButtonL;
                }
                else if (config is StandardControllerInputConfig controllerConfig)
                {
                    LeftJoystick = (TStick)(object)controllerConfig.LeftJoyconStick.Joystick;
                    LeftInvertStickX = controllerConfig.LeftJoyconStick.InvertStickX;
                    LeftInvertStickY = controllerConfig.LeftJoyconStick.InvertStickY;
                    LeftRotate90 = controllerConfig.LeftJoyconStick.Rotate90CW;
                    LeftControllerStickButton = (TKey)(object)controllerConfig.LeftJoyconStick.StickButton;

                    RightJoystick = (TStick)(object)controllerConfig.RightJoyconStick.Joystick;
                    RightInvertStickX = controllerConfig.RightJoyconStick.InvertStickX;
                    RightInvertStickY = controllerConfig.RightJoyconStick.InvertStickY;
                    RightRotate90 = controllerConfig.RightJoyconStick.Rotate90CW;
                    RightControllerStickButton = (TKey)(object)controllerConfig.RightJoyconStick.StickButton;

                    ButtonA = (TKey)(object)controllerConfig.RightJoycon.ButtonA;
                    ButtonB = (TKey)(object)controllerConfig.RightJoycon.ButtonB;
                    ButtonX = (TKey)(object)controllerConfig.RightJoycon.ButtonX;
                    ButtonY = (TKey)(object)controllerConfig.RightJoycon.ButtonY;
                    ButtonR = (TKey)(object)controllerConfig.RightJoycon.ButtonR;
                    RightButtonSl = (TKey)(object)controllerConfig.RightJoycon.ButtonSl;
                    RightButtonSr = (TKey)(object)controllerConfig.RightJoycon.ButtonSr;
                    ButtonZr = (TKey)(object)controllerConfig.RightJoycon.ButtonZr;
                    ButtonPlus = (TKey)(object)controllerConfig.RightJoycon.ButtonPlus;

                    DpadUp = (TKey)(object)controllerConfig.LeftJoycon.DpadUp;
                    DpadDown = (TKey)(object)controllerConfig.LeftJoycon.DpadDown;
                    DpadLeft = (TKey)(object)controllerConfig.LeftJoycon.DpadLeft;
                    DpadRight = (TKey)(object)controllerConfig.LeftJoycon.DpadRight;
                    ButtonMinus = (TKey)(object)controllerConfig.LeftJoycon.ButtonMinus;
                    LeftButtonSl = (TKey)(object)controllerConfig.LeftJoycon.ButtonSl;
                    LeftButtonSr = (TKey)(object)controllerConfig.LeftJoycon.ButtonSr;
                    ButtonZl = (TKey)(object)controllerConfig.LeftJoycon.ButtonZl;
                    ButtonL = (TKey)(object)controllerConfig.LeftJoycon.ButtonL;
=======
                    LeftStickUp = (Key)(object)keyboardConfig.LeftJoyconStick.StickUp;
                    LeftStickDown = (Key)(object)keyboardConfig.LeftJoyconStick.StickDown;
                    LeftStickLeft = (Key)(object)keyboardConfig.LeftJoyconStick.StickLeft;
                    LeftStickRight = (Key)(object)keyboardConfig.LeftJoyconStick.StickRight;
                    LeftKeyboardStickButton = (Key)(object)keyboardConfig.LeftJoyconStick.StickButton;

                    RightStickUp = (Key)(object)keyboardConfig.RightJoyconStick.StickUp;
                    RightStickDown = (Key)(object)keyboardConfig.RightJoyconStick.StickDown;
                    RightStickLeft = (Key)(object)keyboardConfig.RightJoyconStick.StickLeft;
                    RightStickRight = (Key)(object)keyboardConfig.RightJoyconStick.StickRight;
                    RightKeyboardStickButton = (Key)(object)keyboardConfig.RightJoyconStick.StickButton;

                    ButtonA = (Key)(object)keyboardConfig.RightJoycon.ButtonA;
                    ButtonB = (Key)(object)keyboardConfig.RightJoycon.ButtonB;
                    ButtonX = (Key)(object)keyboardConfig.RightJoycon.ButtonX;
                    ButtonY = (Key)(object)keyboardConfig.RightJoycon.ButtonY;
                    ButtonR = (Key)(object)keyboardConfig.RightJoycon.ButtonR;
                    RightButtonSl = (Key)(object)keyboardConfig.RightJoycon.ButtonSl;
                    RightButtonSr = (Key)(object)keyboardConfig.RightJoycon.ButtonSr;
                    ButtonZr = (Key)(object)keyboardConfig.RightJoycon.ButtonZr;
                    ButtonPlus = (Key)(object)keyboardConfig.RightJoycon.ButtonPlus;

                    DpadUp = (Key)(object)keyboardConfig.LeftJoycon.DpadUp;
                    DpadDown = (Key)(object)keyboardConfig.LeftJoycon.DpadDown;
                    DpadLeft = (Key)(object)keyboardConfig.LeftJoycon.DpadLeft;
                    DpadRight = (Key)(object)keyboardConfig.LeftJoycon.DpadRight;
                    ButtonMinus = (Key)(object)keyboardConfig.LeftJoycon.ButtonMinus;
                    LeftButtonSl = (Key)(object)keyboardConfig.LeftJoycon.ButtonSl;
                    LeftButtonSr = (Key)(object)keyboardConfig.LeftJoycon.ButtonSr;
                    ButtonZl = (Key)(object)keyboardConfig.LeftJoycon.ButtonZl;
                    ButtonL = (Key)(object)keyboardConfig.LeftJoycon.ButtonL;
                }
                else if (config is StandardControllerInputConfig controllerConfig)
                {
                    LeftJoystick = (Stick)(object)controllerConfig.LeftJoyconStick.Joystick;
                    LeftInvertStickX = controllerConfig.LeftJoyconStick.InvertStickX;
                    LeftInvertStickY = controllerConfig.LeftJoyconStick.InvertStickY;
                    LeftRotate90 = controllerConfig.LeftJoyconStick.Rotate90CW;
                    LeftControllerStickButton = (Key)(object)controllerConfig.LeftJoyconStick.StickButton;

                    RightJoystick = (Stick)(object)controllerConfig.RightJoyconStick.Joystick;
                    RightInvertStickX = controllerConfig.RightJoyconStick.InvertStickX;
                    RightInvertStickY = controllerConfig.RightJoyconStick.InvertStickY;
                    RightRotate90 = controllerConfig.RightJoyconStick.Rotate90CW;
                    RightControllerStickButton = (Key)(object)controllerConfig.RightJoyconStick.StickButton;

                    ButtonA = (Key)(object)controllerConfig.RightJoycon.ButtonA;
                    ButtonB = (Key)(object)controllerConfig.RightJoycon.ButtonB;
                    ButtonX = (Key)(object)controllerConfig.RightJoycon.ButtonX;
                    ButtonY = (Key)(object)controllerConfig.RightJoycon.ButtonY;
                    ButtonR = (Key)(object)controllerConfig.RightJoycon.ButtonR;
                    RightButtonSl = (Key)(object)controllerConfig.RightJoycon.ButtonSl;
                    RightButtonSr = (Key)(object)controllerConfig.RightJoycon.ButtonSr;
                    ButtonZr = (Key)(object)controllerConfig.RightJoycon.ButtonZr;
                    ButtonPlus = (Key)(object)controllerConfig.RightJoycon.ButtonPlus;

                    DpadUp = (Key)(object)controllerConfig.LeftJoycon.DpadUp;
                    DpadDown = (Key)(object)controllerConfig.LeftJoycon.DpadDown;
                    DpadLeft = (Key)(object)controllerConfig.LeftJoycon.DpadLeft;
                    DpadRight = (Key)(object)controllerConfig.LeftJoycon.DpadRight;
                    ButtonMinus = (Key)(object)controllerConfig.LeftJoycon.ButtonMinus;
                    LeftButtonSl = (Key)(object)controllerConfig.LeftJoycon.ButtonSl;
                    LeftButtonSr = (Key)(object)controllerConfig.LeftJoycon.ButtonSr;
                    ButtonZl = (Key)(object)controllerConfig.LeftJoycon.ButtonZl;
                    ButtonL = (Key)(object)controllerConfig.LeftJoycon.ButtonL;
>>>>>>> 1ec71635b (sync with main branch)

                    DeadzoneLeft = controllerConfig.DeadzoneLeft;
                    DeadzoneRight = controllerConfig.DeadzoneRight;
                    RangeLeft = controllerConfig.RangeLeft;
                    RangeRight = controllerConfig.RangeRight;
                    TriggerThreshold = controllerConfig.TriggerThreshold;

                    if (controllerConfig.Motion != null)
                    {
                        EnableMotion = controllerConfig.Motion.EnableMotion;
                        MotionBackend = controllerConfig.Motion.MotionBackend;
                        GyroDeadzone = controllerConfig.Motion.GyroDeadzone;
                        Sensitivity = controllerConfig.Motion.Sensitivity;

                        if (controllerConfig.Motion is CemuHookMotionConfigController cemuHook)
                        {
                            EnableCemuHookMotion = true;
                            DsuServerHost = cemuHook.DsuServerHost;
                            DsuServerPort = cemuHook.DsuServerPort;
                            Slot = cemuHook.Slot;
                            AltSlot = cemuHook.AltSlot;
                            MirrorInput = cemuHook.MirrorInput;
                        }

                        if (controllerConfig.Rumble != null)
                        {
                            EnableRumble = controllerConfig.Rumble.EnableRumble;
                            WeakRumble = controllerConfig.Rumble.WeakRumble;
                            StrongRumble = controllerConfig.Rumble.StrongRumble;
                        }
                    }
                }
            }
        }

        public InputConfiguration()
        {
        }

        public InputConfig GetConfig()
        {
            if (Backend == InputBackendType.WindowKeyboard)
            {
<<<<<<< HEAD
                return new StandardKeyboardInputConfig
=======
                return new StandardKeyboardInputConfig()
>>>>>>> 1ec71635b (sync with main branch)
                {
                    Id = Id,
                    Backend = Backend,
                    PlayerIndex = PlayerIndex,
                    ControllerType = ControllerType,
<<<<<<< HEAD
                    LeftJoycon = new LeftJoyconCommonConfig<Key>
                    {
                        DpadUp = (Key)(object)DpadUp,
                        DpadDown = (Key)(object)DpadDown,
                        DpadLeft = (Key)(object)DpadLeft,
                        DpadRight = (Key)(object)DpadRight,
                        ButtonL = (Key)(object)ButtonL,
                        ButtonZl = (Key)(object)ButtonZl,
                        ButtonSl = (Key)(object)LeftButtonSl,
                        ButtonSr = (Key)(object)LeftButtonSr,
                        ButtonMinus = (Key)(object)ButtonMinus,
                    },
                    RightJoycon = new RightJoyconCommonConfig<Key>
                    {
                        ButtonA = (Key)(object)ButtonA,
                        ButtonB = (Key)(object)ButtonB,
                        ButtonX = (Key)(object)ButtonX,
                        ButtonY = (Key)(object)ButtonY,
                        ButtonPlus = (Key)(object)ButtonPlus,
                        ButtonSl = (Key)(object)RightButtonSl,
                        ButtonSr = (Key)(object)RightButtonSr,
                        ButtonR = (Key)(object)ButtonR,
                        ButtonZr = (Key)(object)ButtonZr,
                    },
                    LeftJoyconStick = new JoyconConfigKeyboardStick<Key>
                    {
                        StickUp = (Key)(object)LeftStickUp,
                        StickDown = (Key)(object)LeftStickDown,
                        StickRight = (Key)(object)LeftStickRight,
                        StickLeft = (Key)(object)LeftStickLeft,
                        StickButton = (Key)(object)LeftKeyboardStickButton,
                    },
                    RightJoyconStick = new JoyconConfigKeyboardStick<Key>
                    {
                        StickUp = (Key)(object)RightStickUp,
                        StickDown = (Key)(object)RightStickDown,
                        StickLeft = (Key)(object)RightStickLeft,
                        StickRight = (Key)(object)RightStickRight,
                        StickButton = (Key)(object)RightKeyboardStickButton,
                    },
                    Version = InputConfig.CurrentVersion,
                };

            }

            if (Backend == InputBackendType.GamepadSDL2)
            {
                var config = new StandardControllerInputConfig
=======
                    LeftJoycon = new LeftJoyconCommonConfig<Ryujinx.Common.Configuration.Hid.Key>()
                    {
                        DpadUp = (Ryujinx.Common.Configuration.Hid.Key)(object)DpadUp,
                        DpadDown = (Ryujinx.Common.Configuration.Hid.Key)(object)DpadDown,
                        DpadLeft = (Ryujinx.Common.Configuration.Hid.Key)(object)DpadLeft,
                        DpadRight = (Ryujinx.Common.Configuration.Hid.Key)(object)DpadRight,
                        ButtonL = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonL,
                        ButtonZl = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonZl,
                        ButtonSl = (Ryujinx.Common.Configuration.Hid.Key)(object)LeftButtonSl,
                        ButtonSr = (Ryujinx.Common.Configuration.Hid.Key)(object)LeftButtonSr,
                        ButtonMinus = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonMinus
                    },
                    RightJoycon = new RightJoyconCommonConfig<Ryujinx.Common.Configuration.Hid.Key>()
                    {
                        ButtonA = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonA,
                        ButtonB = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonB,
                        ButtonX = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonX,
                        ButtonY = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonY,
                        ButtonPlus = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonPlus,
                        ButtonSl = (Ryujinx.Common.Configuration.Hid.Key)(object)RightButtonSl,
                        ButtonSr = (Ryujinx.Common.Configuration.Hid.Key)(object)RightButtonSr,
                        ButtonR = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonR,
                        ButtonZr = (Ryujinx.Common.Configuration.Hid.Key)(object)ButtonZr
                    },
                    LeftJoyconStick = new JoyconConfigKeyboardStick<Ryujinx.Common.Configuration.Hid.Key>()
                    {
                        StickUp = (Ryujinx.Common.Configuration.Hid.Key)(object)LeftStickUp,
                        StickDown = (Ryujinx.Common.Configuration.Hid.Key)(object)LeftStickDown,
                        StickRight = (Ryujinx.Common.Configuration.Hid.Key)(object)LeftStickRight,
                        StickLeft = (Ryujinx.Common.Configuration.Hid.Key)(object)LeftStickLeft,
                        StickButton = (Ryujinx.Common.Configuration.Hid.Key)(object)LeftKeyboardStickButton
                    },
                    RightJoyconStick = new JoyconConfigKeyboardStick<Ryujinx.Common.Configuration.Hid.Key>()
                    {
                        StickUp = (Ryujinx.Common.Configuration.Hid.Key)(object)RightStickUp,
                        StickDown = (Ryujinx.Common.Configuration.Hid.Key)(object)RightStickDown,
                        StickLeft = (Ryujinx.Common.Configuration.Hid.Key)(object)RightStickLeft,
                        StickRight = (Ryujinx.Common.Configuration.Hid.Key)(object)RightStickRight,
                        StickButton = (Ryujinx.Common.Configuration.Hid.Key)(object)RightKeyboardStickButton
                    },
                    Version = InputConfig.CurrentVersion
                };

            }
            else if (Backend == InputBackendType.GamepadSDL2)
            {
                var config = new StandardControllerInputConfig()
>>>>>>> 1ec71635b (sync with main branch)
                {
                    Id = Id,
                    Backend = Backend,
                    PlayerIndex = PlayerIndex,
                    ControllerType = ControllerType,
<<<<<<< HEAD
                    LeftJoycon = new LeftJoyconCommonConfig<GamepadInputId>
=======
                    LeftJoycon = new LeftJoyconCommonConfig<GamepadInputId>()
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        DpadUp = (GamepadInputId)(object)DpadUp,
                        DpadDown = (GamepadInputId)(object)DpadDown,
                        DpadLeft = (GamepadInputId)(object)DpadLeft,
                        DpadRight = (GamepadInputId)(object)DpadRight,
                        ButtonL = (GamepadInputId)(object)ButtonL,
                        ButtonZl = (GamepadInputId)(object)ButtonZl,
                        ButtonSl = (GamepadInputId)(object)LeftButtonSl,
                        ButtonSr = (GamepadInputId)(object)LeftButtonSr,
                        ButtonMinus = (GamepadInputId)(object)ButtonMinus,
                    },
<<<<<<< HEAD
                    RightJoycon = new RightJoyconCommonConfig<GamepadInputId>
=======
                    RightJoycon = new RightJoyconCommonConfig<GamepadInputId>()
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        ButtonA = (GamepadInputId)(object)ButtonA,
                        ButtonB = (GamepadInputId)(object)ButtonB,
                        ButtonX = (GamepadInputId)(object)ButtonX,
                        ButtonY = (GamepadInputId)(object)ButtonY,
                        ButtonPlus = (GamepadInputId)(object)ButtonPlus,
                        ButtonSl = (GamepadInputId)(object)RightButtonSl,
                        ButtonSr = (GamepadInputId)(object)RightButtonSr,
                        ButtonR = (GamepadInputId)(object)ButtonR,
                        ButtonZr = (GamepadInputId)(object)ButtonZr,
                    },
<<<<<<< HEAD
                    LeftJoyconStick = new JoyconConfigControllerStick<GamepadInputId, StickInputId>
=======
                    LeftJoyconStick = new JoyconConfigControllerStick<GamepadInputId, StickInputId>()
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        Joystick = (StickInputId)(object)LeftJoystick,
                        InvertStickX = LeftInvertStickX,
                        InvertStickY = LeftInvertStickY,
                        Rotate90CW = LeftRotate90,
                        StickButton = (GamepadInputId)(object)LeftControllerStickButton,
                    },
<<<<<<< HEAD
                    RightJoyconStick = new JoyconConfigControllerStick<GamepadInputId, StickInputId>
=======
                    RightJoyconStick = new JoyconConfigControllerStick<GamepadInputId, StickInputId>()
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        Joystick = (StickInputId)(object)RightJoystick,
                        InvertStickX = RightInvertStickX,
                        InvertStickY = RightInvertStickY,
                        Rotate90CW = RightRotate90,
                        StickButton = (GamepadInputId)(object)RightControllerStickButton,
                    },
<<<<<<< HEAD
                    Rumble = new RumbleConfigController
                    {
                        EnableRumble = EnableRumble,
                        WeakRumble = WeakRumble,
                        StrongRumble = StrongRumble,
=======
                    Rumble = new RumbleConfigController()
                    {
                        EnableRumble = EnableRumble,
                        WeakRumble = WeakRumble,
                        StrongRumble = StrongRumble
>>>>>>> 1ec71635b (sync with main branch)
                    },
                    Version = InputConfig.CurrentVersion,
                    DeadzoneLeft = DeadzoneLeft,
                    DeadzoneRight = DeadzoneRight,
                    RangeLeft = RangeLeft,
                    RangeRight = RangeRight,
                    TriggerThreshold = TriggerThreshold,
                    Motion = EnableCemuHookMotion
<<<<<<< HEAD
                        ? new CemuHookMotionConfigController
                        {
                            DsuServerHost = DsuServerHost,
                            DsuServerPort = DsuServerPort,
                            Slot = Slot,
                            AltSlot = AltSlot,
                            MirrorInput = MirrorInput,
                            MotionBackend = MotionInputBackendType.CemuHook,
                        }
                        : new StandardMotionConfigController
                        {
                            MotionBackend = MotionInputBackendType.GamepadDriver,
                        },
=======
                           ? new CemuHookMotionConfigController()
                           {
                               DsuServerHost = DsuServerHost,
                               DsuServerPort = DsuServerPort,
                               Slot = Slot,
                               AltSlot = AltSlot,
                               MirrorInput = MirrorInput,
                               MotionBackend = MotionInputBackendType.CemuHook
                           }
                           : new StandardMotionConfigController()
                           {
                               MotionBackend = MotionInputBackendType.GamepadDriver
                           }
>>>>>>> 1ec71635b (sync with main branch)
                };

                config.Motion.Sensitivity = Sensitivity;
                config.Motion.EnableMotion = EnableMotion;
                config.Motion.GyroDeadzone = GyroDeadzone;

                return config;
            }

            return null;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
