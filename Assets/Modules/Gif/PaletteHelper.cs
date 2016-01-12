using UnityEngine;

namespace GifUtility
{
    internal class PaletteHelper
    {
        internal static Color32[] GetColor32s(byte[] table)
        {
            Color32[] tab = new Color32[table.Length / 3];
            int i = 0;
            int j = 0;
            while (i < table.Length)
            {
                byte r = table[i++];
                byte g = table[i++];
                byte b = table[i++];
                byte a = 255;
                Color32 c = new Color32(r, g, b, a);
                tab[j++] = c;
            }
            return tab;
        }
    }
}