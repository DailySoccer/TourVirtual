using UnityEngine;
using UnityEngine.Analytics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AvatarSelectionData {

	public event Action<string, IDictionary<string, object>> OnAvatarEvent;

	private float enterTime;
	HashSet<string> modelsViewed;

	public void Enter() {
        if (OnAvatarEvent != null) {
            OnAvatarEvent("Enter", new Dictionary<string, object>() {
            });
        }

		// reset necessary data
		enterTime = Time.time;
        modelsViewed = new HashSet<string>();
	}

    public void ShowModel(AvatarAPI descriptor) {
        modelsViewed.Add(descriptor.Head);
	}

    public void SelectModel(AvatarAPI descriptor) {
        if (OnAvatarEvent != null) {
            float leaveTime = Time.time;

            OnAvatarEvent("SelectAvatar", new Dictionary<string, object>() {
                { "modelsViewed", modelsViewed.Count },
                { "selectedModelId", descriptor.Head },
                { "gender", descriptor.Gender },
                { "totalTime", leaveTime - enterTime }
            });
        }
	}

}