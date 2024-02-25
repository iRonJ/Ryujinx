using Ryujinx.Common.Logging;
using System;
using System.IO;
using System.Text;

namespace Ryujinx.HLE.Loaders.Mods
{
    class IPSwitchPatcher
    {
        const string BidHeader = "@nsobid-";

        private enum Token
        {
            Normal,
            String,
            EscapeChar,
<<<<<<< HEAD
            Comment,
=======
            Comment
>>>>>>> 1ec71635b (sync with main branch)
        }

        private readonly StreamReader _reader;
        public string BuildId { get; }

        public IPSwitchPatcher(StreamReader reader)
        {
            string header = reader.ReadLine();
            if (header == null || !header.StartsWith(BidHeader))
            {
                Logger.Error?.Print(LogClass.ModLoader, "IPSwitch:    Malformed PCHTXT file. Skipping...");

                return;
            }

            _reader = reader;
<<<<<<< HEAD
            BuildId = header[BidHeader.Length..].TrimEnd().TrimEnd('0');
=======
            BuildId = header.Substring(BidHeader.Length).TrimEnd().TrimEnd('0');
>>>>>>> 1ec71635b (sync with main branch)
        }

        // Uncomments line and unescapes C style strings within
        private static string PreprocessLine(string line)
        {
<<<<<<< HEAD
            StringBuilder str = new();
=======
            StringBuilder str = new StringBuilder();
>>>>>>> 1ec71635b (sync with main branch)
            Token state = Token.Normal;

            for (int i = 0; i < line.Length; ++i)
            {
                char c = line[i];
                char la = i + 1 != line.Length ? line[i + 1] : '\0';

                switch (state)
                {
                    case Token.Normal:
                        state = c == '"' ? Token.String :
                                c == '/' && la == '/' ? Token.Comment :
                                c == '/' && la != '/' ? Token.Comment : // Ignore error and stop parsing
                                Token.Normal;
                        break;
                    case Token.String:
                        state = c switch
                        {
<<<<<<< HEAD
                            '"' => Token.Normal,
                            '\\' => Token.EscapeChar,
                            _ => Token.String,
=======
                            '"'  => Token.Normal,
                            '\\' => Token.EscapeChar,
                            _    => Token.String
>>>>>>> 1ec71635b (sync with main branch)
                        };
                        break;
                    case Token.EscapeChar:
                        state = Token.String;
                        c = c switch
                        {
<<<<<<< HEAD
                            'a' => '\a',
                            'b' => '\b',
                            'f' => '\f',
                            'n' => '\n',
                            'r' => '\r',
                            't' => '\t',
                            'v' => '\v',
                            '\\' => '\\',
                            _ => '?',
=======
                            'a'  => '\a',
                            'b'  => '\b',
                            'f'  => '\f',
                            'n'  => '\n',
                            'r'  => '\r',
                            't'  => '\t',
                            'v'  => '\v',
                            '\\' => '\\',
                            _    => '?'
>>>>>>> 1ec71635b (sync with main branch)
                        };
                        break;
                }

<<<<<<< HEAD
                if (state == Token.Comment)
                {
                    break;
                }
=======
                if (state == Token.Comment) break;
>>>>>>> 1ec71635b (sync with main branch)

                if (state < Token.EscapeChar)
                {
                    str.Append(c);
                }
            }

            return str.ToString().Trim();
        }

        static int ParseHexByte(byte c)
        {
            if (c >= '0' && c <= '9')
            {
                return c - '0';
            }
            else if (c >= 'A' && c <= 'F')
            {
                return c - 'A' + 10;
            }
            else if (c >= 'a' && c <= 'f')
            {
                return c - 'a' + 10;
            }
            else
            {
                return 0;
            }
        }

