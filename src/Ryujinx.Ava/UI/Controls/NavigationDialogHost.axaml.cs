using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using Avalonia.Threading;
<<<<<<< HEAD
=======
using FluentAvalonia.Core;
>>>>>>> 1ec71635b (sync with main branch)
using FluentAvalonia.UI.Controls;
using LibHac;
using LibHac.Common;
using LibHac.Fs;
using LibHac.Fs.Shim;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Helpers;
<<<<<<< HEAD
=======
using Ryujinx.Ava.UI.Models;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Ava.UI.Views.User;
using Ryujinx.HLE.FileSystem;
using Ryujinx.HLE.HOS.Services.Account.Acc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using UserId = Ryujinx.HLE.HOS.Services.Account.Acc.UserId;
=======
>>>>>>> 1ec71635b (sync with main branch)
using UserProfile = Ryujinx.Ava.UI.Models.UserProfile;

namespace Ryujinx.Ava.UI.Controls
{
    public partial class NavigationDialogHost : UserControl
    {
        public AccountManager AccountManager { get; }
        public ContentManager ContentManager { get; }
        public VirtualFileSystem VirtualFileSystem { get; }
        public HorizonClient HorizonClient { get; }
        public UserProfileViewModel ViewModel { get; set; }

        public NavigationDialogHost()
        {
            InitializeComponent();
        }

        public NavigationDialogHost(AccountManager accountManager, ContentManager contentManager,
            VirtualFileSystem virtualFileSystem, HorizonClient horizonClient)
        {
            AccountManager = accountManager;
            ContentManager = contentManager;
            VirtualFileSystem = virtualFileSystem;
            HorizonClient = horizonClient;
            ViewModel = new UserProfileViewModel();
            LoadProfiles();

            if (contentManager.GetCurrentFirmwareVersion() != null)
            {
                Task.Run(() =>
                {
                    UserFirmwareAvatarSelectorViewModel.PreloadAvatars(contentManager, virtualFileSystem);
                });
            }
            InitializeComponent();
        }

<<<<<<< HEAD
        public void GoBack()
=======
        public void GoBack(object parameter = null)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (ContentFrame.BackStack.Count > 0)
            {
                ContentFrame.GoBack();
            }

            LoadProfiles();
        }

        public void Navigate(Type sourcePageType, object parameter)
        {
            ContentFrame.Navigate(sourcePageType, parameter);
        }

        public static async Task Show(AccountManager ownerAccountManager, ContentManager ownerContentManager,
            VirtualFileSystem ownerVirtualFileSystem, HorizonClient ownerHorizonClient)
        {
            var content = new NavigationDialogHost(ownerAccountManager, ownerContentManager, ownerVirtualFileSystem, ownerHorizonClient);
<<<<<<< HEAD
            ContentDialog contentDialog = new()
=======
            ContentDialog contentDialog = new ContentDialog
>>>>>>> 1ec71635b (sync with main branch)
            {
                Title = LocaleManager.Instance[LocaleKeys.UserProfileWindowTitle],
                PrimaryButtonText = "",
                SecondaryButtonText = "",
                CloseButtonText = "",
                Content = content,
<<<<<<< HEAD
                Padding = new Thickness(0),
=======
                Padding = new Thickness(0)
>>>>>>> 1ec71635b (sync with main branch)
            };

            contentDialog.Closed += (sender, args) =>
            {
                content.ViewModel.Dispose();
            };

            Style footer = new(x => x.Name("DialogSpace").Child().OfType<Border>());
            footer.Setters.Add(new Setter(IsVisibleProperty, false));

            contentDialog.Styles.Add(footer);

            await contentDialog.ShowAsync();
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);

