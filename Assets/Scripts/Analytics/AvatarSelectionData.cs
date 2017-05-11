using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class AvatarSelectionData {

	public event Action<string, IDictionary<string, object>> OnAvatarEvent;

	private float enterTime;
	IDictionary<int, int> modelsViewed;
	private int lastShownModel = 0;

	public void Enter() {
	    IDictionary<string, object> enterData = new Dictionary<string, object>();
		OnAvatarEvent("Enter", enterData);

		// reset necessary data
		enterTime = Time.time;
		modelsViewed = new Dictionary<int, int>();
		lastShownModel = 0;
	}

	public void ShowModel(int model) {
		if(!modelsViewed.ContainsKey(model)) modelsViewed.Add(model, model);
		lastShownModel = model;
	}

	public void SelectModel() {
		float leaveTime = Time.time;

	    IDictionary<string, object> selectModelData = new Dictionary<string, object>();
		selectModelData.Add("modelsViewed", modelsViewed.Count);
		selectModelData.Add("selectedModelId", lastShownModel);
		selectModelData.Add("totalTime", enterTime - leaveTime);
		selectModelData.Add("gender", UserAPI.AvatarDesciptor.Gender);

		OnAvatarEvent("SelectAvatar", selectModelData);
	}

}