        // Big Endian
        static byte[] Hex2ByteArrayBE(string hexstr)
        {
<<<<<<< HEAD
            if ((hexstr.Length & 1) == 1)
            {
                return null;
            }
=======
            if ((hexstr.Length & 1) == 1) return null;
>>>>>>> 1ec71635b (sync with main branch)

            byte[] bytes = new byte[hexstr.Length >> 1];

            for (int i = 0; i < hexstr.Length; i += 2)
            {
                int high = ParseHexByte((byte)hexstr[i]);
<<<<<<< HEAD
                int low = ParseHexByte((byte)hexstr[i + 1]);
=======
                int low  = ParseHexByte((byte)hexstr[i + 1]);
>>>>>>> 1ec71635b (sync with main branch)

                bytes[i >> 1] = (byte)((high << 4) | low);
            }

            return bytes;
        }

        // Auto base discovery
        private static bool ParseInt(string str, out int value)
        {
            if (str[0] == '0' && (str[1] == 'x' || str[1] == 'X'))
            {
                return int.TryParse(str.AsSpan(2), System.Globalization.NumberStyles.HexNumber, null, out value);
            }
            else
            {
                return int.TryParse(str, System.Globalization.NumberStyles.Integer, null, out value);
            }
        }

        private MemPatch Parse()
        {
            if (_reader == null)
            {
                return null;
            }

<<<<<<< HEAD
            MemPatch patches = new();

            bool enabled = false;
            bool printValues = false;
            int offsetShift = 0;
=======
            MemPatch patches = new MemPatch();

            bool enabled     = false;
            bool printValues = false;
            int offset_shift = 0;
>>>>>>> 1ec71635b (sync with main branch)

            string line;
            int lineNum = 0;

            static void Print(string s) => Logger.Info?.Print(LogClass.ModLoader, $"IPSwitch:    {s}");

            void ParseWarn() => Logger.Warning?.Print(LogClass.ModLoader, $"IPSwitch:    Parse error at line {lineNum} for bid={BuildId}");

            while ((line = _reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    enabled = false;

                    continue;
                }

                line = PreprocessLine(line);
                lineNum += 1;

                if (line.Length == 0)
                {
                    continue;
                }
                else if (line.StartsWith('#'))
                {
                    Print(line);
                }
                else if (line.StartsWith("@stop"))
                {
                    break;
                }
                else if (line.StartsWith("@enabled"))
                {
                    enabled = true;
                }
                else if (line.StartsWith("@disabled"))
                {
                    enabled = false;
                }
                else if (line.StartsWith("@flag"))
                {
                    var tokens = line.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Length < 2)
                    {
                        ParseWarn();

                        continue;
                    }

                    if (tokens[1] == "offset_shift")
                    {
<<<<<<< HEAD
                        if (tokens.Length != 3 || !ParseInt(tokens[2], out offsetShift))
=======
                        if (tokens.Length != 3 || !ParseInt(tokens[2], out offset_shift))
>>>>>>> 1ec71635b (sync with main branch)
                        {
                            ParseWarn();

                            continue;
                        }
                    }
                    else if (tokens[1] == "print_values")
                    {
                        printValues = true;
                    }
                }
                else if (line.StartsWith('@'))
                {
                    // Ignore
                }
                else
                {
                    if (!enabled)
                    {
                        continue;
                    }

                    var tokens = line.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Length < 2)
                    {
                        ParseWarn();

                        continue;
                    }

                    if (!int.TryParse(tokens[0], System.Globalization.NumberStyles.HexNumber, null, out int offset))
                    {
                        ParseWarn();

                        continue;
                    }

<<<<<<< HEAD
                    offset += offsetShift;
=======
                    offset += offset_shift;
>>>>>>> 1ec71635b (sync with main branch)

                    if (printValues)
                    {
                        Print($"print_values 0x{offset:x} <= {tokens[1]}");
                    }

                    if (tokens[1][0] == '"')
                    {
                        var patch = Encoding.ASCII.GetBytes(tokens[1].Trim('"') + "\0");
                        patches.Add((uint)offset, patch);
                    }
                    else
                    {
                        var patch = Hex2ByteArrayBE(tokens[1]);
                        patches.Add((uint)offset, patch);
                    }
                }
            }

            return patches;
        }

        public void AddPatches(MemPatch patches)
        {
            patches.AddFrom(Parse());
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
