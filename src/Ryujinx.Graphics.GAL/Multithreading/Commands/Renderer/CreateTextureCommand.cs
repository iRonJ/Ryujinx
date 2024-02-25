<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct CreateTextureCommand : IGALCommand, IGALCommand<CreateTextureCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.CreateTexture;
        private TableRef<ThreadedTexture> _texture;
        private TextureCreateInfo _info;

        public void Set(TableRef<ThreadedTexture> texture, TextureCreateInfo info)
        {
            _texture = texture;
            _info = info;
=======
        public CommandType CommandType => CommandType.CreateTexture;
        private TableRef<ThreadedTexture> _texture;
        private TextureCreateInfo _info;
        private float _scale;

        public void Set(TableRef<ThreadedTexture> texture, TextureCreateInfo info, float scale)
        {
            _texture = texture;
            _info = info;
            _scale = scale;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Run(ref CreateTextureCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
<<<<<<< HEAD
            command._texture.Get(threaded).Base = renderer.CreateTexture(command._info);
=======
            command._texture.Get(threaded).Base = renderer.CreateTexture(command._info, command._scale);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
