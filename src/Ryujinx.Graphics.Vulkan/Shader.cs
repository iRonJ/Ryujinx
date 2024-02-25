<<<<<<< HEAD
using Ryujinx.Common.Logging;
=======
﻿using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.Shader;
using shaderc;
using Silk.NET.Vulkan;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Ryujinx.Graphics.Vulkan
{
    class Shader : IDisposable
    {
        // The shaderc.net dependency's Options constructor and dispose are not thread safe.
        // Take this lock when using them.
<<<<<<< HEAD
        private static readonly object _shaderOptionsLock = new();
=======
        private static object _shaderOptionsLock = new object();
>>>>>>> 1ec71635b (sync with main branch)

        private static readonly IntPtr _ptrMainEntryPointName = Marshal.StringToHGlobalAnsi("main");

        private readonly Vk _api;
        private readonly Device _device;
        private readonly ShaderStageFlags _stage;

        private bool _disposed;
        private ShaderModule _module;

        public ShaderStageFlags StageFlags => _stage;

        public ProgramLinkStatus CompileStatus { private set; get; }

        public readonly Task CompileTask;

        public unsafe Shader(Vk api, Device device, ShaderSource shaderSource)
        {
            _api = api;
            _device = device;

            CompileStatus = ProgramLinkStatus.Incomplete;

            _stage = shaderSource.Stage.Convert();

            CompileTask = Task.Run(() =>
            {
                byte[] spirv = shaderSource.BinaryCode;

                if (spirv == null)
                {
                    spirv = GlslToSpirv(shaderSource.Code, shaderSource.Stage);

                    if (spirv == null)
                    {
                        CompileStatus = ProgramLinkStatus.Failure;

                        return;
                    }
                }

                fixed (byte* pCode = spirv)
                {
<<<<<<< HEAD
                    var shaderModuleCreateInfo = new ShaderModuleCreateInfo
                    {
                        SType = StructureType.ShaderModuleCreateInfo,
                        CodeSize = (uint)spirv.Length,
                        PCode = (uint*)pCode,
=======
                    var shaderModuleCreateInfo = new ShaderModuleCreateInfo()
                    {
                        SType = StructureType.ShaderModuleCreateInfo,
                        CodeSize = (uint)spirv.Length,
                        PCode = (uint*)pCode
>>>>>>> 1ec71635b (sync with main branch)
                    };

                    api.CreateShaderModule(device, shaderModuleCreateInfo, null, out _module).ThrowOnError();
                }

                CompileStatus = ProgramLinkStatus.Success;
            });
        }

        private unsafe static byte[] GlslToSpirv(string glsl, ShaderStage stage)
        {
            Options options;

            lock (_shaderOptionsLock)
            {
                options = new Options(false)
                {
                    SourceLanguage = SourceLanguage.Glsl,
<<<<<<< HEAD
                    TargetSpirVVersion = new SpirVVersion(1, 5),
=======
                    TargetSpirVVersion = new SpirVVersion(1, 5)
>>>>>>> 1ec71635b (sync with main branch)
                };
            }

            options.SetTargetEnvironment(TargetEnvironment.Vulkan, EnvironmentVersion.Vulkan_1_2);
<<<<<<< HEAD
            Compiler compiler = new(options);
=======
            Compiler compiler = new Compiler(options);
>>>>>>> 1ec71635b (sync with main branch)
            var scr = compiler.Compile(glsl, "Ryu", GetShaderCShaderStage(stage));

            lock (_shaderOptionsLock)
            {
                options.Dispose();
            }

            if (scr.Status != Status.Success)
            {
                Logger.Error?.Print(LogClass.Gpu, $"Shader compilation error: {scr.Status} {scr.ErrorMessage}");

                return null;
            }

            var spirvBytes = new Span<byte>((void*)scr.CodePointer, (int)scr.CodeLength);

            byte[] code = new byte[(scr.CodeLength + 3) & ~3];

<<<<<<< HEAD
            spirvBytes.CopyTo(code.AsSpan()[..(int)scr.CodeLength]);
=======
            spirvBytes.CopyTo(code.AsSpan().Slice(0, (int)scr.CodeLength));
>>>>>>> 1ec71635b (sync with main branch)

            return code;
        }

        private static ShaderKind GetShaderCShaderStage(ShaderStage stage)
        {
            switch (stage)
            {
                case ShaderStage.Vertex:
                    return ShaderKind.GlslVertexShader;
                case ShaderStage.Geometry:
                    return ShaderKind.GlslGeometryShader;
                case ShaderStage.TessellationControl:
                    return ShaderKind.GlslTessControlShader;
                case ShaderStage.TessellationEvaluation:
                    return ShaderKind.GlslTessEvaluationShader;
                case ShaderStage.Fragment:
                    return ShaderKind.GlslFragmentShader;
                case ShaderStage.Compute:
                    return ShaderKind.GlslComputeShader;
            }

            Logger.Debug?.Print(LogClass.Gpu, $"Invalid {nameof(ShaderStage)} enum value: {stage}.");

            return ShaderKind.GlslVertexShader;
        }

        public unsafe PipelineShaderStageCreateInfo GetInfo()
        {
<<<<<<< HEAD
            return new PipelineShaderStageCreateInfo
=======
            return new PipelineShaderStageCreateInfo()
>>>>>>> 1ec71635b (sync with main branch)
            {
                SType = StructureType.PipelineShaderStageCreateInfo,
                Stage = _stage,
                Module = _module,
<<<<<<< HEAD
                PName = (byte*)_ptrMainEntryPointName,
=======
                PName = (byte*)_ptrMainEntryPointName
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public void WaitForCompile()
        {
            CompileTask.Wait();
        }

        public unsafe void Dispose()
        {
            if (!_disposed)
            {
                _api.DestroyShaderModule(_device, _module, null);
                _disposed = true;
            }
        }
    }
}
