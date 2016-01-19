using UnityEngine;
using System.Collections;

public class SelectAvatar : MonoBehaviour {

	public AvatarsLibraryPrefabs library;
    public GameObject prefabMale;
    public GameObject prefabFemale;
    public Material baseMaterial;
    public Texture2D textureNumbers;
    public float textureSize = 512;

    public GameObject testHead;
    public GameObject testBody;
    public GameObject testLegs;
    public GameObject testFeet;


    public Texture2D textureSkin;
    public Texture2D textureBody;
    public Texture2D textureLegs;
    public Texture2D textureShoes;
    public Texture2D textureHair;

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

        Assign(testHead, lastInstance.transform.FindChild("Cabeza"), baseMaterial);
        Assign(testBody, lastInstance.transform.FindChild("Torso"), baseMaterial);
        Assign(testLegs, lastInstance.transform.FindChild("Piernas"), baseMaterial);
        Assign(testFeet, lastInstance.transform.FindChild("Pies"), baseMaterial);


        RenderTexture rt = RenderTexture.GetTemporary((int)textureSize, (int)textureSize);

        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);

        Graphics.DrawTexture(new Rect(0, 0, textureSize * 0.5f, textureSize * 0.5f), textureSkin);
        Graphics.DrawTexture(new Rect(textureSize * 0.5f, 0, textureSize * 0.5f, textureSize * 0.5f), textureBody);
        Graphics.DrawTexture(new Rect(0, textureSize * 0.5f, textureSize * 0.5f, textureSize * 0.5f), textureLegs);
        Graphics.DrawTexture(new Rect(textureSize * 0.5f, textureSize * 0.5f, textureSize * 0.25f, textureSize * 0.25f), textureShoes);
        Graphics.DrawTexture(new Rect(textureSize * 0.75f, textureSize * 0.5f, textureSize * 0.25f, textureSize * 0.25f), textureHair);

        Texture2D dst = new Texture2D((int)textureSize, (int)textureSize);
        dst.ReadPixels(new Rect(0, 0, textureSize, textureSize), 0, 0);
        dst.Apply();

        RenderTexture.active = null;

        RenderTexture.ReleaseTemporary(rt);

        baseMaterial.mainTexture = dst;
        GL.PopMatrix();

        lastInstance.SetActive(true);

        RenderTexture.active = null; // Restore


    }

    void Assign(GameObject prefab, Transform target, Material mat) {
        var smrOrg = prefab.GetComponent<SkinnedMeshRenderer>();
        var smrDst = target.GetComponent<SkinnedMeshRenderer>();

        Transform[] bones = smrOrg.bones;
        for (int i = 0; i < bones.Length; ++i)
            bones[i] = SearchHierarchyForBone(target.parent, bones[i].name);
        smrDst.bones = bones;

        smrDst.sharedMesh = smrOrg.sharedMesh;
        Material[] mats = smrDst.sharedMaterials;
        for( int i=0;i< mats.Length; ++i)
            mats[i] = mat;
        smrDst.sharedMaterials = mats;
    }

    public Transform SearchHierarchyForBone(Transform current, string name) {
        if (current.name == name)
            return current;
        for (int i = 0; i < current.childCount; ++i) {
            Transform found = SearchHierarchyForBone( current.GetChild(i), name );
            if (found != null)
                return found;
        }
        return null;
    }


    void Awake() {
	}

	void OnEnable() {
        StartCoroutine(LoadModel() );
	}
}
