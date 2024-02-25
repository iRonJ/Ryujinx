namespace Ryujinx.Audio.Renderer.Server.Effect
{
    /// <summary>
    /// The usage state of an effect.
    /// </summary>
    public enum UsageState : byte
    {
        /// <summary>
        /// The effect is in an invalid state.
        /// </summary>
        Invalid,

        /// <summary>
        /// The effect is new.
        /// </summary>
        New,

        /// <summary>
        /// The effect is enabled.
        /// </summary>
        Enabled,

        /// <summary>
        /// The effect is disabled.
        /// </summary>
<<<<<<< HEAD
        Disabled,
    }
}
=======
        Disabled
    }
}
>>>>>>> 1ec71635b (sync with main branch)
