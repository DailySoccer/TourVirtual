using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class MyTools
{
    public static string AsciiToString(byte[] bytes)
    {
        return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
    }

    public static byte[] GetBytes(string str)
    {
        return System.Text.Encoding.UTF8.GetBytes(str);
    }

    public static Material Slot = null;
    public static int count = 0;
    public static IEnumerator LoadSpriteFromURL(string url, GameObject source)
    {
		if (string.IsNullOrEmpty (url)) {
			Debug.LogError("URL Vacia");
			yield break;
		}
        WWW www = new WWW(url);

        yield return www;
        if (string.IsNullOrEmpty(www.error) ) {
            www.texture.name = "TextureLoadSpriteFromURL";
#if !UNITY_WSA
            Texture2D txt = www.texture;
			Sprite s = Sprite.Create(txt, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
            www.Dispose();
            s.name = "SpriteLoadSpriteFromURL";
            s.texture.wrapMode = TextureWrapMode.Clamp;
			if(source!=null) source.GetComponent<Image>().sprite = s;
#else
            if (Slot == null) Slot = Resources.Load<Material>("Slot");
            if (source != null) {
                Image img = source.GetComponent<Image>();
                if (img != null){
                    img.sprite = null;
                    Material mat = (Material)GameObject.Instantiate(Slot);
                    Texture2D txt = www.texture;
                    txt.wrapMode = TextureWrapMode.Clamp;
                    mat.mainTexture = txt;
                    img.material = mat;
                }
            }
#endif
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

	public static void SetPlayerPrefsBool (string name, bool value) {
		
		PlayerPrefs.SetInt(name, value ? 1 : 0);
	}
	
	public static bool GetPlayerPrefsBool (string name) {
		return PlayerPrefs.GetInt(name) == 1 ? true : false;
	}
	
	public static bool GePlayerPrefsBool (string name, bool defaultValue) {
		if (PlayerPrefs.HasKey(name)) {
			return GetPlayerPrefsBool(name);
		}
		return defaultValue;
	}
}
