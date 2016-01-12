using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GifUtility
{
    internal class StreamHelper
    {
        Stream stream;
        internal StreamHelper(Stream stream)
        {
            this.stream = stream;
        }

        internal byte[] ReadByte(int len)
        {
            byte[] buffer = new byte[len];
            stream.Read(buffer, 0, len);
            return buffer;
        }

        internal int Read()
        {
            return stream.ReadByte();
        }

        internal short ReadShort()
        {
            byte[] buffer = new byte[2];
            stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt16(buffer, 0);
        }

        internal string ReadString(int length)
        {
            return new string(ReadChar(length));
        }

        internal char[] ReadChar(int length)
        {
            byte[] buffer = new byte[length];
            int read = stream.Read(buffer, 0, length);
            char[] charBuffer = new char[length];
            buffer.CopyTo(charBuffer, 0);
            return charBuffer;
        }


        internal ApplicationEx GetApplicationEx(Stream stream)
        {
            ApplicationEx appEx = new ApplicationEx();
            int blockSize = Read();
            if (blockSize != ApplicationEx.BlockSize)
            {
                throw new Exception("数据格式错误！");
            }
            appEx.ApplicationIdentifier = ReadChar(8);
            appEx.ApplicationAuthenticationCode = ReadChar(3);
            int nextFlag = Read();
            appEx.Datas = new List<DataStruct>();
            while (nextFlag != 0)
            {
                DataStruct data = new DataStruct(nextFlag, stream);
                appEx.Datas.Add(data);
                nextFlag = Read();
            }
            return appEx;
        }

        internal CommentEx GetCommentEx(Stream stream)
        {
            CommentEx cmtEx = new CommentEx();
            StreamHelper streamHelper = new StreamHelper(stream);
            cmtEx.CommentDatas = new List<string>();
            int nextFlag = streamHelper.Read();
            cmtEx.CommentDatas = new List<string>();
            while (nextFlag != 0)
            {
                int blockSize = nextFlag;
                string data = streamHelper.ReadString(blockSize);
                cmtEx.CommentDatas.Add(data);
                nextFlag = streamHelper.Read();
            }
            return cmtEx;
        }

        internal PlainTextEx GetPlainTextEx(Stream stream)
        {
            PlainTextEx pltEx = new PlainTextEx();
            int blockSize = Read();
            if (blockSize != PlainTextEx.BlockSize)
            {
                throw new Exception("数据格式错误！");
            }
            pltEx.XOffSet = ReadShort();
            pltEx.YOffSet = ReadShort();
            pltEx.Width = ReadShort();
            pltEx.Height = ReadShort();
            pltEx.CharacterCellWidth = (byte)Read();
            pltEx.CharacterCellHeight = (byte)Read();
            pltEx.ForegroundColorIndex = (byte)Read();
            pltEx.BgColorIndex = (byte)Read();
            int nextFlag = Read();
            pltEx.TextDatas = new List<string>();
            while (nextFlag != 0)
            {
                blockSize = nextFlag;
                string data = ReadString(blockSize);
                pltEx.TextDatas.Add(data);
                nextFlag = Read();
            }
            return pltEx;
        }

        internal ImageDescriptor GetImageDescriptor(Stream stream)
        {
            ImageDescriptor ides = new ImageDescriptor();
            ides.XOffSet = ReadShort();
            ides.YOffSet = ReadShort();
            ides.Width = ReadShort();
            ides.Height = ReadShort();

            ides.Packed = (byte)Read();
            ides.LctFlag = ((ides.Packed & 0x80) >> 7) == 1;
            ides.InterlaceFlag = ((ides.Packed & 0x40) >> 6) == 1;
            ides.SortFlag = ((ides.Packed & 0x20) >> 5) == 1;
            ides.LctSize = (2 << (ides.Packed & 0x07));
            return ides;
        }

        internal GraphicEx GetGraphicControlExtension(Stream stream)
        {
            GraphicEx gex = new GraphicEx();
            int blockSize = Read();
            if (blockSize != GraphicEx.BlockSize)
            {
                throw new Exception("数据格式错误！");
            }
            gex.Packed = (byte)Read();
            gex.TransparencyFlag = (gex.Packed & 0x01) == 1;
            gex.DisposalMethod = (gex.Packed & 0x1C) >> 2;
            gex.Delay = ReadShort();
            gex.TranIndex = (byte)Read();
            Read();
            return gex;
        }

        internal LogicalScreenDescriptor GetLCD(Stream stream)
        {
            LogicalScreenDescriptor lcd = new LogicalScreenDescriptor();
            lcd.Width = ReadShort();
            lcd.Height = ReadShort();
            lcd.Packed = (byte)Read();
            lcd.GlobalColorTableFlag = ((lcd.Packed & 0x80) >> 7) == 1;
            lcd.ColorResoluTion = (byte)((lcd.Packed & 0x60) >> 5);
            lcd.SortFlag = (byte)(lcd.Packed & 0x10) >> 4;
            lcd.GlobalColorTableSize = 2 << (lcd.Packed & 0x07);
            lcd.BgColorIndex = (byte)Read();
            lcd.PixcelAspect = (byte)Read();
            return lcd;
        }
    }
}