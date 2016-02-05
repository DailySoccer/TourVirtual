using UnityEngine;
using System.Collections;

public class SelectAvatar : MonoBehaviour {
	public AvatarsLibraryPrefabs library;

    public GameObject testHead;
    public GameObject testBody;
    public GameObject testLegs;
    public GameObject testFeet;

    //public UMADynamicAvatar avatarLoaderPrefab;	
    public int shownModel = 0;
    public int maxModel = 10;

    private GameObject lastInstance = null;
	
	public void OnNextButton() {
		shownModel++;
        if (shownModel >= maxModel) shownModel = 0;
		StartCoroutine( LoadModel() );
	}
	
	public void OnPreviousButton() {
		shownModel--;
        if (shownModel < 0) shownModel = maxModel - 1;
        StartCoroutine( LoadModel() );
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
        UserAPI.AvatarDesciptor.Head = ((PlayerManager.Instance.Heads[UserAPI.AvatarDesciptor.Sex] as ArrayList)[shownModel] as Hashtable)["id"] as string;
        UserAPI.AvatarDesciptor.Body = ((PlayerManager.Instance.Bodies[UserAPI.AvatarDesciptor.Sex] as ArrayList)[10] as Hashtable)["id"] as string;
        UserAPI.AvatarDesciptor.Legs = ((PlayerManager.Instance.Legs[UserAPI.AvatarDesciptor.Sex] as ArrayList)[0] as Hashtable)["id"] as string;
        UserAPI.AvatarDesciptor.Feet = ((PlayerManager.Instance.Feet[UserAPI.AvatarDesciptor.Sex] as ArrayList)[0] as Hashtable)["id"] as string;
        PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
    }

    void OnEnable() {
        UserAPI.AvatarDesciptor.Sex = "Woman";
        UpdateAvatarDesciptor();
        StartCoroutine(LoadModel() );
	}
}