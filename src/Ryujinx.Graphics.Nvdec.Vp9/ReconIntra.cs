<<<<<<< HEAD
using Ryujinx.Graphics.Nvdec.Vp9.Common;
=======
﻿using Ryujinx.Graphics.Nvdec.Vp9.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Nvdec.Vp9.Types;
using System;
using static Ryujinx.Graphics.Nvdec.Vp9.Dsp.IntraPred;

namespace Ryujinx.Graphics.Nvdec.Vp9
{
    internal static class ReconIntra
    {
<<<<<<< HEAD
        public static readonly TxType[] IntraModeToTxTypeLookup = {
            TxType.DctDct, // DC
            TxType.AdstDct, // V
            TxType.DctAdst, // H
            TxType.DctDct, // D45
            TxType.AdstAdst, // D135
            TxType.AdstDct, // D117
            TxType.DctAdst, // D153
            TxType.DctAdst, // D207
            TxType.AdstDct, // D63
            TxType.AdstAdst, // TM
=======
        public static readonly TxType[] IntraModeToTxTypeLookup = new TxType[]
        {
            TxType.DctDct,    // DC
            TxType.AdstDct,   // V
            TxType.DctAdst,   // H
            TxType.DctDct,    // D45
            TxType.AdstAdst,  // D135
            TxType.AdstDct,   // D117
            TxType.DctAdst,   // D153
            TxType.DctAdst,   // D207
            TxType.AdstDct,   // D63
            TxType.AdstAdst   // TM
>>>>>>> 1ec71635b (sync with main branch)
        };

        private const int NeedLeft = 1 << 1;
        private const int NeedAbove = 1 << 2;
        private const int NeedAboveRight = 1 << 3;

        private static ReadOnlySpan<byte> ExtendModes => new byte[]
        {
<<<<<<< HEAD
            NeedAbove | NeedLeft, // DC
            NeedAbove, // V
            NeedLeft, // H
            NeedAboveRight, // D45
            NeedLeft | NeedAbove, // D135
            NeedLeft | NeedAbove, // D117
            NeedLeft | NeedAbove, // D153
            NeedLeft, // D207
            NeedAboveRight, // D63
            NeedLeft | NeedAbove, // TM
=======
            NeedAbove | NeedLeft,  // DC
            NeedAbove,             // V
            NeedLeft,              // H
            NeedAboveRight,        // D45
            NeedLeft | NeedAbove,  // D135
            NeedLeft | NeedAbove,  // D117
            NeedLeft | NeedAbove,  // D153
            NeedLeft,              // D207
            NeedAboveRight,        // D63
            NeedLeft | NeedAbove,  // TM
>>>>>>> 1ec71635b (sync with main branch)
        };

        private unsafe delegate void IntraPredFn(byte* dst, int stride, byte* above, byte* left);

<<<<<<< HEAD
        private static readonly unsafe IntraPredFn[][] _pred = {
=======
        private static unsafe IntraPredFn[][] _pred = new IntraPredFn[][]
        {
>>>>>>> 1ec71635b (sync with main branch)
            new IntraPredFn[]
            {
                null,
                null,
                null,
<<<<<<< HEAD
                null,
=======
                null
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                VPredictor4x4,
                VPredictor8x8,
                VPredictor16x16,
<<<<<<< HEAD
                VPredictor32x32,
=======
                VPredictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                HPredictor4x4,
                HPredictor8x8,
                HPredictor16x16,
<<<<<<< HEAD
                HPredictor32x32,
=======
                HPredictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                D45Predictor4x4,
                D45Predictor8x8,
                D45Predictor16x16,
<<<<<<< HEAD
                D45Predictor32x32,
=======
                D45Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                D135Predictor4x4,
                D135Predictor8x8,
                D135Predictor16x16,
<<<<<<< HEAD
                D135Predictor32x32,
=======
                D135Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                D117Predictor4x4,
                D117Predictor8x8,
                D117Predictor16x16,
<<<<<<< HEAD
                D117Predictor32x32,
=======
                D117Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                D153Predictor4x4,
                D153Predictor8x8,
                D153Predictor16x16,
<<<<<<< HEAD
                D153Predictor32x32,
=======
                D153Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                D207Predictor4x4,
                D207Predictor8x8,
                D207Predictor16x16,
<<<<<<< HEAD
                D207Predictor32x32,
=======
                D207Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                D63Predictor4x4,
                D63Predictor8x8,
                D63Predictor16x16,
<<<<<<< HEAD
                D63Predictor32x32,
=======
                D63Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraPredFn[]
            {
                TMPredictor4x4,
                TMPredictor8x8,
                TMPredictor16x16,
<<<<<<< HEAD
                TMPredictor32x32,
            },
        };

        private static readonly unsafe IntraPredFn[][][] _dcPred = {
            new[]
=======
                TMPredictor32x32
            }
        };

        private static unsafe IntraPredFn[][][] _dcPred = new IntraPredFn[][][]
        {
            new IntraPredFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new IntraPredFn[]
                {
                    Dc128Predictor4x4,
                    Dc128Predictor8x8,
                    Dc128Predictor16x16,
<<<<<<< HEAD
                    Dc128Predictor32x32,
=======
                    Dc128Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
                },
                new IntraPredFn[]
                {
                    DcTopPredictor4x4,
                    DcTopPredictor8x8,
                    DcTopPredictor16x16,
<<<<<<< HEAD
                    DcTopPredictor32x32,
                },
            },
            new[]
=======
                    DcTopPredictor32x32
                }
            },
            new IntraPredFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new IntraPredFn[]
                {
                    DcLeftPredictor4x4,
                    DcLeftPredictor8x8,
                    DcLeftPredictor16x16,
<<<<<<< HEAD
                    DcLeftPredictor32x32,
=======
                    DcLeftPredictor32x32
>>>>>>> 1ec71635b (sync with main branch)
                },
                new IntraPredFn[]
                {
                    DcPredictor4x4,
                    DcPredictor8x8,
                    DcPredictor16x16,
<<<<<<< HEAD
                    DcPredictor32x32,
                },
            },
=======
                    DcPredictor32x32
                }
            }
