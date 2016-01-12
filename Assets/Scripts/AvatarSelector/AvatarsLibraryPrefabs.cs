using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarsLibraryPrefabs : MonoBehaviour {

	public static GameObject defaultRecipe;

	[SerializeField]
	public List<GameObject> assetRecipes;
	
	public GameObject GetRecipe(int id) {
		return (id >= 0 && id < assetRecipes.Count) ? assetRecipes[id] : null;
	}
	
	void Start() {
		defaultRecipe = defaultRecipe ?? GetRecipe(0);
	}
}
