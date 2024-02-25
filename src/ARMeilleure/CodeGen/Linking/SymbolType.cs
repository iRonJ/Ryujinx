<<<<<<< HEAD
namespace ARMeilleure.CodeGen.Linking
=======
﻿namespace ARMeilleure.CodeGen.Linking
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Types of <see cref="Symbol"/>.
    /// </summary>
    enum SymbolType : byte
    {
        /// <summary>
        /// Refers to nothing, i.e no symbol.
        /// </summary>
        None,

        /// <summary>
        /// Refers to an entry in <see cref="Translation.Delegates"/>.
        /// </summary>
        DelegateTable,

        /// <summary>
        /// Refers to an entry in <see cref="Translation.Translator.FunctionTable"/>.
        /// </summary>
        FunctionTable,

        /// <summary>
        /// Refers to a special symbol which is handled by <see cref="Translation.PTC.Ptc.PatchCode"/>.
        /// </summary>
<<<<<<< HEAD
        Special,
=======
        Special
>>>>>>> 1ec71635b (sync with main branch)
    }
}
