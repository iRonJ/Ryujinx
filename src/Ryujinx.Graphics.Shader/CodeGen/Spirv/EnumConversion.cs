<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using static Spv.Specification;

namespace Ryujinx.Graphics.Shader.CodeGen.Spirv
{
    static class EnumConversion
    {
        public static ExecutionModel Convert(this ShaderStage stage)
        {
            return stage switch
            {
                ShaderStage.Compute => ExecutionModel.GLCompute,
                ShaderStage.Vertex => ExecutionModel.Vertex,
                ShaderStage.TessellationControl => ExecutionModel.TessellationControl,
                ShaderStage.TessellationEvaluation => ExecutionModel.TessellationEvaluation,
                ShaderStage.Geometry => ExecutionModel.Geometry,
                ShaderStage.Fragment => ExecutionModel.Fragment,
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid shader stage \"{stage}\"."),
=======
                _ => throw new ArgumentException($"Invalid shader stage \"{stage}\".")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }
    }
}
