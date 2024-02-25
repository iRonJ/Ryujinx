<<<<<<< HEAD
using Ryujinx.Horizon.Common;

namespace Ryujinx.Horizon
{
    public static class LibHacResultExtensions
=======
﻿using Ryujinx.Horizon.Common;

namespace Ryujinx.Horizon
{
    internal static class LibHacResultExtensions
>>>>>>> 1ec71635b (sync with main branch)
    {
        public static Result ToHorizonResult(this LibHac.Result result)
        {
            return new Result((int)result.Module, (int)result.Description);
        }
    }
}
