<<<<<<< HEAD
namespace Ryujinx.Graphics.Nvdec.Vp9.Types
{
    internal enum PredictionMode
    {
        DcPred = 0, // Average of above and left pixels
        VPred = 1, // Vertical
        HPred = 2, // Horizontal
        D45Pred = 3, // Directional 45  deg = round(arctan(1 / 1) * 180 / pi)
        D135Pred = 4, // Directional 135 deg = 180 - 45
        D117Pred = 5, // Directional 117 deg = 180 - 63
        D153Pred = 6, // Directional 153 deg = 180 - 27
        D207Pred = 7, // Directional 207 deg = 180 + 27
        D63Pred = 8, // Directional 63  deg = round(arctan(2 / 1) * 180 / pi)
        TmPred = 9, // True-motion
=======
﻿namespace Ryujinx.Graphics.Nvdec.Vp9.Types
{
    internal enum PredictionMode
    {
        DcPred = 0,    // Average of above and left pixels
        VPred = 1,     // Vertical
        HPred = 2,     // Horizontal
        D45Pred = 3,   // Directional 45  deg = round(arctan(1 / 1) * 180 / pi)
        D135Pred = 4,  // Directional 135 deg = 180 - 45
        D117Pred = 5,  // Directional 117 deg = 180 - 63
        D153Pred = 6,  // Directional 153 deg = 180 - 27
        D207Pred = 7,  // Directional 207 deg = 180 + 27
        D63Pred = 8,   // Directional 63  deg = round(arctan(2 / 1) * 180 / pi)
        TmPred = 9,    // True-motion
>>>>>>> 1ec71635b (sync with main branch)
        NearestMv = 10,
        NearMv = 11,
        ZeroMv = 12,
        NewMv = 13,
<<<<<<< HEAD
        MbModeCount = 14,
=======
        MbModeCount = 14
>>>>>>> 1ec71635b (sync with main branch)
    }
}
