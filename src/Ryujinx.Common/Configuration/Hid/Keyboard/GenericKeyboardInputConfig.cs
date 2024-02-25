<<<<<<< HEAD
namespace Ryujinx.Common.Configuration.Hid.Keyboard
{
    public class GenericKeyboardInputConfig<TKey> : GenericInputConfigurationCommon<TKey> where TKey : unmanaged
=======
﻿namespace Ryujinx.Common.Configuration.Hid.Keyboard
{
    public class GenericKeyboardInputConfig<Key> : GenericInputConfigurationCommon<Key> where Key : unmanaged
>>>>>>> 1ec71635b (sync with main branch)
    {
        /// <summary>
        /// Left JoyCon Controller Stick Bindings
        /// </summary>
<<<<<<< HEAD
        public JoyconConfigKeyboardStick<TKey> LeftJoyconStick { get; set; }
=======
        public JoyconConfigKeyboardStick<Key> LeftJoyconStick { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Right JoyCon Controller Stick Bindings
        /// </summary>
<<<<<<< HEAD
        public JoyconConfigKeyboardStick<TKey> RightJoyconStick { get; set; }
=======
        public JoyconConfigKeyboardStick<Key> RightJoyconStick { get; set; }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
