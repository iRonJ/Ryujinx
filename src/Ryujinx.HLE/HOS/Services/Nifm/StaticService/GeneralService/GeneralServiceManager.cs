<<<<<<< HEAD
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)
using System.Linq;

namespace Ryujinx.HLE.HOS.Services.Nifm.StaticService.GeneralService
{
    static class GeneralServiceManager
    {
<<<<<<< HEAD
        private static readonly List<GeneralServiceDetail> _generalServices = new();
=======
        private static List<GeneralServiceDetail> _generalServices = new List<GeneralServiceDetail>();
>>>>>>> 1ec71635b (sync with main branch)

        public static int Count
        {
            get => _generalServices.Count;
        }

        public static void Add(GeneralServiceDetail generalServiceDetail)
        {
            _generalServices.Add(generalServiceDetail);
        }

        public static void Remove(int index)
        {
            _generalServices.RemoveAt(index);
        }

        public static GeneralServiceDetail Get(int clientId)
        {
            return _generalServices.First(item => item.ClientId == clientId);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
