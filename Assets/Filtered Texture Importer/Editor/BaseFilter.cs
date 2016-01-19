using UnityEngine;
using UnityEditor;

// ---------------------------------------------------------------------------------------------------------------------------
// BaseFilter class all texture import filters must derive from
// ---------------------------------------------------------------------------------------------------------------------------

[System.Serializable]
public class BaseFilter
{
    // ---------------------------------------------------------------------------------------------------------------------------
    // Override this with the filter name
    // ---------------------------------------------------------------------------------------------------------------------------

    public virtual string FilterName { get { return "FilterName"; } }

    // ---------------------------------------------------------------------------------------------------------------------------
    
    [SerializeField] public bool IsEnabled = false; // Filter enabled?

    // ---------------------------------------------------------------------------------------------------------------------------
    // Allows defining asset fields in your OnGUI override as: assetId = ObjectField<FieldType>("Field Name", assetId);
    // ---------------------------------------------------------------------------------------------------------------------------
    
    protected int ObjectField<T>(string label, int id, params GUILayoutOption[] options) where T : Object
    {
        return ObjectField<T>(new GUIContent(label), id, options);
    }

    protected int ObjectField<T>(GUIContent label, int id, params GUILayoutOption[] options) where T : Object
    {
        Object obj = GetObject<T>(id);
        obj = EditorGUILayout.ObjectField(label, obj, typeof(T), false, options);
        return obj != null ? obj.GetInstanceID() : 0;
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    // Internal
    // ---------------------------------------------------------------------------------------------------------------------------

    protected T GetObject<T>(int id) where T : Object
    {
        return id == 0 ? default(T) : (T)EditorUtility.InstanceIDToObject(id);
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    // Draw filter
    // ---------------------------------------------------------------------------------------------------------------------------

    public virtual void OnGUI(AssetImporter assetImporter)
    {
        // Add your OnGUI() filter code here ...
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    // Process texture
    // ---------------------------------------------------------------------------------------------------------------------------

    public virtual void Process(Texture2D texture)
    {
        // Read and modify texture pixels here ...
    }
}
