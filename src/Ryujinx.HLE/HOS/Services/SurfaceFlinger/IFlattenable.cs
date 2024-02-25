<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
=======
﻿namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
>>>>>>> 1ec71635b (sync with main branch)
{
    interface IFlattenable
    {
        uint GetFlattenedSize();

        uint GetFdCount();

        void Flatten(Parcel parcel);

        void Unflatten(Parcel parcel);
    }
}
