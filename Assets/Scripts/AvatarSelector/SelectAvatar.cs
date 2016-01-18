using UnityEngine;
using System.Collections;

public class SelectAvatar : MonoBehaviour {

	public AvatarsLibraryPrefabs library;
    public GameObject prefabMale;
    public GameObject prefabFemale;
    public Material baseMaterial;

    public GameObject testHead;
    public GameObject testBody;
    public GameObject testLegs;
    public GameObject testFeet;


    public Texture2D textureSkin;
    public Texture2D textureBody;
    public Texture2D textureLegs;
    public Texture2D textureShoes;

    //public UMADynamicAvatar avatarLoaderPrefab;	
    public int shownModel = 0;

	private GameObject lastInstance = null;
	
	public void OnNextButton() {
		var maxModel = library.assetRecipes.Count;
		shownModel++;
		
		if (shownModel >= maxModel) {
			shownModel = 0;
		}
		
		StartCoroutine( LoadModel() );
	}
	
	public void OnPreviousButton() {
		shownModel--;
		
		if (shownModel < 0) {
			shownModel = library.assetRecipes.Count -1;
		}

        StartCoroutine( LoadModel() );
	}

	public void OnSelectButton() {
        Debug.LogError(">>>>>>>>>>>>>>>>>>>>  OnSelectButton ");

        GameObject newInstance = Instantiate(prefabMale);// library.GetRecipe(shownModel));

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
	
	IEnumerator LoadModel() {
		if (lastInstance != null) {
			Destroy(lastInstance);
		}

        lastInstance = Instantiate(prefabMale);
		lastInstance.layer = LayerMask.NameToLayer( "Player" );
		lastInstance.transform.position = Vector3.zero;
        lastInstance.GetComponent<Rigidbody>().isKinematic = true;
        lastInstance.GetComponent<SynchNet>().enabled = false;

        Assign(testHead, lastInstance.transform.FindChild("Body"), baseMaterial);
        Assign(testBody, lastInstance.transform.FindChild("Tops"), baseMaterial);
        Assign(testLegs, lastInstance.transform.FindChild("Bottoms"), baseMaterial);
        Assign(testFeet, lastInstance.transform.FindChild("Shoes"), baseMaterial);

        Debug.LogError("<<<<<<<<<<<<<<<<<<<<< >>>>>>>>>>>>>>>>>>>>>>>>>");

        RenderTexture rt = RenderTexture.GetTemporary(1024, 1024);

        yield return null;
//        Graphics.Blit(textureSkin, rt);
        RenderTexture.active = rt;
        Graphics.DrawTexture(new Rect(0, 0, 512, 512), textureSkin);

        Texture2D dst = new Texture2D(1024, 1024);
        dst.ReadPixels(new Rect(0, 0, 1024, 1024), 0, 0);
        dst.Apply();

        RenderTexture.active = null;

        RenderTexture.ReleaseTemporary(rt);

        baseMaterial.mainTexture = dst;


    }

    void Assign(GameObject prefab, Transform parent, Material mat) {
        var tmpMesh = prefab.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        parent.GetComponent<SkinnedMeshRenderer>().sharedMesh = tmpMesh;
        Material[] mats = parent.GetComponent<SkinnedMeshRenderer>().sharedMaterials;
        for( int i=0;i< mats.Length; ++i)
            mats[i] = mat;
        parent.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
        

    }


    void Awake() {
	}

	void OnEnable() {
        StartCoroutine(LoadModel() );
	}
}