>>>>>>> 1ec71635b (sync with main branch)
        };

        private unsafe delegate void IntraHighPredFn(ushort* dst, int stride, ushort* above, ushort* left, int bd);

<<<<<<< HEAD
        private static readonly unsafe IntraHighPredFn[][] _predHigh = {
=======
        private static unsafe IntraHighPredFn[][] _predHigh = new IntraHighPredFn[][]
        {
>>>>>>> 1ec71635b (sync with main branch)
            new IntraHighPredFn[]
            {
                null,
                null,
                null,
<<<<<<< HEAD
                null,
=======
                null
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdVPredictor4x4,
                HighbdVPredictor8x8,
                HighbdVPredictor16x16,
<<<<<<< HEAD
                HighbdVPredictor32x32,
=======
                HighbdVPredictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdHPredictor4x4,
                HighbdHPredictor8x8,
                HighbdHPredictor16x16,
<<<<<<< HEAD
                HighbdHPredictor32x32,
=======
                HighbdHPredictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdD45Predictor4x4,
                HighbdD45Predictor8x8,
                HighbdD45Predictor16x16,
<<<<<<< HEAD
                HighbdD45Predictor32x32,
=======
                HighbdD45Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdD135Predictor4x4,
                HighbdD135Predictor8x8,
                HighbdD135Predictor16x16,
<<<<<<< HEAD
                HighbdD135Predictor32x32,
=======
                HighbdD135Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdD117Predictor4x4,
                HighbdD117Predictor8x8,
                HighbdD117Predictor16x16,
<<<<<<< HEAD
                HighbdD117Predictor32x32,
=======
                HighbdD117Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdD153Predictor4x4,
                HighbdD153Predictor8x8,
                HighbdD153Predictor16x16,
<<<<<<< HEAD
                HighbdD153Predictor32x32,
=======
                HighbdD153Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdD207Predictor4x4,
                HighbdD207Predictor8x8,
                HighbdD207Predictor16x16,
<<<<<<< HEAD
                HighbdD207Predictor32x32,
=======
                HighbdD207Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdD63Predictor4x4,
                HighbdD63Predictor8x8,
                HighbdD63Predictor16x16,
<<<<<<< HEAD
                HighbdD63Predictor32x32,
=======
                HighbdD63Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
            },
            new IntraHighPredFn[]
            {
                HighbdTMPredictor4x4,
                HighbdTMPredictor8x8,
                HighbdTMPredictor16x16,
<<<<<<< HEAD
                HighbdTMPredictor32x32,
            },
        };

        private static readonly unsafe IntraHighPredFn[][][] _dcPredHigh = {
            new[]
=======
                HighbdTMPredictor32x32
            }
        };

        private static unsafe IntraHighPredFn[][][] _dcPredHigh = new IntraHighPredFn[][][]
        {
            new IntraHighPredFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new IntraHighPredFn[]
                {
                    HighbdDc128Predictor4x4,
                    HighbdDc128Predictor8x8,
                    HighbdDc128Predictor16x16,
<<<<<<< HEAD
                    HighbdDc128Predictor32x32,
=======
                    HighbdDc128Predictor32x32
>>>>>>> 1ec71635b (sync with main branch)
                },
                new IntraHighPredFn[]
                {
                    HighbdDcTopPredictor4x4,
                    HighbdDcTopPredictor8x8,
                    HighbdDcTopPredictor16x16,
<<<<<<< HEAD
                    HighbdDcTopPredictor32x32,
                },
            },
            new[]
