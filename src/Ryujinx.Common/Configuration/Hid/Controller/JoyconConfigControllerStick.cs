<<<<<<< HEAD
namespace Ryujinx.Common.Configuration.Hid.Controller
{
    public class JoyconConfigControllerStick<TButton, TStick> where TButton : unmanaged where TStick : unmanaged
    {
        public TStick Joystick { get; set; }
        public bool InvertStickX { get; set; }
        public bool InvertStickY { get; set; }
        public bool Rotate90CW { get; set; }
        public TButton StickButton { get; set; }
=======
﻿namespace Ryujinx.Common.Configuration.Hid.Controller
{
    public class JoyconConfigControllerStick<Button, Stick> where Button: unmanaged where Stick: unmanaged
    {
        public Stick Joystick { get; set; }
        public bool InvertStickX { get; set; }
        public bool InvertStickY { get; set; }
        public bool Rotate90CW { get; set; }
        public Button StickButton { get; set; }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
