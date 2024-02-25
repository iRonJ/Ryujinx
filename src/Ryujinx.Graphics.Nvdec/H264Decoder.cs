<<<<<<< HEAD
using Ryujinx.Graphics.Nvdec.FFmpeg.H264;
=======
﻿using Ryujinx.Graphics.Nvdec.FFmpeg.H264;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Nvdec.Image;
using Ryujinx.Graphics.Nvdec.Types.H264;
using Ryujinx.Graphics.Video;
using System;

namespace Ryujinx.Graphics.Nvdec
{
    static class H264Decoder
    {
        private const int MbSizeInPixels = 16;

        public static void Decode(NvdecDecoderContext context, ResourceManager rm, ref NvdecRegisters state)
        {
<<<<<<< HEAD
            PictureInfo pictureInfo = rm.MemoryManager.DeviceRead<PictureInfo>(state.SetDrvPicSetupOffset);
            H264PictureInfo info = pictureInfo.Convert();

            ReadOnlySpan<byte> bitstream = rm.MemoryManager.DeviceGetSpan(state.SetInBufBaseOffset, (int)pictureInfo.BitstreamSize);

            int width = (int)pictureInfo.PicWidthInMbs * MbSizeInPixels;
=======
            PictureInfo pictureInfo = rm.Gmm.DeviceRead<PictureInfo>(state.SetDrvPicSetupOffset);
            H264PictureInfo info = pictureInfo.Convert();

            ReadOnlySpan<byte> bitstream = rm.Gmm.DeviceGetSpan(state.SetInBufBaseOffset, (int)pictureInfo.BitstreamSize);

            int width  = (int)pictureInfo.PicWidthInMbs * MbSizeInPixels;
>>>>>>> 1ec71635b (sync with main branch)
            int height = (int)pictureInfo.PicHeightInMbs * MbSizeInPixels;

            int surfaceIndex = (int)pictureInfo.OutputSurfaceIndex;

<<<<<<< HEAD
            uint lumaOffset = state.SetPictureLumaOffset[surfaceIndex];
=======
            uint lumaOffset   = state.SetPictureLumaOffset[surfaceIndex];
>>>>>>> 1ec71635b (sync with main branch)
            uint chromaOffset = state.SetPictureChromaOffset[surfaceIndex];

            Decoder decoder = context.GetH264Decoder();

            ISurface outputSurface = rm.Cache.Get(decoder, 0, 0, width, height);

            if (decoder.Decode(ref info, outputSurface, bitstream))
            {
                if (outputSurface.Field == FrameField.Progressive)
                {
                    SurfaceWriter.Write(
<<<<<<< HEAD
                        rm.MemoryManager,
                        outputSurface,
                        lumaOffset + pictureInfo.LumaFrameOffset,
=======
                        rm.Gmm,
                        outputSurface,
                        lumaOffset   + pictureInfo.LumaFrameOffset,
>>>>>>> 1ec71635b (sync with main branch)
                        chromaOffset + pictureInfo.ChromaFrameOffset);
                }
                else
                {
                    SurfaceWriter.WriteInterlaced(
<<<<<<< HEAD
                        rm.MemoryManager,
                        outputSurface,
                        lumaOffset + pictureInfo.LumaTopFieldOffset,
                        chromaOffset + pictureInfo.ChromaTopFieldOffset,
                        lumaOffset + pictureInfo.LumaBottomFieldOffset,
=======
                        rm.Gmm,
                        outputSurface,
                        lumaOffset   + pictureInfo.LumaTopFieldOffset,
                        chromaOffset + pictureInfo.ChromaTopFieldOffset,
                        lumaOffset   + pictureInfo.LumaBottomFieldOffset,
>>>>>>> 1ec71635b (sync with main branch)
                        chromaOffset + pictureInfo.ChromaBottomFieldOffset);
                }
            }

            rm.Cache.Put(outputSurface);
        }
    }
}
