using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace GifUtility
{
    public class GifImage
    {
        public short  Width { get { return lcd.Width; } }
        public short  Height { get { return lcd.Height; } }

        string header = "";
        public string Header {
            get { return header; }
            set { header = value; }
        }

        private byte[] gct;
        public byte[] GlobalColorTable {
            get { return gct; }
            set { gct = value; }
        }

        public Color32[] Palette {
            get {
                Color32[] act = PaletteHelper.GetColor32s(GlobalColorTable);
                act[lcd.BgColorIndex] = new Color32();
                return act;
            }
        }
        
        Hashtable table = new Hashtable();
        public Hashtable GlobalColorIndexedTable {
            get { return table; }
        }

        LogicalScreenDescriptor lcd;
        public LogicalScreenDescriptor LogicalScreenDescriptor {
            get { return lcd; }
            set { lcd = value; }
        }
    }
}