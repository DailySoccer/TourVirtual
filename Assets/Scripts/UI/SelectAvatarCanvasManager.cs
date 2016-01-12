using UnityEngine;
using System.Collections;

public class SelectAvatarCanvasManager : CanvasManager 
{
	void OnEnable() {
		ShowScreen(currentGUIScreen);
	}
}
