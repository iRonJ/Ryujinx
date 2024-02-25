using Gtk;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using Ryujinx.Common;
using Ryujinx.Common.Logging;
using Ryujinx.Common.Utilities;
<<<<<<< HEAD
using Ryujinx.UI;
using Ryujinx.UI.Common.Models.Github;
using Ryujinx.UI.Widgets;
=======
using Ryujinx.Ui;
using Ryujinx.Ui.Common.Models.Github;
using Ryujinx.Ui.Widgets;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ryujinx.Modules
{
    public static class Updater
    {
<<<<<<< HEAD
        private const string GitHubApiUrl = "https://api.github.com";
=======
        private const string GitHubApiURL = "https://api.github.com";
>>>>>>> 1ec71635b (sync with main branch)
        private const int ConnectionCount = 4;

        internal static bool Running;

<<<<<<< HEAD
        private static readonly string _homeDir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _updateDir = Path.Combine(Path.GetTempPath(), "Ryujinx", "update");
        private static readonly string _updatePublishDir = Path.Combine(_updateDir, "publish");
=======
        private static readonly string HomeDir          = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string UpdateDir        = Path.Combine(Path.GetTempPath(), "Ryujinx", "update");
        private static readonly string UpdatePublishDir = Path.Combine(UpdateDir, "publish");
>>>>>>> 1ec71635b (sync with main branch)

        private static string _buildVer;
        private static string _platformExt;
        private static string _buildUrl;
<<<<<<< HEAD
        private static long _buildSize;

        private static readonly GithubReleasesJsonSerializerContext _serializerContext = new(JsonHelper.GetDefaultSerializerOptions());

        // On Windows, GtkSharp.Dependencies adds these extra dirs that must be cleaned during updates.
        private static readonly string[] _windowsDependencyDirs = { "bin", "etc", "lib", "share" };

        private static HttpClient ConstructHttpClient()
        {
            HttpClient result = new();
=======
        private static long   _buildSize;

        private static readonly GithubReleasesJsonSerializerContext SerializerContext = new(JsonHelper.GetDefaultSerializerOptions());

        // On Windows, GtkSharp.Dependencies adds these extra dirs that must be cleaned during updates.
        private static readonly string[] WindowsDependencyDirs = new string[] { "bin", "etc", "lib", "share" };

        private static HttpClient ConstructHttpClient()
        {
            HttpClient result = new HttpClient();
>>>>>>> 1ec71635b (sync with main branch)

            // Required by GitHub to interact with APIs.
            result.DefaultRequestHeaders.Add("User-Agent", "Ryujinx-Updater/1.0.0");

            return result;
        }

        public static async Task BeginParse(MainWindow mainWindow, bool showVersionUpToDate)
        {
<<<<<<< HEAD
            if (Running)
            {
                return;
            }
=======
            if (Running) return;
>>>>>>> 1ec71635b (sync with main branch)

            Running = true;
            mainWindow.UpdateMenuItem.Sensitive = false;

            int artifactIndex = -1;

            // Detect current platform
            if (OperatingSystem.IsMacOS())
            {
<<<<<<< HEAD
                _platformExt = "osx_x64.zip";
=======
                _platformExt  = "osx_x64.zip";
>>>>>>> 1ec71635b (sync with main branch)
                artifactIndex = 1;
            }
            else if (OperatingSystem.IsWindows())
            {
<<<<<<< HEAD
                _platformExt = "win_x64.zip";
=======
                _platformExt  = "win_x64.zip";
>>>>>>> 1ec71635b (sync with main branch)
                artifactIndex = 2;
            }
            else if (OperatingSystem.IsLinux())
            {
<<<<<<< HEAD
                var arch = RuntimeInformation.OSArchitecture == Architecture.Arm64 ? "arm64" : "x64";
                _platformExt = $"linux_{arch}.tar.gz";
=======
                _platformExt  = "linux_x64.tar.gz";
>>>>>>> 1ec71635b (sync with main branch)
                artifactIndex = 0;
            }

            if (artifactIndex == -1)
            {
                GtkDialog.CreateErrorDialog("Your platform is not supported!");

                return;
            }

            Version newVersion;
            Version currentVersion;

            try
            {
                currentVersion = Version.Parse(Program.Version);
            }
            catch
            {
                GtkDialog.CreateWarningDialog("Failed to convert the current Ryujinx version.", "Cancelling Update!");
                Logger.Error?.Print(LogClass.Application, "Failed to convert the current Ryujinx version!");

                return;
            }

            // Get latest version number from GitHub API
            try
            {
                using HttpClient jsonClient = ConstructHttpClient();
<<<<<<< HEAD
                string buildInfoUrl = $"{GitHubApiUrl}/repos/{ReleaseInformation.ReleaseChannelOwner}/{ReleaseInformation.ReleaseChannelRepo}/releases/latest";

                // Fetch latest build information
                string fetchedJson = await jsonClient.GetStringAsync(buildInfoUrl);
                var fetched = JsonHelper.Deserialize(fetchedJson, _serializerContext.GithubReleasesJsonResponse);
=======
                string buildInfoURL = $"{GitHubApiURL}/repos/{ReleaseInformation.ReleaseChannelOwner}/{ReleaseInformation.ReleaseChannelRepo}/releases/latest";

                // Fetch latest build information
                string  fetchedJson = await jsonClient.GetStringAsync(buildInfoURL);
                var fetched = JsonHelper.Deserialize(fetchedJson, SerializerContext.GithubReleasesJsonResponse);
>>>>>>> 1ec71635b (sync with main branch)
                _buildVer = fetched.Name;

                foreach (var asset in fetched.Assets)
                {
                    if (asset.Name.StartsWith("ryujinx") && asset.Name.EndsWith(_platformExt))
                    {
                        _buildUrl = asset.BrowserDownloadUrl;

                        if (asset.State != "uploaded")
                        {
                            if (showVersionUpToDate)
                            {
                                GtkDialog.CreateUpdaterInfoDialog("You are already using the latest version of Ryujinx!", "");
                            }

                            return;
                        }

                        break;
                    }
                }

                if (_buildUrl == null)
                {
                    if (showVersionUpToDate)
                    {
                        GtkDialog.CreateUpdaterInfoDialog("You are already using the latest version of Ryujinx!", "");
                    }

                    return;
                }
            }
            catch (Exception exception)
            {
                Logger.Error?.Print(LogClass.Application, exception.Message);
                GtkDialog.CreateErrorDialog("An error occurred when trying to get release information from GitHub Release. This can be caused if a new release is being compiled by GitHub Actions. Try again in a few minutes.");

                return;
            }

            try
            {
                newVersion = Version.Parse(_buildVer);
            }
            catch
            {
                GtkDialog.CreateWarningDialog("Failed to convert the received Ryujinx version from GitHub Release.", "Cancelling Update!");
                Logger.Error?.Print(LogClass.Application, "Failed to convert the received Ryujinx version from GitHub Release!");

                return;
            }

            if (newVersion <= currentVersion)
            {
                if (showVersionUpToDate)
                {
                    GtkDialog.CreateUpdaterInfoDialog("You are already using the latest version of Ryujinx!", "");
                }

                Running = false;
                mainWindow.UpdateMenuItem.Sensitive = true;

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

            // Show a message asking the user if they want to update
            UpdateDialog updateDialog = new(mainWindow, newVersion, _buildUrl);
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

            // Show a message asking the user if they want to update
            UpdateDialog updateDialog = new UpdateDialog(mainWindow, newVersion, _buildUrl);
>>>>>>> 1ec71635b (sync with main branch)
            updateDialog.Show();
        }

        public static void UpdateRyujinx(UpdateDialog updateDialog, string downloadUrl)
        {
            // Empty update dir, although it shouldn't ever have anything inside it
<<<<<<< HEAD
            if (Directory.Exists(_updateDir))
            {
                Directory.Delete(_updateDir, true);
            }

            Directory.CreateDirectory(_updateDir);

            string updateFile = Path.Combine(_updateDir, "update.bin");

            // Download the update .zip
            updateDialog.MainText.Text = "Downloading Update...";
            updateDialog.ProgressBar.Value = 0;
=======
            if (Directory.Exists(UpdateDir))
            {
                Directory.Delete(UpdateDir, true);
            }

            Directory.CreateDirectory(UpdateDir);

            string updateFile = Path.Combine(UpdateDir, "update.bin");

            // Download the update .zip
            updateDialog.MainText.Text        = "Downloading Update...";
            updateDialog.ProgressBar.Value    = 0;
>>>>>>> 1ec71635b (sync with main branch)
            updateDialog.ProgressBar.MaxValue = 100;

            if (_buildSize >= 0)
            {
                DoUpdateWithMultipleThreads(updateDialog, downloadUrl, updateFile);
            }
            else
            {
                DoUpdateWithSingleThread(updateDialog, downloadUrl, updateFile);
            }
        }

        private static void DoUpdateWithMultipleThreads(UpdateDialog updateDialog, string downloadUrl, string updateFile)
        {
            // Multi-Threaded Updater
            long chunkSize = _buildSize / ConnectionCount;
            long remainderChunk = _buildSize % ConnectionCount;

            int completedRequests = 0;
            int totalProgressPercentage = 0;
            int[] progressPercentage = new int[ConnectionCount];

<<<<<<< HEAD
            List<byte[]> list = new(ConnectionCount);
            List<WebClient> webClients = new(ConnectionCount);
=======
            List<byte[]> list = new List<byte[]>(ConnectionCount);
            List<WebClient> webClients = new List<WebClient>(ConnectionCount);
>>>>>>> 1ec71635b (sync with main branch)

            for (int i = 0; i < ConnectionCount; i++)
            {
                list.Add(Array.Empty<byte>());
            }

            for (int i = 0; i < ConnectionCount; i++)
            {
#pragma warning disable SYSLIB0014
                // TODO: WebClient is obsolete and need to be replaced with a more complex logic using HttpClient.
<<<<<<< HEAD
                using WebClient client = new();
=======
                using WebClient client = new WebClient();
>>>>>>> 1ec71635b (sync with main branch)
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

                    updateDialog.ProgressBar.Value = totalProgressPercentage / ConnectionCount;
                };

                client.DownloadDataCompleted += (_, args) =>
                {
                    int index = (int)args.UserState;

                    if (args.Cancelled)
                    {
                        webClients[index].Dispose();

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

                        try
                        {
                            InstallUpdate(updateDialog, updateFile);
                        }
                        catch (Exception e)
                        {
                            Logger.Warning?.Print(LogClass.Application, e.Message);
                            Logger.Warning?.Print(LogClass.Application, "Multi-Threaded update failed, falling back to single-threaded updater.");

                            DoUpdateWithSingleThread(updateDialog, downloadUrl, updateFile);

                            return;
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

                    DoUpdateWithSingleThread(updateDialog, downloadUrl, updateFile);

                    return;
                }
            }
        }

        private static void DoUpdateWithSingleThreadWorker(UpdateDialog updateDialog, string downloadUrl, string updateFile)
        {
<<<<<<< HEAD
            using HttpClient client = new();
            // We do not want to timeout while downloading
            client.Timeout = TimeSpan.FromDays(1);

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

                updateDialog.ProgressBar.Value = ((double)byteWritten / totalBytes) * 100;
                updateFileStream.Write(buffer, 0, readSize);
=======
            using HttpClient client = new HttpClient();
            // We do not want to timeout while downloading
            client.Timeout = TimeSpan.FromDays(1);

            using (HttpResponseMessage response = client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead).Result)
            using (Stream remoteFileStream = response.Content.ReadAsStreamAsync().Result)
            {
                using (Stream updateFileStream = File.Open(updateFile, FileMode.Create))
                {
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

                        updateDialog.ProgressBar.Value = ((double)byteWritten / totalBytes) * 100;
                        updateFileStream.Write(buffer, 0, readSize);
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)
            }

            InstallUpdate(updateDialog, updateFile);
        }

        private static void DoUpdateWithSingleThread(UpdateDialog updateDialog, string downloadUrl, string updateFile)
        {
<<<<<<< HEAD
            Thread worker = new(() => DoUpdateWithSingleThreadWorker(updateDialog, downloadUrl, updateFile))
            {
                Name = "Updater.SingleThreadWorker",
=======
            Thread worker = new Thread(() => DoUpdateWithSingleThreadWorker(updateDialog, downloadUrl, updateFile))
            {
                Name = "Updater.SingleThreadWorker"
>>>>>>> 1ec71635b (sync with main branch)
            };
            worker.Start();
        }

        private static async void InstallUpdate(UpdateDialog updateDialog, string updateFile)
        {
            // Extract Update
<<<<<<< HEAD
            updateDialog.MainText.Text = "Extracting Update...";
=======
            updateDialog.MainText.Text     = "Extracting Update...";
>>>>>>> 1ec71635b (sync with main branch)
            updateDialog.ProgressBar.Value = 0;

            if (OperatingSystem.IsLinux())
            {
<<<<<<< HEAD
                using Stream inStream = File.OpenRead(updateFile);
                using Stream gzipStream = new GZipInputStream(inStream);
                using TarInputStream tarStream = new(gzipStream, Encoding.ASCII);
=======
                using Stream         inStream   = File.OpenRead(updateFile);
                using Stream         gzipStream = new GZipInputStream(inStream);
                using TarInputStream tarStream  = new TarInputStream(gzipStream, Encoding.ASCII);
>>>>>>> 1ec71635b (sync with main branch)
                updateDialog.ProgressBar.MaxValue = inStream.Length;

                await Task.Run(() =>
                {
                    TarEntry tarEntry;

                    if (!OperatingSystem.IsWindows())
                    {
                        while ((tarEntry = tarStream.GetNextEntry()) != null)
                        {
<<<<<<< HEAD
                            if (tarEntry.IsDirectory)
                            {
                                continue;
                            }

                            string outPath = Path.Combine(_updateDir, tarEntry.Name);

                            Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                            using FileStream outStream = File.OpenWrite(outPath);
                            tarStream.CopyEntryContents(outStream);
=======
                            if (tarEntry.IsDirectory) continue;

                            string outPath = Path.Combine(UpdateDir, tarEntry.Name);

                            Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                            using (FileStream outStream = File.OpenWrite(outPath))
                            {
                                tarStream.CopyEntryContents(outStream);
                            }
>>>>>>> 1ec71635b (sync with main branch)

                            File.SetUnixFileMode(outPath, (UnixFileMode)tarEntry.TarHeader.Mode);
                            File.SetLastWriteTime(outPath, DateTime.SpecifyKind(tarEntry.ModTime, DateTimeKind.Utc));

                            TarEntry entry = tarEntry;

                            Application.Invoke(delegate
                            {
                                updateDialog.ProgressBar.Value += entry.Size;
                            });
                        }
                    }
                });

                updateDialog.ProgressBar.Value = inStream.Length;
            }
            else
            {
<<<<<<< HEAD
                using Stream inStream = File.OpenRead(updateFile);
                using ZipFile zipFile = new(inStream);
=======
                using Stream  inStream = File.OpenRead(updateFile);
                using ZipFile zipFile  = new ZipFile(inStream);
>>>>>>> 1ec71635b (sync with main branch)
                updateDialog.ProgressBar.MaxValue = zipFile.Count;

                await Task.Run(() =>
                {
                    foreach (ZipEntry zipEntry in zipFile)
                    {
<<<<<<< HEAD
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        string outPath = Path.Combine(_updateDir, zipEntry.Name);

                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                        using Stream zipStream = zipFile.GetInputStream(zipEntry);
                        using FileStream outStream = File.OpenWrite(outPath);
                        zipStream.CopyTo(outStream);
=======
                        if (zipEntry.IsDirectory) continue;

                        string outPath = Path.Combine(UpdateDir, zipEntry.Name);

                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                        using (Stream     zipStream = zipFile.GetInputStream(zipEntry))
                        using (FileStream outStream = File.OpenWrite(outPath))
                        {
                            zipStream.CopyTo(outStream);
                        }
>>>>>>> 1ec71635b (sync with main branch)

                        File.SetLastWriteTime(outPath, DateTime.SpecifyKind(zipEntry.DateTime, DateTimeKind.Utc));

                        Application.Invoke(delegate
                        {
                            updateDialog.ProgressBar.Value++;
                        });
                    }
                });
            }

            // Delete downloaded zip
            File.Delete(updateFile);

            List<string> allFiles = EnumerateFilesToDelete().ToList();

<<<<<<< HEAD
            updateDialog.MainText.Text = "Renaming Old Files...";
            updateDialog.ProgressBar.Value = 0;
=======
            updateDialog.MainText.Text        = "Renaming Old Files...";
            updateDialog.ProgressBar.Value    = 0;
>>>>>>> 1ec71635b (sync with main branch)
            updateDialog.ProgressBar.MaxValue = allFiles.Count;

            // Replace old files
            await Task.Run(() =>
            {
                foreach (string file in allFiles)
                {
                    try
                    {
                        File.Move(file, file + ".ryuold");

                        Application.Invoke(delegate
                        {
                            updateDialog.ProgressBar.Value++;
                        });
                    }
                    catch
                    {
                        Logger.Warning?.Print(LogClass.Application, "Updater was unable to rename file: " + file);
                    }
                }

                Application.Invoke(delegate
                {
<<<<<<< HEAD
                    updateDialog.MainText.Text = "Adding New Files...";
                    updateDialog.ProgressBar.Value = 0;
                    updateDialog.ProgressBar.MaxValue = Directory.GetFiles(_updatePublishDir, "*", SearchOption.AllDirectories).Length;
                });

                MoveAllFilesOver(_updatePublishDir, _homeDir, updateDialog);
            });

            Directory.Delete(_updateDir, true);

            updateDialog.MainText.Text = "Update Complete!";
            updateDialog.SecondaryText.Text = "Do you want to restart Ryujinx now?";
            updateDialog.Modal = true;
=======
                    updateDialog.MainText.Text        = "Adding New Files...";
                    updateDialog.ProgressBar.Value    = 0;
                    updateDialog.ProgressBar.MaxValue = Directory.GetFiles(UpdatePublishDir, "*", SearchOption.AllDirectories).Length;
                });

                MoveAllFilesOver(UpdatePublishDir, HomeDir, updateDialog);
            });

            Directory.Delete(UpdateDir, true);

            updateDialog.MainText.Text      = "Update Complete!";
            updateDialog.SecondaryText.Text = "Do you want to restart Ryujinx now?";
            updateDialog.Modal              = true;
>>>>>>> 1ec71635b (sync with main branch)

            updateDialog.ProgressBar.Hide();
            updateDialog.YesButton.Show();
            updateDialog.NoButton.Show();
        }

        public static bool CanUpdate(bool showWarnings)
        {
#if !DISABLE_UPDATER
<<<<<<< HEAD
=======
            if (RuntimeInformation.OSArchitecture != Architecture.X64)
            {
                if (showWarnings)
                {
                    GtkDialog.CreateWarningDialog("You are not running a supported system architecture!", "(Only x64 systems are supported!)");
                }

                return false;
            }

>>>>>>> 1ec71635b (sync with main branch)
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                if (showWarnings)
                {
                    GtkDialog.CreateWarningDialog("You are not connected to the Internet!", "Please verify that you have a working Internet connection!");
                }

                return false;
            }

<<<<<<< HEAD
            if (Program.Version.Contains("dirty") || !ReleaseInformation.IsValid)
=======
            if (Program.Version.Contains("dirty") || !ReleaseInformation.IsValid())
>>>>>>> 1ec71635b (sync with main branch)
            {
                if (showWarnings)
                {
                    GtkDialog.CreateWarningDialog("You cannot update a Dirty build of Ryujinx!", "Please download Ryujinx at https://ryujinx.org/ if you are looking for a supported version.");
                }

                return false;
            }

            return true;
#else
            if (showWarnings)
            {
<<<<<<< HEAD
                if (ReleaseInformation.IsFlatHubBuild)
=======
                if (ReleaseInformation.IsFlatHubBuild())
>>>>>>> 1ec71635b (sync with main branch)
                {
                    GtkDialog.CreateWarningDialog("Updater Disabled!", "Please update Ryujinx via FlatHub.");
                }
                else
                {
                    GtkDialog.CreateWarningDialog("Updater Disabled!", "Please download Ryujinx at https://ryujinx.org/ if you are looking for a supported version.");
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
            if (Running)
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

        private static void MoveAllFilesOver(string root, string dest, UpdateDialog dialog)
        {
            foreach (string directory in Directory.GetDirectories(root))
            {
                string dirName = Path.GetFileName(directory);

                if (!Directory.Exists(Path.Combine(dest, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, dirName));
                }

                MoveAllFilesOver(directory, Path.Combine(dest, dirName), dialog);
            }

            foreach (string file in Directory.GetFiles(root))
            {
                File.Move(file, Path.Combine(dest, Path.GetFileName(file)), true);

                Application.Invoke(delegate
                {
                    dialog.ProgressBar.Value++;
                });
            }
        }

        public static void CleanupUpdate()
        {
            foreach (string file in EnumerateFilesToDelete())
            {
                if (Path.GetExtension(file).EndsWith(".ryuold"))
                {
                    File.Delete(file);
                }
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
