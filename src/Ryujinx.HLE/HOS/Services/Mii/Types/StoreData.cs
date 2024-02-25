<<<<<<< HEAD
using Ryujinx.Common.Utilities;
=======
﻿using Ryujinx.Common.Utilities;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Mii.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = Size)]
    struct StoreData : IStoredData<StoreData>
    {
        public const int Size = 0x44;

<<<<<<< HEAD
        public CoreData CoreData;
        private CreateId _createId;
        public ushort DataCrc;
        public ushort DeviceCrc;

        public byte Type => CoreData.Type;

        public readonly CreateId CreateId => _createId;

        public readonly ResultCode InvalidData => ResultCode.InvalidStoreData;
=======
        public  CoreData CoreData;
        private CreateId _createId;
        public  ushort   DataCrc;
        public  ushort   DeviceCrc;

        public byte Type => CoreData.Type;

        public CreateId CreateId => _createId;

        public ResultCode InvalidData => ResultCode.InvalidStoreData;
>>>>>>> 1ec71635b (sync with main branch)

        private void UpdateDataCrc()
        {
            DataCrc = CalculateDataCrc();
        }

        private void UpdateDeviceCrc()
        {
            DeviceCrc = CalculateDeviceCrc();
        }

        public void UpdateCrc()
        {
            UpdateDataCrc();
            UpdateDeviceCrc();
        }

        public bool IsSpecial()
        {
            return CoreData.Type == 1;
        }

        public bool IsValid()
        {
            return CoreData.IsValid() && IsValidDataCrc() && IsValidDeviceCrc();
        }

        public bool IsValidDataCrc()
        {
            return Helper.CalculateCrc16(AsSpanWithoutDeviceCrc(), 0, false) == 0;
        }

        public bool IsValidDeviceCrc()
        {
            UInt128 deviceId = Helper.GetDeviceId();

            ushort deviceIdCrc16 = Helper.CalculateCrc16(SpanHelpers.AsByteSpan(ref deviceId), 0, false);

            return Helper.CalculateCrc16(AsSpan(), deviceIdCrc16, false) == 0;
        }

        private ushort CalculateDataCrc()
        {
<<<<<<< HEAD
            return Helper.CalculateCrc16(AsSpanWithoutCrcs(), 0, true);
=======
            return Helper.CalculateCrc16(AsSpanWithoutDeviceCrc(), 0, true);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private ushort CalculateDeviceCrc()
        {
            UInt128 deviceId = Helper.GetDeviceId();

            ushort deviceIdCrc16 = Helper.CalculateCrc16(SpanHelpers.AsByteSpan(ref deviceId), 0, false);

<<<<<<< HEAD
            return Helper.CalculateCrc16(AsSpanWithoutDeviceCrc(), deviceIdCrc16, true);
=======
            return Helper.CalculateCrc16(AsSpan(), deviceIdCrc16, true);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private ReadOnlySpan<byte> AsSpan()
        {
            return SpanHelpers.AsReadOnlyByteSpan(ref this);
        }

        private ReadOnlySpan<byte> AsSpanWithoutDeviceCrc()
        {
<<<<<<< HEAD
            return AsSpan()[..(Size - 2)];
        }

        private ReadOnlySpan<byte> AsSpanWithoutCrcs()
        {
            return AsSpan()[..(Size - 4)];
=======
            return AsSpan().Slice(0, Size - 2);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static StoreData BuildDefault(UtilityImpl utilImpl, uint index)
        {
<<<<<<< HEAD
            StoreData result = new()
            {
                _createId = utilImpl.MakeCreateId(),
            };

            CoreData coreData = new();
=======
            StoreData result = new StoreData
            {
                _createId = utilImpl.MakeCreateId()
            };

            CoreData coreData = new CoreData();
>>>>>>> 1ec71635b (sync with main branch)

            DefaultMii template = DefaultMii.GetDefaultMii(index);

            coreData.SetDefault();

<<<<<<< HEAD
#pragma warning disable IDE0055 // Disable formatting
=======
>>>>>>> 1ec71635b (sync with main branch)
            coreData.Nickname        = template.Nickname;
            coreData.FontRegion      = (FontRegion)template.FontRegion;
            coreData.FavoriteColor   = (byte)template.FavoriteColor;
            coreData.Gender          = (Gender)template.Gender;
            coreData.Height          = (byte)template.Height;
            coreData.Build           = (byte)template.Build;
            coreData.Type            = (byte)template.Type;
            coreData.RegionMove      = (byte)template.RegionMove;
            coreData.FacelineType    = (FacelineType)template.FacelineType;
            coreData.FacelineColor   = (FacelineColor)Helper.Ver3FacelineColorTable[template.FacelineColorVer3];
            coreData.FacelineWrinkle = (FacelineWrinkle)template.FacelineWrinkle;
            coreData.FacelineMake    = (FacelineMake)template.FacelineMake;
            coreData.HairType        = (HairType)template.HairType;
            coreData.HairColor       = (CommonColor)Helper.Ver3HairColorTable[template.HairColorVer3];
            coreData.HairFlip        = (HairFlip)template.HairFlip;
            coreData.EyeType         = (EyeType)template.EyeType;
            coreData.EyeColor        = (CommonColor)Helper.Ver3EyeColorTable[template.EyeColorVer3];
            coreData.EyeScale        = (byte)template.EyeScale;
            coreData.EyeAspect       = (byte)template.EyeAspect;
            coreData.EyeRotate       = (byte)template.EyeRotate;
            coreData.EyeX            = (byte)template.EyeX;
            coreData.EyeY            = (byte)template.EyeY;
            coreData.EyebrowType     = (EyebrowType)template.EyebrowType;
            coreData.EyebrowColor    = (CommonColor)Helper.Ver3HairColorTable[template.EyebrowColorVer3];
            coreData.EyebrowScale    = (byte)template.EyebrowScale;
            coreData.EyebrowAspect   = (byte)template.EyebrowAspect;
            coreData.EyebrowRotate   = (byte)template.EyebrowRotate;
            coreData.EyebrowX        = (byte)template.EyebrowX;
            coreData.EyebrowY        = (byte)template.EyebrowY;
            coreData.NoseType        = (NoseType)template.NoseType;
            coreData.NoseScale       = (byte)template.NoseScale;
            coreData.NoseY           = (byte)template.NoseY;
            coreData.MouthType       = (MouthType)template.MouthType;
            coreData.MouthColor      = (CommonColor)Helper.Ver3MouthColorTable[template.MouthColorVer3];
            coreData.MouthScale      = (byte)template.MouthScale;
            coreData.MouthAspect     = (byte)template.MouthAspect;
            coreData.MouthY          = (byte)template.MouthY;
            coreData.BeardColor      = (CommonColor)Helper.Ver3HairColorTable[template.BeardColorVer3];
            coreData.BeardType       = (BeardType)template.BeardType;
            coreData.MustacheType    = (MustacheType)template.MustacheType;
            coreData.MustacheScale   = (byte)template.MustacheScale;
            coreData.MustacheY       = (byte)template.MustacheY;
            coreData.GlassType       = (GlassType)template.GlassType;
            coreData.GlassColor      = (CommonColor)Helper.Ver3GlassColorTable[template.GlassColorVer3];
            coreData.GlassScale      = (byte)template.GlassScale;
            coreData.GlassY          = (byte)template.GlassY;
            coreData.MoleType        = (MoleType)template.MoleType;
            coreData.MoleScale       = (byte)template.MoleScale;
            coreData.MoleX           = (byte)template.MoleX;
            coreData.MoleY           = (byte)template.MoleY;
<<<<<<< HEAD
#pragma warning restore IDE0055
=======
>>>>>>> 1ec71635b (sync with main branch)

            result.CoreData = coreData;

            result.UpdateCrc();

            return result;
        }

        public static StoreData BuildRandom(UtilityImpl utilImpl, Age age, Gender gender, Race race)
        {
            return BuildFromCoreData(utilImpl, CoreData.BuildRandom(utilImpl, age, gender, race));
        }

        public static StoreData BuildFromCoreData(UtilityImpl utilImpl, CoreData coreData)
        {
<<<<<<< HEAD
            StoreData result = new()
            {
                CoreData = coreData,
                _createId = utilImpl.MakeCreateId(),
=======
            StoreData result = new StoreData
            {
                CoreData  = coreData,
                _createId = utilImpl.MakeCreateId()
>>>>>>> 1ec71635b (sync with main branch)
            };

            result.UpdateCrc();

            return result;
        }

        public void SetFromStoreData(StoreData storeData)
        {
            this = storeData;
        }

<<<<<<< HEAD
        public readonly void SetSource(Source source)
=======
        public void SetSource(Source source)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // Only implemented for Element variants.
        }

        public static bool operator ==(StoreData x, StoreData y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(StoreData x, StoreData y)
        {
            return !x.Equals(y);
        }

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is StoreData storeData && Equals(storeData);
        }

<<<<<<< HEAD
        public readonly bool Equals(StoreData cmpObj)
=======
        public bool Equals(StoreData cmpObj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (!cmpObj.IsValid())
            {
                return false;
            }

            bool result = true;

            result &= CreateId == cmpObj.CreateId;
            result &= CoreData == cmpObj.CoreData;
            result &= DataCrc == cmpObj.DataCrc;
            result &= DeviceCrc == cmpObj.DeviceCrc;

            return result;
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
        {
            HashCode hashCode = new();
=======
        public override int GetHashCode()
        {
            HashCode hashCode = new HashCode();
>>>>>>> 1ec71635b (sync with main branch)

            hashCode.Add(CreateId);
            hashCode.Add(CoreData);
            hashCode.Add(DataCrc);
            hashCode.Add(DeviceCrc);

            return hashCode.ToHashCode();
        }
    }
}
