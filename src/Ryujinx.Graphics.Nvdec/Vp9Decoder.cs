<<<<<<< HEAD
using Ryujinx.Common;
using Ryujinx.Graphics.Device;
=======
﻿using Ryujinx.Common;
using Ryujinx.Graphics.Gpu.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Nvdec.Image;
using Ryujinx.Graphics.Nvdec.Types.Vp9;
using Ryujinx.Graphics.Nvdec.Vp9;
using Ryujinx.Graphics.Video;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Ryujinx.Graphics.Nvdec.MemoryExtensions;

namespace Ryujinx.Graphics.Nvdec
{
    static class Vp9Decoder
    {
<<<<<<< HEAD
        private static readonly Decoder _decoder = new();

        public unsafe static void Decode(ResourceManager rm, ref NvdecRegisters state)
        {
            PictureInfo pictureInfo = rm.MemoryManager.DeviceRead<PictureInfo>(state.SetDrvPicSetupOffset);
            EntropyProbs entropy = rm.MemoryManager.DeviceRead<EntropyProbs>(state.Vp9SetProbTabBufOffset);
=======
        private static Decoder _decoder = new Decoder();

        public unsafe static void Decode(ResourceManager rm, ref NvdecRegisters state)
        {
            PictureInfo pictureInfo = rm.Gmm.DeviceRead<PictureInfo>(state.SetDrvPicSetupOffset);
            EntropyProbs entropy = rm.Gmm.DeviceRead<EntropyProbs>(state.Vp9SetProbTabBufOffset);
>>>>>>> 1ec71635b (sync with main branch)

            ISurface Rent(uint lumaOffset, uint chromaOffset, FrameSize size)
            {
                return rm.Cache.Get(_decoder, lumaOffset, chromaOffset, size.Width, size.Height);
            }

<<<<<<< HEAD
            ISurface lastSurface = Rent(state.SetPictureLumaOffset[0], state.SetPictureChromaOffset[0], pictureInfo.LastFrameSize);
            ISurface goldenSurface = Rent(state.SetPictureLumaOffset[1], state.SetPictureChromaOffset[1], pictureInfo.GoldenFrameSize);
            ISurface altSurface = Rent(state.SetPictureLumaOffset[2], state.SetPictureChromaOffset[2], pictureInfo.AltFrameSize);
=======
            ISurface lastSurface    = Rent(state.SetPictureLumaOffset[0], state.SetPictureChromaOffset[0], pictureInfo.LastFrameSize);
            ISurface goldenSurface  = Rent(state.SetPictureLumaOffset[1], state.SetPictureChromaOffset[1], pictureInfo.GoldenFrameSize);
            ISurface altSurface     = Rent(state.SetPictureLumaOffset[2], state.SetPictureChromaOffset[2], pictureInfo.AltFrameSize);
>>>>>>> 1ec71635b (sync with main branch)
            ISurface currentSurface = Rent(state.SetPictureLumaOffset[3], state.SetPictureChromaOffset[3], pictureInfo.CurrentFrameSize);

            Vp9PictureInfo info = pictureInfo.Convert();

            info.LastReference = lastSurface;
            info.GoldenReference = goldenSurface;
            info.AltReference = altSurface;

            entropy.Convert(ref info.Entropy);

<<<<<<< HEAD
            ReadOnlySpan<byte> bitstream = rm.MemoryManager.DeviceGetSpan(state.SetInBufBaseOffset, (int)pictureInfo.BitstreamSize);
=======
            ReadOnlySpan<byte> bitstream = rm.Gmm.DeviceGetSpan(state.SetInBufBaseOffset, (int)pictureInfo.BitstreamSize);
>>>>>>> 1ec71635b (sync with main branch)

            ReadOnlySpan<Vp9MvRef> mvsIn = ReadOnlySpan<Vp9MvRef>.Empty;

            if (info.UsePrevInFindMvRefs)
            {
<<<<<<< HEAD
                mvsIn = GetMvsInput(rm.MemoryManager, pictureInfo.CurrentFrameSize, state.Vp9SetColMvReadBufOffset);
=======
                mvsIn = GetMvsInput(rm.Gmm, pictureInfo.CurrentFrameSize, state.Vp9SetColMvReadBufOffset);
>>>>>>> 1ec71635b (sync with main branch)
            }

            int miCols = BitUtils.DivRoundUp(pictureInfo.CurrentFrameSize.Width, 8);
            int miRows = BitUtils.DivRoundUp(pictureInfo.CurrentFrameSize.Height, 8);

<<<<<<< HEAD
            using var mvsRegion = rm.MemoryManager.GetWritableRegion(ExtendOffset(state.Vp9SetColMvWriteBufOffset), miRows * miCols * 16);

            Span<Vp9MvRef> mvsOut = MemoryMarshal.Cast<byte, Vp9MvRef>(mvsRegion.Memory.Span);

            uint lumaOffset = state.SetPictureLumaOffset[3];
=======
            using var mvsRegion = rm.Gmm.GetWritableRegion(ExtendOffset(state.Vp9SetColMvWriteBufOffset), miRows * miCols * 16);

            Span<Vp9MvRef> mvsOut = MemoryMarshal.Cast<byte, Vp9MvRef>(mvsRegion.Memory.Span);

            uint lumaOffset   = state.SetPictureLumaOffset[3];
>>>>>>> 1ec71635b (sync with main branch)
            uint chromaOffset = state.SetPictureChromaOffset[3];

            if (_decoder.Decode(ref info, currentSurface, bitstream, mvsIn, mvsOut))
            {
<<<<<<< HEAD
                SurfaceWriter.Write(rm.MemoryManager, currentSurface, lumaOffset, chromaOffset);
            }

            WriteBackwardUpdates(rm.MemoryManager, state.Vp9SetCtxCounterBufOffset, ref info.BackwardUpdateCounts);
=======
                SurfaceWriter.Write(rm.Gmm, currentSurface, lumaOffset, chromaOffset);
            }

            WriteBackwardUpdates(rm.Gmm, state.Vp9SetCtxCounterBufOffset, ref info.BackwardUpdateCounts);
>>>>>>> 1ec71635b (sync with main branch)

            rm.Cache.Put(lastSurface);
            rm.Cache.Put(goldenSurface);
            rm.Cache.Put(altSurface);
            rm.Cache.Put(currentSurface);
        }

<<<<<<< HEAD
        private static ReadOnlySpan<Vp9MvRef> GetMvsInput(DeviceMemoryManager mm, FrameSize size, uint offset)
=======
        private static ReadOnlySpan<Vp9MvRef> GetMvsInput(MemoryManager gmm, FrameSize size, uint offset)
>>>>>>> 1ec71635b (sync with main branch)
        {
            int miCols = BitUtils.DivRoundUp(size.Width, 8);
            int miRows = BitUtils.DivRoundUp(size.Height, 8);

<<<<<<< HEAD
            return MemoryMarshal.Cast<byte, Vp9MvRef>(mm.DeviceGetSpan(offset, miRows * miCols * 16));
        }

        private static void WriteBackwardUpdates(DeviceMemoryManager mm, uint offset, ref Vp9BackwardUpdates counts)
        {
            using var backwardUpdatesRegion = mm.GetWritableRegion(ExtendOffset(offset), Unsafe.SizeOf<BackwardUpdates>());
=======
            return MemoryMarshal.Cast<byte, Vp9MvRef>(gmm.DeviceGetSpan(offset, miRows * miCols * 16));
        }

        private static void WriteBackwardUpdates(MemoryManager gmm, uint offset, ref Vp9BackwardUpdates counts)
        {
            using var backwardUpdatesRegion = gmm.GetWritableRegion(ExtendOffset(offset), Unsafe.SizeOf<BackwardUpdates>());
>>>>>>> 1ec71635b (sync with main branch)

            ref var backwardUpdates = ref MemoryMarshal.Cast<byte, BackwardUpdates>(backwardUpdatesRegion.Memory.Span)[0];

            backwardUpdates = new BackwardUpdates(ref counts);
        }
    }
}
