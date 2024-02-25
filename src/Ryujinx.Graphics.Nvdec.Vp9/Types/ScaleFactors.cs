<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.CompilerServices;
using static Ryujinx.Graphics.Nvdec.Vp9.Dsp.Convolve;
using static Ryujinx.Graphics.Nvdec.Vp9.Dsp.Filter;

namespace Ryujinx.Graphics.Nvdec.Vp9.Types
{
    internal struct ScaleFactors
    {
        private const int RefScaleShift = 14;
        private const int RefNoScale = (1 << RefScaleShift);
        private const int RefInvalidScale = -1;

        private unsafe delegate void ConvolveFn(
            byte* src,
            int srcStride,
            byte* dst,
            int dstStride,
            Array8<short>[] filter,
            int x0Q4,
            int xStepQ4,
            int y0Q4,
            int yStepQ4,
            int w,
            int h);

        private unsafe delegate void HighbdConvolveFn(
            ushort* src,
            int srcStride,
            ushort* dst,
            int dstStride,
            Array8<short>[] filter,
            int x0Q4,
            int xStepQ4,
            int y0Q4,
            int yStepQ4,
            int w,
            int h,
            int bd);

<<<<<<< HEAD
        private static readonly unsafe ConvolveFn[][][] _predictX16Y16 = {
            new[]
=======
        private static readonly unsafe ConvolveFn[][][] PredictX16Y16 = new ConvolveFn[][][]
        {
            new ConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new ConvolveFn[]
                {
                    ConvolveCopy,
<<<<<<< HEAD
                    ConvolveAvg,
=======
                    ConvolveAvg
>>>>>>> 1ec71635b (sync with main branch)
                },
                new ConvolveFn[]
                {
                    Convolve8Vert,
<<<<<<< HEAD
                    Convolve8AvgVert,
                },
            },
            new[]
=======
                    Convolve8AvgVert
                }
            },
            new ConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new ConvolveFn[]
                {
                    Convolve8Horiz,
<<<<<<< HEAD
                    Convolve8AvgHoriz,
=======
                    Convolve8AvgHoriz
>>>>>>> 1ec71635b (sync with main branch)
                },
                new ConvolveFn[]
                {
                    Convolve8,
<<<<<<< HEAD
                    Convolve8Avg,
                },
            },
        };

        private static readonly unsafe ConvolveFn[][][] _predictX16 = {
            new[]
=======
                    Convolve8Avg
                }
            }
        };

        private static readonly unsafe ConvolveFn[][][] PredictX16 = new ConvolveFn[][][]
        {
            new ConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new ConvolveFn[]
                {
                    ScaledVert,
<<<<<<< HEAD
                    ScaledAvgVert,
=======
                    ScaledAvgVert
>>>>>>> 1ec71635b (sync with main branch)
                },
                new ConvolveFn[]
                {
                    ScaledVert,
<<<<<<< HEAD
                    ScaledAvgVert,
                },
            },
            new[]
=======
                    ScaledAvgVert
                }
            },
            new ConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new ConvolveFn[]
                {
                    Scaled2D,
<<<<<<< HEAD
                    ScaledAvg2D,
=======
                    ScaledAvg2D
>>>>>>> 1ec71635b (sync with main branch)
                },
                new ConvolveFn[]
                {
                    Scaled2D,
<<<<<<< HEAD
                    ScaledAvg2D,
                },
            },
        };

        private static readonly unsafe ConvolveFn[][][] _predictY16 = {
            new[]
=======
                    ScaledAvg2D
                }
            }
        };

        private static readonly unsafe ConvolveFn[][][] PredictY16 = new ConvolveFn[][][]
        {
            new ConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new ConvolveFn[]
                {
                    ScaledHoriz,
<<<<<<< HEAD
                    ScaledAvgHoriz,
=======
                    ScaledAvgHoriz
>>>>>>> 1ec71635b (sync with main branch)
                },
                new ConvolveFn[]
                {
                    Scaled2D,
<<<<<<< HEAD
                    ScaledAvg2D,
                },
            },
            new[]
