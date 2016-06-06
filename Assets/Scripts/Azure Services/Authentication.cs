using System.Collections;
using UnityEngine;

public class Authentication : MonoBehaviour {
    public static AzureInterfaz AzureServices;
	static public Authentication Instance { get; private set;  }
    void Awake() {
        Instance = this;
#if UNITY_EDITOR
        AzureServices = gameObject.AddComponent<EditorAzureInterfaz>();
#elif UNITY_ANDROID
        AzureServices = gameObject.AddComponent <AndroidAzureInterfaz>();
#elif UNITY_IOS
        AzureServices = gameObject.AddComponent <IOSAzureInterfaz>();
#elif UNITY_WSA
        AzureServices = gameObject.AddComponent <WSAAzureInterfaz>();
#endif
    }

    public enum MiniGame {
        FreeKicks,
        FreeShoots,
        HiddenObjects
    };

    string[] MiniGameID = new string[] {
        "64c478e3-a3dd-441e-94e5-f5f4fe64ceae",
        "9ca1aacd-9104-404d-87bb-909a64957c4c",
        "9c45010a-eb1c-4b51-9c2c-e2339b824e21"
    };

    public void DeepLinking(string url)
    {

    }

    public void Init() {
        Debug.LogError(">>> Call AzureServices.Init "+ AzureServices.GetType()+" <<< ");
        AzureServices.Init("p=B2C_1_SignInSignUp_TourVirtual&nonce=defaultNonce&scope=openid");        
        AzureServices.SignIn((success) => {
            StartCoroutine(UserAPI.Instance.Request());
        });
    }
}


