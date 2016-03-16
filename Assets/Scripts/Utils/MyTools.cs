using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class MyTools
{
    public static string AsciiToString(byte[] bytes)
    {
#if !UNITY_WSA
        return ASCIIEncoding.UTF8.GetString(bytes);
#else
        StringBuilder sb = new StringBuilder(bytes.Length);
        foreach (byte b in bytes)
        {
            sb.Append(b <= 0x7f ? (char)b : '?');
        }
        return sb.ToString();
#endif
    }

    public static byte[] GetBytes(string str)
    {
#if !UNITY_WSA
        return Encoding.ASCII.GetBytes(str);
#else
        byte[] retval = new byte[str.Length];
        for (int ix = 0; ix < str.Length; ++ix)
        {
            char ch = str[ix];
            if (ch <= 0x7f) retval[ix] = (byte)ch;
            else retval[ix] = (byte)'?';
        }
        return retval;
#endif
    }

    public static IEnumerator LoadSpriteFromURL(string url, GameObject source)
    {
		if (string.IsNullOrEmpty (url)) {
			Debug.LogError("URL Vacia");
			yield break;
		}
        Debug.LogError(">>>> " + url);
        WWW www = new WWW(url);

        yield return www;
        if (string.IsNullOrEmpty(www.error)) {
            Texture2D txt = www.texture;
            Sprite s = Sprite.Create(txt, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
            s.texture.wrapMode = TextureWrapMode.Clamp;
            if(source!=null) source.GetComponent<Image>().sprite = s;
        }
        //yield return true;
    }

    public static string ToShortDateString(System.DateTime dt)
    {
#if !UNITY_WSA
        return dt.ToShortDateString();
#else
        return dt.ToString(System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern);
#endif
    }
    public static string ToShortTimeString(System.DateTime dt)
    {
#if !UNITY_WSA
        return dt.ToShortTimeString();
#else
        return dt.ToString(System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortTimePattern);
#endif
    }
}
