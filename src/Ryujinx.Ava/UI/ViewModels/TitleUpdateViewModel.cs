<<<<<<< HEAD
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
=======
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Threading;
using LibHac.Common;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.Ns;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.Models;
using Ryujinx.Common.Configuration;
using Ryujinx.Common.Logging;
using Ryujinx.Common.Utilities;
using Ryujinx.HLE.FileSystem;
<<<<<<< HEAD
using Ryujinx.UI.App.Common;
=======
using Ryujinx.HLE.HOS;
using Ryujinx.Ui.App.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
>>>>>>> 1ec71635b (sync with main branch)
using Path = System.IO.Path;
using SpanHelpers = LibHac.Common.SpanHelpers;

namespace Ryujinx.Ava.UI.ViewModels
{
    public class TitleUpdateViewModel : BaseModel
    {
<<<<<<< HEAD
        public TitleUpdateMetadata TitleUpdateWindowData;
        public readonly string TitleUpdateJsonPath;
        private VirtualFileSystem VirtualFileSystem { get; }
        private ulong TitleId { get; }
=======
        public TitleUpdateMetadata _titleUpdateWindowData;
        public readonly string     _titleUpdateJsonPath;
        private VirtualFileSystem  _virtualFileSystem { get; }
        private ulong              _titleId           { get; }
        private string             _titleName         { get; }
>>>>>>> 1ec71635b (sync with main branch)

        private AvaloniaList<TitleUpdateModel> _titleUpdates = new();
        private AvaloniaList<object> _views = new();
        private object _selectedUpdate;

<<<<<<< HEAD
        private static readonly TitleUpdateMetadataJsonSerializerContext _serializerContext = new(JsonHelper.GetDefaultSerializerOptions());
=======
        private static readonly TitleUpdateMetadataJsonSerializerContext SerializerContext = new(JsonHelper.GetDefaultSerializerOptions());
>>>>>>> 1ec71635b (sync with main branch)

        public AvaloniaList<TitleUpdateModel> TitleUpdates
        {
            get => _titleUpdates;
            set
            {
                _titleUpdates = value;
                OnPropertyChanged();
            }
        }

        public AvaloniaList<object> Views
        {
            get => _views;
            set
            {
                _views = value;
                OnPropertyChanged();
            }
        }

        public object SelectedUpdate
        {
            get => _selectedUpdate;
            set
            {
                _selectedUpdate = value;
                OnPropertyChanged();
            }
        }

<<<<<<< HEAD
        public IStorageProvider StorageProvider;

        public TitleUpdateViewModel(VirtualFileSystem virtualFileSystem, ulong titleId)
        {
            VirtualFileSystem = virtualFileSystem;

            TitleId = titleId;

            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                StorageProvider = desktop.MainWindow.StorageProvider;
            }

            TitleUpdateJsonPath = Path.Combine(AppDataManager.GamesDirPath, titleId.ToString("x16"), "updates.json");

