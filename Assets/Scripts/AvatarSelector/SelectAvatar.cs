using UnityEngine;
using System.Collections.Generic;

public class SelectAvatar : MonoBehaviour {
    public int shownModel = 0;
    public int maxModel = 10;

    public ButtonCheckable MaleButton;
    public ButtonCheckable FemaleButton;

    private GameObject lastInstance = null;
	
	public void OnNextButton() {
		shownModel++;
        if (shownModel >= maxModel) shownModel = 0;
        UpdateAvatarDesciptor();
        StartCoroutine( LoadModel() );
	}
	
	public void OnPreviousButton() {
		shownModel--;
        if (shownModel < 0) shownModel = maxModel - 1;
        UpdateAvatarDesciptor();
        StartCoroutine( LoadModel() );
	}

    public void OnSelectGender(string gender) {
        switch (gender) {
            case "Man":
                MaleButton.IsTabActive = true;
                FemaleButton.IsTabActive = false;
                break;
            case "Woman":
                MaleButton.IsTabActive = false;
                FemaleButton.IsTabActive = true;
                break;
        }
        UserAPI.AvatarDesciptor.Gender = gender;
        maxModel = (PlayerManager.Instance.Selector[UserAPI.AvatarDesciptor.Gender] as List<object>).Count;
        UpdateAvatarDesciptor();
        StartCoroutine(LoadModel());
    }


    public void OnSelectButton() {
        // Guarda el avatar en el servidor.
        if (UserAPI.Instance != null) {
            UserAPI.Instance.UpdateAvatar();
            UserAPI.Instance.SendAvatar( PlayerManager.Instance.RenderModel(lastInstance) );
            UserAPI.Instance.UpdateNick("Nick" + Random.Range(0, 100000));
            // Prueba de escritura de nick.

        }

        StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) => {
            UserAPI.VirtualGoodsDesciptor.FilterBySex();
            instance.layer = LayerMask.NameToLayer("Player");
            Player thePlayer = Player.Instance;
            if (thePlayer != null) thePlayer.Avatar = instance;

            RoomManager roomManager = RoomManager.Instance;
            if (roomManager != null)
            {
                // Si venimos por Deep
                if (MainManager.IsDeepLinking)
                {
                    // De momento no puedo hacer que se vista, ergo, sale direcatamente.
                    // roomManager.GotoRoom("VESTIDOR");
					Authentication.AzureServices.OpenURL("rmapp://You");
                    Application.Quit();
                }
                else roomManager.ToRoom("AVATAR");
            }
        }));
	}
	
	System.Collections.IEnumerator LoadModel() {
		if (MainManager.VestidorMode == VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR) {
			if (lastInstance != null)
				Destroy (lastInstance);
			yield return StartCoroutine (PlayerManager.Instance.CreateAvatar (PlayerManager.Instance.SelectedModel, (instance) => {
                VestidorCanvasController_Lite.PlayerInstance = instance;
                lastInstance = instance;
				instance.GetComponent<Rigidbody> ().isKinematic = true;
				instance.GetComponent<SynchNet> ().enabled = false; 
			}));
		}
    }

    void UpdateAvatarDesciptor() {
        // Pillar los descriptores de cara y pelo de algun sitio
        Dictionary<string, object> headesc = (PlayerManager.Instance.Selector[UserAPI.AvatarDesciptor.Gender] as List<object>)[shownModel] as Dictionary<string,object>;
        UserAPI.AvatarDesciptor.Hair = headesc["Hair"] as string;
        UserAPI.AvatarDesciptor.Head = headesc["Head"] as string;
        UserAPI.AvatarDesciptor.Torso = "";
        UserAPI.AvatarDesciptor.Legs = "";
        UserAPI.AvatarDesciptor.Feet = "";
        UserAPI.AvatarDesciptor.Compliment = "";
        PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
    }

    void OnEnable() {
        if (MainManager.VestidorMode == VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR)
        {
            maxModel = (PlayerManager.Instance.Heads["Man"] as List<object>).Count;
            OnSelectGender("Man");
        }
        else
            gameObject.SetActive(false);
 	}
}