using System;
using System.Collections.ObjectModel;

namespace Ryujinx.Graphics.Shader
{
    public class ShaderProgramInfo
    {
        public ReadOnlyCollection<BufferDescriptor> CBuffers { get; }
        public ReadOnlyCollection<BufferDescriptor> SBuffers { get; }
        public ReadOnlyCollection<TextureDescriptor> Textures { get; }
        public ReadOnlyCollection<TextureDescriptor> Images { get; }

<<<<<<< HEAD
        public ShaderStage Stage { get; }
        public int GeometryVerticesPerPrimitive { get; }
        public int GeometryMaxOutputVertices { get; }
        public int ThreadsPerInputPrimitive { get; }
        public bool UsesFragCoord { get; }
=======
        public ShaderIdentification Identification { get; }
        public int GpLayerInputAttribute { get; }
        public ShaderStage Stage { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public bool UsesInstanceId { get; }
        public bool UsesDrawParameters { get; }
        public bool UsesRtLayer { get; }
        public byte ClipDistancesWritten { get; }
        public int FragmentOutputMap { get; }

        public ShaderProgramInfo(
            BufferDescriptor[] cBuffers,
            BufferDescriptor[] sBuffers,
            TextureDescriptor[] textures,
            TextureDescriptor[] images,
<<<<<<< HEAD
            ShaderStage stage,
            int geometryVerticesPerPrimitive,
            int geometryMaxOutputVertices,
            int threadsPerInputPrimitive,
            bool usesFragCoord,
=======
            ShaderIdentification identification,
            int gpLayerInputAttribute,
            ShaderStage stage,
>>>>>>> 1ec71635b (sync with main branch)
            bool usesInstanceId,
            bool usesDrawParameters,
            bool usesRtLayer,
            byte clipDistancesWritten,
            int fragmentOutputMap)
        {
            CBuffers = Array.AsReadOnly(cBuffers);
            SBuffers = Array.AsReadOnly(sBuffers);
            Textures = Array.AsReadOnly(textures);
            Images = Array.AsReadOnly(images);

<<<<<<< HEAD
            Stage = stage;
            GeometryVerticesPerPrimitive = geometryVerticesPerPrimitive;
            GeometryMaxOutputVertices = geometryMaxOutputVertices;
            ThreadsPerInputPrimitive = threadsPerInputPrimitive;
            UsesFragCoord = usesFragCoord;
=======
            Identification = identification;
            GpLayerInputAttribute = gpLayerInputAttribute;
            Stage = stage;
>>>>>>> 1ec71635b (sync with main branch)
            UsesInstanceId = usesInstanceId;
            UsesDrawParameters = usesDrawParameters;
            UsesRtLayer = usesRtLayer;
            ClipDistancesWritten = clipDistancesWritten;
            FragmentOutputMap = fragmentOutputMap;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
