using System;
using System.IO;

namespace GifUtility
{
    public class DataStruct
    {
        internal DataStruct() { }
        private byte _blockSize = 0;
        internal byte BlockSize {
            get { return _blockSize; }
            set { _blockSize = value; }
        }

        private byte[] _data = new byte[0];
        internal byte[] Data {
            get { return _data; }
            set { _data = value; }
        }

        internal DataStruct(int blockSize, Stream stream) {
            StreamHelper streamHelper = new StreamHelper(stream);
            _blockSize = (byte)blockSize;
            if (_blockSize > 0) {
                _data = streamHelper.ReadByte(_blockSize);
            }
        }

        internal byte[] GetBuffer() {
            byte[] buffer = new byte[_blockSize + 1];
            buffer[0] = _blockSize;
            Array.Copy(_data, 0, buffer, 1, _blockSize);
            return buffer;
        }
    }
}