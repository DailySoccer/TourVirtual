using UnityEngine;
using UnityEditor;
using System.Collections;

class MeshesPreprocessor : AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (var str in importedAssets)
        {
            if (str.Contains("Avatares") && str.Contains("Meshes"))
            {
                string newPath = str.Substring(0, str.LastIndexOf("/"));
                newPath = newPath.Substring(0, newPath.LastIndexOf("/"));

                var go = AssetDatabase.LoadAssetAtPath<GameObject>(str);
                for (int i = 0; i < go.transform.childCount; ++i) {
                    var child = go.transform.GetChild(i);
                    var smr = child.GetComponent<SkinnedMeshRenderer>();
                    if (smr != null) {
                        var ppath = newPath + "/" + go.name + ".prefab";
                        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(ppath);
                        if (prefab != null)
                        {
                            Debug.LogError(">>>> REPLACE");
                            PrefabUtility.ReplacePrefab(child.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
                        }
                        else {
                            Debug.LogError(">>>> CREATE");
                            PrefabUtility.CreatePrefab(ppath, child.gameObject, ReplacePrefabOptions.Default);
                        }
                    }


                }
                
            }
        }
    }
}