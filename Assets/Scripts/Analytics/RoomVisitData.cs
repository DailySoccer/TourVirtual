using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class RoomVisitData {

	public event Action<string, IDictionary<string, object>> OnRoomEvent;
	public event Action<string, IDictionary<string, object>> OnViewerEvent;

	private float enterTime;
	private int viewersOpened;
	private bool fromMenu = false;
	private string lastRoomId = "";
	private string lastOpenViewerId = "";
	private HashSet<string> viewersOpenedList;
    private HashSet<string> viewersStepedList;

	public void SetFromMenu() {
		fromMenu = true;
	}

	public void Enter(String id) {
        if (OnRoomEvent != null) {
            OnRoomEvent(fromMenu? "EnterFromMenu" : "EnterFromPortal", new Dictionary<string, object>() {
                { "enteringRoomId", id },
                { "leavingRoomId", lastRoomId }
            });
        }

		lastRoomId = id;

		// reset necessary data
		enterTime = Time.time;
        viewersOpenedList = new HashSet<string>();
        viewersStepedList = new HashSet<string>();
		viewersOpened = 0;
        fromMenu = false;
	}

	public void OpenViewer(string viewerId) {
		viewersOpened++;
		lastOpenViewerId = viewerId;
		viewersOpenedList.Add(viewerId);
		if (OnViewerEvent != null) {
            OnViewerEvent("Open", new Dictionary<string, object>() {
                { "viewerId", viewerId },
                { "roomId", lastRoomId }
            });
		}
	}

	public void StepOnViewer(string viewerId) {
		viewersStepedList.Add(viewerId);
	}

	public void ViewerBuySuccess(float coinsNeeded) {
		if (OnViewerEvent != null) {
            OnViewerEvent("BuySuccess", new Dictionary<string, object>() {
                { "viewerId", lastOpenViewerId },
                { "roomId", lastRoomId },
                { "coinsNeeded", coinsNeeded }
            });
		}
	}

	public void ViewerBuyCancel(float coinsNeeded) {
		if (OnViewerEvent != null) {
            OnViewerEvent("BuyCancel", new Dictionary<string, object>() {
                { "viewerId", lastOpenViewerId },
                { "roomId", lastRoomId },
                { "coinsNeeded", coinsNeeded }
            });
		}
	}

	public void Leave() {
		if (String.IsNullOrEmpty(lastRoomId)) return;

        if (OnRoomEvent != null) {
            float leaveTime = Time.time;

            OnRoomEvent("Leave", new Dictionary<string, object>() {
                { "roomId", lastRoomId },
                { "totalTime", leaveTime - enterTime },
                { "usersInRoom", PlayerManager.Instance.CountPlayersInRoom },
                { "viewersOpened", viewersOpened },
                { "viewersOpenedList", String.Join(" | ", viewersOpenedList.ToArray()) },
                { "viewersSteped", viewersStepedList.Count },
                { "fromMenu", fromMenu }
            });
        }
            
	}
}
