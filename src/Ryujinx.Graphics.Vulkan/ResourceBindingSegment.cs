using Ryujinx.Graphics.GAL;

namespace Ryujinx.Graphics.Vulkan
{
    readonly struct ResourceBindingSegment
    {
        public readonly int Binding;
        public readonly int Count;
        public readonly ResourceType Type;
        public readonly ResourceStages Stages;
<<<<<<< HEAD

        public ResourceBindingSegment(int binding, int count, ResourceType type, ResourceStages stages)
=======
        public readonly ResourceAccess Access;

        public ResourceBindingSegment(int binding, int count, ResourceType type, ResourceStages stages, ResourceAccess access)
>>>>>>> 1ec71635b (sync with main branch)
        {
            Binding = binding;
            Count = count;
            Type = type;
            Stages = stages;
<<<<<<< HEAD
        }
    }
}
=======
            Access = access;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
