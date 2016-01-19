using UnityEngine;
using UnityEditor;

// ---------------------------------------------------------------------------------------------------------------------------
// Texture import filter
// ---------------------------------------------------------------------------------------------------------------------------

[System.Serializable]
public class Inverse : BaseFilter
{
    [SerializeField]
    public bool status;
    [SerializeField]
    public int textureId;

    public override string FilterName { get { return "Inverse"; } }
    public override void OnGUI(AssetImporter assetImporter)
    {
        status = GUILayout.Toggle(status, "Negative");
        textureId = ObjectField<Texture2D>("Other texture", textureId);
    }

    public override void Process(Texture2D texture)
    {
        for (var m = 0; m < texture.mipmapCount; m++)
        {
            Color[] c = texture.GetPixels(m);
            for (var i = 0; i < c.Length; i++)
            {
                c[i].r = 1 - c[i].r;
                c[i].g = 1 - c[i].g;
                c[i].b = 1 - c[i].b;
            }
            texture.SetPixels(c, m);
        }
    }
}
