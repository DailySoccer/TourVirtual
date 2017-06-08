using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class RoomVisitData {

	public bool FromMenu = false;
    public string CurrentRoomId = "";
    public string LastRoomId = "";

    private float _enterTime;
    public float TotalTimeInSeconds {
        get {
            return Time.time - _enterTime;
        }
    }

	public void SetFromMenu() {
		FromMenu = true;
	}

	public void Enter(string id) {
        LastRoomId = CurrentRoomId;
        CurrentRoomId = id;

		// reset necessary data
		_enterTime = Time.time;
        FromMenu = false;
	}
}
