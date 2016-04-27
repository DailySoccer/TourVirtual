using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
			achivs + "/" + maxAchivs + "#" +
			packs + "/" + maxPacks + "#";
	}

	public void SetDataModel(string data, string head) {
		//TODO: parseamos los datos a sus variables.

		/// Orden de los datos: Cara, nombre, nivelFan, ptos. Futbol, ptos. Basket, ptos. HiddenObjects, num. Packs, num. logros";
		dataModel = (head + "#" + data).Split ('#');
		Name.text = dataModel [(int)PlayerDataModel.NOMBRE];
		FanLevel.text = dataModel [(int)PlayerDataModel.NIVEL_FAN];
		Face.sprite = MainManager.Instance.GetComponent<AvatarPictureManager>().GetAvatarPicture(dataModel[(int)PlayerDataModel.CARA]);
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
		if (canvasManager == null)
			if ( GameObject.FindGameObjectWithTag ("GameCanvasManager") ) {
				canvasManager = GameObject.FindGameObjectWithTag ("GameCanvasManager").GetComponent<GameCanvasManager> ();
			}

		// rotates the object relative to the camera
		Vector3 targetPos = transform.position + referenceCamera.transform.rotation * (reverseFace ? Vector3.back : Vector3.forward);
		Vector3 targetOrientation = referenceCamera.transform.rotation * GetAxis (axis);
		transform.LookAt (targetPos, targetOrientation);
		transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);

		Parent.SetActive(Vector3.Distance(transform.position, referenceCamera.transform.position) > 2 && Vector3.Distance(transform.position, referenceCamera.transform.position) < 14);

		//Debug.Log ("Distancia HUD-Camara: " + Vector3.Distance(transform.position, referenceCamera.transform.position).ToString());
	}

	public void RemotePlayerHUD_ClickHandle() {
		Debug.Log("Solicitado el perfil del usuario: " + dataModel[(int)PlayerDataModel.NOMBRE]);
		canvasManager.ShowOTherPlayerInfo (dataModel);
	}
}
