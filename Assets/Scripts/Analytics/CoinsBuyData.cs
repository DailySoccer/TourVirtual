using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class CoinsBuyData {

	public event Action<string, IDictionary<string, object>> onBuyEvent;

	private float enterTime;

	public void Enter(String roomId) {
	    /*IDictionary<string, object> enterData = new Dictionary<string, object>();
		enterData.Add("roomId", roomId);
		//enterData.Add("currentCoins", );
		onBuyEvent(fromMenu? "EnterFromMenu" : "EnterFromPortal", enterData);
		
		enterTime = Time.time;
		*/
		/*IDictionary<string, object> enterData = new Dictionary<string, object>();
		enterData.Add("enteringRoomId", id);
		enterData.Add("leavingRoomId", lastRoomId);
		onRoomEvent(fromMenu? "EnterFromMenu" : "EnterFromPortal", enterData);

		lastRoomId = id;
		// reset necessary data
		enterTime = Time.time;
		viewersOpenedList = new Dictionary<string, string>();
		viewersOpened = 0;
		viewersSteped = 0;*/
	}

	public void LeaveWithoutBuy() {
		float leaveTime = Time.time;

        if (onBuyEvent != null) {
            onBuyEvent("LeaveWithoutBuy", new Dictionary<string, object>() {
                { "totalTime", leaveTime - enterTime }
            });
        }
	}

	public void BuyItem(string id) {
        if (onBuyEvent != null) {
            onBuyEvent("LeaveWithoutBuy", new Dictionary<string, object>() {
            });
        }
	}

}
