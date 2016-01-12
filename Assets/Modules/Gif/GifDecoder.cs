using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GifUtility
{
    public class GifDecoder
    {
        long firstFrame;
        MemoryStream fs;
        StreamHelper streamHelper = null;
        public GifImage gifImage = new GifImage();
        GraphicEx graphics;
        public Texture2D texture;
        GifFrame frame = new GifFrame();
        LZWDecoder lzwDecoder;

        float nextFrame = 0;

        public GifDecoder(byte[] bytes)
        {
            fs = new System.IO.MemoryStream(bytes);

            streamHelper = new StreamHelper(fs);
            gifImage.Header = streamHelper.ReadString(6);
            gifImage.LogicalScreenDescriptor = streamHelper.GetLCD(fs);
            if (gifImage.LogicalScreenDescriptor.GlobalColorTableFlag)
                gifImage.GlobalColorTable = streamHelper.ReadByte(gifImage.LogicalScreenDescriptor.GlobalColorTableSize * 3);

            texture = new Texture2D(gifImage.Width, gifImage.Height);

            lzwDecoder = new LZWDecoder(fs, bytes, gifImage.Width * gifImage.Height);

            firstFrame = fs.Position;

        }

        ImageDescriptor imgDes;
        int dataSize;
        void ReadImageStart()
        {
            nextFrame = Time.realtimeSinceStartup + graphics.Delay / 150.0f;
            imgDes = streamHelper.GetImageDescriptor(fs);

            frame.ImageDescriptor = imgDes;
            frame.LocalColorTable = gifImage.GlobalColorTable;
            if (imgDes.LctFlag) frame.LocalColorTable = streamHelper.ReadByte(imgDes.LctSize * 3);

            dataSize = streamHelper.Read();
            frame.ColorDepth = dataSize;
        }

        void ReadImageLoop()
        {
            if (finished)
            {
                ReadImageEnd(lzwDecoder.pixels);
                
            }
            else
            {
                if (pending == false) ReadImageStart(); // Iniciando la lectura de la imagen...
                finished = lzwDecoder.DecodeImageData(imgDes.Width, imgDes.Height, dataSize, !pending);
                pending = !finished;


            }
        }

        void ReadImageEnd(byte[] piexel)
        {
            frame.IndexedPixel = piexel;
            int blockSize = streamHelper.Read();
            // DataStruct data = new DataStruct(blockSize, fs);
            fs.Seek(blockSize, SeekOrigin.Current);

            frame.GraphicExtension = graphics;

            Profiler.BeginSample("GetImageFromPixel");
            Color32[] img = GetImageFromPixel(piexel, imgDes.Width * imgDes.Height, frame.Palette, imgDes.InterlaceFlag, imgDes.Width, imgDes.Height);
            Profiler.EndSample();

            Profiler.BeginSample("SetPixels32");
            texture.SetPixels32(imgDes.XOffSet, imgDes.YOffSet, imgDes.Width, imgDes.Height, img);
            Profiler.EndSample();

            Profiler.BeginSample("Apply");
            texture.Apply();
            Profiler.EndSample();

            finished = false;
        }

        unsafe Color32[] GetImageFromPixel(byte[] pixel, int length, Color32[] colorTable, bool interlactFlag, int iw, int ih)
        {
            Color32[] colors = new Color32[iw * ih];
            fixed (Color32* tempPointer = &colors[0])
            {
                Color32* p = tempPointer;
                int offSet = 0;
                if (interlactFlag)
                {

                    int i = 0;
                    int pass = 0;
                    while (pass < 4)
                    {

                        if (pass == 1)
                        {
                            p = tempPointer;
                            p += (4 * iw);
                            offSet += 4 * iw;
                        }
                        else if (pass == 2)
                        {
                            p = tempPointer;
                            p += (2 * iw);
                            offSet += 2 * iw;
                        }
                        else if (pass == 3)
                        {
                            p = tempPointer;
                            p += (1 * iw);
                            offSet += 1 * iw;
                        }
                        int rate = 2;
                        if (pass == 0 | pass == 1)
                        {
                            rate = 8;
                        }
                        else if (pass == 2)
                        {
                            rate = 4;
                        }
                        while (i < length)
                        {
                            *p++ = colorTable[pixel[i++]];
                            offSet++;
                            if (i % (iw) == 0)
                            {
                                p += (iw * (rate - 1));
                                offSet += (iw * (rate - 1));
                                if (offSet >= length)
                                {
                                    pass++;
                                    offSet = 0;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    int i = 0;
                    for (i = 0; i < length;)
                    {
                        * p++ = colorTable[pixel[i++]];
                    }
                }
            }
            return colors;
        }

        bool pending = false;
        bool finished = false;

        public void Play() {
            if (pending || finished)
                ReadImageLoop();
            else
            {
                if (Time.realtimeSinceStartup < nextFrame) return;

                int nextFlag = streamHelper.Read();
                while (nextFlag != 0)
                {
                    if (nextFlag == GifExtensions.ImageLabel) {
                        ReadImageLoop();
                        return;
                    }
                    else if (nextFlag == GifExtensions.ExtensionIntroducer)
                    {
                        Profiler.BeginSample("ExtensionIntroducer");
                        int gcl = streamHelper.Read();
                        switch (gcl)
                        {
                            case GifExtensions.GraphicControlLabel:
                                {
                                    graphics = streamHelper.GetGraphicControlExtension(fs);
                                    break;
                                }
                            case GifExtensions.CommentLabel:
                                {
                                    streamHelper.GetCommentEx(fs);
                                    break;
                                }
                            case GifExtensions.ApplicationExtensionLabel:
                                {
                                    streamHelper.GetApplicationEx(fs);
                                    break;
                                }
                            case GifExtensions.PlainTextLabel:
                                {
                                    streamHelper.GetPlainTextEx(fs);
                                    break;
                                }
                        }
                        Profiler.EndSample();
                    }
                    else if (nextFlag == GifExtensions.EndIntroducer)
                    {
                        fs.Position = firstFrame;
                    }
                    nextFlag = streamHelper.Read();
                }
            }
        }
    }
}
  