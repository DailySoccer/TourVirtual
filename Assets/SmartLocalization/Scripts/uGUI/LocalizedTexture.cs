#if UNITY_4_6 || UNITY_5_1 || UNITY_5_2
namespace SmartLocalization.Editor
{
	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;
	
	[RequireComponent (typeof (RawImage))]
	public class LocalizedTexture : MonoBehaviour 
	{
		public string localizedKey = "INSERT_KEY_HERE";
		RawImage imageObject;
		
		void Start () 
		{
			imageObject = this.GetComponent<RawImage>();
			
			//Subscribe to the change language event
			LanguageManager languageManager = LanguageManager.Instance;
			languageManager.OnChangeLanguage += OnChangeLanguage;
			
			//Run the method one first time
			OnChangeLanguage(languageManager);
		}
		
		void OnDestroy()
		{
			if(LanguageManager.HasInstance)
			{
				LanguageManager.Instance.OnChangeLanguage -= OnChangeLanguage;
			}
		}
		
		void OnChangeLanguage(LanguageManager languageManager)
		{
			imageObject.texture = LanguageManager.Instance.GetTexture(localizedKey);
		}
	}
}
#endif