using UnityEngine;
using System.Collections.Generic;

public class DeepLinkingManager : Photon.PunBehaviour
{
    public static bool IsEditAvatar;
    public static string URL;
    public static Dictionary<string, object> Parameters = new Dictionary<string, object>();


	// He quitado esto porque hace que se logue n veces.

	private void OnApplicationFocus(bool focusStatus)
	{
		Debug.Log("DeepLinkingManager::OnApplicationFocus>> Focus=" + focusStatus);

		if(!focusStatus)
			return;

	    var url = Authentication.AzureServices.CheckDeepLinking();

		// HACK FRS 170308 Quizá habría que reiniciar desde el main start...  
		if(!string.IsNullOrEmpty(url))
		{
			Debug.LogError(">>>>> SetDeepLinking ---> " + url);
			System.Uri uri = new System.Uri(url);
			URL = WWW.UnEscapeURL(url);

			IsEditAvatar = uri.Host == "editavatar";

			var pair = url.Split('?');
			Parameters.Clear();
			if(pair.Length == 2) {
				var pars = pair[1].Split('&');
				foreach(var p in pars) {
					var par = p.Split('=');
					if(par.Length == 2) 
						Parameters.Add(par[0], par[1]);
				}
			}
		}

		Debug.Log("DeepLinkingManager::OnApplicationFocus>> Current User=" + UserAPI.Instance.UserID 
			+ "; AvatarDescriptor=" + UserAPI.AvatarDescriptor);

		// Miro, primero que este logado...
	    if (!string.IsNullOrEmpty(UserAPI.Instance.UserID) && UserAPI.Instance.CheckIsOtherUser())
		{  
			Debug.Log("DeepLinkingManager::OnApplicationFocus>> Is other user!!");		  
			StartCoroutine(CanvasRootController.Instance.FadeOut(2));
	    }
		else if (IsEditAvatar)
		{
			if(string.IsNullOrEmpty(UserAPI.Instance.UserID))
				UserAPI.Instance.OnUserLogin += OnUserLogin;
			else
				DoDeepLinking();
		}
	}

	private static void DoDeepLinking()
	{
		// Mira si  esta editando el avatar.
		if (!IsEditAvatar)
			return;

		Debug.Log("DeepLinkingManager::DoDeepLinking");
		
		// Tengo que ver para que viene el deeplinking.
		if(RoomManager.Instance != null && UserAPI.Instance.Online && !UserAPI.Instance.errorLogin) {
			Debug.Log("DeepLinkingManager::DoDeepLinking>> IsEditAvatar; AvatarDescriptor=" + UserAPI.AvatarDescriptor);

			if(RoomManager.Instance.Room.Id != "VESTIDORLITE") 
				RoomManager.Instance.GotoRoom("VESTIDORLITE");	 
			else  
				FindObjectOfType<VestidorCanvasController_Lite>().ShowClothesShop();
			
		}
	}

	private static void OnUserLogin()
	{
		Debug.Log("DeepLinkingManager::OnUserLogin>> AvatarDescriptor=" + UserAPI.AvatarDescriptor);
		UserAPI.Instance.OnUserLogin -= OnUserLogin;

		DoDeepLinking();
	}
}