            Navigate(typeof(UserSelectorViews), this);
        }

        public void LoadProfiles()
        {
            ViewModel.Profiles.Clear();
            ViewModel.LostProfiles.Clear();

            var profiles = AccountManager.GetAllUsers().OrderBy(x => x.Name);

            foreach (var profile in profiles)
            {
                ViewModel.Profiles.Add(new UserProfile(profile, this));
            }

            var saveDataFilter = SaveDataFilter.Make(programId: default, saveType: SaveDataType.Account, default, saveDataId: default, index: default);

            using var saveDataIterator = new UniqueRef<SaveDataIterator>();

            HorizonClient.Fs.OpenSaveDataIterator(ref saveDataIterator.Ref, SaveDataSpaceId.User, in saveDataFilter).ThrowIfFailure();

            Span<SaveDataInfo> saveDataInfo = stackalloc SaveDataInfo[10];

<<<<<<< HEAD
            HashSet<UserId> lostAccounts = new();
=======
            HashSet<HLE.HOS.Services.Account.Acc.UserId> lostAccounts = new();
>>>>>>> 1ec71635b (sync with main branch)

            while (true)
            {
                saveDataIterator.Get.ReadSaveDataInfo(out long readCount, saveDataInfo).ThrowIfFailure();

                if (readCount == 0)
                {
                    break;
                }

                for (int i = 0; i < readCount; i++)
                {
                    var save = saveDataInfo[i];
<<<<<<< HEAD
                    var id = new UserId((long)save.UserId.Id.Low, (long)save.UserId.Id.High);
                    if (ViewModel.Profiles.Cast<UserProfile>().FirstOrDefault(x => x.UserId == id) == null)
=======
                    var id = new HLE.HOS.Services.Account.Acc.UserId((long)save.UserId.Id.Low, (long)save.UserId.Id.High);
                    if (ViewModel.Profiles.Cast<UserProfile>().FirstOrDefault( x=> x.UserId == id) == null)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        lostAccounts.Add(id);
                    }
                }
            }

<<<<<<< HEAD
            foreach (var account in lostAccounts)
=======
            foreach(var account in lostAccounts)
>>>>>>> 1ec71635b (sync with main branch)
            {
                ViewModel.LostProfiles.Add(new UserProfile(new HLE.HOS.Services.Account.Acc.UserProfile(account, "", null), this));
            }

            ViewModel.Profiles.Add(new BaseModel());
        }

        public async void DeleteUser(UserProfile userProfile)
        {
            var lastUserId = AccountManager.LastOpenedUser.UserId;

            if (userProfile.UserId == lastUserId)
            {
                // If we are deleting the currently open profile, then we must open something else before deleting.
                var profile = ViewModel.Profiles.Cast<UserProfile>().FirstOrDefault(x => x.UserId != lastUserId);

                if (profile == null)
                {
<<<<<<< HEAD
                    static async void Action()
=======
                    async void Action()
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance[LocaleKeys.DialogUserProfileDeletionWarningMessage]);
                    }

                    Dispatcher.UIThread.Post(Action);

                    return;
                }

                AccountManager.OpenUser(profile.UserId);
            }

            var result = await ContentDialogHelper.CreateConfirmationDialog(
                LocaleManager.Instance[LocaleKeys.DialogUserProfileDeletionConfirmMessage],
                "",
                LocaleManager.Instance[LocaleKeys.InputDialogYes],
                LocaleManager.Instance[LocaleKeys.InputDialogNo],
                "");

            if (result == UserResult.Yes)
            {
                GoBack();
                AccountManager.DeleteUser(userProfile.UserId);
            }

            LoadProfiles();
        }

        public void AddUser()
        {
            Navigate(typeof(UserEditorView), (this, (UserProfile)null, true));
        }

        public void EditUser(UserProfile userProfile)
        {
            Navigate(typeof(UserEditorView), (this, userProfile, false));
        }

        public void RecoverLostAccounts()
        {
            Navigate(typeof(UserRecovererView), this);
        }

        public void ManageSaves()
        {
            Navigate(typeof(UserSaveManagerView), (this, AccountManager, HorizonClient, VirtualFileSystem));
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
