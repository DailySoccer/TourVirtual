using UnityEngine;
using System.Collections;

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
        UserAPI.AvatarDesciptor.Sex = gender;
        maxModel = (PlayerManager.Instance.Selector[UserAPI.AvatarDesciptor.Sex] as ArrayList).Count;
        UpdateAvatarDesciptor();
        StartCoroutine(LoadModel());
    }


    public void OnSelectButton() {
        // Guarda el avatar en el servidor.
        if (UserAPI.Instance != null) {
            UserAPI.Instance.UpdateAvatar();
            UserAPI.Instance.SendAvatar( PlayerManager.Instance.RenderModel(lastInstance) );
        }

        StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) => {
            instance.layer = LayerMask.NameToLayer("Player");
            Player thePlayer = Player.Instance;
            if (thePlayer != null) thePlayer.Avatar = instance;

            RoomManager roomManager = RoomManager.Instance;
            if (roomManager != null) roomManager.ToRoom("AVATAR");
        }));
	}
	
	IEnumerator LoadModel() {
		if (lastInstance != null) Destroy(lastInstance);
        yield return StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance)=>{
            lastInstance = instance;
            instance.GetComponent<Rigidbody>().isKinematic = true;
            instance.GetComponent<SynchNet>().enabled = false;
        }) );
    }

    void UpdateAvatarDesciptor() {
        // Pillar los descriptores de cara y pelo de algun sitio
        Hashtable headesc = (PlayerManager.Instance.Selector[UserAPI.AvatarDesciptor.Sex] as ArrayList)[shownModel] as Hashtable;
        UserAPI.AvatarDesciptor.Hair = headesc["Hair"] as string;
        UserAPI.AvatarDesciptor.Head = headesc["Head"] as string;
        UserAPI.AvatarDesciptor.Body = ((PlayerManager.Instance.Bodies[UserAPI.AvatarDesciptor.Sex] as ArrayList)[0] as Hashtable)["id"] as string;
        UserAPI.AvatarDesciptor.Legs = ((PlayerManager.Instance.Legs[UserAPI.AvatarDesciptor.Sex] as ArrayList)[0] as Hashtable)["id"] as string;
        UserAPI.AvatarDesciptor.Feet = ((PlayerManager.Instance.Feet[UserAPI.AvatarDesciptor.Sex] as ArrayList)[0] as Hashtable)["id"] as string;
        UserAPI.AvatarDesciptor.Compliment = ((PlayerManager.Instance.Compliments[UserAPI.AvatarDesciptor.Sex] as ArrayList)[0] as Hashtable)["id"] as string;

        Debug.LogError(">>>>> " + UserAPI.AvatarDesciptor.ToString());
        PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
    }

    void OnEnable() {

        maxModel = (PlayerManager.Instance.Heads["Man"] as ArrayList).Count;
        OnSelectGender("Man");
 	}

}