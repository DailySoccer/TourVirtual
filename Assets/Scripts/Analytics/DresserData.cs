using UnityEngine;
using System.Collections;

public class DresserData {

//	public event Action<string, IDictionary<string, object>> onDresserEvent;
/*
	private float enterTime;
	IDictionary<int, int> modelsViewed;
	private int lastShownModel = 0;
*/
	public void Enter() {
	    /*
		IDictionary<string, object> enterData = new Dictionary<string, object>();
		onDresserEvent("Enter", enterData);

		// reset necessary data
		enterTime = Time.time;
		modelsViewed = new Dictionary<int, int>();
		lastShownModel = 0;
		*/
	}

	public void CloseAccept() {
		
	}

	public void CloseCancel() {
		
	}

	public void ShowDress(int dressId) {

	}

	public void OpenBuy() {
		
	}

	public void BuySuccess(ClothSlot cloth) {
		
	}

	public void BuyCancel(ClothSlot cloth) {
		
	}


}
