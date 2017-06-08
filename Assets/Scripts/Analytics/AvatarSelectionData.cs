using UnityEngine;
using UnityEngine.Analytics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AvatarSelectionData {

    private HashSet<string> _modelsViewed;
    private float _enterTime;

    public int CountModelsViewed {
        get {
            return _modelsViewed.Count;
        }
    }

    public float TotalTimeInSeconds {
        get {
            return Time.time - _enterTime;
        }
    }

	public void Enter() {
		// reset necessary data
		_enterTime = Time.time;
        _modelsViewed = new HashSet<string>();
	}

    public void ShowModel(AvatarAPI descriptor) {
        _modelsViewed.Add(descriptor.Head);
	}
}