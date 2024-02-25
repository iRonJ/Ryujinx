using Ryujinx.HLE.HOS.Tamper.Operations;

namespace Ryujinx.HLE.HOS.Tamper
{
<<<<<<< HEAD
    class Value<TP> : IOperand where TP : unmanaged
    {
        private TP _value;

        public Value(TP value)
=======
    class Value<P> : IOperand where P : unmanaged
    {
        private P _value;

        public Value(P value)
>>>>>>> 1ec71635b (sync with main branch)
        {
            _value = value;
        }

        public T Get<T>() where T : unmanaged
        {
            return (T)(dynamic)_value;
        }

        public void Set<T>(T value) where T : unmanaged
        {
<<<<<<< HEAD
            _value = (TP)(dynamic)value;
=======
            _value = (P)(dynamic)value;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