            try
            {
                TitleUpdateWindowData = JsonHelper.DeserializeFromFile(TitleUpdateJsonPath, _serializerContext.TitleUpdateMetadata);
            }
            catch
            {
                Logger.Warning?.Print(LogClass.Application, $"Failed to deserialize title update data for {TitleId} at {TitleUpdateJsonPath}");

                TitleUpdateWindowData = new TitleUpdateMetadata
                {
                    Selected = "",
                    Paths = new List<string>(),
=======
        public TitleUpdateViewModel(VirtualFileSystem virtualFileSystem, ulong titleId, string titleName)
        {
            _virtualFileSystem = virtualFileSystem;

            _titleId   = titleId;
            _titleName = titleName;

            _titleUpdateJsonPath = Path.Combine(AppDataManager.GamesDirPath, titleId.ToString("x16"), "updates.json");

            try
            {
                _titleUpdateWindowData = JsonHelper.DeserializeFromFile(_titleUpdateJsonPath, SerializerContext.TitleUpdateMetadata);
            }
            catch
            {
                Logger.Warning?.Print(LogClass.Application, $"Failed to deserialize title update data for {_titleId} at {_titleUpdateJsonPath}");

                _titleUpdateWindowData = new TitleUpdateMetadata
                {
                    Selected = "",
                    Paths    = new List<string>()
>>>>>>> 1ec71635b (sync with main branch)
                };

                Save();
            }

            LoadUpdates();
        }

        private void LoadUpdates()
        {
<<<<<<< HEAD
            foreach (string path in TitleUpdateWindowData.Paths)
=======
            foreach (string path in _titleUpdateWindowData.Paths)
>>>>>>> 1ec71635b (sync with main branch)
            {
                AddUpdate(path);
            }

<<<<<<< HEAD
            TitleUpdateModel selected = TitleUpdates.FirstOrDefault(x => x.Path == TitleUpdateWindowData.Selected, null);
=======
            TitleUpdateModel selected = TitleUpdates.FirstOrDefault(x => x.Path == _titleUpdateWindowData.Selected, null);
>>>>>>> 1ec71635b (sync with main branch)

            SelectedUpdate = selected;

            // NOTE: Save the list again to remove leftovers.
            Save();
            SortUpdates();
        }

        public void SortUpdates()
        {
            var list = TitleUpdates.ToList();

            list.Sort((first, second) =>
            {
                if (string.IsNullOrEmpty(first.Control.DisplayVersionString.ToString()))
                {
                    return -1;
                }
<<<<<<< HEAD

                if (string.IsNullOrEmpty(second.Control.DisplayVersionString.ToString()))
=======
                else if (string.IsNullOrEmpty(second.Control.DisplayVersionString.ToString()))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    return 1;
                }

                return Version.Parse(first.Control.DisplayVersionString.ToString()).CompareTo(Version.Parse(second.Control.DisplayVersionString.ToString())) * -1;
            });

            Views.Clear();
            Views.Add(new BaseModel());
            Views.AddRange(list);

            if (SelectedUpdate == null)
            {
                SelectedUpdate = Views[0];
            }
            else if (!TitleUpdates.Contains(SelectedUpdate))
            {
                if (Views.Count > 1)
                {
                    SelectedUpdate = Views[1];
                }
                else
                {
                    SelectedUpdate = Views[0];
                }
            }
        }

        private void AddUpdate(string path)
        {
            if (File.Exists(path) && TitleUpdates.All(x => x.Path != path))
            {
                using FileStream file = new(path, FileMode.Open, FileAccess.Read);

                try
                {
<<<<<<< HEAD
                    var pfs = new PartitionFileSystem();
                    pfs.Initialize(file.AsStorage()).ThrowIfFailure();
                    (Nca patchNca, Nca controlNca) = ApplicationLibrary.GetGameUpdateDataFromPartition(VirtualFileSystem, pfs, TitleId.ToString("x16"), 0);
=======
                    (Nca patchNca, Nca controlNca) = ApplicationLibrary.GetGameUpdateDataFromPartition(_virtualFileSystem, new PartitionFileSystem(file.AsStorage()), _titleId.ToString("x16"), 0);
>>>>>>> 1ec71635b (sync with main branch)

                    if (controlNca != null && patchNca != null)
                    {
                        ApplicationControlProperty controlData = new();

                        using UniqueRef<IFile> nacpFile = new();

                        controlNca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None).OpenFile(ref nacpFile.Ref, "/control.nacp".ToU8Span(), OpenMode.Read).ThrowIfFailure();
                        nacpFile.Get.Read(out _, 0, SpanHelpers.AsByteSpan(ref controlData), ReadOption.None).ThrowIfFailure();

                        TitleUpdates.Add(new TitleUpdateModel(controlData, path));
                    }
                    else
                    {
<<<<<<< HEAD
                        Dispatcher.UIThread.InvokeAsync(() => ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance[LocaleKeys.DialogUpdateAddUpdateErrorMessage]));
=======
                        Dispatcher.UIThread.Post(async () =>
                        {
                            await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance[LocaleKeys.DialogUpdateAddUpdateErrorMessage]);
                        });
>>>>>>> 1ec71635b (sync with main branch)
                    }
                }
                catch (Exception ex)
                {
<<<<<<< HEAD
                    Dispatcher.UIThread.InvokeAsync(() => ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogLoadFileErrorMessage, ex.Message, path)));
=======
                    Dispatcher.UIThread.Post(async () =>
                    {
                        await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogLoadNcaErrorMessage, ex.Message, path));
                    });
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

        public void RemoveUpdate(TitleUpdateModel update)
        {
            TitleUpdates.Remove(update);

            SortUpdates();
        }

<<<<<<< HEAD
        public async Task Add()
        {
            var result = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                AllowMultiple = true,
                FileTypeFilter = new List<FilePickerFileType>
                {
                    new(LocaleManager.Instance[LocaleKeys.AllSupportedFormats])
                    {
                        Patterns = new[] { "*.nsp" },
                        AppleUniformTypeIdentifiers = new[] { "com.ryujinx.nsp" },
                        MimeTypes = new[] { "application/x-nx-nsp" },
                    },
                },
            });

            foreach (var file in result)
            {
                AddUpdate(file.Path.LocalPath);
=======
        public async void Add()
        {
            OpenFileDialog dialog = new()
            {
                Title         = LocaleManager.Instance[LocaleKeys.SelectUpdateDialogTitle],
                AllowMultiple = true
            };

            dialog.Filters.Add(new FileDialogFilter
            {
                Name       = "NSP",
                Extensions = { "nsp" }
            });

            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                string[] files = await dialog.ShowAsync(desktop.MainWindow);

                if (files != null)
                {
                    foreach (string file in files)
                    {
                        AddUpdate(file);
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)
            }

            SortUpdates();
        }

        public void Save()
        {
<<<<<<< HEAD
            TitleUpdateWindowData.Paths.Clear();
            TitleUpdateWindowData.Selected = "";

            foreach (TitleUpdateModel update in TitleUpdates)
            {
                TitleUpdateWindowData.Paths.Add(update.Path);

                if (update == SelectedUpdate)
                {
                    TitleUpdateWindowData.Selected = update.Path;
                }
            }

            JsonHelper.SerializeToFile(TitleUpdateJsonPath, TitleUpdateWindowData, _serializerContext.TitleUpdateMetadata);
        }
    }
}
=======
            _titleUpdateWindowData.Paths.Clear();
            _titleUpdateWindowData.Selected = "";

            foreach (TitleUpdateModel update in TitleUpdates)
            {
                _titleUpdateWindowData.Paths.Add(update.Path);

                if (update == SelectedUpdate)
                {
                    _titleUpdateWindowData.Selected = update.Path;
                }
            }

            JsonHelper.SerializeToFile(_titleUpdateJsonPath, _titleUpdateWindowData, SerializerContext.TitleUpdateMetadata);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
