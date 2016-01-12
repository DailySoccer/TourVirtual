using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

namespace GifUtility
{
    public class GifFrame
    {
        private ImageDescriptor _imgDes;
        private UnityEngine.Texture2D _img;
        private int _colorSize = 3;
        private byte[] _lct;
        private GraphicEx _graphicEx;
        private byte[] _buffer;

        public Color32 BgColor
        {
            get {
                Color32[] act = PaletteHelper.GetColor32s(LocalColorTable);
                return act[GraphicExtension.TranIndex];
            }
        }

        public ImageDescriptor ImageDescriptor
        {
            get { return _imgDes; }
            set { _imgDes = value; }
        }

        public Color32[] Palette
        {
            get
            {
                Color32[] act = PaletteHelper.GetColor32s(LocalColorTable);
                if (GraphicExtension != null && GraphicExtension.TransparencyFlag)
                {
                    act[GraphicExtension.TranIndex] = new Color32();
                }
                return act;
            }
        }

        public UnityEngine.Texture2D Image
        {
            get { return _img; }
            set { _img = value; }
        }

        public int ColorDepth
        {
            get
            {
                return _colorSize;
            }
            set
            {
                _colorSize = value;
            }
        }

        public byte[] LocalColorTable
        {
            get { return _lct; }
            set { _lct = value; }
        }

        public GraphicEx GraphicExtension
        {
            get { return _graphicEx; }
            set { _graphicEx = value; }
        }

        public short Delay
        {
            get { return _graphicEx.Delay; }
            set { _graphicEx.Delay = value; }
        }

        public byte[] IndexedPixel
        {
            get { return _buffer; }
            set { _buffer = value; }
        }
    }
}
