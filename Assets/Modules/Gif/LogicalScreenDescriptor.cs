using System;

namespace GifUtility
{
    public class LogicalScreenDescriptor
    {
        private short _width;
        public short Width {
            get { return _width; }
            set { _width = value; }
        }

        private short _height;
        public short Height {
            get { return _height; }
            set { _height = value; }
        }

        private byte _packed;
        public byte Packed {
            get { return _packed; }
            set { _packed = value; }
        }

        private byte _bgIndex;
        public byte BgColorIndex {
            get { return _bgIndex; }
            set { _bgIndex = value; }
        }

        private byte _pixelAspect;
        public byte PixcelAspect {
            get { return _pixelAspect; }
            set { _pixelAspect = value; }
        }
        private bool _globalColorTableFlag;
        public bool GlobalColorTableFlag {
            get { return _globalColorTableFlag; }
            set { _globalColorTableFlag = value; }
        }

        private byte _colorResoluTion;
        public byte ColorResoluTion {
            get { return _colorResoluTion; }
            set { _colorResoluTion = value; }
        }

        private int _sortFlag;
        public int SortFlag {
            get { return _sortFlag; }
            set { _sortFlag = value; }
        }

        private int _globalColorTableSize;
        public int GlobalColorTableSize {
            get { return _globalColorTableSize; }
            set { _globalColorTableSize = value; }
        }

        public byte[] GetBuffer() {
            byte[] buffer = new byte[7];
            Array.Copy(BitConverter.GetBytes(_width), 0, buffer, 0, 2);
            Array.Copy(BitConverter.GetBytes(_height), 0, buffer, 2, 2);
            int m = 0;
            if (_globalColorTableFlag) {
                m = 1;
            }
            byte pixel = (byte)(Math.Log(_globalColorTableSize, 2) - 1);
            _packed = (byte)(pixel | (_sortFlag << 4) | (_colorResoluTion << 5) | (m << 7));
            buffer[4] = _packed;
            buffer[5] = _bgIndex;
            buffer[6] = _pixelAspect;
            return buffer;
        }
    }
}