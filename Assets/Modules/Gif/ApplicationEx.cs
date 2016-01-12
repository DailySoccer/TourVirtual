using System.Collections.Generic;

namespace GifUtility
{
    public struct ApplicationEx
    {
        internal static readonly byte BlockSize = 0X0B;
        internal char[] ApplicationIdentifier;
        internal char[] ApplicationAuthenticationCode;
        internal List<DataStruct> Datas;
        internal byte[] GetBuffer()
        {
            List<byte> list = new List<byte>();
            list.Add(GifExtensions.ExtensionIntroducer);
            list.Add(GifExtensions.ApplicationExtensionLabel);
            list.Add(BlockSize);
            if (ApplicationIdentifier == null)
            {
                ApplicationIdentifier = "NETSCAPE".ToCharArray();
            }
            foreach (char c in ApplicationIdentifier)
            {
                list.Add((byte)c);
            }
            if (ApplicationAuthenticationCode == null)
            {
                ApplicationAuthenticationCode = "2.0".ToCharArray();
            }
            foreach (char c in ApplicationAuthenticationCode)
            {
                list.Add((byte)c);
            }
            if (Datas != null)
            {
                foreach (DataStruct ds in Datas)
                {
                    list.AddRange(ds.GetBuffer());
                }
            }
            list.Add(GifExtensions.Terminator);
            return list.ToArray();
        }
    }
}