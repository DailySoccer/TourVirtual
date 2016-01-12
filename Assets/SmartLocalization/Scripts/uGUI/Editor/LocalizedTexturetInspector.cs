#if UNITY_4_6 || UNITY_5_1 || UNITY_5_2

namespace SmartLocalization.Editor{
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LocalizedTexture))]
public class LocalizedTextureInspector : Editor 
{
	private string selectedKey = null;
	
	void Awake()
	{
			LocalizedTexture texttureObject = ((LocalizedTexture)target);
			if(texttureObject != null)
		{
				selectedKey = texttureObject.localizedKey;
		}
	}
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		
		selectedKey = LocalizedKeySelector.SelectKeyGUI(selectedKey, true, LocalizedObjectType.TEXTURE);

		if(!Application.isPlaying && GUILayout.Button("Use Key", GUILayout.Width(70)))
		{
			LocalizedTexture textureObject = ((LocalizedTexture)target);
				textureObject.localizedKey = selectedKey;
		}
	}
	
}
}
#endif