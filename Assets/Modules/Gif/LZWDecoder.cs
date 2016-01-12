using System.IO;
using UnityEngine;

namespace GifUtility
{
    unsafe internal class LZWDecoder
    {
        protected static readonly int MaxStackSize = 4096;
        protected Stream stream;
        protected byte[] bytes;
        internal LZWDecoder(Stream stream, byte[] bytes, int size) {
            this.bytes = bytes;
            this.stream = stream;
            this.pixels = new byte[size];
        }

        int[] prefix = new int[MaxStackSize];
        byte[] suffix = new byte[MaxStackSize];
        byte[] pixelStatck = new byte[MaxStackSize + 1];
        public byte[] pixels;


        byte* pbytes;
        byte* ppixels;
        byte* ppixelStatck;
        byte* end;
        
        int NullCode;
        int pixelCount;
        int codeSize;
        int clearFlag;
        int endFlag;
        int available;

        int code;
        int old_code;
        int code_mask;
        int bits;

        int count;
        int bi;
            
        int data;
        byte first;
        int inCode;

        internal bool DecodeImageData(int width, int height, int dataSize, bool bFirst) {
            if (bFirst)
            {
                NullCode = -1;
                pixelCount = width * height;
                codeSize = dataSize + 1;
                clearFlag = 1 << dataSize;
                endFlag = clearFlag + 1;
                available = endFlag + 1;

                code = NullCode;
                old_code = NullCode;
                code_mask = (1 << codeSize) - 1;
                bits = 0;

                count = 0;
                bi = 0;

                data = 0;
                first = 0;
                inCode = NullCode;

                for (code = 0; code < clearFlag; code++)
                {
                    prefix[code] = 0;
                    suffix[code] = (byte)code;
                }
            }
            Profiler.BeginSample("DecodeImageData Fill" );
            fixed (byte* apixels = pixels, abytes = bytes, apixelStatck = pixelStatck)
            {
                if (bFirst)
                {
                    pbytes = abytes + stream.Position;
                    ppixels = apixels;
                    ppixelStatck = apixelStatck;
                    end = ppixels + pixelCount;
                }
                byte* tempend = ppixels + (pixelCount / 4);

                while (ppixels < end)
                {
                    if (ppixelStatck == apixelStatck)
                    {
                        // Rellena el buffer.
                        if (ppixels > tempend) return false;

                        if (bits < codeSize)
                        {
                            if (count == 0)
                            {
                                // Lectura del stream
                                count = * pbytes++;
                                if (count == 0) break;
                            }
                            data += * pbytes++ << bits;
                            bits += 8;
                            bi++;
                            count--;
                            continue;
                        }
                        code = data & code_mask;
                        data >>= codeSize;
                        bits -= codeSize;

                        if (code > available || code == endFlag)
                            break;

                        if (code == clearFlag)
                        {
                            codeSize = dataSize + 1;
                            code_mask = (1 << codeSize) - 1;
                            available = clearFlag + 2;
                            old_code = NullCode;
                            continue;
                        }

                        if (old_code == NullCode)
                        {
                            *ppixelStatck++ = suffix[code];
                            old_code = code;
                            first = (byte)code;
                            continue;
                        }

                        inCode = code;
                        if (code == available) {
                            *ppixelStatck++ = first;
                            code = old_code;
                        }

                        while (code > clearFlag) {
                            *ppixelStatck++ = suffix[code];
                            code = prefix[code];
                        }

                        first = suffix[code];
                        if (available > MaxStackSize)
                            break;
                        *ppixelStatck++ = suffix[code];
                        prefix[available] = old_code;
                        suffix[available] = first;
                        available++;
                        if (available == code_mask + 1 && available < MaxStackSize) {
                            codeSize++;
                            code_mask = (1 << codeSize) - 1;
                        }
                        old_code = inCode;
                    }
                    *ppixels++ = *--ppixelStatck;
                }
                pbytes += count;
                stream.Position = (pbytes - abytes);
            }
            Profiler.EndSample();
            return true;
        }



 
    }
}