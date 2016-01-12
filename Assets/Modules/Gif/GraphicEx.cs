using System;
using System.Collections.Generic;

namespace GifUtility
{
    public class GraphicEx : ExData
    {
        byte _packed;
        short _delay;
        byte _tranIndex;
        bool _transFlag;
        int _disposalMethod;

        public static readonly byte BlockSize = 4;
        public bool TransparencyFlag {
            get { return _transFlag; }
            set { _transFlag = value; }
        }

        public int DisposalMethod {
            get { return _disposalMethod; }
            set { _disposalMethod = value; }
        }

        public byte Packed {
            get { return _packed; }
            set { _packed = value; }
        }

        public short Delay {
            get { return _delay; }
            set { _delay = value; }
        }

        public byte TranIndex {
            get { return _tranIndex; }
            set { _tranIndex = value; }
        }

        public GraphicEx() { }

        public byte[] GetBuffer() {
            List<byte> list = new List<byte>();
            list.Add(GifExtensions.ExtensionIntroducer);
            list.Add(GifExtensions.GraphicControlLabel);
            list.Add(BlockSize);
            int t = 0;
            if (_transFlag)
            {
                t = 1;
            }
            _packed = (byte)((_disposalMethod << 2) | t);
            list.Add(_packed);
            list.AddRange(BitConverter.GetBytes(_delay));
            list.Add(_tranIndex);
            list.Add(GifExtensions.Terminator);
            return list.ToArray();
        }
    }
}