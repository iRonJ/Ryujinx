<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Account.Acc
{
    public class UserProfile
    {
        public UserId UserId { get; }

        public long LastModifiedTimestamp { get; set; }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;

                UpdateLastModifiedTimestamp();
            }
        }

        private byte[] _image;

        public byte[] Image
        {
            get => _image;
            set
            {
                _image = value;

                UpdateLastModifiedTimestamp();
            }
        }

        private AccountState _accountState;

        public AccountState AccountState
        {
            get => _accountState;
            set
            {
                _accountState = value;

                UpdateLastModifiedTimestamp();
            }
        }

<<<<<<< HEAD
        private AccountState _onlinePlayState;
=======
        public AccountState _onlinePlayState;
>>>>>>> 1ec71635b (sync with main branch)

        public AccountState OnlinePlayState
        {
            get => _onlinePlayState;
            set
            {
                _onlinePlayState = value;

                UpdateLastModifiedTimestamp();
            }
        }

        public UserProfile(UserId userId, string name, byte[] image, long lastModifiedTimestamp = 0)
        {
            UserId = userId;
<<<<<<< HEAD
            Name = name;
            Image = image;

            AccountState = AccountState.Closed;
=======
            Name   = name;
            Image  = image;

            AccountState    = AccountState.Closed;
>>>>>>> 1ec71635b (sync with main branch)
            OnlinePlayState = AccountState.Closed;

            if (lastModifiedTimestamp != 0)
            {
                LastModifiedTimestamp = lastModifiedTimestamp;
            }
            else
            {
                UpdateLastModifiedTimestamp();
            }
        }

        private void UpdateLastModifiedTimestamp()
        {
            LastModifiedTimestamp = (long)(DateTime.Now - DateTime.UnixEpoch).TotalSeconds;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
