<<<<<<< HEAD
using System;

namespace Ryujinx.Graphics.GAL
{
    [Flags]
    public enum BufferAccess
    {
        Default = 0,
        FlushPersistent = 1 << 0,
        Stream = 1 << 1,
        SparseCompatible = 1 << 2,
=======
namespace Ryujinx.Graphics.GAL
{
    public enum BufferAccess
    {
        Default,
        FlushPersistent
>>>>>>> 1ec71635b (sync with main branch)
    }
}
