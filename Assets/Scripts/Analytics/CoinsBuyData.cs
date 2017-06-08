using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class CoinsBuyData {

	public event Action<string, IDictionary<string, object>> onBuyEvent;

    private float _enterTime;

    public float TotalTimeInSeconds {
        get {
            return Time.time - _enterTime;
        }
    }

	public void Enter() {
		// reset necessary data
		_enterTime = Time.time;
	}
}
