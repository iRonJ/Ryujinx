<<<<<<< HEAD
=======
﻿using Avalonia;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Collections;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Models;
using Ryujinx.HLE.FileSystem;
using Ryujinx.HLE.HOS;
<<<<<<< HEAD
using Ryujinx.UI.App.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
=======
using Ryujinx.Ui.App.Common;
using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)
using System.IO;
using System.Linq;

namespace Ryujinx.Ava.UI.Windows
{
    public partial class CheatWindow : StyleableWindow
    {
        private readonly string _enabledCheatsPath;
        public bool NoCheatsFound { get; }

<<<<<<< HEAD
        public AvaloniaList<CheatNode> LoadedCheats { get; }
=======
        private AvaloniaList<CheatsList> LoadedCheats { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public string Heading { get; }
        public string BuildId { get; }

        public CheatWindow()
        {
            DataContext = this;

            InitializeComponent();

            Title = $"Ryujinx {Program.Version} - " + LocaleManager.Instance[LocaleKeys.CheatWindowTitle];
        }

        public CheatWindow(VirtualFileSystem virtualFileSystem, string titleId, string titleName, string titlePath)
        {
<<<<<<< HEAD
            LoadedCheats = new AvaloniaList<CheatNode>();

            Heading = LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.CheatWindowHeading, titleName, titleId.ToUpper());
            BuildId = ApplicationData.GetApplicationBuildId(virtualFileSystem, titlePath);

            InitializeComponent();

            string modsBasePath = ModLoader.GetModsBasePath();
            string titleModsPath = ModLoader.GetApplicationDir(modsBasePath, titleId);
            ulong titleIdValue = ulong.Parse(titleId, NumberStyles.HexNumber);

            _enabledCheatsPath = Path.Combine(titleModsPath, "cheats", "enabled.txt");

            string[] enabled = Array.Empty<string>();
=======
            LoadedCheats = new AvaloniaList<CheatsList>();

            Heading = LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.CheatWindowHeading, titleName, titleId.ToUpper());
            BuildId = ApplicationData.GetApplicationBuildId(virtualFileSystem, titlePath);
            
            InitializeComponent();

            string modsBasePath = ModLoader.GetModsBasePath();
            string titleModsPath = ModLoader.GetTitleDir(modsBasePath, titleId);
            ulong titleIdValue = ulong.Parse(titleId, System.Globalization.NumberStyles.HexNumber);

            _enabledCheatsPath = Path.Combine(titleModsPath, "cheats", "enabled.txt");

            string[] enabled = { };
>>>>>>> 1ec71635b (sync with main branch)

            if (File.Exists(_enabledCheatsPath))
            {
                enabled = File.ReadAllLines(_enabledCheatsPath);
            }

            int cheatAdded = 0;

            var mods = new ModLoader.ModCache();

            ModLoader.QueryContentsDir(mods, new DirectoryInfo(Path.Combine(modsBasePath, "contents")), titleIdValue);

            string currentCheatFile = string.Empty;
            string buildId = string.Empty;
<<<<<<< HEAD

            CheatNode currentGroup = null;
=======
            string parentPath = string.Empty;

            CheatsList currentGroup = null;
>>>>>>> 1ec71635b (sync with main branch)

            foreach (var cheat in mods.Cheats)
            {
                if (cheat.Path.FullName != currentCheatFile)
                {
                    currentCheatFile = cheat.Path.FullName;
<<<<<<< HEAD
                    string parentPath = currentCheatFile.Replace(titleModsPath, "");

                    buildId = Path.GetFileNameWithoutExtension(currentCheatFile).ToUpper();
                    currentGroup = new CheatNode("", buildId, parentPath, true);
=======
                    parentPath = currentCheatFile.Replace(titleModsPath, "");

                    buildId = Path.GetFileNameWithoutExtension(currentCheatFile).ToUpper();
                    currentGroup = new CheatsList(buildId, parentPath);
>>>>>>> 1ec71635b (sync with main branch)

                    LoadedCheats.Add(currentGroup);
                }

<<<<<<< HEAD
                var model = new CheatNode(cheat.Name, buildId, "", false, enabled.Contains($"{buildId}-{cheat.Name}"));
                currentGroup?.SubNodes.Add(model);
=======
                var model = new CheatModel(cheat.Name, buildId, enabled.Contains($"{buildId}-{cheat.Name}"));
                currentGroup?.Add(model);
>>>>>>> 1ec71635b (sync with main branch)

                cheatAdded++;
            }

            if (cheatAdded == 0)
            {
                NoCheatsFound = true;
            }

            DataContext = this;
<<<<<<< HEAD

=======
            
>>>>>>> 1ec71635b (sync with main branch)
            Title = $"Ryujinx {Program.Version} - " + LocaleManager.Instance[LocaleKeys.CheatWindowTitle];
        }

        public void Save()
        {
            if (NoCheatsFound)
            {
                return;
            }

<<<<<<< HEAD
            List<string> enabledCheats = new();

            foreach (var cheats in LoadedCheats)
            {
                foreach (var cheat in cheats.SubNodes)
=======
            List<string> enabledCheats = new List<string>();

            foreach (var cheats in LoadedCheats)
            {
                foreach (var cheat in cheats)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    if (cheat.IsEnabled)
                    {
                        enabledCheats.Add(cheat.BuildIdKey);
                    }
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(_enabledCheatsPath));

            File.WriteAllLines(_enabledCheatsPath, enabledCheats);

            Close();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
