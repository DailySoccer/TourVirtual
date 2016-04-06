using UnityEngine;

public class PlayerMaterialMemory : MonoBehaviour {
    public Material matMaterial;
    public Material matCompliment;
    public void OnDestroy() {
        // Elimina las meshes.
        foreach (SkinnedMeshRenderer smr in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
            DestroyImmediate(smr.sharedMesh, true);
        // Elimina los materiales.
        if (matMaterial != null) {
            if(matMaterial.mainTexture != null) DestroyImmediate(matMaterial.mainTexture,true);
            Destroy(matMaterial);
        }
        if (matCompliment != null){
            // No lo destruyo porque no se instancia la textura, no se si es buena o mala idea...
            //if(matCompliment.mainTexture!=null) DestroyImmediate(matCompliment.mainTexture,true);
            Destroy(matCompliment);
        }
    }
}
