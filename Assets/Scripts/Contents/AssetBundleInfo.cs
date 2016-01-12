using UnityEngine;
using System.Collections;

public class AssetBundleInfo : MonoBehaviour {
	public string BundleKey;

	IEnumerator Start() {
		if (DLCManager.Instance == null) {
			yield break;
		}
        // Descargar el fichero de versiones.
        yield return StartCoroutine(DLCManager.Instance.LoadVersion());

        if (RoomManager.Instance.Room.ExistsBundle(BundleKey)) {
			string bundleID = RoomManager.Instance.Room.Bundle(BundleKey);
			yield return StartCoroutine(DLCManager.Instance.LoadResource(bundleID, (bundle) => {
				if (bundle != null) {
					string AssetName = "";
					foreach(string assetName in bundle.GetAllAssetNames()) {
						AssetName = assetName;
						break;
					}
					GameObject bundleGO = (string.IsNullOrEmpty(AssetName) 
					                       ? Instantiate(bundle.mainAsset, transform.position, transform.rotation) 
					                       : Instantiate(bundle.LoadAsset(AssetName), transform.position, transform.rotation)) as GameObject;

					bundleGO.transform.parent = transform.parent;
					gameObject.SetActive(false);

					Debug.Log ("AssetBundleInfo: Instantiate: " + name + " Bundle: " + bundleID);
				}
			}));
		}
		else {
			Debug.LogError("AssetBundleInfo Error: Not BundleKey: " + BundleKey + " in Room " + RoomManager.Instance.Room.Id);
		}
	}
}