=======
                    ScaledAvg2D
                }
            },
            new ConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new ConvolveFn[]
                {
                    ScaledHoriz,
<<<<<<< HEAD
                    ScaledAvgHoriz,
=======
                    ScaledAvgHoriz
>>>>>>> 1ec71635b (sync with main branch)
                },
                new ConvolveFn[]
                {
                    Scaled2D,
<<<<<<< HEAD
                    ScaledAvg2D,
                },
            },
        };

        private static readonly unsafe ConvolveFn[][][] _predict = {
            new[]
=======
                    ScaledAvg2D
                }
            }
        };

        private static readonly unsafe ConvolveFn[][][] Predict = new ConvolveFn[][][]
        {
            new ConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new ConvolveFn[]
                {
                    Scaled2D,
<<<<<<< HEAD
                    ScaledAvg2D,
=======
                    ScaledAvg2D
>>>>>>> 1ec71635b (sync with main branch)
                },
                new ConvolveFn[]
                {
                    Scaled2D,
<<<<<<< HEAD
                    ScaledAvg2D,
                },
            },
            new[]
=======
                    ScaledAvg2D
                }
            },
            new ConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new ConvolveFn[]
                {
                    Scaled2D,
<<<<<<< HEAD
                    ScaledAvg2D,
=======
                    ScaledAvg2D
>>>>>>> 1ec71635b (sync with main branch)
                },
                new ConvolveFn[]
                {
                    Scaled2D,
<<<<<<< HEAD
                    ScaledAvg2D,
                },
            },
        };

        private static readonly unsafe HighbdConvolveFn[][][] _highbdPredictX16Y16 = {
            new[]
=======
                    ScaledAvg2D
                }
            }
        };

        private static readonly unsafe HighbdConvolveFn[][][] HighbdPredictX16Y16 = new HighbdConvolveFn[][][]
        {
            new HighbdConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new HighbdConvolveFn[]
                {
                    HighbdConvolveCopy,
<<<<<<< HEAD
                    HighbdConvolveAvg,
=======
                    HighbdConvolveAvg
>>>>>>> 1ec71635b (sync with main branch)
                },
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8Vert,
<<<<<<< HEAD
                    HighbdConvolve8AvgVert,
                },
            },
            new[]
=======
                    HighbdConvolve8AvgVert
                }
            },
            new HighbdConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8Horiz,
<<<<<<< HEAD
                    HighbdConvolve8AvgHoriz,
=======
                    HighbdConvolve8AvgHoriz
>>>>>>> 1ec71635b (sync with main branch)
                },
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
                },
            },
        };

        private static readonly unsafe HighbdConvolveFn[][][] _highbdPredictX16 = {
            new[]
=======
                    HighbdConvolve8Avg
                }
            }
        };

        private static readonly unsafe HighbdConvolveFn[][][] HighbdPredictX16 = new HighbdConvolveFn[][][]
        {
            new HighbdConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8Vert,
<<<<<<< HEAD
                    HighbdConvolve8AvgVert,
=======
                    HighbdConvolve8AvgVert
>>>>>>> 1ec71635b (sync with main branch)
                },
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8Vert,
<<<<<<< HEAD
                    HighbdConvolve8AvgVert,
                },
            },
            new[]
=======
                    HighbdConvolve8AvgVert
                }
            },
            new HighbdConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
=======
                    HighbdConvolve8Avg
>>>>>>> 1ec71635b (sync with main branch)
                },
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
                },
            },
        };

        private static readonly unsafe HighbdConvolveFn[][][] _highbdPredictY16 = {
            new[]
=======
                    HighbdConvolve8Avg
                }
            }
        };

        private static readonly unsafe HighbdConvolveFn[][][] HighbdPredictY16 = new HighbdConvolveFn[][][]
        {
            new HighbdConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8Horiz,
<<<<<<< HEAD
                    HighbdConvolve8AvgHoriz,
=======
                    HighbdConvolve8AvgHoriz
>>>>>>> 1ec71635b (sync with main branch)
                },
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
                },
            },
            new[]
