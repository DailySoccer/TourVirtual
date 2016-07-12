using UnityEngine;
using UnityEngine.UI;

public enum ChatChannelType {
	Community,
	General,
	Private,
	UserList
}

//[ExecuteInEditMode]
public class TVBChatChannel : MonoBehaviour {
	//public RawImage userAvatar;

	//public Image AvatarPicture;

	public Text channelName;
	public Text lastUpdateDate;
	public Text  ChannelCounter;

	public Sprite CommunityChannelTypeIcon;
	public Sprite GeneralChannelTypeIcon;
	public Sprite PrivateChannelTypeIcon;

	public Image ChannelTypeIcon;

	public Image ChannelBase;
	public Color PublicChannelBaseColor;
	public Color PrivateChannelBaseColor;

	public Sprite ChannelBase_ChannelsSprite;
	public Sprite ChannelBase_UserListSprite;
	
	public ChatChannelType channelType;
	public string friendlyName { get; set; }
	public string realName { get; set; }

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

	public void setup(){
		switch (channelType) {
		case ChatChannelType.Community:
			ChannelTypeIcon.sprite = CommunityChannelTypeIcon;
			ChannelBase.sprite = ChannelBase_ChannelsSprite;
			ChannelBase.color = PublicChannelBaseColor;
			break;
		case ChatChannelType.General:
			ChannelTypeIcon.sprite = GeneralChannelTypeIcon;
			ChannelBase.sprite = ChannelBase_ChannelsSprite;
			ChannelBase.color = PublicChannelBaseColor;
			break;
		case ChatChannelType.Private:
			ChannelTypeIcon.sprite = PrivateChannelTypeIcon;
			ChannelBase.sprite = ChannelBase_ChannelsSprite;
			ChannelBase.color = PrivateChannelBaseColor;
			break;
		case ChatChannelType.UserList:
			ChannelTypeIcon.gameObject.SetActive(false);
			ChannelBase.sprite = ChannelBase_UserListSprite;
			ChannelBase.color = PrivateChannelBaseColor;
			lastUpdateDate.gameObject.SetActive(false);
			break;
		}

		channelName.text = friendlyName;
	} 

	void Update() {
		CountObject.SetActive(count > 0);
		if (ChannelCounter != null) {
			if (lastCount != count && count > 0) {
				ChannelCounter.text = count < maxCount ? count.ToString() : "+" + (maxCount -1);
				lastCount = count;
			}
		}
	}
}
