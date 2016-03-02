using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class MyTools{
    public static string AsciiToString(byte[] bytes) {
#if !UNITY_WINRT
        return ASCIIEncoding.ASCII.GetString(bytes);
#else
        StringBuilder sb = new StringBuilder(bytes.Length);
        foreach (byte b in bytes) {
            sb.Append(b <= 0x7f ? (char)b : '?');
        }
        return sb.ToString();
#endif
    }
    
    public static byte[] GetBytes(string str) {
#if !UNITY_WINRT
        return Encoding.ASCII.GetBytes(str);
#else
        byte[] retval = new byte[str.Length];
        for (int ix = 0; ix < str.Length; ++ix) {
            char ch = str[ix];
            if (ch <= 0x7f) retval[ix] = (byte)ch;
            else retval[ix] = (byte)'?';
        }
        return retval;
#endif
    }

	public static IEnumerator LoadSpriteFromURL( string url, Sprite source)
	{
		WWW www = new WWW(url);
		yield return www; 
		
		source = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero, 100.0f);
		//yield return true;
	}
}