=======
                    HighbdDcTopPredictor32x32
                }
            },
            new IntraHighPredFn[][]
>>>>>>> 1ec71635b (sync with main branch)
            {
                new IntraHighPredFn[]
                {
                    HighbdDcLeftPredictor4x4,
                    HighbdDcLeftPredictor8x8,
                    HighbdDcLeftPredictor16x16,
<<<<<<< HEAD
                    HighbdDcLeftPredictor32x32,
=======
                    HighbdDcLeftPredictor32x32
>>>>>>> 1ec71635b (sync with main branch)
                },
                new IntraHighPredFn[]
                {
                    HighbdDcPredictor4x4,
                    HighbdDcPredictor8x8,
                    HighbdDcPredictor16x16,
<<<<<<< HEAD
                    HighbdDcPredictor32x32,
                },
            },
=======
                    HighbdDcPredictor32x32
                }
            }
>>>>>>> 1ec71635b (sync with main branch)
        };

        private static unsafe void BuildIntraPredictorsHigh(
            ref MacroBlockD xd,
            byte* ref8,
            int refStride,
            byte* dst8,
            int dstStride,
            PredictionMode mode,
            TxSize txSize,
            int upAvailable,
            int leftAvailable,
            int rightAvailable,
            int x,
            int y,
            int plane)
        {
            int i;
            ushort* dst = (ushort*)dst8;
            ushort* refr = (ushort*)ref8;
            ushort* leftCol = stackalloc ushort[32];
            ushort* aboveData = stackalloc ushort[64 + 16];
            ushort* aboveRow = aboveData + 16;
            ushort* constAboveRow = aboveRow;
            int bs = 4 << (int)txSize;
            int frameWidth, frameHeight;
            int x0, y0;
            ref MacroBlockDPlane pd = ref xd.Plane[plane];
            int needLeft = ExtendModes[(int)mode] & NeedLeft;
            int needAbove = ExtendModes[(int)mode] & NeedAbove;
            int needAboveRight = ExtendModes[(int)mode] & NeedAboveRight;
            int baseVal = 128 << (xd.Bd - 8);
            // 127 127 127 .. 127 127 127 127 127 127
            // 129  A   B  ..  Y   Z
            // 129  C   D  ..  W   X
            // 129  E   F  ..  U   V
            // 129  G   H  ..  S   T   T   T   T   T
            // For 10 bit and 12 bit, 127 and 129 are replaced by base -1 and base + 1.

            // Get current frame pointer, width and height.
            if (plane == 0)
            {
                frameWidth = xd.CurBuf.Width;
                frameHeight = xd.CurBuf.Height;
            }
            else
            {
                frameWidth = xd.CurBuf.UvWidth;
                frameHeight = xd.CurBuf.UvHeight;
            }

            // Get block position in current frame.
            x0 = (-xd.MbToLeftEdge >> (3 + pd.SubsamplingX)) + x;
            y0 = (-xd.MbToTopEdge >> (3 + pd.SubsamplingY)) + y;

            // NEED_LEFT
            if (needLeft != 0)
            {
                if (leftAvailable != 0)
                {
                    if (xd.MbToBottomEdge < 0)
                    {
                        /* slower path if the block needs border extension */
                        if (y0 + bs <= frameHeight)
                        {
                            for (i = 0; i < bs; ++i)
                            {
                                leftCol[i] = refr[i * refStride - 1];
                            }
                        }
                        else
                        {
                            int extendBottom = frameHeight - y0;
                            for (i = 0; i < extendBottom; ++i)
                            {
                                leftCol[i] = refr[i * refStride - 1];
                            }

                            for (; i < bs; ++i)
                            {
                                leftCol[i] = refr[(extendBottom - 1) * refStride - 1];
                            }
                        }
                    }
                    else
                    {
                        /* faster path if the block does not need extension */
                        for (i = 0; i < bs; ++i)
                        {
                            leftCol[i] = refr[i * refStride - 1];
                        }
                    }
                }
                else
                {
                    MemoryUtil.Fill(leftCol, (ushort)(baseVal + 1), bs);
                }
            }

            // NEED_ABOVE
            if (needAbove != 0)
            {
                if (upAvailable != 0)
                {
                    ushort* aboveRef = refr - refStride;
                    if (xd.MbToRightEdge < 0)
                    {
                        /* slower path if the block needs border extension */
                        if (x0 + bs <= frameWidth)
                        {
                            MemoryUtil.Copy(aboveRow, aboveRef, bs);
                        }
                        else if (x0 <= frameWidth)
                        {
                            int r = frameWidth - x0;
                            MemoryUtil.Copy(aboveRow, aboveRef, r);
                            MemoryUtil.Fill(aboveRow + r, aboveRow[r - 1], x0 + bs - frameWidth);
                        }
                    }
                    else
                    {
                        /* faster path if the block does not need extension */
                        if (bs == 4 && rightAvailable != 0 && leftAvailable != 0)
                        {
                            constAboveRow = aboveRef;
                        }
                        else
                        {
                            MemoryUtil.Copy(aboveRow, aboveRef, bs);
                        }
                    }
                    aboveRow[-1] = leftAvailable != 0 ? aboveRef[-1] : (ushort)(baseVal + 1);
                }
                else
                {
                    MemoryUtil.Fill(aboveRow, (ushort)(baseVal - 1), bs);
                    aboveRow[-1] = (ushort)(baseVal - 1);
                }
            }

            // NEED_ABOVERIGHT
            if (needAboveRight != 0)
            {
                if (upAvailable != 0)
                {
                    ushort* aboveRef = refr - refStride;
                    if (xd.MbToRightEdge < 0)
                    {
                        /* slower path if the block needs border extension */
                        if (x0 + 2 * bs <= frameWidth)
                        {
                            if (rightAvailable != 0 && bs == 4)
                            {
                                MemoryUtil.Copy(aboveRow, aboveRef, 2 * bs);
                            }
                            else
                            {
                                MemoryUtil.Copy(aboveRow, aboveRef, bs);
                                MemoryUtil.Fill(aboveRow + bs, aboveRow[bs - 1], bs);
                            }
                        }
                        else if (x0 + bs <= frameWidth)
                        {
                            int r = frameWidth - x0;
                            if (rightAvailable != 0 && bs == 4)
                            {
                                MemoryUtil.Copy(aboveRow, aboveRef, r);
                                MemoryUtil.Fill(aboveRow + r, aboveRow[r - 1], x0 + 2 * bs - frameWidth);
                            }
                            else
                            {
                                MemoryUtil.Copy(aboveRow, aboveRef, bs);
                                MemoryUtil.Fill(aboveRow + bs, aboveRow[bs - 1], bs);
                            }
                        }
                        else if (x0 <= frameWidth)
                        {
                            int r = frameWidth - x0;
                            MemoryUtil.Copy(aboveRow, aboveRef, r);
                            MemoryUtil.Fill(aboveRow + r, aboveRow[r - 1], x0 + 2 * bs - frameWidth);
                        }
                        aboveRow[-1] = leftAvailable != 0 ? aboveRef[-1] : (ushort)(baseVal + 1);
                    }
                    else
                    {
                        /* faster path if the block does not need extension */
                        if (bs == 4 && rightAvailable != 0 && leftAvailable != 0)
                        {
                            constAboveRow = aboveRef;
                        }
                        else
                        {
                            MemoryUtil.Copy(aboveRow, aboveRef, bs);
                            if (bs == 4 && rightAvailable != 0)
                            {
                                MemoryUtil.Copy(aboveRow + bs, aboveRef + bs, bs);
                            }
                            else
                            {
                                MemoryUtil.Fill(aboveRow + bs, aboveRow[bs - 1], bs);
                            }

                            aboveRow[-1] = leftAvailable != 0 ? aboveRef[-1] : (ushort)(baseVal + 1);
                        }
                    }
                }
                else
                {
                    MemoryUtil.Fill(aboveRow, (ushort)(baseVal - 1), bs * 2);
                    aboveRow[-1] = (ushort)(baseVal - 1);
                }
            }

            // Predict
            if (mode == PredictionMode.DcPred)
            {
                _dcPredHigh[leftAvailable][upAvailable][(int)txSize](dst, dstStride, constAboveRow, leftCol, xd.Bd);
            }
            else
            {
                _predHigh[(int)mode][(int)txSize](dst, dstStride, constAboveRow, leftCol, xd.Bd);
            }
        }

        public static unsafe void BuildIntraPredictors(
            ref MacroBlockD xd,
            byte* refr,
            int refStride,
            byte* dst,
            int dstStride,
            PredictionMode mode,
            TxSize txSize,
            int upAvailable,
            int leftAvailable,
            int rightAvailable,
            int x,
            int y,
            int plane)
        {
            int i;
            byte* leftCol = stackalloc byte[32];
            byte* aboveData = stackalloc byte[64 + 16];
            byte* aboveRow = aboveData + 16;
            byte* constAboveRow = aboveRow;
            int bs = 4 << (int)txSize;
            int frameWidth, frameHeight;
            int x0, y0;
            ref MacroBlockDPlane pd = ref xd.Plane[plane];

            // 127 127 127 .. 127 127 127 127 127 127
            // 129  A   B  ..  Y   Z
            // 129  C   D  ..  W   X
            // 129  E   F  ..  U   V
            // 129  G   H  ..  S   T   T   T   T   T
            // ..

            // Get current frame pointer, width and height.
            if (plane == 0)
            {
                frameWidth = xd.CurBuf.Width;
                frameHeight = xd.CurBuf.Height;
            }
            else
            {
                frameWidth = xd.CurBuf.UvWidth;
                frameHeight = xd.CurBuf.UvHeight;
            }

            // Get block position in current frame.
            x0 = (-xd.MbToLeftEdge >> (3 + pd.SubsamplingX)) + x;
            y0 = (-xd.MbToTopEdge >> (3 + pd.SubsamplingY)) + y;

            // NEED_LEFT
            if ((ExtendModes[(int)mode] & NeedLeft) != 0)
            {
                if (leftAvailable != 0)
                {
                    if (xd.MbToBottomEdge < 0)
                    {
                        /* Slower path if the block needs border extension */
                        if (y0 + bs <= frameHeight)
                        {
                            for (i = 0; i < bs; ++i)
                            {
                                leftCol[i] = refr[i * refStride - 1];
                            }
                        }
                        else
                        {
                            int extendBottom = frameHeight - y0;
                            for (i = 0; i < extendBottom; ++i)
                            {
                                leftCol[i] = refr[i * refStride - 1];
                            }

                            for (; i < bs; ++i)
                            {
                                leftCol[i] = refr[(extendBottom - 1) * refStride - 1];
                            }
                        }
                    }
                    else
                    {
                        /* Faster path if the block does not need extension */
                        for (i = 0; i < bs; ++i)
                        {
                            leftCol[i] = refr[i * refStride - 1];
                        }
                    }
                }
                else
                {
                    MemoryUtil.Fill(leftCol, (byte)129, bs);
                }
            }

            // NEED_ABOVE
            if ((ExtendModes[(int)mode] & NeedAbove) != 0)
            {
                if (upAvailable != 0)
                {
                    byte* aboveRef = refr - refStride;
                    if (xd.MbToRightEdge < 0)
                    {
                        /* Slower path if the block needs border extension */
                        if (x0 + bs <= frameWidth)
                        {
                            MemoryUtil.Copy(aboveRow, aboveRef, bs);
                        }
                        else if (x0 <= frameWidth)
                        {
                            int r = frameWidth - x0;
                            MemoryUtil.Copy(aboveRow, aboveRef, r);
                            MemoryUtil.Fill(aboveRow + r, aboveRow[r - 1], x0 + bs - frameWidth);
                        }
                    }
                    else
                    {
                        /* Faster path if the block does not need extension */
                        if (bs == 4 && rightAvailable != 0 && leftAvailable != 0)
                        {
                            constAboveRow = aboveRef;
                        }
                        else
                        {
                            MemoryUtil.Copy(aboveRow, aboveRef, bs);
                        }
                    }
                    aboveRow[-1] = leftAvailable != 0 ? aboveRef[-1] : (byte)129;
                }
                else
                {
                    MemoryUtil.Fill(aboveRow, (byte)127, bs);
                    aboveRow[-1] = 127;
                }
            }

            // NEED_ABOVERIGHT
            if ((ExtendModes[(int)mode] & NeedAboveRight) != 0)
            {
                if (upAvailable != 0)
                {
                    byte* aboveRef = refr - refStride;
                    if (xd.MbToRightEdge < 0)
                    {
                        /* Slower path if the block needs border extension */
                        if (x0 + 2 * bs <= frameWidth)
                        {
                            if (rightAvailable != 0 && bs == 4)
                            {
                                MemoryUtil.Copy(aboveRow, aboveRef, 2 * bs);
                            }
                            else
                            {
                                MemoryUtil.Copy(aboveRow, aboveRef, bs);
                                MemoryUtil.Fill(aboveRow + bs, aboveRow[bs - 1], bs);
                            }
                        }
                        else if (x0 + bs <= frameWidth)
                        {
                            int r = frameWidth - x0;
                            if (rightAvailable != 0 && bs == 4)
                            {
                                MemoryUtil.Copy(aboveRow, aboveRef, r);
                                MemoryUtil.Fill(aboveRow + r, aboveRow[r - 1], x0 + 2 * bs - frameWidth);
                            }
                            else
                            {
                                MemoryUtil.Copy(aboveRow, aboveRef, bs);
                                MemoryUtil.Fill(aboveRow + bs, aboveRow[bs - 1], bs);
                            }
                        }
                        else if (x0 <= frameWidth)
                        {
                            int r = frameWidth - x0;
                            MemoryUtil.Copy(aboveRow, aboveRef, r);
                            MemoryUtil.Fill(aboveRow + r, aboveRow[r - 1], x0 + 2 * bs - frameWidth);
                        }
                    }
                    else
                    {
                        /* Faster path if the block does not need extension */
                        if (bs == 4 && rightAvailable != 0 && leftAvailable != 0)
                        {
                            constAboveRow = aboveRef;
                        }
                        else
                        {
                            MemoryUtil.Copy(aboveRow, aboveRef, bs);
                            if (bs == 4 && rightAvailable != 0)
                            {
                                MemoryUtil.Copy(aboveRow + bs, aboveRef + bs, bs);
                            }
                            else
                            {
                                MemoryUtil.Fill(aboveRow + bs, aboveRow[bs - 1], bs);
                            }
                        }
                    }
                    aboveRow[-1] = leftAvailable != 0 ? aboveRef[-1] : (byte)129;
                }
                else
                {
                    MemoryUtil.Fill(aboveRow, (byte)127, bs * 2);
                    aboveRow[-1] = 127;
                }
            }

            // Predict
            if (mode == PredictionMode.DcPred)
            {
                _dcPred[leftAvailable][upAvailable][(int)txSize](dst, dstStride, constAboveRow, leftCol);
            }
            else
            {
                _pred[(int)mode][(int)txSize](dst, dstStride, constAboveRow, leftCol);
            }
        }

        public static unsafe void PredictIntraBlock(
            ref MacroBlockD xd,
            int bwlIn,
            TxSize txSize,
            PredictionMode mode,
            byte* refr,
            int refStride,
            byte* dst,
            int dstStride,
            int aoff,
            int loff,
            int plane)
        {
            int bw = 1 << bwlIn;
            int txw = 1 << (int)txSize;
            int haveTop = loff != 0 || !xd.AboveMi.IsNull ? 1 : 0;
            int haveLeft = aoff != 0 || !xd.LeftMi.IsNull ? 1 : 0;
            int haveRight = (aoff + txw) < bw ? 1 : 0;
            int x = aoff * 4;
            int y = loff * 4;

            if (xd.CurBuf.HighBd)
            {
                BuildIntraPredictorsHigh(
                    ref xd,
                    refr,
                    refStride,
                    dst,
                    dstStride,
                    mode,
                    txSize,
                    haveTop,
                    haveLeft,
                    haveRight,
                    x,
                    y,
                    plane);
<<<<<<< HEAD

=======
>>>>>>> 1ec71635b (sync with main branch)
                return;
            }
            BuildIntraPredictors(
                ref xd,
                refr,
                refStride,
                dst,
                dstStride,
                mode,
                txSize,
                haveTop,
                haveLeft,
                haveRight,
                x,
                y,
                plane);
        }
    }
}
