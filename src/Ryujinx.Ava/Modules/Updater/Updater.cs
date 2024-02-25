using Avalonia.Controls;
using Avalonia.Threading;
using FluentAvalonia.UI.Controls;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using Ryujinx.Ava;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Common;
using Ryujinx.Common.Logging;
using Ryujinx.Common.Utilities;
<<<<<<< HEAD
using Ryujinx.UI.Common.Helper;
using Ryujinx.UI.Common.Models.Github;
=======
using Ryujinx.Ui.Common.Helper;
using Ryujinx.Ui.Common.Models.Github;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ryujinx.Modules
{
    internal static class Updater
    {
<<<<<<< HEAD
        private const string GitHubApiUrl = "https://api.github.com";
        private static readonly GithubReleasesJsonSerializerContext _serializerContext = new(JsonHelper.GetDefaultSerializerOptions());

        private static readonly string _homeDir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _updateDir = Path.Combine(Path.GetTempPath(), "Ryujinx", "update");
        private static readonly string _updatePublishDir = Path.Combine(_updateDir, "publish");
        private const int ConnectionCount = 4;
=======
        private const string GitHubApiURL = "https://api.github.com";
        private static readonly GithubReleasesJsonSerializerContext SerializerContext = new(JsonHelper.GetDefaultSerializerOptions());

        private static readonly string HomeDir          = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string UpdateDir        = Path.Combine(Path.GetTempPath(), "Ryujinx", "update");
        private static readonly string UpdatePublishDir = Path.Combine(UpdateDir, "publish");
        private static readonly int    ConnectionCount  = 4;
>>>>>>> 1ec71635b (sync with main branch)

        private static string _buildVer;
        private static string _platformExt;
        private static string _buildUrl;
<<<<<<< HEAD
        private static long _buildSize;
        private static bool _updateSuccessful;
        private static bool _running;

        private static readonly string[] _windowsDependencyDirs = Array.Empty<string>();
=======
        private static long   _buildSize;
        private static bool   _updateSuccessful;
        private static bool   _running;

        private static readonly string[] WindowsDependencyDirs = Array.Empty<string>();
>>>>>>> 1ec71635b (sync with main branch)

        public static async Task BeginParse(Window mainWindow, bool showVersionUpToDate)
        {
            if (_running)
            {
                return;
            }

            _running = true;

            // Detect current platform
            if (OperatingSystem.IsMacOS())
            {
                _platformExt = "macos_universal.app.tar.gz";
            }
            else if (OperatingSystem.IsWindows())
            {
                _platformExt = "win_x64.zip";
            }
            else if (OperatingSystem.IsLinux())
            {
<<<<<<< HEAD
                var arch = RuntimeInformation.OSArchitecture == Architecture.Arm64 ? "arm64" : "x64";
                _platformExt = $"linux_{arch}.tar.gz";
=======
                _platformExt = "linux_x64.tar.gz";
>>>>>>> 1ec71635b (sync with main branch)
            }

            Version newVersion;
            Version currentVersion;

            try
            {
                currentVersion = Version.Parse(Program.Version);
            }
            catch
            {
                Logger.Error?.Print(LogClass.Application, "Failed to convert the current Ryujinx version!");

<<<<<<< HEAD
                await ContentDialogHelper.CreateWarningDialog(
                    LocaleManager.Instance[LocaleKeys.DialogUpdaterConvertFailedMessage],
                    LocaleManager.Instance[LocaleKeys.DialogUpdaterCancelUpdateMessage]);
=======
                Dispatcher.UIThread.Post(async () =>
                {
                    await ContentDialogHelper.CreateWarningDialog(
                        LocaleManager.Instance[LocaleKeys.DialogUpdaterConvertFailedMessage],
                        LocaleManager.Instance[LocaleKeys.DialogUpdaterCancelUpdateMessage]);
                });
>>>>>>> 1ec71635b (sync with main branch)

                _running = false;

                return;
            }

            // Get latest version number from GitHub API
            try
            {
                using HttpClient jsonClient = ConstructHttpClient();

<<<<<<< HEAD
                string buildInfoUrl = $"{GitHubApiUrl}/repos/{ReleaseInformation.ReleaseChannelOwner}/{ReleaseInformation.ReleaseChannelRepo}/releases/latest";
                string fetchedJson = await jsonClient.GetStringAsync(buildInfoUrl);
                var fetched = JsonHelper.Deserialize(fetchedJson, _serializerContext.GithubReleasesJsonResponse);
=======
                string  buildInfoURL = $"{GitHubApiURL}/repos/{ReleaseInformation.ReleaseChannelOwner}/{ReleaseInformation.ReleaseChannelRepo}/releases/latest";
                string  fetchedJson  = await jsonClient.GetStringAsync(buildInfoURL);
                var fetched = JsonHelper.Deserialize(fetchedJson, SerializerContext.GithubReleasesJsonResponse);
>>>>>>> 1ec71635b (sync with main branch)
                _buildVer = fetched.Name;

                foreach (var asset in fetched.Assets)
                {
                    if (asset.Name.StartsWith("test-ava-ryujinx") && asset.Name.EndsWith(_platformExt))
                    {
                        _buildUrl = asset.BrowserDownloadUrl;

                        if (asset.State != "uploaded")
                        {
                            if (showVersionUpToDate)
                            {
<<<<<<< HEAD
                                await ContentDialogHelper.CreateUpdaterInfoDialog(
                                    LocaleManager.Instance[LocaleKeys.DialogUpdaterAlreadyOnLatestVersionMessage],
                                    "");
=======
                                Dispatcher.UIThread.Post(async () =>
                                {
                                    await ContentDialogHelper.CreateUpdaterInfoDialog(LocaleManager.Instance[LocaleKeys.DialogUpdaterAlreadyOnLatestVersionMessage], "");
                                });
>>>>>>> 1ec71635b (sync with main branch)
                            }

                            _running = false;

                            return;
                        }

                        break;
                    }
                }

                // If build not done, assume no new update are available.
                if (_buildUrl is null)
                {
                    if (showVersionUpToDate)
                    {
<<<<<<< HEAD
                        await ContentDialogHelper.CreateUpdaterInfoDialog(
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterAlreadyOnLatestVersionMessage],
                            "");
=======
                        Dispatcher.UIThread.Post(async () =>
                        {
                            await ContentDialogHelper.CreateUpdaterInfoDialog(LocaleManager.Instance[LocaleKeys.DialogUpdaterAlreadyOnLatestVersionMessage], "");
                        });
>>>>>>> 1ec71635b (sync with main branch)
                    }

                    _running = false;

                    return;
                }
            }
            catch (Exception exception)
            {
                Logger.Error?.Print(LogClass.Application, exception.Message);

<<<<<<< HEAD
                await ContentDialogHelper.CreateErrorDialog(
                    LocaleManager.Instance[LocaleKeys.DialogUpdaterFailedToGetVersionMessage]);
=======
                Dispatcher.UIThread.Post(async () =>
                {
                    await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance[LocaleKeys.DialogUpdaterFailedToGetVersionMessage]);
                });
>>>>>>> 1ec71635b (sync with main branch)

                _running = false;

                return;
            }

            try
            {
                newVersion = Version.Parse(_buildVer);
            }
            catch
            {
                Logger.Error?.Print(LogClass.Application, "Failed to convert the received Ryujinx version from Github!");

<<<<<<< HEAD
                await ContentDialogHelper.CreateWarningDialog(
                    LocaleManager.Instance[LocaleKeys.DialogUpdaterConvertFailedGithubMessage],
                    LocaleManager.Instance[LocaleKeys.DialogUpdaterCancelUpdateMessage]);
=======
                Dispatcher.UIThread.Post(async () =>
                {
                    await ContentDialogHelper.CreateWarningDialog(
                        LocaleManager.Instance[LocaleKeys.DialogUpdaterConvertFailedGithubMessage],
                        LocaleManager.Instance[LocaleKeys.DialogUpdaterCancelUpdateMessage]);
                });
>>>>>>> 1ec71635b (sync with main branch)

                _running = false;

                return;
            }

            if (newVersion <= currentVersion)
            {
                if (showVersionUpToDate)
                {
<<<<<<< HEAD
                    await ContentDialogHelper.CreateUpdaterInfoDialog(
                        LocaleManager.Instance[LocaleKeys.DialogUpdaterAlreadyOnLatestVersionMessage],
                        "");
=======
                    Dispatcher.UIThread.Post(async () =>
                    {
                        await ContentDialogHelper.CreateUpdaterInfoDialog(LocaleManager.Instance[LocaleKeys.DialogUpdaterAlreadyOnLatestVersionMessage], "");
                    });
>>>>>>> 1ec71635b (sync with main branch)
                }

                _running = false;

                return;
            }

            // Fetch build size information to learn chunk sizes.
<<<<<<< HEAD
            using HttpClient buildSizeClient = ConstructHttpClient();
            try
            {
                buildSizeClient.DefaultRequestHeaders.Add("Range", "bytes=0-0");

                HttpResponseMessage message = await buildSizeClient.GetAsync(new Uri(_buildUrl), HttpCompletionOption.ResponseHeadersRead);

                _buildSize = message.Content.Headers.ContentRange.Length.Value;
            }
            catch (Exception ex)
            {
                Logger.Warning?.Print(LogClass.Application, ex.Message);
                Logger.Warning?.Print(LogClass.Application, "Couldn't determine build size for update, using single-threaded updater");

                _buildSize = -1;
            }

            await Dispatcher.UIThread.InvokeAsync(async () =>
=======
            using (HttpClient buildSizeClient = ConstructHttpClient())
            {
                try
                {
                    buildSizeClient.DefaultRequestHeaders.Add("Range", "bytes=0-0");

                    HttpResponseMessage message = await buildSizeClient.GetAsync(new Uri(_buildUrl), HttpCompletionOption.ResponseHeadersRead);

                    _buildSize = message.Content.Headers.ContentRange.Length.Value;
                }
                catch (Exception ex)
                {
                    Logger.Warning?.Print(LogClass.Application, ex.Message);
                    Logger.Warning?.Print(LogClass.Application, "Couldn't determine build size for update, using single-threaded updater");

                    _buildSize = -1;
                }
            }

            Dispatcher.UIThread.Post(async () =>
>>>>>>> 1ec71635b (sync with main branch)
            {
                // Show a message asking the user if they want to update
                var shouldUpdate = await ContentDialogHelper.CreateChoiceDialog(
                    LocaleManager.Instance[LocaleKeys.RyujinxUpdater],
                    LocaleManager.Instance[LocaleKeys.RyujinxUpdaterMessage],
                    $"{Program.Version} -> {newVersion}");

                if (shouldUpdate)
                {
<<<<<<< HEAD
                    await UpdateRyujinx(mainWindow, _buildUrl);
=======
                    UpdateRyujinx(mainWindow, _buildUrl);
>>>>>>> 1ec71635b (sync with main branch)
                }
                else
                {
                    _running = false;
                }
            });
        }

        private static HttpClient ConstructHttpClient()
        {
            HttpClient result = new();

            // Required by GitHub to interact with APIs.
            result.DefaultRequestHeaders.Add("User-Agent", "Ryujinx-Updater/1.0.0");

            return result;
        }

<<<<<<< HEAD
        private static async Task UpdateRyujinx(Window parent, string downloadUrl)
=======
        private static async void UpdateRyujinx(Window parent, string downloadUrl)
>>>>>>> 1ec71635b (sync with main branch)
        {
            _updateSuccessful = false;

            // Empty update dir, although it shouldn't ever have anything inside it
<<<<<<< HEAD
            if (Directory.Exists(_updateDir))
            {
                Directory.Delete(_updateDir, true);
            }

            Directory.CreateDirectory(_updateDir);

            string updateFile = Path.Combine(_updateDir, "update.bin");

            TaskDialog taskDialog = new()
            {
                Header = LocaleManager.Instance[LocaleKeys.RyujinxUpdater],
                SubHeader = LocaleManager.Instance[LocaleKeys.UpdaterDownloading],
                IconSource = new SymbolIconSource { Symbol = Symbol.Download },
                ShowProgressBar = true,
                XamlRoot = parent,
=======
            if (Directory.Exists(UpdateDir))
            {
                Directory.Delete(UpdateDir, true);
            }

            Directory.CreateDirectory(UpdateDir);

            string updateFile = Path.Combine(UpdateDir, "update.bin");

            TaskDialog taskDialog = new()
            {
                Header          = LocaleManager.Instance[LocaleKeys.RyujinxUpdater],
                SubHeader       = LocaleManager.Instance[LocaleKeys.UpdaterDownloading],
                IconSource      = new SymbolIconSource { Symbol = Symbol.Download },
                Buttons         = { },
                ShowProgressBar = true,
                XamlRoot        = parent
>>>>>>> 1ec71635b (sync with main branch)
            };

            taskDialog.Opened += (s, e) =>
            {
                if (_buildSize >= 0)
                {
                    DoUpdateWithMultipleThreads(taskDialog, downloadUrl, updateFile);
                }
                else
                {
                    DoUpdateWithSingleThread(taskDialog, downloadUrl, updateFile);
                }
            };

            await taskDialog.ShowAsync(true);

            if (_updateSuccessful)
            {
                bool shouldRestart = true;

                if (!OperatingSystem.IsMacOS())
                {
                    shouldRestart = await ContentDialogHelper.CreateChoiceDialog(LocaleManager.Instance[LocaleKeys.RyujinxUpdater],
                        LocaleManager.Instance[LocaleKeys.DialogUpdaterCompleteMessage],
                        LocaleManager.Instance[LocaleKeys.DialogUpdaterRestartMessage]);
                }

                if (shouldRestart)
                {
                    List<string> arguments = CommandLineState.Arguments.ToList();
                    string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    // On macOS we perform the update at relaunch.
                    if (OperatingSystem.IsMacOS())
                    {
                        string baseBundlePath = Path.GetFullPath(Path.Combine(executableDirectory, "..", ".."));
<<<<<<< HEAD
                        string newBundlePath = Path.Combine(_updateDir, "Ryujinx.app");
=======
                        string newBundlePath = Path.Combine(UpdateDir, "Ryujinx.app");
>>>>>>> 1ec71635b (sync with main branch)
                        string updaterScriptPath = Path.Combine(newBundlePath, "Contents", "Resources", "updater.sh");
                        string currentPid = Environment.ProcessId.ToString();

                        arguments.InsertRange(0, new List<string> { updaterScriptPath, baseBundlePath, newBundlePath, currentPid });
                        Process.Start("/bin/bash", arguments);
                    }
                    else
                    {
                        // Find the process name.
                        string ryuName = Path.GetFileName(Environment.ProcessPath);

                        // Some operating systems can see the renamed executable, so strip off the .ryuold if found.
                        if (ryuName.EndsWith(".ryuold"))
                        {
                            ryuName = ryuName[..^7];
                        }

                        // Fallback if the executable could not be found.
                        if (!Path.Exists(Path.Combine(executableDirectory, ryuName)))
                        {
                            ryuName = OperatingSystem.IsWindows() ? "Ryujinx.Ava.exe" : "Ryujinx.Ava";
                        }

                        ProcessStartInfo processStart = new(ryuName)
                        {
                            UseShellExecute = true,
<<<<<<< HEAD
                            WorkingDirectory = executableDirectory,
=======
                            WorkingDirectory = executableDirectory
>>>>>>> 1ec71635b (sync with main branch)
                        };

                        foreach (string argument in CommandLineState.Arguments)
                        {
                            processStart.ArgumentList.Add(argument);
                        }

                        Process.Start(processStart);
                    }

                    Environment.Exit(0);
                }
            }
        }

        private static void DoUpdateWithMultipleThreads(TaskDialog taskDialog, string downloadUrl, string updateFile)
        {
            // Multi-Threaded Updater
<<<<<<< HEAD
            long chunkSize = _buildSize / ConnectionCount;
            long remainderChunk = _buildSize % ConnectionCount;

            int completedRequests = 0;
            int totalProgressPercentage = 0;
            int[] progressPercentage = new int[ConnectionCount];

            List<byte[]> list = new(ConnectionCount);
=======
            long chunkSize      = _buildSize / ConnectionCount;
            long remainderChunk = _buildSize % ConnectionCount;

            int   completedRequests       = 0;
            int   totalProgressPercentage = 0;
            int[] progressPercentage      = new int[ConnectionCount];

            List<byte[]>    list       = new(ConnectionCount);
>>>>>>> 1ec71635b (sync with main branch)
            List<WebClient> webClients = new(ConnectionCount);

            for (int i = 0; i < ConnectionCount; i++)
            {
                list.Add(Array.Empty<byte>());
            }

            for (int i = 0; i < ConnectionCount; i++)
            {
#pragma warning disable SYSLIB0014
                // TODO: WebClient is obsolete and need to be replaced with a more complex logic using HttpClient.
                using WebClient client = new();
#pragma warning restore SYSLIB0014

                webClients.Add(client);

                if (i == ConnectionCount - 1)
                {
                    client.Headers.Add("Range", $"bytes={chunkSize * i}-{(chunkSize * (i + 1) - 1) + remainderChunk}");
                }
                else
                {
                    client.Headers.Add("Range", $"bytes={chunkSize * i}-{chunkSize * (i + 1) - 1}");
                }

                client.DownloadProgressChanged += (_, args) =>
                {
                    int index = (int)args.UserState;

                    Interlocked.Add(ref totalProgressPercentage, -1 * progressPercentage[index]);
                    Interlocked.Exchange(ref progressPercentage[index], args.ProgressPercentage);
                    Interlocked.Add(ref totalProgressPercentage, args.ProgressPercentage);

                    taskDialog.SetProgressBarState(totalProgressPercentage / ConnectionCount, TaskDialogProgressState.Normal);
                };

                client.DownloadDataCompleted += (_, args) =>
                {
                    int index = (int)args.UserState;

                    if (args.Cancelled)
                    {
                        webClients[index].Dispose();

                        taskDialog.Hide();

                        return;
                    }

                    list[index] = args.Result;
                    Interlocked.Increment(ref completedRequests);

                    if (Equals(completedRequests, ConnectionCount))
                    {
                        byte[] mergedFileBytes = new byte[_buildSize];
                        for (int connectionIndex = 0, destinationOffset = 0; connectionIndex < ConnectionCount; connectionIndex++)
                        {
                            Array.Copy(list[connectionIndex], 0, mergedFileBytes, destinationOffset, list[connectionIndex].Length);
                            destinationOffset += list[connectionIndex].Length;
                        }

                        File.WriteAllBytes(updateFile, mergedFileBytes);

                        // On macOS, ensure that we remove the quarantine bit to prevent Gatekeeper from blocking execution.
                        if (OperatingSystem.IsMacOS())
                        {
<<<<<<< HEAD
                            using Process xattrProcess = Process.Start("xattr", new List<string> { "-d", "com.apple.quarantine", updateFile });

                            xattrProcess.WaitForExit();
=======
                            using (Process xattrProcess = Process.Start("xattr", new List<string> { "-d", "com.apple.quarantine", updateFile }))
                            {
                                xattrProcess.WaitForExit();
                            }
>>>>>>> 1ec71635b (sync with main branch)
                        }

                        try
                        {
                            InstallUpdate(taskDialog, updateFile);
                        }
                        catch (Exception e)
                        {
                            Logger.Warning?.Print(LogClass.Application, e.Message);
                            Logger.Warning?.Print(LogClass.Application, "Multi-Threaded update failed, falling back to single-threaded updater.");

                            DoUpdateWithSingleThread(taskDialog, downloadUrl, updateFile);
<<<<<<< HEAD
=======

                            return;
>>>>>>> 1ec71635b (sync with main branch)
                        }
                    }
                };

                try
                {
                    client.DownloadDataAsync(new Uri(downloadUrl), i);
                }
                catch (WebException ex)
                {
                    Logger.Warning?.Print(LogClass.Application, ex.Message);
                    Logger.Warning?.Print(LogClass.Application, "Multi-Threaded update failed, falling back to single-threaded updater.");

                    foreach (WebClient webClient in webClients)
                    {
                        webClient.CancelAsync();
                    }

                    DoUpdateWithSingleThread(taskDialog, downloadUrl, updateFile);

                    return;
                }
            }
        }

        private static void DoUpdateWithSingleThreadWorker(TaskDialog taskDialog, string downloadUrl, string updateFile)
        {
            using HttpClient client = new();
            // We do not want to timeout while downloading
            client.Timeout = TimeSpan.FromDays(1);

<<<<<<< HEAD
            using HttpResponseMessage response = client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead).Result;
            using Stream remoteFileStream = response.Content.ReadAsStreamAsync().Result;
            using Stream updateFileStream = File.Open(updateFile, FileMode.Create);

            long totalBytes = response.Content.Headers.ContentLength.Value;
            long byteWritten = 0;

            byte[] buffer = new byte[32 * 1024];

            while (true)
            {
                int readSize = remoteFileStream.Read(buffer);

                if (readSize == 0)
                {
                    break;
                }

                byteWritten += readSize;

                taskDialog.SetProgressBarState(GetPercentage(byteWritten, totalBytes), TaskDialogProgressState.Normal);

                updateFileStream.Write(buffer, 0, readSize);
=======
            using (HttpResponseMessage response         = client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead).Result)
            using (Stream              remoteFileStream = response.Content.ReadAsStreamAsync().Result)
            {
                using Stream updateFileStream = File.Open(updateFile, FileMode.Create);

                long totalBytes  = response.Content.Headers.ContentLength.Value;
                long byteWritten = 0;

                byte[] buffer = new byte[32 * 1024];

                while (true)
                {
                    int readSize = remoteFileStream.Read(buffer);

                    if (readSize == 0)
                    {
                        break;
                    }

                    byteWritten += readSize;

                    taskDialog.SetProgressBarState(GetPercentage(byteWritten, totalBytes), TaskDialogProgressState.Normal);

                    updateFileStream.Write(buffer, 0, readSize);
                }
>>>>>>> 1ec71635b (sync with main branch)
            }

            InstallUpdate(taskDialog, updateFile);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double GetPercentage(double value, double max)
        {
            return max == 0 ? 0 : value / max * 100;
        }

        private static void DoUpdateWithSingleThread(TaskDialog taskDialog, string downloadUrl, string updateFile)
        {
            Thread worker = new(() => DoUpdateWithSingleThreadWorker(taskDialog, downloadUrl, updateFile))
            {
<<<<<<< HEAD
                Name = "Updater.SingleThreadWorker",
=======
                Name = "Updater.SingleThreadWorker"
>>>>>>> 1ec71635b (sync with main branch)
            };

            worker.Start();
        }

        [SupportedOSPlatform("linux")]
        [SupportedOSPlatform("macos")]
        private static void ExtractTarGzipFile(TaskDialog taskDialog, string archivePath, string outputDirectoryPath)
        {
<<<<<<< HEAD
            using Stream inStream = File.OpenRead(archivePath);
            using GZipInputStream gzipStream = new(inStream);
            using TarInputStream tarStream = new(gzipStream, Encoding.ASCII);
=======
            using Stream          inStream   = File.OpenRead(archivePath);
            using GZipInputStream gzipStream = new(inStream);
            using TarInputStream  tarStream  = new(gzipStream, Encoding.ASCII);
>>>>>>> 1ec71635b (sync with main branch)

            TarEntry tarEntry;

            while ((tarEntry = tarStream.GetNextEntry()) is not null)
            {
                if (tarEntry.IsDirectory)
                {
                    continue;
                }

                string outPath = Path.Combine(outputDirectoryPath, tarEntry.Name);

                Directory.CreateDirectory(Path.GetDirectoryName(outPath));

<<<<<<< HEAD
                using FileStream outStream = File.OpenWrite(outPath);
                tarStream.CopyEntryContents(outStream);
=======
                using (FileStream outStream = File.OpenWrite(outPath))
                {
                    tarStream.CopyEntryContents(outStream);
                }
>>>>>>> 1ec71635b (sync with main branch)

                File.SetUnixFileMode(outPath, (UnixFileMode)tarEntry.TarHeader.Mode);
                File.SetLastWriteTime(outPath, DateTime.SpecifyKind(tarEntry.ModTime, DateTimeKind.Utc));

                Dispatcher.UIThread.Post(() =>
                {
                    if (tarEntry is null)
                    {
                        return;
                    }

                    taskDialog.SetProgressBarState(GetPercentage(tarEntry.Size, inStream.Length), TaskDialogProgressState.Normal);
                });
            }
        }

        private static void ExtractZipFile(TaskDialog taskDialog, string archivePath, string outputDirectoryPath)
        {
<<<<<<< HEAD
            using Stream inStream = File.OpenRead(archivePath);
            using ZipFile zipFile = new(inStream);
=======
            using Stream  inStream = File.OpenRead(archivePath);
            using ZipFile zipFile  = new(inStream);
>>>>>>> 1ec71635b (sync with main branch)

            double count = 0;
            foreach (ZipEntry zipEntry in zipFile)
            {
                count++;
<<<<<<< HEAD
                if (zipEntry.IsDirectory)
                {
                    continue;
                }
=======
                if (zipEntry.IsDirectory) continue;
>>>>>>> 1ec71635b (sync with main branch)

                string outPath = Path.Combine(outputDirectoryPath, zipEntry.Name);

                Directory.CreateDirectory(Path.GetDirectoryName(outPath));

<<<<<<< HEAD
                using Stream zipStream = zipFile.GetInputStream(zipEntry);
                using FileStream outStream = File.OpenWrite(outPath);

                zipStream.CopyTo(outStream);
=======
                using (Stream     zipStream = zipFile.GetInputStream(zipEntry))
                using (FileStream outStream = File.OpenWrite(outPath))
                {
                    zipStream.CopyTo(outStream);
                }
>>>>>>> 1ec71635b (sync with main branch)

                File.SetLastWriteTime(outPath, DateTime.SpecifyKind(zipEntry.DateTime, DateTimeKind.Utc));

                Dispatcher.UIThread.Post(() =>
                {
                    taskDialog.SetProgressBarState(GetPercentage(count, zipFile.Count), TaskDialogProgressState.Normal);
                });
            }
        }

<<<<<<< HEAD
        private static void InstallUpdate(TaskDialog taskDialog, string updateFile)
=======
        private static async void InstallUpdate(TaskDialog taskDialog, string updateFile)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // Extract Update
            taskDialog.SubHeader = LocaleManager.Instance[LocaleKeys.UpdaterExtracting];
            taskDialog.SetProgressBarState(0, TaskDialogProgressState.Normal);

<<<<<<< HEAD
            if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
            {
                ExtractTarGzipFile(taskDialog, updateFile, _updateDir);
            }
            else if (OperatingSystem.IsWindows())
            {
                ExtractZipFile(taskDialog, updateFile, _updateDir);
            }
            else
            {
                throw new NotSupportedException();
            }
=======
            await Task.Run(() =>
            {
                if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                {
                    ExtractTarGzipFile(taskDialog, updateFile, UpdateDir);
                }
                else if (OperatingSystem.IsWindows())
                {
                    ExtractZipFile(taskDialog, updateFile, UpdateDir);
                }
                else
                {
                    throw new NotSupportedException();
                }
            });
>>>>>>> 1ec71635b (sync with main branch)

            // Delete downloaded zip
            File.Delete(updateFile);

            List<string> allFiles = EnumerateFilesToDelete().ToList();

            taskDialog.SubHeader = LocaleManager.Instance[LocaleKeys.UpdaterRenaming];
            taskDialog.SetProgressBarState(0, TaskDialogProgressState.Normal);

            // NOTE: On macOS, replacement is delayed to the restart phase.
            if (!OperatingSystem.IsMacOS())
            {
                // Replace old files
<<<<<<< HEAD
                double count = 0;
                foreach (string file in allFiles)
                {
                    count++;
                    try
                    {
                        File.Move(file, file + ".ryuold");

                        Dispatcher.UIThread.InvokeAsync(() =>
                        {
                            taskDialog.SetProgressBarState(GetPercentage(count, allFiles.Count), TaskDialogProgressState.Normal);
                        });
                    }
                    catch
                    {
                        Logger.Warning?.Print(LogClass.Application, LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.UpdaterRenameFailed, file));
                    }
                }

                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    taskDialog.SubHeader = LocaleManager.Instance[LocaleKeys.UpdaterAddingFiles];
                    taskDialog.SetProgressBarState(0, TaskDialogProgressState.Normal);
                });

                MoveAllFilesOver(_updatePublishDir, _homeDir, taskDialog);

                Directory.Delete(_updateDir, true);
