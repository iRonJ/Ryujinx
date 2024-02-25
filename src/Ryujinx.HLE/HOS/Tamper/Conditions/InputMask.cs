namespace Ryujinx.HLE.HOS.Tamper.Conditions
{
    class InputMask : ICondition
    {
<<<<<<< HEAD
        private readonly long _mask;
        private readonly Parameter<long> _input;
=======
        private long _mask;
        private Parameter<long> _input;
>>>>>>> 1ec71635b (sync with main branch)

        public InputMask(long mask, Parameter<long> input)
        {
            _mask = mask;
            _input = input;
        }

        public bool Evaluate()
        {
            return (_input.Value & _mask) == _mask;
        }
    }
}
