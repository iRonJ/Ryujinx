<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Texture
{
    struct TextureCopyToSliceCommand : IGALCommand, IGALCommand<TextureCopyToSliceCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.TextureCopyToSlice;
=======
        public CommandType CommandType => CommandType.TextureCopyToSlice;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ThreadedTexture> _texture;
        private TableRef<ThreadedTexture> _destination;
        private int _srcLayer;
        private int _dstLayer;
        private int _srcLevel;
        private int _dstLevel;

        public void Set(TableRef<ThreadedTexture> texture, TableRef<ThreadedTexture> destination, int srcLayer, int dstLayer, int srcLevel, int dstLevel)
        {
            _texture = texture;
            _destination = destination;
            _srcLayer = srcLayer;
            _dstLayer = dstLayer;
            _srcLevel = srcLevel;
            _dstLevel = dstLevel;
        }

        public static void Run(ref TextureCopyToSliceCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            ThreadedTexture source = command._texture.Get(threaded);
            source.Base.CopyTo(command._destination.Get(threaded).Base, command._srcLayer, command._dstLayer, command._srcLevel, command._dstLevel);
        }
    }
}