=======
                await Task.Run(() =>
                {
                    double count = 0;
                    foreach (string file in allFiles)
                    {
                        count++;
                        try
                        {
                            File.Move(file, file + ".ryuold");

                            Dispatcher.UIThread.Post(() =>
                            {
                                taskDialog.SetProgressBarState(GetPercentage(count, allFiles.Count), TaskDialogProgressState.Normal);
                            });
                        }
                        catch
                        {
                            Logger.Warning?.Print(LogClass.Application, LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.UpdaterRenameFailed, file));
                        }
                    }

                    Dispatcher.UIThread.Post(() =>
                    {
                        taskDialog.SubHeader = LocaleManager.Instance[LocaleKeys.UpdaterAddingFiles];
                        taskDialog.SetProgressBarState(0, TaskDialogProgressState.Normal);
                    });

                    MoveAllFilesOver(UpdatePublishDir, HomeDir, taskDialog);
                });

                Directory.Delete(UpdateDir, true);
>>>>>>> 1ec71635b (sync with main branch)
            }

            _updateSuccessful = true;

            taskDialog.Hide();
        }

        public static bool CanUpdate(bool showWarnings)
        {
#if !DISABLE_UPDATER
<<<<<<< HEAD
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                if (showWarnings)
                {
                    Dispatcher.UIThread.InvokeAsync(() =>
                        ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterNoInternetMessage],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterNoInternetSubMessage])
                    );