=======
                    HighbdConvolve8Avg
                }
            },
            new HighbdConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8Horiz,
<<<<<<< HEAD
                    HighbdConvolve8AvgHoriz,
=======
                    HighbdConvolve8AvgHoriz
>>>>>>> 1ec71635b (sync with main branch)
                },
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
                },
            },
        };

        private static readonly unsafe HighbdConvolveFn[][][] _highbdPredict = {
            new[]
=======
                    HighbdConvolve8Avg
                }
            }
        };

        private static readonly unsafe HighbdConvolveFn[][][] HighbdPredict = new HighbdConvolveFn[][][]
        {
            new HighbdConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
=======
                    HighbdConvolve8Avg
>>>>>>> 1ec71635b (sync with main branch)
                },
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
                },
            },
            new[]
=======
                    HighbdConvolve8Avg
                }
            },
            new HighbdConvolveFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
=======
                    HighbdConvolve8Avg
>>>>>>> 1ec71635b (sync with main branch)
                },
                new HighbdConvolveFn[]
                {
                    HighbdConvolve8,
<<<<<<< HEAD
                    HighbdConvolve8Avg,
                },
            },
        };

        public int XScaleFP; // Horizontal fixed point scale factor
        public int YScaleFP; // Vertical fixed point scale factor
        public int XStepQ4;
        public int YStepQ4;

        public readonly int ScaleValueX(int val)
=======
                    HighbdConvolve8Avg
                }
            }
        };

        public int XScaleFP;  // Horizontal fixed point scale factor
        public int YScaleFP;  // Vertical fixed point scale factor
        public int XStepQ4;
        public int YStepQ4;

        public int ScaleValueX(int val)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return IsScaled() ? ScaledX(val) : val;
        }

<<<<<<< HEAD
        public readonly int ScaleValueY(int val)
