<<<<<<< HEAD
using Ryujinx.UI.App.Common;
=======
using Ryujinx.Ui.App.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;

namespace Ryujinx.Ava.UI.Models.Generic
{
    internal class LastPlayedSortComparer : IComparer<ApplicationData>
    {
        public LastPlayedSortComparer() { }
        public LastPlayedSortComparer(bool isAscending) { IsAscending = isAscending; }

        public bool IsAscending { get; }

        public int Compare(ApplicationData x, ApplicationData y)
        {
<<<<<<< HEAD
            DateTime aValue = DateTime.UnixEpoch, bValue = DateTime.UnixEpoch;

            if (x?.LastPlayed != null)
            {
                aValue = x.LastPlayed.Value;
            }

            if (y?.LastPlayed != null)
            {
                bValue = y.LastPlayed.Value;
            }

            return (IsAscending ? 1 : -1) * DateTime.Compare(aValue, bValue);
        }
    }
}
=======
            var aValue = x.LastPlayed;
            var bValue = y.LastPlayed;

            if (!aValue.HasValue)
            {
                aValue = DateTime.UnixEpoch;
            }

            if (!bValue.HasValue)
            {
                bValue = DateTime.UnixEpoch;
            }

            return (IsAscending ? 1 : -1) * DateTime.Compare(bValue.Value, aValue.Value);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
