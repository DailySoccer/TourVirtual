using UnityEngine;
using System.Collections;

public class SelectAvatarCanvasManager : CanvasManager 
{
	void OnEnable() {
#if !LITE_VERSION
		ShowScreen(currentGUIScreen);
#endif
	}
}
