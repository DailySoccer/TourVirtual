using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
public class DeepLinkingData {

	public event Action<string, IDictionary<string, object>> OnDeepLinkEvent;

	public void Enter() {
        if (OnDeepLinkEvent != null) {
            OnDeepLinkEvent("Enter", new Dictionary<string, object>() {
            });
        }
	}
	
	public void AvatarChange() {
        if (OnDeepLinkEvent != null) {
            OnDeepLinkEvent("AvatarChange", new Dictionary<string, object>() {
            });
        }
	}
}
