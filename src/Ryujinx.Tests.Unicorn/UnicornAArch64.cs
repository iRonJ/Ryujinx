using System;
using UnicornEngine.Const;

namespace Ryujinx.Tests.Unicorn
{
    public class UnicornAArch64 : IDisposable
    {
<<<<<<< HEAD
        internal readonly UnicornEngine.Unicorn Uc;
=======
        internal readonly UnicornEngine.Unicorn uc;
>>>>>>> 1ec71635b (sync with main branch)
        private bool _isDisposed;

        public IndexedProperty<int, ulong> X => new(GetX, SetX);

        public IndexedProperty<int, SimdValue> Q => new(GetQ, SetQ);

        public ulong LR
        {
            get => GetRegister(Arm64.UC_ARM64_REG_LR);
            set => SetRegister(Arm64.UC_ARM64_REG_LR, value);
        }

        public ulong SP
        {
            get => GetRegister(Arm64.UC_ARM64_REG_SP);
            set => SetRegister(Arm64.UC_ARM64_REG_SP, value);
        }

        public ulong PC
        {
            get => GetRegister(Arm64.UC_ARM64_REG_PC);
            set => SetRegister(Arm64.UC_ARM64_REG_PC, value);
        }

        public uint Pstate
        {
            get => (uint)GetRegister(Arm64.UC_ARM64_REG_PSTATE);
<<<<<<< HEAD
            set => SetRegister(Arm64.UC_ARM64_REG_PSTATE, value);
=======
            set =>       SetRegister(Arm64.UC_ARM64_REG_PSTATE, value);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public int Fpcr
        {
            get => (int)GetRegister(Arm64.UC_ARM64_REG_FPCR);
<<<<<<< HEAD
            set => SetRegister(Arm64.UC_ARM64_REG_FPCR, (uint)value);
=======
            set =>      SetRegister(Arm64.UC_ARM64_REG_FPCR, (uint)value);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public int Fpsr
        {
            get => (int)GetRegister(Arm64.UC_ARM64_REG_FPSR);
<<<<<<< HEAD
            set => SetRegister(Arm64.UC_ARM64_REG_FPSR, (uint)value);
=======
            set =>      SetRegister(Arm64.UC_ARM64_REG_FPSR, (uint)value);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public bool OverflowFlag
        {
<<<<<<< HEAD
            get => (Pstate & 0x10000000u) != 0;
=======
            get =>          (Pstate &  0x10000000u) != 0;
>>>>>>> 1ec71635b (sync with main branch)
            set => Pstate = (Pstate & ~0x10000000u) | (value ? 0x10000000u : 0u);
        }

        public bool CarryFlag
        {
<<<<<<< HEAD
            get => (Pstate & 0x20000000u) != 0;
=======
            get =>          (Pstate &  0x20000000u) != 0;
>>>>>>> 1ec71635b (sync with main branch)
            set => Pstate = (Pstate & ~0x20000000u) | (value ? 0x20000000u : 0u);
        }

        public bool ZeroFlag
        {
<<<<<<< HEAD
            get => (Pstate & 0x40000000u) != 0;
=======
            get =>          (Pstate &  0x40000000u) != 0;
>>>>>>> 1ec71635b (sync with main branch)
            set => Pstate = (Pstate & ~0x40000000u) | (value ? 0x40000000u : 0u);
        }

        public bool NegativeFlag
        {
<<<<<<< HEAD
            get => (Pstate & 0x80000000u) != 0;
=======
            get =>          (Pstate &  0x80000000u) != 0;
>>>>>>> 1ec71635b (sync with main branch)
            set => Pstate = (Pstate & ~0x80000000u) | (value ? 0x80000000u : 0u);
        }

        public UnicornAArch64()
        {
<<<<<<< HEAD
            Uc = new UnicornEngine.Unicorn(Common.UC_ARCH_ARM64, Common.UC_MODE_LITTLE_ENDIAN);
=======
            uc = new UnicornEngine.Unicorn(Common.UC_ARCH_ARM64, Common.UC_MODE_LITTLE_ENDIAN);
>>>>>>> 1ec71635b (sync with main branch)

            SetRegister(Arm64.UC_ARM64_REG_CPACR_EL1, 0x00300000);
        }

        ~UnicornAArch64()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
<<<<<<< HEAD
                Uc.Close();
=======
                uc.Close();
>>>>>>> 1ec71635b (sync with main branch)
                _isDisposed = true;
            }
        }

        public void RunForCount(ulong count)
        {
            // FIXME: untilAddr should be 0xFFFFFFFFFFFFFFFFul
<<<<<<< HEAD
            Uc.EmuStart((long)this.PC, -1, 0, (long)count);
=======
            uc.EmuStart((long)this.PC, -1, 0, (long)count);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void Step()
        {
            RunForCount(1);
        }

<<<<<<< HEAD
        private static readonly int[] _xRegisters =
=======
        private static int[] XRegisters =
>>>>>>> 1ec71635b (sync with main branch)
        {
            Arm64.UC_ARM64_REG_X0,
            Arm64.UC_ARM64_REG_X1,
            Arm64.UC_ARM64_REG_X2,
            Arm64.UC_ARM64_REG_X3,
            Arm64.UC_ARM64_REG_X4,
            Arm64.UC_ARM64_REG_X5,
            Arm64.UC_ARM64_REG_X6,
            Arm64.UC_ARM64_REG_X7,
            Arm64.UC_ARM64_REG_X8,
            Arm64.UC_ARM64_REG_X9,
            Arm64.UC_ARM64_REG_X10,
            Arm64.UC_ARM64_REG_X11,
            Arm64.UC_ARM64_REG_X12,
            Arm64.UC_ARM64_REG_X13,
            Arm64.UC_ARM64_REG_X14,
            Arm64.UC_ARM64_REG_X15,
            Arm64.UC_ARM64_REG_X16,
            Arm64.UC_ARM64_REG_X17,
            Arm64.UC_ARM64_REG_X18,
            Arm64.UC_ARM64_REG_X19,
            Arm64.UC_ARM64_REG_X20,
            Arm64.UC_ARM64_REG_X21,
            Arm64.UC_ARM64_REG_X22,
            Arm64.UC_ARM64_REG_X23,
            Arm64.UC_ARM64_REG_X24,
            Arm64.UC_ARM64_REG_X25,
            Arm64.UC_ARM64_REG_X26,
            Arm64.UC_ARM64_REG_X27,
            Arm64.UC_ARM64_REG_X28,
            Arm64.UC_ARM64_REG_X29,
            Arm64.UC_ARM64_REG_X30,
        };

<<<<<<< HEAD
        private static readonly int[] _qRegisters =
=======
        private static int[] QRegisters =
>>>>>>> 1ec71635b (sync with main branch)
        {
            Arm64.UC_ARM64_REG_Q0,
            Arm64.UC_ARM64_REG_Q1,
            Arm64.UC_ARM64_REG_Q2,
            Arm64.UC_ARM64_REG_Q3,
            Arm64.UC_ARM64_REG_Q4,
            Arm64.UC_ARM64_REG_Q5,
            Arm64.UC_ARM64_REG_Q6,
            Arm64.UC_ARM64_REG_Q7,
            Arm64.UC_ARM64_REG_Q8,
            Arm64.UC_ARM64_REG_Q9,
            Arm64.UC_ARM64_REG_Q10,
            Arm64.UC_ARM64_REG_Q11,
            Arm64.UC_ARM64_REG_Q12,
            Arm64.UC_ARM64_REG_Q13,
            Arm64.UC_ARM64_REG_Q14,
            Arm64.UC_ARM64_REG_Q15,
            Arm64.UC_ARM64_REG_Q16,
            Arm64.UC_ARM64_REG_Q17,
            Arm64.UC_ARM64_REG_Q18,
            Arm64.UC_ARM64_REG_Q19,
            Arm64.UC_ARM64_REG_Q20,
            Arm64.UC_ARM64_REG_Q21,
            Arm64.UC_ARM64_REG_Q22,
            Arm64.UC_ARM64_REG_Q23,
            Arm64.UC_ARM64_REG_Q24,
            Arm64.UC_ARM64_REG_Q25,
            Arm64.UC_ARM64_REG_Q26,
            Arm64.UC_ARM64_REG_Q27,
            Arm64.UC_ARM64_REG_Q28,
            Arm64.UC_ARM64_REG_Q29,
            Arm64.UC_ARM64_REG_Q30,
            Arm64.UC_ARM64_REG_Q31,
        };

        public ulong GetX(int index)
        {
            if ((uint)index > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

<<<<<<< HEAD
            return GetRegister(_xRegisters[index]);
=======
            return GetRegister(XRegisters[index]);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void SetX(int index, ulong value)
        {
            if ((uint)index > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

<<<<<<< HEAD
            SetRegister(_xRegisters[index], value);
=======
            SetRegister(XRegisters[index], value);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public SimdValue GetQ(int index)
        {
            if ((uint)index > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

<<<<<<< HEAD
            return GetVector(_qRegisters[index]);
=======
            return GetVector(QRegisters[index]);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void SetQ(int index, SimdValue value)
        {
            if ((uint)index > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

<<<<<<< HEAD
            SetVector(_qRegisters[index], value);
=======
            SetVector(QRegisters[index], value);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private ulong GetRegister(int register)
        {
            byte[] data = new byte[8];

<<<<<<< HEAD
            Uc.RegRead(register, data);
=======
            uc.RegRead(register, data);
>>>>>>> 1ec71635b (sync with main branch)

            return BitConverter.ToUInt64(data, 0);
        }

        private void SetRegister(int register, ulong value)
        {
            byte[] data = BitConverter.GetBytes(value);

<<<<<<< HEAD
            Uc.RegWrite(register, data);
=======
            uc.RegWrite(register, data);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private SimdValue GetVector(int register)
        {
            byte[] data = new byte[16];

<<<<<<< HEAD
            Uc.RegRead(register, data);
=======
            uc.RegRead(register, data);
>>>>>>> 1ec71635b (sync with main branch)

            return new SimdValue(data);
        }

        private void SetVector(int register, SimdValue value)
        {
            byte[] data = value.ToArray();

<<<<<<< HEAD
            Uc.RegWrite(register, data);
=======
            uc.RegWrite(register, data);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public byte[] MemoryRead(ulong address, ulong size)
        {
            byte[] value = new byte[size];

<<<<<<< HEAD
            Uc.MemRead((long)address, value);
=======
            uc.MemRead((long)address, value);
>>>>>>> 1ec71635b (sync with main branch)

            return value;
        }

<<<<<<< HEAD
        public byte MemoryRead8(ulong address) => MemoryRead(address, 1)[0];
        public ushort MemoryRead16(ulong address) => BitConverter.ToUInt16(MemoryRead(address, 2), 0);
        public uint MemoryRead32(ulong address) => BitConverter.ToUInt32(MemoryRead(address, 4), 0);
        public ulong MemoryRead64(ulong address) => BitConverter.ToUInt64(MemoryRead(address, 8), 0);

        public void MemoryWrite(ulong address, byte[] value)
        {
            Uc.MemWrite((long)address, value);
        }

        public void MemoryWrite8(ulong address, byte value) => MemoryWrite(address, new[] { value });
        public void MemoryWrite16(ulong address, short value) => MemoryWrite(address, BitConverter.GetBytes(value));
        public void MemoryWrite16(ulong address, ushort value) => MemoryWrite(address, BitConverter.GetBytes(value));
        public void MemoryWrite32(ulong address, int value) => MemoryWrite(address, BitConverter.GetBytes(value));
        public void MemoryWrite32(ulong address, uint value) => MemoryWrite(address, BitConverter.GetBytes(value));
        public void MemoryWrite64(ulong address, long value) => MemoryWrite(address, BitConverter.GetBytes(value));
=======
        public byte   MemoryRead8 (ulong address) => MemoryRead(address, 1)[0];
        public ushort MemoryRead16(ulong address) => BitConverter.ToUInt16(MemoryRead(address, 2), 0);
        public uint   MemoryRead32(ulong address) => BitConverter.ToUInt32(MemoryRead(address, 4), 0);
        public ulong  MemoryRead64(ulong address) => BitConverter.ToUInt64(MemoryRead(address, 8), 0);

        public void MemoryWrite(ulong address, byte[] value)
        {
            uc.MemWrite((long)address, value);
        }

        public void MemoryWrite8 (ulong address, byte value)   => MemoryWrite(address, new[]{ value });
        public void MemoryWrite16(ulong address, short value)  => MemoryWrite(address, BitConverter.GetBytes(value));
        public void MemoryWrite16(ulong address, ushort value) => MemoryWrite(address, BitConverter.GetBytes(value));
        public void MemoryWrite32(ulong address, int value)  => MemoryWrite(address, BitConverter.GetBytes(value));
        public void MemoryWrite32(ulong address, uint value) => MemoryWrite(address, BitConverter.GetBytes(value));
        public void MemoryWrite64(ulong address, long value)  => MemoryWrite(address, BitConverter.GetBytes(value));
>>>>>>> 1ec71635b (sync with main branch)
        public void MemoryWrite64(ulong address, ulong value) => MemoryWrite(address, BitConverter.GetBytes(value));

        public void MemoryMap(ulong address, ulong size, MemoryPermission permissions)
        {
<<<<<<< HEAD
            Uc.MemMap((long)address, (long)size, (int)permissions);
=======
            uc.MemMap((long)address, (long)size, (int)permissions);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void MemoryUnmap(ulong address, ulong size)
        {
<<<<<<< HEAD
            Uc.MemUnmap((long)address, (long)size);
=======
            uc.MemUnmap((long)address, (long)size);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void MemoryProtect(ulong address, ulong size, MemoryPermission permissions)
        {
<<<<<<< HEAD
            Uc.MemProtect((long)address, (long)size, (int)permissions);
        }
    }
}
=======
            uc.MemProtect((long)address, (long)size, (int)permissions);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
