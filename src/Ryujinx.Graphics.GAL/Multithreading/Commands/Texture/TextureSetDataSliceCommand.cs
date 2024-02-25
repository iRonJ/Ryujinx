<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Texture
{
    struct TextureSetDataSliceCommand : IGALCommand, IGALCommand<TextureSetDataSliceCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.TextureSetDataSlice;
=======
        public CommandType CommandType => CommandType.TextureSetDataSlice;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ThreadedTexture> _texture;
        private TableRef<byte[]> _data;
        private int _layer;
        private int _level;

        public void Set(TableRef<ThreadedTexture> texture, TableRef<byte[]> data, int layer, int level)
        {
            _texture = texture;
            _data = data;
            _layer = layer;
            _level = level;
        }

        public static void Run(ref TextureSetDataSliceCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            ThreadedTexture texture = command._texture.Get(threaded);
            texture.Base.SetData(new ReadOnlySpan<byte>(command._data.Get(threaded)), command._layer, command._level);
        }
    }
}
