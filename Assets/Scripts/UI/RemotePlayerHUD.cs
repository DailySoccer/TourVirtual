using UnityEngine;
using UnityEngine.UI;


public enum PlayerDataModel {	
	CARA,
	NOMBRE,
	NIVEL_FAN,
	PTOS_FUTBOL,
	PTOS_BASKET,
	PTOS_HIDDENOBJECTS,
	PACKS,
	LOGROS
};

public class RemotePlayerHUD : MonoBehaviour {

	string[] dataModel;

	CanvasManager canvasManager;

	// Use this for initialization
	public Camera referenceCamera;

	public string playerID = "";
	
	public enum Axis {up, down, left, right, forward, back};
	public bool reverseFace = false; 
	public Axis axis = Axis.up; 

	public bool IsButtonDbug;

	public Text Name;
	public Text FanLevel;
	public Image Face;

	public GameObject Parent;


	public static string GetDataModel(UserAPI user) {
		int maxPacks = 0;
		int packs = user.ContentPack (out maxPacks);

		int maxAchivs;
		int achivs = user.GetAchievements (out maxAchivs);
		//TODO: parseamos los datos a sus variables.
		return user.Nick + "#" + user.Level + "#" + 
			user.GetScore (UserAPI.MiniGame.FreeKicks).ToString() + "#" +
			user.GetScore (UserAPI.MiniGame.FreeShoots).ToString() + "#" +
			user.GetScore (UserAPI.MiniGame.HiddenObjects).ToString() + "#" + 
			packs + "/" + maxPacks + "#" +
			achivs + "/" + maxAchivs + "#";
	}

	public void SetDataModel(string data, string head) {
		//TODO: parseamos los datos a sus variables.
		if(string.IsNullOrEmpty(data)) return;
		/// Orden de los datos: Cara, nombre, nivelFan, ptos. Futbol, ptos. Basket, ptos. HiddenObjects, num. Packs, num. logros";
		dataModel = (head + "#" + data).Split ('#');
		Name.text = dataModel [(int)PlayerDataModel.NOMBRE];// + " PlayerHUD";
		FanLevel.text = dataModel [(int)PlayerDataModel.NIVEL_FAN];
		Face.sprite = MainManager.Instance.GetComponent<AvatarPictureManager>().GetAvatarPicture(dataModel[(int)PlayerDataModel.CARA]);
		playerID = dataModel[(int)PlayerDataModel.NOMBRE];
	}

	// return a direction based upon chosen axis
	public Vector3 GetAxis (Axis refAxis)
	{
		switch (refAxis)
		{
		case Axis.down:
			return Vector3.down; 
		case Axis.forward:
			return Vector3.forward; 
		case Axis.back:
			return Vector3.back; 
		case Axis.left:
			return Vector3.left; 
		case Axis.right:
			return Vector3.right; 
		}		
		// default is Vector3.up
		return Vector3.forward; 		
	}
	
	void  Awake ()
	{


		// if no camera referenced, grab the main camera
		if (!referenceCamera)
			referenceCamera = Camera.main; 
	}
	
	void  Update ()
	{
		if (name != "RemotePlayerHUDCanvas") {
			if (canvasManager == null)
				if (GameObject.FindGameObjectWithTag ("GameCanvasManager"))
					canvasManager = GameObject.FindGameObjectWithTag ("GameCanvasManager").GetComponent<GameCanvasManager> ();

			// Corrección de rotacion Billboard
			Vector3 dir = referenceCamera.transform.forward;
			dir.y = 0;
			transform.rotation = Quaternion.LookRotation(dir);

			// Solo visible en el rango de 2 a 14 metros
			Parent.SetActive (Vector3.Distance (transform.position, referenceCamera.transform.position) > 2 && Vector3.Distance (transform.position, referenceCamera.transform.position) < 10);
		}
	}

	public void RemotePlayerHUD_ClickHandle() {
		if(dataModel==null) return;
		canvasManager.ShowOTherPlayerInfo (dataModel);
	}
}
