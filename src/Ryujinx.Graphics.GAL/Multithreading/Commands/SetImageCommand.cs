<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
using Ryujinx.Graphics.GAL.Multithreading.Resources;
using Ryujinx.Graphics.Shader;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
using Ryujinx.Graphics.GAL.Multithreading.Resources;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetImageCommand : IGALCommand, IGALCommand<SetImageCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetImage;
        private ShaderStage _stage;
=======
        public CommandType CommandType => CommandType.SetImage;
>>>>>>> 1ec71635b (sync with main branch)
        private int _binding;
        private TableRef<ITexture> _texture;
        private Format _imageFormat;

<<<<<<< HEAD
        public void Set(ShaderStage stage, int binding, TableRef<ITexture> texture, Format imageFormat)
        {
            _stage = stage;
=======
        public void Set(int binding, TableRef<ITexture> texture, Format imageFormat)
        {
>>>>>>> 1ec71635b (sync with main branch)
            _binding = binding;
            _texture = texture;
            _imageFormat = imageFormat;
        }

        public static void Run(ref SetImageCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
<<<<<<< HEAD
            renderer.Pipeline.SetImage(command._stage, command._binding, command._texture.GetAs<ThreadedTexture>(threaded)?.Base, command._imageFormat);
=======
            renderer.Pipeline.SetImage(command._binding, command._texture.GetAs<ThreadedTexture>(threaded)?.Base, command._imageFormat);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
