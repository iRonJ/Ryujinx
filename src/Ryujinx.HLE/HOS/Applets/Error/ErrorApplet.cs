<<<<<<< HEAD
using LibHac.Common;
=======
﻿using LibHac.Common;
>>>>>>> 1ec71635b (sync with main branch)
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.Ncm;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Services.Am.AppletAE;
using Ryujinx.HLE.HOS.SystemState;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Ryujinx.HLE.HOS.Applets.Error
{
    internal partial class ErrorApplet : IApplet
    {
        private const long ErrorMessageBinaryTitleId = 0x0100000000000801;

<<<<<<< HEAD
        private readonly Horizon _horizon;
        private AppletSession _normalSession;
        private CommonArguments _commonArguments;
        private ErrorCommonHeader _errorCommonHeader;
        private byte[] _errorStorage;
=======
        private Horizon           _horizon;
        private AppletSession     _normalSession;
        private CommonArguments   _commonArguments;
        private ErrorCommonHeader _errorCommonHeader;
        private byte[]            _errorStorage;
>>>>>>> 1ec71635b (sync with main branch)

        public event EventHandler AppletStateChanged;

        [GeneratedRegex(@"[^\u0000\u0009\u000A\u000D\u0020-\uFFFF]..")]
        private static partial Regex CleanTextRegex();

        public ErrorApplet(Horizon horizon)
        {
            _horizon = horizon;
        }

        public ResultCode Start(AppletSession normalSession, AppletSession interactiveSession)
        {
<<<<<<< HEAD
            _normalSession = normalSession;
=======
            _normalSession   = normalSession;
>>>>>>> 1ec71635b (sync with main branch)
            _commonArguments = IApplet.ReadStruct<CommonArguments>(_normalSession.Pop());

            Logger.Info?.PrintMsg(LogClass.ServiceAm, $"ErrorApplet version: 0x{_commonArguments.AppletVersion:x8}");

<<<<<<< HEAD
            _errorStorage = _normalSession.Pop();
            _errorCommonHeader = IApplet.ReadStruct<ErrorCommonHeader>(_errorStorage);
            _errorStorage = _errorStorage.Skip(Marshal.SizeOf<ErrorCommonHeader>()).ToArray();
=======
            _errorStorage      = _normalSession.Pop();
            _errorCommonHeader = IApplet.ReadStruct<ErrorCommonHeader>(_errorStorage);
            _errorStorage      = _errorStorage.Skip(Marshal.SizeOf<ErrorCommonHeader>()).ToArray();
>>>>>>> 1ec71635b (sync with main branch)

            switch (_errorCommonHeader.Type)
            {
                case ErrorType.ErrorCommonArg:
                    {
                        ParseErrorCommonArg();

                        break;
                    }
                case ErrorType.ApplicationErrorArg:
                    {
                        ParseApplicationErrorArg();

                        break;
                    }
<<<<<<< HEAD
                default:
                    throw new NotImplementedException($"ErrorApplet type {_errorCommonHeader.Type} is not implemented.");
=======
                default: throw new NotImplementedException($"ErrorApplet type {_errorCommonHeader.Type} is not implemented.");
>>>>>>> 1ec71635b (sync with main branch)
            }

            AppletStateChanged?.Invoke(this, null);

            return ResultCode.Success;
        }

<<<<<<< HEAD
        private static (uint module, uint description) HexToResultCode(uint resultCode)
=======
        private (uint module, uint description) HexToResultCode(uint resultCode)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return ((resultCode & 0x1FF) + 2000, (resultCode >> 9) & 0x3FFF);
        }

<<<<<<< HEAD
        private static string SystemLanguageToLanguageKey(SystemLanguage systemLanguage)
        {
            return systemLanguage switch
            {
#pragma warning disable IDE0055 // Disable formatting
=======
        private string SystemLanguageToLanguageKey(SystemLanguage systemLanguage)
        {
            return systemLanguage switch
            {
>>>>>>> 1ec71635b (sync with main branch)
                SystemLanguage.Japanese             => "ja",
                SystemLanguage.AmericanEnglish      => "en-US",
                SystemLanguage.French               => "fr",
                SystemLanguage.German               => "de",
                SystemLanguage.Italian              => "it",
                SystemLanguage.Spanish              => "es",
                SystemLanguage.Chinese              => "zh-Hans",
                SystemLanguage.Korean               => "ko",
                SystemLanguage.Dutch                => "nl",
                SystemLanguage.Portuguese           => "pt",
                SystemLanguage.Russian              => "ru",
                SystemLanguage.Taiwanese            => "zh-HansT",
                SystemLanguage.BritishEnglish       => "en-GB",
                SystemLanguage.CanadianFrench       => "fr-CA",
                SystemLanguage.LatinAmericanSpanish => "es-419",
                SystemLanguage.SimplifiedChinese    => "zh-Hans",
                SystemLanguage.TraditionalChinese   => "zh-Hant",
                SystemLanguage.BrazilianPortuguese  => "pt-BR",
<<<<<<< HEAD
                _                                   => "en-US",
#pragma warning restore IDE0055
=======
                _                                   => "en-US"
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static string CleanText(string value)
        {
            return CleanTextRegex().Replace(value, "").Replace("\0", "");
        }

        private string GetMessageText(uint module, uint description, string key)
        {
            string binaryTitleContentPath = _horizon.ContentManager.GetInstalledContentPath(ErrorMessageBinaryTitleId, StorageId.BuiltInSystem, NcaContentType.Data);

<<<<<<< HEAD
            using LibHac.Fs.IStorage ncaFileStream = new LocalStorage(FileSystem.VirtualFileSystem.SwitchPathToSystemPath(binaryTitleContentPath), FileAccess.Read, FileMode.Open);
            Nca nca = new(_horizon.Device.FileSystem.KeySet, ncaFileStream);
            IFileSystem romfs = nca.OpenFileSystem(NcaSectionType.Data, _horizon.FsIntegrityCheckLevel);
            string languageCode = SystemLanguageToLanguageKey(_horizon.State.DesiredSystemLanguage);
            string filePath = $"/{module}/{description:0000}/{languageCode}_{key}";

            if (romfs.FileExists(filePath))
            {
                using var binaryFile = new UniqueRef<IFile>();

                romfs.OpenFile(ref binaryFile.Ref, filePath.ToU8Span(), OpenMode.Read).ThrowIfFailure();
                StreamReader reader = new(binaryFile.Get.AsStream(), Encoding.Unicode);

                return CleanText(reader.ReadToEnd());
            }
            else
            {
                return "";
=======
            using (LibHac.Fs.IStorage ncaFileStream = new LocalStorage(_horizon.Device.FileSystem.SwitchPathToSystemPath(binaryTitleContentPath), FileAccess.Read, FileMode.Open))
            {
                Nca         nca          = new Nca(_horizon.Device.FileSystem.KeySet, ncaFileStream);
                IFileSystem romfs        = nca.OpenFileSystem(NcaSectionType.Data, _horizon.FsIntegrityCheckLevel);
                string      languageCode = SystemLanguageToLanguageKey(_horizon.State.DesiredSystemLanguage);
                string      filePath     = $"/{module}/{description:0000}/{languageCode}_{key}";

                if (romfs.FileExists(filePath))
                {
                    using var binaryFile = new UniqueRef<IFile>();

                    romfs.OpenFile(ref binaryFile.Ref, filePath.ToU8Span(), OpenMode.Read).ThrowIfFailure();
                    StreamReader reader = new StreamReader(binaryFile.Get.AsStream(), Encoding.Unicode);

                    return CleanText(reader.ReadToEnd());
                }
                else
                {
                    return "";
                }
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        private string[] GetButtonsText(uint module, uint description, string key)
        {
            string buttonsText = GetMessageText(module, description, key);

            return (buttonsText == "") ? null : buttonsText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        private void ParseErrorCommonArg()
        {
            ErrorCommonArg errorCommonArg = IApplet.ReadStruct<ErrorCommonArg>(_errorStorage);

<<<<<<< HEAD
            uint module = errorCommonArg.Module;
=======
            uint module      = errorCommonArg.Module;
>>>>>>> 1ec71635b (sync with main branch)
            uint description = errorCommonArg.Description;

            if (_errorCommonHeader.MessageFlag == 0)
            {
                (module, description) = HexToResultCode(errorCommonArg.ResultCode);
            }

            string message = GetMessageText(module, description, "DlgMsg");

            if (message == "")
            {
                message = "An error has occured.\n\n"
                        + "Please try again later.\n\n"
                        + "If the problem persists, please refer to the Ryujinx website.\n"
                        + "www.ryujinx.org";
            }

            string[] buttons = GetButtonsText(module, description, "DlgBtn");

<<<<<<< HEAD
            bool showDetails = _horizon.Device.UIHandler.DisplayErrorAppletDialog($"Error Code: {module}-{description:0000}", "\n" + message, buttons);
=======
            bool showDetails = _horizon.Device.UiHandler.DisplayErrorAppletDialog($"Error Code: {module}-{description:0000}", "\n" + message, buttons);
>>>>>>> 1ec71635b (sync with main branch)
            if (showDetails)
            {
                message = GetMessageText(module, description, "FlvMsg");
                buttons = GetButtonsText(module, description, "FlvBtn");

<<<<<<< HEAD
                _horizon.Device.UIHandler.DisplayErrorAppletDialog($"Details: {module}-{description:0000}", "\n" + message, buttons);
=======
                _horizon.Device.UiHandler.DisplayErrorAppletDialog($"Details: {module}-{description:0000}", "\n" + message, buttons);
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        private void ParseApplicationErrorArg()
        {
            ApplicationErrorArg applicationErrorArg = IApplet.ReadStruct<ApplicationErrorArg>(_errorStorage);

            byte[] messageTextBuffer = new byte[0x800];
            byte[] detailsTextBuffer = new byte[0x800];

            applicationErrorArg.MessageText.AsSpan().CopyTo(messageTextBuffer);
            applicationErrorArg.DetailsText.AsSpan().CopyTo(detailsTextBuffer);

            string messageText = Encoding.ASCII.GetString(messageTextBuffer.TakeWhile(b => !b.Equals(0)).ToArray());
            string detailsText = Encoding.ASCII.GetString(detailsTextBuffer.TakeWhile(b => !b.Equals(0)).ToArray());

<<<<<<< HEAD
            List<string> buttons = new();
=======
            List<string> buttons = new List<string>();
>>>>>>> 1ec71635b (sync with main branch)

            // TODO: Handle the LanguageCode to return the translated "OK" and "Details".

            if (detailsText.Trim() != "")
            {
                buttons.Add("Details");
            }

            buttons.Add("OK");

<<<<<<< HEAD
            bool showDetails = _horizon.Device.UIHandler.DisplayErrorAppletDialog($"Error Number: {applicationErrorArg.ErrorNumber}", "\n" + messageText, buttons.ToArray());
=======
            bool showDetails = _horizon.Device.UiHandler.DisplayErrorAppletDialog($"Error Number: {applicationErrorArg.ErrorNumber}", "\n" + messageText, buttons.ToArray());
>>>>>>> 1ec71635b (sync with main branch)
            if (showDetails)
            {
                buttons.RemoveAt(0);

<<<<<<< HEAD
                _horizon.Device.UIHandler.DisplayErrorAppletDialog($"Error Number: {applicationErrorArg.ErrorNumber} (Details)", "\n" + detailsText, buttons.ToArray());
=======
                _horizon.Device.UiHandler.DisplayErrorAppletDialog($"Error Number: {applicationErrorArg.ErrorNumber} (Details)", "\n" + detailsText, buttons.ToArray());
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public ResultCode GetResult()
        {
            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
