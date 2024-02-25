<<<<<<< HEAD
using Ryujinx.Common.Configuration.Hid.Controller.Motion;
=======
﻿using Ryujinx.Common.Configuration.Hid.Controller.Motion;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Configuration.Hid.Controller
{
<<<<<<< HEAD
    public class GenericControllerInputConfig<TButton, TStick> : GenericInputConfigurationCommon<TButton> where TButton : unmanaged where TStick : unmanaged
=======
    public class GenericControllerInputConfig<Button, Stick> : GenericInputConfigurationCommon<Button> where Button : unmanaged where Stick : unmanaged
>>>>>>> 1ec71635b (sync with main branch)
    {
        [JsonIgnore]
        private float _deadzoneLeft;
        [JsonIgnore]
        private float _deadzoneRight;
        [JsonIgnore]
        private float _triggerThreshold;

        /// <summary>
        /// Left JoyCon Controller Stick Bindings
        /// </summary>
<<<<<<< HEAD
        public JoyconConfigControllerStick<TButton, TStick> LeftJoyconStick { get; set; }
=======
        public JoyconConfigControllerStick<Button, Stick> LeftJoyconStick { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Right JoyCon Controller Stick Bindings
        /// </summary>
<<<<<<< HEAD
        public JoyconConfigControllerStick<TButton, TStick> RightJoyconStick { get; set; }
=======
        public JoyconConfigControllerStick<Button, Stick> RightJoyconStick { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Controller Left Analog Stick Deadzone
        /// </summary>
        public float DeadzoneLeft
        {
            get => _deadzoneLeft; set
            {
                _deadzoneLeft = MathF.Round(value, 3);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Controller Right Analog Stick Deadzone
        /// </summary>
        public float DeadzoneRight
        {
            get => _deadzoneRight; set
            {
                _deadzoneRight = MathF.Round(value, 3);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Controller Left Analog Stick Range
        /// </summary>
        public float RangeLeft { get; set; }

        /// <summary>
        /// Controller Right Analog Stick Range
        /// </summary>
        public float RangeRight { get; set; }

        /// <summary>
        /// Controller Trigger Threshold
        /// </summary>
        public float TriggerThreshold
        {
            get => _triggerThreshold; set
            {
                _triggerThreshold = MathF.Round(value, 3);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Controller Motion Settings
        /// </summary>
        public MotionConfigController Motion { get; set; }

        /// <summary>
        /// Controller Rumble Settings
        /// </summary>
        public RumbleConfigController Rumble { get; set; }
    }
}