=======
            if (RuntimeInformation.OSArchitecture != Architecture.X64 && !OperatingSystem.IsMacOS())
            {
                if (showWarnings)
                {
                    Dispatcher.UIThread.Post(async () =>
                    {
                        await ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterArchNotSupportedMessage],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterArchNotSupportedSubMessage]);
                    });
>>>>>>> 1ec71635b (sync with main branch)
                }

                return false;
            }

<<<<<<< HEAD
            if (Program.Version.Contains("dirty") || !ReleaseInformation.IsValid)
            {
                if (showWarnings)
                {
                    Dispatcher.UIThread.InvokeAsync(() =>
                        ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterDirtyBuildMessage],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterDirtyBuildSubMessage])
                    );
=======
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                if (showWarnings)
                {
                    Dispatcher.UIThread.Post(async () =>
                    {
                        await ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterNoInternetMessage],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterNoInternetSubMessage]);
                    });
                }

                return false;
            }

            if (Program.Version.Contains("dirty") || !ReleaseInformation.IsValid())
            {
                if (showWarnings)
                {
                    Dispatcher.UIThread.Post(async () =>
                    {
                        await ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterDirtyBuildMessage],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterDirtyBuildSubMessage]);
                    });
>>>>>>> 1ec71635b (sync with main branch)
                }

                return false;
            }

            return true;
