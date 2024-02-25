using ARMeilleure.Instructions;

namespace ARMeilleure.Decoders
{
    readonly struct InstDescriptor
    {
<<<<<<< HEAD
        public static InstDescriptor Undefined => new(InstName.Und, InstEmit.Und);

        public InstName Name { get; }
=======
        public static InstDescriptor Undefined => new InstDescriptor(InstName.Und, InstEmit.Und);

        public InstName    Name    { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public InstEmitter Emitter { get; }

        public InstDescriptor(InstName name, InstEmitter emitter)
        {
<<<<<<< HEAD
            Name = name;
            Emitter = emitter;
        }
    }
}
=======
            Name    = name;
            Emitter = emitter;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
