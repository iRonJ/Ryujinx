<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Window
{
    struct WindowPresentCommand : IGALCommand, IGALCommand<WindowPresentCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.WindowPresent;
=======
        public CommandType CommandType => CommandType.WindowPresent;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ThreadedTexture> _texture;
        private ImageCrop _crop;
        private TableRef<Action> _swapBuffersCallback;

        public void Set(TableRef<ThreadedTexture> texture, ImageCrop crop, TableRef<Action> swapBuffersCallback)
        {
            _texture = texture;
            _crop = crop;
            _swapBuffersCallback = swapBuffersCallback;
        }

        public static void Run(ref WindowPresentCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            threaded.SignalFrame();
            renderer.Window.Present(command._texture.Get(threaded)?.Base, command._crop, command._swapBuffersCallback.Get(threaded));
        }
    }
}
