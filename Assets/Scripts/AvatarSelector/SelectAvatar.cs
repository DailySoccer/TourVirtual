using UnityEngine;
using System.Collections;

public class SelectAvatar : MonoBehaviour {

	public AvatarsLibraryPrefabs library;
	//public UMADynamicAvatar avatarLoaderPrefab;	
	public int shownModel = 0;

	private GameObject lastInstance = null;
	
	public void OnNextButton() {
		var maxModel = library.assetRecipes.Count;
		shownModel++;
		
		if (shownModel >= maxModel) {
			shownModel = 0;
		}
		
		LoadModel();
	}
	
	public void OnPreviousButton() {
		shownModel--;
		
		if (shownModel < 0) {
			shownModel = library.assetRecipes.Count -1;
		}
		
		LoadModel();
	}

	public void OnSelectButton() {
		GameObject newInstance = Instantiate(library.GetRecipe(shownModel));
		/*newInstance.umaRecipe = library.GetRecipe(shownModel);
		newInstance.loadOnStart = true;
		*/

		Player thePlayer = Player.Instance;
		if (thePlayer != null) {
			thePlayer.Avatar = newInstance;
		}

		PlayerManager playerManager = PlayerManager.Instance;
		if (playerManager != null) {
			playerManager.SelectedModel = shownModel;
		}

		RoomManager roomManager = RoomManager.Instance;
		if (roomManager != null) {
			roomManager.ToRoom ("AVATAR");
		}
	}
	
	public void LoadModel() {
		if (lastInstance != null) {
			Destroy(lastInstance);
		}
		
		lastInstance = Instantiate(library.GetRecipe(shownModel));
		lastInstance.layer = LayerMask.NameToLayer( "Player" );
		lastInstance.transform.position = Vector3.zero;

		lastInstance.GetComponent<Rigidbody>().isKinematic = true;



        lastInstance.GetComponent<SynchNet>().enabled = false;
        //lastInstance.GetComponent<PhotonTransformView>().enabled = false;
        //lastInstance.GetComponent<PhotonAnimatorView>().enabled = false;

        //lastInstance.AddComponent<AudioListener>();
    }

    void Awake() {
	}

	void OnEnable() {
		//library = GameObject.Find("AvatarsLibraryPrefabs").GetComponent<AvatarsLibraryPrefabs>();
		LoadModel();
	}
}
