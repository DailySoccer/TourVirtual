using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChannelListUI : MonoBehaviour {

	public Text PlayerName;
	public Text ChannelList;
	public GameObject ContentPanel;

	void Start () {
		_roomManager = RoomManager.Instance;
		_roomManager.OnChange += HandleOnChange;
	}
	
	void Update () {
	}

	void HandleOnChange () {
		PlayerName.text = "<color=green>" + PhotonNetwork.player.name + "</color>";

		string playerList = _roomManager.Room.Name + "\n";
		foreach (PhotonPlayer player in PhotonNetwork.otherPlayers) {
			playerList += player.name;
			playerList += "\n";
		}
		ChannelList.text = playerList;
	}

	public RoomManager _roomManager;
}
