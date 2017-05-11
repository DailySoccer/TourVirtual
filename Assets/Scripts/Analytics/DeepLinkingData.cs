using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
public class DeepLinkingData {

	public event Action<string, IDictionary<string, object>> OnDeepLinkEvent;

	public void Enter() {
		IDictionary<string, object> data = new Dictionary<string, object>();
		OnDeepLinkEvent("Enter", data);
	}
	
	public void AvatarChange() {
		IDictionary<string, object> data = new Dictionary<string, object>();
		OnDeepLinkEvent("AvatarChange", data);
	}
}
