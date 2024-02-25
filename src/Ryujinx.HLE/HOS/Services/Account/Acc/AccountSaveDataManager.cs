<<<<<<< HEAD
using Ryujinx.Common.Configuration;
=======
﻿using Ryujinx.Common.Configuration;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Logging;
using Ryujinx.Common.Utilities;
using Ryujinx.HLE.HOS.Services.Account.Acc.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace Ryujinx.HLE.HOS.Services.Account.Acc
{
    class AccountSaveDataManager
    {
        private readonly string _profilesJsonPath = Path.Join(AppDataManager.BaseDirPath, "system", "Profiles.json");

<<<<<<< HEAD
        private static readonly ProfilesJsonSerializerContext _serializerContext = new(JsonHelper.GetDefaultSerializerOptions());
=======
        private static readonly ProfilesJsonSerializerContext SerializerContext = new(JsonHelper.GetDefaultSerializerOptions());
>>>>>>> 1ec71635b (sync with main branch)

        public UserId LastOpened { get; set; }

        public AccountSaveDataManager(ConcurrentDictionary<string, UserProfile> profiles)
        {
            // TODO: Use 0x8000000000000010 system savedata instead of a JSON file if needed.

            if (File.Exists(_profilesJsonPath))
            {
<<<<<<< HEAD
                try
                {
                    ProfilesJson profilesJson = JsonHelper.DeserializeFromFile(_profilesJsonPath, _serializerContext.ProfilesJson);

                    foreach (var profile in profilesJson.Profiles)
                    {
                        UserProfile addedProfile = new(new UserId(profile.UserId), profile.Name, profile.Image, profile.LastModifiedTimestamp);
=======
                try 
                {
                    ProfilesJson profilesJson = JsonHelper.DeserializeFromFile(_profilesJsonPath, SerializerContext.ProfilesJson);

                    foreach (var profile in profilesJson.Profiles)
                    {
                        UserProfile addedProfile = new UserProfile(new UserId(profile.UserId), profile.Name, profile.Image, profile.LastModifiedTimestamp);
>>>>>>> 1ec71635b (sync with main branch)

                        profiles.AddOrUpdate(profile.UserId, addedProfile, (key, old) => addedProfile);
                    }

                    LastOpened = new UserId(profilesJson.LastOpened);
                }
<<<<<<< HEAD
                catch (Exception ex)
                {
                    Logger.Error?.Print(LogClass.Application, $"Failed to parse {_profilesJsonPath}: {ex.Message} Loading default profile!");
=======
                catch (Exception e) 
                {
                    Logger.Error?.Print(LogClass.Application, $"Failed to parse {_profilesJsonPath}: {e.Message} Loading default profile!");
>>>>>>> 1ec71635b (sync with main branch)

                    LastOpened = AccountManager.DefaultUserId;
                }
            }
            else
            {
                LastOpened = AccountManager.DefaultUserId;
            }
        }

        public void Save(ConcurrentDictionary<string, UserProfile> profiles)
        {
<<<<<<< HEAD
            ProfilesJson profilesJson = new()
            {
                Profiles = new List<UserProfileJson>(),
                LastOpened = LastOpened.ToString(),
=======
            ProfilesJson profilesJson = new ProfilesJson()
            {
                Profiles   = new List<UserProfileJson>(),
                LastOpened = LastOpened.ToString()
>>>>>>> 1ec71635b (sync with main branch)
            };

            foreach (var profile in profiles)
            {
                profilesJson.Profiles.Add(new UserProfileJson()
                {
<<<<<<< HEAD
                    UserId = profile.Value.UserId.ToString(),
                    Name = profile.Value.Name,
                    AccountState = profile.Value.AccountState,
                    OnlinePlayState = profile.Value.OnlinePlayState,
                    LastModifiedTimestamp = profile.Value.LastModifiedTimestamp,
                    Image = profile.Value.Image,
                });
            }

            JsonHelper.SerializeToFile(_profilesJsonPath, profilesJson, _serializerContext.ProfilesJson);
        }
    }
}
=======
                    UserId                = profile.Value.UserId.ToString(),
                    Name                  = profile.Value.Name,
                    AccountState          = profile.Value.AccountState,
                    OnlinePlayState       = profile.Value.OnlinePlayState,
                    LastModifiedTimestamp = profile.Value.LastModifiedTimestamp,
                    Image                 = profile.Value.Image,
                });
            }

            JsonHelper.SerializeToFile(_profilesJsonPath, profilesJson, SerializerContext.ProfilesJson);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
