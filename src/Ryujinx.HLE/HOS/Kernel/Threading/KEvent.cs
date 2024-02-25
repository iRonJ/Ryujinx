namespace Ryujinx.HLE.HOS.Kernel.Threading
{
    class KEvent
    {
        public KReadableEvent ReadableEvent { get; private set; }
        public KWritableEvent WritableEvent { get; private set; }

        public KEvent(KernelContext context)
        {
<<<<<<< HEAD
            ReadableEvent = new KReadableEvent(context);
            WritableEvent = new KWritableEvent(context, this);
        }
    }
}
=======
            ReadableEvent = new KReadableEvent(context, this);
            WritableEvent = new KWritableEvent(context, this);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
