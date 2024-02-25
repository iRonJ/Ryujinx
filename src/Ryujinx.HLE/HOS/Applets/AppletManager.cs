<<<<<<< HEAD
using Ryujinx.HLE.HOS.Applets.Browser;
=======
﻿using Ryujinx.HLE.HOS.Applets.Browser;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Applets.Error;
using Ryujinx.HLE.HOS.Services.Am.AppletAE;
using System;
using System.Collections.Generic;

namespace Ryujinx.HLE.HOS.Applets
{
    static class AppletManager
    {
<<<<<<< HEAD
        private static readonly Dictionary<AppletId, Type> _appletMapping;
=======
        private static Dictionary<AppletId, Type> _appletMapping;
>>>>>>> 1ec71635b (sync with main branch)

        static AppletManager()
        {
            _appletMapping = new Dictionary<AppletId, Type>
            {
                { AppletId.Error,            typeof(ErrorApplet)            },
                { AppletId.PlayerSelect,     typeof(PlayerSelectApplet)     },
                { AppletId.Controller,       typeof(ControllerApplet)       },
                { AppletId.SoftwareKeyboard, typeof(SoftwareKeyboardApplet) },
                { AppletId.LibAppletWeb,     typeof(BrowserApplet)          },
                { AppletId.LibAppletShop,    typeof(BrowserApplet)          },
<<<<<<< HEAD
                { AppletId.LibAppletOff,     typeof(BrowserApplet)          },
=======
                { AppletId.LibAppletOff,     typeof(BrowserApplet)          }
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static IApplet Create(AppletId applet, Horizon system)
        {
            if (_appletMapping.TryGetValue(applet, out Type appletClass))
            {
                return (IApplet)Activator.CreateInstance(appletClass, system);
            }

            throw new NotImplementedException($"{applet} applet is not implemented.");
        }
    }
}
