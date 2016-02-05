using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum ChatChannelType {
	General,
	Private
}

[ExecuteInEditMode]
public class TVBChatChannel : MonoBehaviour {
	//public RawImage userAvatar;

	public Image AvatarPicture;

	public Text channelName;
	public Text lastUpdateDate;
	public Text  ChannelCounter;

	public Sprite GeneralChannelTypeIcon;
	public Sprite PrivateChannelTypeIcon;

	public Image ChannelTypeIcon;
	public Image ChannelTypeBase;
	
	public ChatChannelType channelType;

	public GameObject CountObject;
	public int maxCount = 1000;
	
	[SerializeField]
	private int count;

	public int Count { 
		get{return count;}
		set{count = value;}
	}

	private int lastCount;

	void Awake () {
		if (CountObject == null) {
			Debug.LogError("Soy un Objecto con Badge y no tengo un badge asociado");
		}
	}


	void Update() {
		switch (channelType) {
		case ChatChannelType.General:
			ChannelTypeIcon.sprite = GeneralChannelTypeIcon;
			ChannelTypeBase.color = new Color(1f,1f,1f);
			ChannelCounter.color = new Color(0.08f, 0.10f, 0.16f);
			ChannelTypeIcon.color = new Color(0.08f, 0.10f, 0.16f);
			break;
		case ChatChannelType.Private:
			ChannelTypeIcon.sprite = PrivateChannelTypeIcon;
			ChannelTypeBase.color = new Color(1.0f,0.0f,0.0f);
			ChannelCounter.color = new Color(1.0f,1.0f,1.0f);
			ChannelTypeIcon.color = new Color(1.0f,1.0f,1.0f);
			break;
		}

		CountObject.SetActive(count > 0);

		if (ChannelCounter != null) {
			if (lastCount != count && count > 0) {
				ChannelCounter.text = count < maxCount ? count.ToString() : "+" + (maxCount -1);
				lastCount = count;
			}
		}
	}
}
