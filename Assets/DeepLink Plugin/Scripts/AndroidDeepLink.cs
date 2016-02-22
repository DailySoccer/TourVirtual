////////////////////////////////////////////////////////////////////////////////
//  
// @module Android DeepLink Plugin for Unity
// @author CausalLink Assets
// @support causallink.assets@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class AndroidDeepLink : MonoBehaviour
{

    public static string GetURL()
    {

#if UNITY_ANDROID

        try
        {
            using (AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = jclass.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent");
                AndroidJavaObject uri = intent.Call<AndroidJavaObject>("getData");
                return uri.Call<string>("toString");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(ex.Message);
            return "null";  // or replace with return null;

        }

#endif
#if !UNITY_ANDROID
            return "null";
#endif
    }


    public static string GetValueInString(string name)
    {
#if UNITY_ANDROID

        try
        {
            using (AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = jclass.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent");
                AndroidJavaObject uri = intent.Call<AndroidJavaObject>("getData");
                return uri.Call<string>("getQueryParameter", name);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(ex.Message);
            return "null"; // or replace with return null;
        }

#endif
#if !UNITY_ANDROID
                    return "null";
#endif
    }

    public static int GetValueInInt(string name)
    {
        int value = 0;
        int.TryParse(GetValueInString(name), out value);
        return value;
    }

    public static float GetValueInFloat(string name)
    {
        float value = 0.0f;
        float.TryParse(GetValueInString(name), out value);
        return value;
    }
}
