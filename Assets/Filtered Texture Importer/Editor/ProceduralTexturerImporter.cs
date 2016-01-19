
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;


[CanEditMultipleObjects, CustomEditor(typeof(TextureImporter))]
public class ProceduralTexturerImporter : Editor
{
    private Editor nativeEditor;
    private SerializedProperty m_userData;

    BaseFilter[] filters = new BaseFilter[] { new Inverse(), new Inverse() };
    new SerializedObject serializedObject { get { return nativeEditor.serializedObject; } }
    public void OnEnable()
    {
        m_userData = serializedObject.FindProperty("m_UserData");

        try
        {
            string str = m_userData.stringValue;
            if (!string.IsNullOrEmpty(str)) filters = (BaseFilter[])Deserialize(str);
        }
        catch (System.Exception e)
        {
            Debug.Log(target.name + " -> OnEnable:" + e);
        }
    }

    public void OnDisable()
    {
        bool hasModifiedProperties = (bool)typeof(SerializedObject).GetProperty("hasModifiedProperties", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(serializedObject, null);
        AssetImporter assetImporter = this.target as AssetImporter;
        // if ( this.m_MightHaveModified && assetImporter != null && !InternalEditorUtility.ignoreInspectorChanges && this.HasModified() && !this.AssetWasUpdated())
        if (hasModifiedProperties && assetImporter != null) //this.m_MightHaveModified && this.HasModified() && !this.AssetWasUpdated())
        {
            string message = "Unapplied import settings for '" + assetImporter.assetPath + "'";
            if (base.targets.Length > 1)
            {
                message = "Unapplied import settings for '" + base.targets.Length + "' files";
            }
            if (EditorUtility.DisplayDialog("Unapplied import settings", message, "Apply", "Revert"))
            {
                typeof(Editor).Assembly.GetType("UnityEditor.AssetImporterInspector").GetMethod("ApplyAndImport", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(nativeEditor, null);
            }
        }

        if (serializedObject != null && hasModifiedProperties)
        {
            serializedObject.GetType().GetMethod("Cache", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(serializedObject, new object[] { base.GetInstanceID() });
        }
    }

    #region Bridges
    public override GUIContent GetPreviewTitle()
    {
        if (nativeEditor != null) return nativeEditor.GetPreviewTitle();
        return base.GetPreviewTitle();
    }

    public override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height)
    {
        if (nativeEditor != null) return nativeEditor.RenderStaticPreview(assetPath, subAssets, width, height);
        return base.RenderStaticPreview(assetPath, subAssets, width, height);
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        if (nativeEditor != null) nativeEditor.OnPreviewGUI(r, background);
        else base.OnPreviewGUI(r, background);
    }
    public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        if (nativeEditor != null) nativeEditor.OnInteractivePreviewGUI(r, background);
        else base.OnInteractivePreviewGUI(r, background);
    }
    public override void OnPreviewSettings()
    {
        if (nativeEditor != null) nativeEditor.OnPreviewSettings();
        else base.OnPreviewSettings();
    }
    /* ***************************** WARNING: HAD TO REMOVE FOR RUNNING ON UNITY 4.3 !!!!! *******************************************************
    public override void DrawPreview(Rect previewArea)
    {
        if (nativeEditor != null) nativeEditor.DrawPreview(previewArea);
        else base.DrawPreview(previewArea);
    }*/
    public override bool HasPreviewGUI()
    {
        if (nativeEditor != null) return nativeEditor.HasPreviewGUI();
        return base.HasPreviewGUI();
    }
    #endregion

    void Awake()
    {
        nativeEditor = Editor.CreateEditor(targets/* serializedObject.targetObject*/, typeof(Editor).Assembly.GetType("UnityEditor.TextureImporterInspector"));
        if (nativeEditor != null)
        {
            typeof(Editor).GetField("m_Targets", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(nativeEditor, this.targets);
            if (this.targets == null || this.targets.Length < 1)
            {
                FieldInfo m_ReferenceTargetIndex = typeof(Editor).GetField("m_ReferenceTargetIndex", BindingFlags.Instance | BindingFlags.NonPublic);
                m_ReferenceTargetIndex.SetValue(nativeEditor, m_ReferenceTargetIndex.GetValue(this));
            }
            typeof(Editor).Assembly.GetType("UnityEditor.TextureImporterInspector").GetMethod("ResetValues", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(nativeEditor, null);
        }
    }

    Editor currentTargetEditor;
    protected override void OnHeaderGUI()
    {
        System.Type InspectorWindowType = typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow");
        object s_CurrentInspectorWindow = InspectorWindowType.GetField("s_CurrentInspectorWindow", BindingFlags.Static | BindingFlags.Public).GetValue(null);
        if (s_CurrentInspectorWindow != null)
        {
            currentTargetEditor = ((ActiveEditorTracker)InspectorWindowType.GetField("m_Tracker", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(s_CurrentInspectorWindow)).activeEditors[1];
            typeof(Editor).Assembly.GetType("UnityEditor.AssetImporterInspector").GetField("m_AssetEditor", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(nativeEditor, currentTargetEditor);
            typeof(Editor).GetMethod("InternalSetHidden", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(currentTargetEditor, new object[] { true });
            string title = (string)typeof(Editor).GetProperty("targetTitle", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(currentTargetEditor, null);
            if (nativeEditor != null) typeof(Editor).GetMethod("DrawHeaderGUI", BindingFlags.Static | BindingFlags.NonPublic, null, new System.Type[] { typeof(Editor), typeof(string) }, null ).Invoke(null, new object[] { nativeEditor, title + " Import Settings" });
        }
    }

    GUIStyle MyGUIStyle;
    public override void OnInspectorGUI()
    {
        if (nativeEditor != null) nativeEditor.OnInspectorGUI();
        GUILayout.Space(10);
        bool modded = false;
        foreach (BaseFilter filter in filters)
        {
            if (filter != null)
            {
                EditorGUI.BeginChangeCheck();
                //            EditorGUI.indentLevel = -1;

                if (MyGUIStyle == null) MyGUIStyle = new GUIStyle("IN BigTitle inner");

                GUILayout.BeginVertical(MyGUIStyle);
                filter.IsEnabled = EditorGUILayout.ToggleLeft(filter.FilterName, filter.IsEnabled);
                GUILayout.EndVertical();
                GUILayout.BeginVertical(MyGUIStyle);

                EditorGUI.BeginDisabledGroup(filter.IsEnabled == false);
                filter.OnGUI((AssetImporter)target);
                EditorGUI.EndDisabledGroup();
                GUILayout.EndVertical();
                EditorGUILayout.Space();

                if (EditorGUI.EndChangeCheck())
                {
                    modded = true;
                }
            }
        }
        if (modded)
            m_userData.stringValue = Serialize(filters);

    }

    public static string Serialize(object value)
    {
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(stream, value);
        //byte[] buff = stream.GetBuffer();
        return System.Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length);
    }
    public static object Deserialize(string value)
    {
        byte[] buff = System.Convert.FromBase64String(value);
        System.IO.MemoryStream stream = new System.IO.MemoryStream(buff);
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        return b.Deserialize(stream);
    }

}

public class MyTexturePostprocessor : AssetPostprocessor
{
    public void OnPostprocessTexture(Texture2D texture)
    {
        try
        {
            if (!string.IsNullOrEmpty(assetImporter.userData))
            {
                BaseFilter[] bfs = (BaseFilter[])ProceduralTexturerImporter.Deserialize(assetImporter.userData);
                if (bfs != null)
                    foreach (var bf in bfs)
                        if (bf != null && bf.IsEnabled) bf.Process(texture);
            }
        }
        catch { }
    }
}