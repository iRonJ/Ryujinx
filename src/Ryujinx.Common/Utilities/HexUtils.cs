<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Text;

namespace Ryujinx.Common
{
    public static class HexUtils
    {
<<<<<<< HEAD
        private static readonly char[] _hexChars = "0123456789ABCDEF".ToCharArray();
=======
        private static readonly char[] HexChars = "0123456789ABCDEF".ToCharArray();
>>>>>>> 1ec71635b (sync with main branch)

        private const int HexTableColumnWidth = 8;
        private const int HexTableColumnSpace = 3;

        // Modified for Ryujinx
        // Original by Pascal Ganaye - CPOL License
        // https://www.codeproject.com/Articles/36747/Quick-and-Dirty-HexDump-of-a-Byte-Array
        public static string HexTable(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null)
            {
                return "<null>";
            }

            int bytesLength = bytes.Length;

            int firstHexColumn =
                  HexTableColumnWidth
                + HexTableColumnSpace;

            int firstCharColumn = firstHexColumn
                + bytesPerLine * HexTableColumnSpace
                + (bytesPerLine - 1) / HexTableColumnWidth
                + 2;

            int lineLength = firstCharColumn
                + bytesPerLine
                + Environment.NewLine.Length;

            char[] line = (new String(' ', lineLength - Environment.NewLine.Length) + Environment.NewLine).ToCharArray();

            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;

<<<<<<< HEAD
            StringBuilder result = new(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = _hexChars[(i >> 28) & 0xF];
                line[1] = _hexChars[(i >> 24) & 0xF];
                line[2] = _hexChars[(i >> 20) & 0xF];
                line[3] = _hexChars[(i >> 16) & 0xF];
                line[4] = _hexChars[(i >> 12) & 0xF];
                line[5] = _hexChars[(i >> 8) & 0xF];
                line[6] = _hexChars[(i >> 4) & 0xF];
                line[7] = _hexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
=======
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >>  8) & 0xF];
                line[6] = HexChars[(i >>  4) & 0xF];
                line[7] = HexChars[(i >>  0) & 0xF];

                int hexColumn  = firstHexColumn;
>>>>>>> 1ec71635b (sync with main branch)
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0)
                    {
                        hexColumn++;
                    }

                    if (i + j >= bytesLength)
                    {
<<<<<<< HEAD
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
=======
                        line[hexColumn]     = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn]    = ' ';
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    else
                    {
                        byte b = bytes[i + j];

<<<<<<< HEAD
                        line[hexColumn] = _hexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = _hexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
=======
                        line[hexColumn]     = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn]    = (b < 32 ? '·' : (char)b);
>>>>>>> 1ec71635b (sync with main branch)
                    }

                    hexColumn += 3;
                    charColumn++;
                }

                result.Append(line);
            }

            return result.ToString();
        }
    }
}
