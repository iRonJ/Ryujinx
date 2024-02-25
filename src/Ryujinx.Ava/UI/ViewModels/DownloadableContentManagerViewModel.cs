using Avalonia.Collections;
<<<<<<< HEAD
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
=======
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Threading;
using DynamicData;
using LibHac.Common;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.Tools.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.Models;
using Ryujinx.Common.Configuration;
using Ryujinx.Common.Logging;
using Ryujinx.Common.Utilities;
using Ryujinx.HLE.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Application = Avalonia.Application;
=======
>>>>>>> 1ec71635b (sync with main branch)
using Path = System.IO.Path;

namespace Ryujinx.Ava.UI.ViewModels
{
    public class DownloadableContentManagerViewModel : BaseModel
    {
        private readonly List<DownloadableContentContainer> _downloadableContentContainerList;
<<<<<<< HEAD
        private readonly string _downloadableContentJsonPath;

        private readonly VirtualFileSystem _virtualFileSystem;
=======
        private readonly string                             _downloadableContentJsonPath;

        private VirtualFileSystem                      _virtualFileSystem;
>>>>>>> 1ec71635b (sync with main branch)
        private AvaloniaList<DownloadableContentModel> _downloadableContents = new();
        private AvaloniaList<DownloadableContentModel> _views = new();
        private AvaloniaList<DownloadableContentModel> _selectedDownloadableContents = new();

        private string _search;
<<<<<<< HEAD
        private readonly ulong _titleId;
        private readonly IStorageProvider _storageProvider;

        private static readonly DownloadableContentJsonSerializerContext _serializerContext = new(JsonHelper.GetDefaultSerializerOptions());
=======
        private ulong _titleId;
        private string _titleName;

        private static readonly DownloadableContentJsonSerializerContext SerializerContext = new(JsonHelper.GetDefaultSerializerOptions());
>>>>>>> 1ec71635b (sync with main branch)

        public AvaloniaList<DownloadableContentModel> DownloadableContents
        {
            get => _downloadableContents;
            set
            {
                _downloadableContents = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UpdateCount));
                Sort();
            }
        }

        public AvaloniaList<DownloadableContentModel> Views
        {
            get => _views;
            set
            {
                _views = value;
                OnPropertyChanged();
            }
        }

        public AvaloniaList<DownloadableContentModel> SelectedDownloadableContents
        {
            get => _selectedDownloadableContents;
            set
            {
                _selectedDownloadableContents = value;
                OnPropertyChanged();
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged();
                Sort();
            }
        }

        public string UpdateCount
        {
            get => string.Format(LocaleManager.Instance[LocaleKeys.DlcWindowHeading], DownloadableContents.Count);
        }

<<<<<<< HEAD
        public DownloadableContentManagerViewModel(VirtualFileSystem virtualFileSystem, ulong titleId)
        {
            _virtualFileSystem = virtualFileSystem;

            _titleId = titleId;

            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                _storageProvider = desktop.MainWindow.StorageProvider;
            }
