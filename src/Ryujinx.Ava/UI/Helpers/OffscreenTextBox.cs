using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Ryujinx.Ava.UI.Helpers
{
    public class OffscreenTextBox : TextBox
    {
<<<<<<< HEAD
        public static RoutedEvent<KeyEventArgs> GetKeyDownRoutedEvent()
=======
        public RoutedEvent<KeyEventArgs> GetKeyDownRoutedEvent()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return KeyDownEvent;
        }

<<<<<<< HEAD
        public static RoutedEvent<KeyEventArgs> GetKeyUpRoutedEvent()
=======
        public RoutedEvent<KeyEventArgs> GetKeyUpRoutedEvent()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return KeyUpEvent;
        }

        public void SendKeyDownEvent(KeyEventArgs keyEvent)
        {
            OnKeyDown(keyEvent);
        }

        public void SendKeyUpEvent(KeyEventArgs keyEvent)
        {
            OnKeyUp(keyEvent);
        }

        public void SendText(string text)
        {
<<<<<<< HEAD
            OnTextInput(new TextInputEventArgs
            {
                Text = text,
                Source = this,
                RoutedEvent = TextInputEvent,
            });
        }
    }
}
=======
            OnTextInput(new TextInputEventArgs()
            {
                Text = text,
                Device = KeyboardDevice.Instance,
                Source = this,
                RoutedEvent = TextInputEvent
            });
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
