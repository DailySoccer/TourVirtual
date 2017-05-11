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
	private bool lastRoomByMenu = false;
	private string lastOpenViewerId = "";
	private IDictionary<string, string> viewersOpenedList;
	private IDictionary<string, string> viewersStepedList;

	public void SetFromMenu() {
		fromMenu = true;
	}

	public void Enter(String id) {
	    IDictionary<string, object> enterData = new Dictionary<string, object>();
		enterData.Add("enteringRoomId", id);
		enterData.Add("leavingRoomId", lastRoomId);
		if (OnRoomEvent != null) OnRoomEvent(fromMenu? "EnterFromMenu" : "EnterFromPortal", enterData);

		lastRoomByMenu = fromMenu;
		fromMenu = false;
		lastRoomId = id;
		// reset necessary data
		enterTime = Time.time;
		viewersOpenedList = new Dictionary<string, string>();
		viewersStepedList = new Dictionary<string, string>();
		viewersOpened = 0;
	}

	public void OpenViewer(string viewerId) {
		viewersOpened++;
		lastOpenViewerId = viewerId;
		if(!viewersOpenedList.ContainsKey(viewerId))
			viewersOpenedList.Add(viewerId, viewerId);
		if (OnViewerEvent != null) {
	    	IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("viewerId", viewerId);
			data.Add("roomId", lastRoomId);
			OnViewerEvent("Open", data);
		}
	}

	public void StepOnViewer(string viewerId) {
		if(!viewersStepedList.ContainsKey(viewerId))
			viewersStepedList.Add(viewerId, viewerId);
	}

	public void ViewerBuySuccess(float coinsNeeded) {
		if (OnViewerEvent != null) {
	    	IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("viewerId", lastOpenViewerId);
			data.Add("roomId", lastRoomId);
			data.Add("coinsNeeded", coinsNeeded);
			OnViewerEvent("BuySuccess", data);
		}
	}

	public void ViewerBuyCancel(float coinsNeeded) {
		if (OnViewerEvent != null) {
	    	IDictionary<string, object> data = new Dictionary<string, object>();
			data.Add("viewerId", lastOpenViewerId);
			data.Add("roomId", lastRoomId);
			data.Add("coinsNeeded", coinsNeeded);
			OnViewerEvent("BuyCancel", data);
		}
	}

	public void Leave() {
		if(String.IsNullOrEmpty(lastRoomId)) return;
		float leaveTime = Time.time;

	    IDictionary<string, object> visitData = new Dictionary<string, object>();
		visitData.Add("roomId", lastRoomId);
		visitData.Add("totalTime", leaveTime - enterTime);
		visitData.Add("usersInRoom", PlayerManager.Instance.CountPlayersInRoom);
		visitData.Add("viewersOpened", viewersOpened);
		visitData.Add("viewersOpenedList", String.Join(" | ", viewersOpenedList.Keys.ToArray()));
		visitData.Add("viewersSteped", viewersStepedList.Count);
		visitData.Add("fromMenu", lastRoomByMenu);
		// visitData.Add("fromMenu", ); // TODO: set from menu

		if (OnRoomEvent != null) OnRoomEvent("Leave", visitData);
		lastRoomByMenu = false;
	}
}