=======
        public DownloadableContentManagerViewModel(VirtualFileSystem virtualFileSystem, ulong titleId, string titleName)
        {
            _virtualFileSystem = virtualFileSystem;

            _titleId   = titleId;
            _titleName = titleName;
>>>>>>> 1ec71635b (sync with main branch)

            _downloadableContentJsonPath = Path.Combine(AppDataManager.GamesDirPath, titleId.ToString("x16"), "dlc.json");

            try
            {
<<<<<<< HEAD
                _downloadableContentContainerList = JsonHelper.DeserializeFromFile(_downloadableContentJsonPath, _serializerContext.ListDownloadableContentContainer);
=======
                _downloadableContentContainerList = JsonHelper.DeserializeFromFile(_downloadableContentJsonPath, SerializerContext.ListDownloadableContentContainer);
>>>>>>> 1ec71635b (sync with main branch)
            }
            catch
            {
                Logger.Error?.Print(LogClass.Configuration, "Downloadable Content JSON failed to deserialize.");
                _downloadableContentContainerList = new List<DownloadableContentContainer>();
            }

            LoadDownloadableContents();
        }

        private void LoadDownloadableContents()
        {
            foreach (DownloadableContentContainer downloadableContentContainer in _downloadableContentContainerList)
            {
                if (File.Exists(downloadableContentContainer.ContainerPath))
                {
                    using FileStream containerFile = File.OpenRead(downloadableContentContainer.ContainerPath);

<<<<<<< HEAD
                    PartitionFileSystem partitionFileSystem = new();
                    partitionFileSystem.Initialize(containerFile.AsStorage()).ThrowIfFailure();
=======
                    PartitionFileSystem partitionFileSystem = new(containerFile.AsStorage());
>>>>>>> 1ec71635b (sync with main branch)

                    _virtualFileSystem.ImportTickets(partitionFileSystem);

                    foreach (DownloadableContentNca downloadableContentNca in downloadableContentContainer.DownloadableContentNcaList)
                    {
                        using UniqueRef<IFile> ncaFile = new();

                        partitionFileSystem.OpenFile(ref ncaFile.Ref, downloadableContentNca.FullPath.ToU8Span(), OpenMode.Read).ThrowIfFailure();

                        Nca nca = TryOpenNca(ncaFile.Get.AsStorage(), downloadableContentContainer.ContainerPath);
                        if (nca != null)
<<<<<<< HEAD
                        {
=======
                        {   
>>>>>>> 1ec71635b (sync with main branch)
                            var content = new DownloadableContentModel(nca.Header.TitleId.ToString("X16"),
                                downloadableContentContainer.ContainerPath,
                                downloadableContentNca.FullPath,
                                downloadableContentNca.Enabled);

                            DownloadableContents.Add(content);

                            if (content.Enabled)
                            {
                                SelectedDownloadableContents.Add(content);
                            }

                            OnPropertyChanged(nameof(UpdateCount));
                        }
                    }
                }
            }

            // NOTE: Save the list again to remove leftovers.
            Save();
            Sort();
        }

        public void Sort()
        {
            DownloadableContents.AsObservableChangeSet()
                .Filter(Filter)
                .Bind(out var view).AsObservableList();

            _views.Clear();
            _views.AddRange(view);
            OnPropertyChanged(nameof(Views));
        }

        private bool Filter(object arg)
        {
            if (arg is DownloadableContentModel content)
            {
                return string.IsNullOrWhiteSpace(_search) || content.FileName.ToLower().Contains(_search.ToLower()) || content.TitleId.ToLower().Contains(_search.ToLower());
            }

            return false;
        }

        private Nca TryOpenNca(IStorage ncaStorage, string containerPath)
        {
            try
            {
                return new Nca(_virtualFileSystem.KeySet, ncaStorage);
            }
            catch (Exception ex)
            {
                Dispatcher.UIThread.InvokeAsync(async () =>
                {
<<<<<<< HEAD
                    await ContentDialogHelper.CreateErrorDialog(string.Format(LocaleManager.Instance[LocaleKeys.DialogLoadFileErrorMessage], ex.Message, containerPath));
=======
                    await ContentDialogHelper.CreateErrorDialog(string.Format(LocaleManager.Instance[LocaleKeys.DialogLoadNcaErrorMessage], ex.Message, containerPath));
>>>>>>> 1ec71635b (sync with main branch)
                });
            }

            return null;
        }

        public async void Add()
        {
<<<<<<< HEAD
            var result = await _storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = LocaleManager.Instance[LocaleKeys.SelectDlcDialogTitle],
                AllowMultiple = true,
                FileTypeFilter = new List<FilePickerFileType>
                {
                    new("NSP")
                    {
                        Patterns = new[] { "*.nsp" },
                        AppleUniformTypeIdentifiers = new[] { "com.ryujinx.nsp" },
                        MimeTypes = new[] { "application/x-nx-nsp" },
                    },
                },
            });

            foreach (var file in result)
            {
                await AddDownloadableContent(file.Path.LocalPath);
=======
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Title         = LocaleManager.Instance[LocaleKeys.SelectDlcDialogTitle],
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
                        await AddDownloadableContent(file);
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        private async Task AddDownloadableContent(string path)
        {
            if (!File.Exists(path) || DownloadableContents.FirstOrDefault(x => x.ContainerPath == path) != null)
            {
                return;
            }

            using FileStream containerFile = File.OpenRead(path);

<<<<<<< HEAD
            PartitionFileSystem partitionFileSystem = new();
            partitionFileSystem.Initialize(containerFile.AsStorage()).ThrowIfFailure();
            bool containsDownloadableContent = false;
=======
            PartitionFileSystem partitionFileSystem         = new(containerFile.AsStorage());
            bool                containsDownloadableContent = false;
>>>>>>> 1ec71635b (sync with main branch)

            _virtualFileSystem.ImportTickets(partitionFileSystem);

            foreach (DirectoryEntryEx fileEntry in partitionFileSystem.EnumerateEntries("/", "*.nca"))
            {
                using var ncaFile = new UniqueRef<IFile>();

                partitionFileSystem.OpenFile(ref ncaFile.Ref, fileEntry.FullPath.ToU8Span(), OpenMode.Read).ThrowIfFailure();

                Nca nca = TryOpenNca(ncaFile.Get.AsStorage(), path);
                if (nca == null)
                {
                    continue;
                }

                if (nca.Header.ContentType == NcaContentType.PublicData)
                {
                    if ((nca.Header.TitleId & 0xFFFFFFFFFFFFE000) != _titleId)
                    {
                        break;
                    }

                    var content = new DownloadableContentModel(nca.Header.TitleId.ToString("X16"), path, fileEntry.FullPath, true);
                    DownloadableContents.Add(content);
                    SelectedDownloadableContents.Add(content);

                    OnPropertyChanged(nameof(UpdateCount));
                    Sort();

                    containsDownloadableContent = true;
                }
            }

            if (!containsDownloadableContent)
            {
                await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance[LocaleKeys.DialogDlcNoDlcErrorMessage]);
            }
        }

        public void Remove(DownloadableContentModel model)
        {
            DownloadableContents.Remove(model);
            OnPropertyChanged(nameof(UpdateCount));
            Sort();
        }

        public void RemoveAll()
        {
            DownloadableContents.Clear();
            OnPropertyChanged(nameof(UpdateCount));
            Sort();
        }

        public void EnableAll()
        {
            SelectedDownloadableContents = new(DownloadableContents);
        }

        public void DisableAll()
        {
            SelectedDownloadableContents.Clear();
        }

        public void Save()
        {
            _downloadableContentContainerList.Clear();

            DownloadableContentContainer container = default;

            foreach (DownloadableContentModel downloadableContent in DownloadableContents)
            {
                if (container.ContainerPath != downloadableContent.ContainerPath)
                {
                    if (!string.IsNullOrWhiteSpace(container.ContainerPath))
                    {
                        _downloadableContentContainerList.Add(container);
                    }

                    container = new DownloadableContentContainer
                    {
<<<<<<< HEAD
                        ContainerPath = downloadableContent.ContainerPath,
                        DownloadableContentNcaList = new List<DownloadableContentNca>(),
=======
                        ContainerPath              = downloadableContent.ContainerPath,
                        DownloadableContentNcaList = new List<DownloadableContentNca>()
>>>>>>> 1ec71635b (sync with main branch)
                    };
                }

                container.DownloadableContentNcaList.Add(new DownloadableContentNca
                {
<<<<<<< HEAD
                    Enabled = downloadableContent.Enabled,
                    TitleId = Convert.ToUInt64(downloadableContent.TitleId, 16),
                    FullPath = downloadableContent.FullPath,
=======
                    Enabled  = downloadableContent.Enabled,
                    TitleId  = Convert.ToUInt64(downloadableContent.TitleId, 16),
                    FullPath = downloadableContent.FullPath
>>>>>>> 1ec71635b (sync with main branch)
                });
            }

            if (!string.IsNullOrWhiteSpace(container.ContainerPath))
            {
                _downloadableContentContainerList.Add(container);
            }

<<<<<<< HEAD
            JsonHelper.SerializeToFile(_downloadableContentJsonPath, _downloadableContentContainerList, _serializerContext.ListDownloadableContentContainer);
        }

    }
}
=======
            JsonHelper.SerializeToFile(_downloadableContentJsonPath, _downloadableContentContainerList, SerializerContext.ListDownloadableContentContainer);
        }

    }
}
>>>>>>> 1ec71635b (sync with main branch)
