<<<<<<< HEAD
namespace Ryujinx.Common.Configuration.Hid
{
    public class GenericInputConfigurationCommon<TButton> : InputConfig where TButton : unmanaged
=======
﻿namespace Ryujinx.Common.Configuration.Hid
{
    public class GenericInputConfigurationCommon<Button> : InputConfig where Button : unmanaged
>>>>>>> 1ec71635b (sync with main branch)
    {
        /// <summary>
        /// Left JoyCon Controller Bindings
        /// </summary>
<<<<<<< HEAD
        public LeftJoyconCommonConfig<TButton> LeftJoycon { get; set; }
=======
        public LeftJoyconCommonConfig<Button> LeftJoycon { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Right JoyCon Controller Bindings
        /// </summary>
<<<<<<< HEAD
        public RightJoyconCommonConfig<TButton> RightJoycon { get; set; }
=======
        public RightJoyconCommonConfig<Button> RightJoycon { get; set; }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
