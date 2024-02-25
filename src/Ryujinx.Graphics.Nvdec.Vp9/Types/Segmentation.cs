<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Ryujinx.Graphics.Nvdec.Vp9.Types
{
    internal struct Segmentation
    {
<<<<<<< HEAD
        private static readonly int[] _segFeatureDataSigned = { 1, 1, 0, 0 };
        private static readonly int[] _segFeatureDataMax = { QuantCommon.MaxQ, Vp9.LoopFilter.MaxLoopFilter, 3, 0 };
=======
        private static readonly int[] SegFeatureDataSigned = new int[] { 1, 1, 0, 0 };
        private static readonly int[] SegFeatureDataMax = new int[] { QuantCommon.MaxQ, Vp9.LoopFilter.MaxLoopFilter, 3, 0 };
>>>>>>> 1ec71635b (sync with main branch)

        public bool Enabled;
        public bool UpdateMap;
        public byte UpdateData;
        public byte AbsDelta;
        public bool TemporalUpdate;

        public Array8<Array4<short>> FeatureData;
        public Array8<uint> FeatureMask;
        public int AqAvOffset;

        public static byte GetPredProbSegId(ref Array3<byte> segPredProbs, ref MacroBlockD xd)
        {
            return segPredProbs[xd.GetPredContextSegId()];
        }

        public void ClearAllSegFeatures()
        {
<<<<<<< HEAD
            MemoryMarshal.CreateSpan(ref FeatureData[0][0], 8 * 4).Clear();
            MemoryMarshal.CreateSpan(ref FeatureMask[0], 8).Clear();
=======
            MemoryMarshal.CreateSpan(ref FeatureData[0][0], 8 * 4).Fill(0);
            MemoryMarshal.CreateSpan(ref FeatureMask[0], 8).Fill(0);
>>>>>>> 1ec71635b (sync with main branch)
            AqAvOffset = 0;
        }

        internal void EnableSegFeature(int segmentId, SegLvlFeatures featureId)
        {
            FeatureMask[segmentId] |= 1u << (int)featureId;
        }

        internal static int FeatureDataMax(SegLvlFeatures featureId)
        {
<<<<<<< HEAD
            return _segFeatureDataMax[(int)featureId];
=======
            return SegFeatureDataMax[(int)featureId];
>>>>>>> 1ec71635b (sync with main branch)
        }

        internal static int IsSegFeatureSigned(SegLvlFeatures featureId)
        {
<<<<<<< HEAD
            return _segFeatureDataSigned[(int)featureId];
=======
            return SegFeatureDataSigned[(int)featureId];
>>>>>>> 1ec71635b (sync with main branch)
        }

        internal void SetSegData(int segmentId, SegLvlFeatures featureId, int segData)
        {
<<<<<<< HEAD
            Debug.Assert(segData <= _segFeatureDataMax[(int)featureId]);
            if (segData < 0)
            {
                Debug.Assert(_segFeatureDataSigned[(int)featureId] != 0);
                Debug.Assert(-segData <= _segFeatureDataMax[(int)featureId]);
=======
            Debug.Assert(segData <= SegFeatureDataMax[(int)featureId]);
            if (segData < 0)
            {
                Debug.Assert(SegFeatureDataSigned[(int)featureId] != 0);
                Debug.Assert(-segData <= SegFeatureDataMax[(int)featureId]);
>>>>>>> 1ec71635b (sync with main branch)
            }

            FeatureData[segmentId][(int)featureId] = (short)segData;
        }

        internal int IsSegFeatureActive(int segmentId, SegLvlFeatures featureId)
        {
            return Enabled && (FeatureMask[segmentId] & (1 << (int)featureId)) != 0 ? 1 : 0;
        }

        internal short GetSegData(int segmentId, SegLvlFeatures featureId)
        {
            return FeatureData[segmentId][(int)featureId];
        }
    }
}