=======
        public int ScaleValueY(int val)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return IsScaled() ? ScaledY(val) : val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        public readonly unsafe void InterPredict(
=======
        public unsafe void InterPredict(
>>>>>>> 1ec71635b (sync with main branch)
            int horiz,
            int vert,
            int avg,
            byte* src,
            int srcStride,
            byte* dst,
            int dstStride,
            int subpelX,
            int subpelY,
            int w,
            int h,
            Array8<short>[] kernel,
            int xs,
            int ys)
        {
            if (XStepQ4 == 16)
            {
                if (YStepQ4 == 16)
                {
                    // No scaling in either direction.
<<<<<<< HEAD
                    _predictX16Y16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h);
=======
                    PredictX16Y16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h);
>>>>>>> 1ec71635b (sync with main branch)
                }
                else
                {
                    // No scaling in x direction. Must always scale in the y direction.
<<<<<<< HEAD
                    _predictX16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h);
=======
                    PredictX16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
            else
            {
                if (YStepQ4 == 16)
                {
                    // No scaling in the y direction. Must always scale in the x direction.
<<<<<<< HEAD
                    _predictY16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h);
=======
                    PredictY16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h);
>>>>>>> 1ec71635b (sync with main branch)
                }
                else
                {
                    // Must always scale in both directions.
<<<<<<< HEAD
                    _predict[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h);
=======
                    Predict[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        public readonly unsafe void HighbdInterPredict(
=======
        public unsafe void HighbdInterPredict(
>>>>>>> 1ec71635b (sync with main branch)
            int horiz,
            int vert,
            int avg,
            ushort* src,
            int srcStride,
            ushort* dst,
            int dstStride,
            int subpelX,
            int subpelY,
            int w,
            int h,
            Array8<short>[] kernel,
            int xs,
            int ys,
            int bd)
        {
            if (XStepQ4 == 16)
            {
                if (YStepQ4 == 16)
                {
                    // No scaling in either direction.
<<<<<<< HEAD
                    _highbdPredictX16Y16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h, bd);
=======
                    HighbdPredictX16Y16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h, bd);
>>>>>>> 1ec71635b (sync with main branch)
                }
                else
                {
                    // No scaling in x direction. Must always scale in the y direction.
<<<<<<< HEAD
                    _highbdPredictX16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h, bd);
=======
                    HighbdPredictX16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h, bd);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
            else
            {
                if (YStepQ4 == 16)
                {
                    // No scaling in the y direction. Must always scale in the x direction.
<<<<<<< HEAD
                    _highbdPredictY16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h, bd);
=======
                    HighbdPredictY16[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h, bd);
>>>>>>> 1ec71635b (sync with main branch)
                }
                else
                {
                    // Must always scale in both directions.
<<<<<<< HEAD
                    _highbdPredict[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h, bd);
=======
                    HighbdPredict[horiz][vert][avg](src, srcStride, dst, dstStride, kernel, subpelX, xs, subpelY, ys, w, h, bd);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

<<<<<<< HEAD
        private readonly int ScaledX(int val)
=======
        private int ScaledX(int val)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)((long)val * XScaleFP >> RefScaleShift);
        }

<<<<<<< HEAD
        private readonly int ScaledY(int val)
=======
        private int ScaledY(int val)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)((long)val * YScaleFP >> RefScaleShift);
        }

        private static int GetFixedPointScaleFactor(int otherSize, int thisSize)
        {
            // Calculate scaling factor once for each reference frame
            // and use fixed point scaling factors in decoding and encoding routines.
            // Hardware implementations can calculate scale factor in device driver
            // and use multiplication and shifting on hardware instead of division.
            return (otherSize << RefScaleShift) / thisSize;
        }

        public Mv32 ScaleMv(ref Mv mv, int x, int y)
        {
            int xOffQ4 = ScaledX(x << SubpelBits) & SubpelMask;
            int yOffQ4 = ScaledY(y << SubpelBits) & SubpelMask;
<<<<<<< HEAD
            Mv32 res = new()
            {
                Row = ScaledY(mv.Row) + yOffQ4,
                Col = ScaledX(mv.Col) + xOffQ4,
            };

            return res;
        }

        public readonly bool IsValidScale()
=======
            Mv32 res = new Mv32()
            {
                Row = ScaledY(mv.Row) + yOffQ4,
                Col = ScaledX(mv.Col) + xOffQ4
            };
            return res;
        }

        public bool IsValidScale()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return XScaleFP != RefInvalidScale && YScaleFP != RefInvalidScale;
        }

<<<<<<< HEAD
        public readonly bool IsScaled()
=======
        public bool IsScaled()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return IsValidScale() && (XScaleFP != RefNoScale || YScaleFP != RefNoScale);
        }

        public static bool ValidRefFrameSize(int refWidth, int refHeight, int thisWidth, int thisHeight)
        {
            return 2 * thisWidth >= refWidth &&
                   2 * thisHeight >= refHeight &&
                   thisWidth <= 16 * refWidth &&
                   thisHeight <= 16 * refHeight;
        }

        public void SetupScaleFactorsForFrame(int otherW, int otherH, int thisW, int thisH)
        {
            if (!ValidRefFrameSize(otherW, otherH, thisW, thisH))
            {
                XScaleFP = RefInvalidScale;
                YScaleFP = RefInvalidScale;
<<<<<<< HEAD

=======
>>>>>>> 1ec71635b (sync with main branch)
                return;
            }

            XScaleFP = GetFixedPointScaleFactor(otherW, thisW);
            YScaleFP = GetFixedPointScaleFactor(otherH, thisH);
            XStepQ4 = ScaledX(16);
            YStepQ4 = ScaledY(16);
        }
    }
}
