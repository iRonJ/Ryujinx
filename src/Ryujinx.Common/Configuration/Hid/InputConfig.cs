<<<<<<< HEAD
using System.ComponentModel;
=======
﻿using System.ComponentModel;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Configuration.Hid
{
    [JsonConverter(typeof(JsonInputConfigConverter))]
    public class InputConfig : INotifyPropertyChanged
    {
        /// <summary>
        /// The current version of the input file format
        /// </summary>
        public const int CurrentVersion = 1;

        public int Version { get; set; }

        public InputBackendType Backend { get; set; }

        /// <summary>
        /// Controller id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///  Controller's Type
        /// </summary>
        public ControllerType ControllerType { get; set; }

        /// <summary>
        ///  Player's Index for the controller
        /// </summary>
        public PlayerIndex PlayerIndex { get; set; }
<<<<<<< HEAD

=======
        
>>>>>>> 1ec71635b (sync with main branch)
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
