using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class RoomVisitData {

	public int ViewersOpened;
	public bool FromMenu = false;
    public string CurrentRoomId = "";
    public string LastRoomId = "";
    public string LastOpenViewerId = "";
	public HashSet<string> ViewersOpenedList;
    public HashSet<string> ViewersStepedList;

    private float _enterTime;
    public float TotalTime {
        get {
            return Time.time - _enterTime;
        }
    }

    public string ViewersOpenedListToString() {
        return String.Join(" | ", ViewersOpenedList.ToArray());
    }

	public void SetFromMenu() {
		FromMenu = true;
	}

	public void Enter(string id) {
        LastRoomId = CurrentRoomId;
        CurrentRoomId = id;

		// reset necessary data
		_enterTime = Time.time;
        ViewersOpenedList = new HashSet<string>();
        ViewersStepedList = new HashSet<string>();
		ViewersOpened = 0;
        FromMenu = false;
	}

	public void OpenViewer(string viewerId) {
		ViewersOpened++;
		LastOpenViewerId = viewerId;
		ViewersOpenedList.Add(viewerId);
	}

	public void StepOnViewer(string viewerId) {
		ViewersStepedList.Add(viewerId);
	}

	public void ViewerBuySuccess(float coinsNeeded) {
        /*
        OnViewerEvent("BuySuccess", new Dictionary<string, object>() {
            { "viewerId", lastOpenViewerId },
            { "roomId", currentRoomId },
            { "coinsNeeded", coinsNeeded }
        });
        */      
	}

	public void ViewerBuyCancel(float coinsNeeded) {
        /*
        OnViewerEvent("BuyCancel", new Dictionary<string, object>() {
            { "viewerId", lastOpenViewerId },
            { "roomId", currentRoomId },
            { "coinsNeeded", coinsNeeded }
        });
        */      
	}
}