#else
            if (showWarnings)
            {
<<<<<<< HEAD
                if (ReleaseInformation.IsFlatHubBuild)
                {
                    Dispatcher.UIThread.InvokeAsync(() =>
                        ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.UpdaterDisabledWarningTitle],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterFlatpakNotSupportedMessage])
                    );
                }
                else
                {
                    Dispatcher.UIThread.InvokeAsync(() =>
                        ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.UpdaterDisabledWarningTitle],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterDirtyBuildSubMessage])
                    );
=======
                if (ReleaseInformation.IsFlatHubBuild())
                {
                    Dispatcher.UIThread.Post(async () =>
                    {
                        await ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.UpdaterDisabledWarningTitle],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterFlatpakNotSupportedMessage]);
                    });
                }
                else
                {
                    Dispatcher.UIThread.Post(async () =>
                    {
                        await ContentDialogHelper.CreateWarningDialog(
                            LocaleManager.Instance[LocaleKeys.UpdaterDisabledWarningTitle],
                            LocaleManager.Instance[LocaleKeys.DialogUpdaterDirtyBuildSubMessage]);
                    });
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            return false;
#endif
        }

        // NOTE: This method should always reflect the latest build layout.
        private static IEnumerable<string> EnumerateFilesToDelete()
        {
<<<<<<< HEAD
            var files = Directory.EnumerateFiles(_homeDir); // All files directly in base dir.

            // Determine and exclude user files only when the updater is running, not when cleaning old files
            if (_running && !OperatingSystem.IsMacOS())
            {
                // Compare the loose files in base directory against the loose files from the incoming update, and store foreign ones in a user list.
                var oldFiles = Directory.EnumerateFiles(_homeDir, "*", SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
                var newFiles = Directory.EnumerateFiles(_updatePublishDir, "*", SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
                var userFiles = oldFiles.Except(newFiles).Select(filename => Path.Combine(_homeDir, filename));

                // Remove user files from the paths in files.
                files = files.Except(userFiles);
            }

            if (OperatingSystem.IsWindows())
            {
                foreach (string dir in _windowsDependencyDirs)
                {
                    string dirPath = Path.Combine(_homeDir, dir);
=======
            var files = Directory.EnumerateFiles(HomeDir); // All files directly in base dir.

            if (OperatingSystem.IsWindows())
            {
                foreach (string dir in WindowsDependencyDirs)
                {
                    string dirPath = Path.Combine(HomeDir, dir);
>>>>>>> 1ec71635b (sync with main branch)
                    if (Directory.Exists(dirPath))
                    {
                        files = files.Concat(Directory.EnumerateFiles(dirPath, "*", SearchOption.AllDirectories));
                    }
                }
            }

            return files.Where(f => !new FileInfo(f).Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System));
        }

        private static void MoveAllFilesOver(string root, string dest, TaskDialog taskDialog)
        {
            int total = Directory.GetFiles(root, "*", SearchOption.AllDirectories).Length;
            foreach (string directory in Directory.GetDirectories(root))
            {
                string dirName = Path.GetFileName(directory);

                if (!Directory.Exists(Path.Combine(dest, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, dirName));
                }

                MoveAllFilesOver(directory, Path.Combine(dest, dirName), taskDialog);
            }

            double count = 0;
            foreach (string file in Directory.GetFiles(root))
            {
                count++;

                File.Move(file, Path.Combine(dest, Path.GetFileName(file)), true);

                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    taskDialog.SetProgressBarState(GetPercentage(count, total), TaskDialogProgressState.Normal);
                });
            }
        }

        public static void CleanupUpdate()
        {
<<<<<<< HEAD
            foreach (string file in Directory.GetFiles(_homeDir, "*.ryuold", SearchOption.AllDirectories))
=======
            foreach (string file in Directory.GetFiles(HomeDir, "*.ryuold", SearchOption.AllDirectories))
>>>>>>> 1ec71635b (sync with main branch)
            {
                File.Delete(file);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
