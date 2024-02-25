namespace Ryujinx.Graphics.GAL
{
    public readonly struct DepthTestDescriptor
    {
<<<<<<< HEAD
        public bool TestEnable { get; }
=======
        public bool TestEnable  { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public bool WriteEnable { get; }

        public CompareOp Func { get; }

        public DepthTestDescriptor(
<<<<<<< HEAD
            bool testEnable,
            bool writeEnable,
            CompareOp func)
        {
            TestEnable = testEnable;
            WriteEnable = writeEnable;
            Func = func;
=======
            bool      testEnable,
            bool      writeEnable,
            CompareOp func)
        {
            TestEnable  = testEnable;
            WriteEnable = writeEnable;
            Func        = func;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
