<<<<<<< HEAD
using Ryujinx.HLE.UI;
=======
using Ryujinx.HLE.Ui;
>>>>>>> 1ec71635b (sync with main branch)
using System.Threading;
using System.Threading.Tasks;

namespace Ryujinx.Headless.SDL2
{
    /// <summary>
    /// Headless text processing class, right now there is no way to forward the input to it.
    /// </summary>
    internal class HeadlessDynamicTextInputHandler : IDynamicTextInputHandler
    {
        private bool _canProcessInput;

        public event DynamicTextChangedHandler TextChangedEvent;
<<<<<<< HEAD
        public event KeyPressedHandler KeyPressedEvent { add { } remove { } }
        public event KeyReleasedHandler KeyReleasedEvent { add { } remove { } }
=======
        public event KeyPressedHandler         KeyPressedEvent  { add { } remove { } }
        public event KeyReleasedHandler        KeyReleasedEvent { add { } remove { } }
>>>>>>> 1ec71635b (sync with main branch)

        public bool TextProcessingEnabled
        {
            get
            {
                return Volatile.Read(ref _canProcessInput);
            }

            set
            {
                Volatile.Write(ref _canProcessInput, value);

                // Launch a task to update the text.
                Task.Run(() =>
                {
                    Thread.Sleep(100);
                    TextChangedEvent?.Invoke("Ryujinx", 7, 7, false);
                });
            }
        }

        public HeadlessDynamicTextInputHandler()
        {
            // Start with input processing turned off so the text box won't accumulate text
            // if the user is playing on the keyboard.
            _canProcessInput = false;
        }

        public void SetText(string text, int cursorBegin) { }

        public void SetText(string text, int cursorBegin, int cursorEnd) { }

        public void Dispose() { }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
