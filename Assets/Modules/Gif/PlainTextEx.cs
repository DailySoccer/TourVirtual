using System;
using System.Collections.Generic;

namespace GifUtility
{
    internal struct PlainTextEx
    {
        internal static readonly byte BlockSize = 0X0C;
        internal short XOffSet;
        internal short YOffSet;
        internal short Width;
        internal short Height;
        internal byte CharacterCellWidth;
        internal byte CharacterCellHeight;
        internal byte ForegroundColorIndex;
        internal byte BgColorIndex;
        internal List<string> TextDatas;

        internal byte[] GetBuffer()
        {
            List<byte> list = new List<byte>();
            list.Add(GifExtensions.ExtensionIntroducer);
            list.Add(GifExtensions.PlainTextLabel);
            list.Add(BlockSize);
            list.AddRange(BitConverter.GetBytes(XOffSet));
            list.AddRange(BitConverter.GetBytes(YOffSet));
            list.AddRange(BitConverter.GetBytes(Width));
            list.AddRange(BitConverter.GetBytes(Height));
            list.Add(CharacterCellWidth);
            list.Add(CharacterCellHeight);
            list.Add(ForegroundColorIndex);
            list.Add(BgColorIndex);
            if (TextDatas != null)
            {
                foreach (string text in TextDatas)
                {
                    list.Add((byte)text.Length);
                    foreach (char c in text)
                    {
                        list.Add((byte)c);
                    }
                }
            }
            list.Add(GifExtensions.Terminator);
            return list.ToArray();
        }
    }
}