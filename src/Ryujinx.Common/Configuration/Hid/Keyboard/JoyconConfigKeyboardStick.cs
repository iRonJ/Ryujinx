<<<<<<< HEAD
namespace Ryujinx.Common.Configuration.Hid.Keyboard
{
    public class JoyconConfigKeyboardStick<TKey> where TKey : unmanaged
    {
        public TKey StickUp { get; set; }
        public TKey StickDown { get; set; }
        public TKey StickLeft { get; set; }
        public TKey StickRight { get; set; }
        public TKey StickButton { get; set; }
=======
﻿namespace Ryujinx.Common.Configuration.Hid.Keyboard
{
    public class JoyconConfigKeyboardStick<Key> where Key: unmanaged
    {
        public Key StickUp { get; set; }
        public Key StickDown { get; set; }
        public Key StickLeft { get; set; }
        public Key StickRight { get; set; }
        public Key StickButton { get; set; }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
