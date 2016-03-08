using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum MinigameModalType {
	FootbalShots,
	BasketShots
}
//[ExecuteInEditMode]
public class MinigameModal : MonoBehaviour {
	public Sprite FootballBg;
	public Sprite BasketBg;
	public Image backgroundBase;

    public MinigameModalType CurrentMinigameStyle;
	private MinigameModalType _LastMinigameStyle;
    /*
	private MinigameModalType _CurrentMinigameStyle {
        get { return _CurrentMinigameStyle; }
        set {
            if(_CurrentMinigameStyle != value) {
                _CurrentMinigameStyle = value;
                switch (CurrentMinigameStyle) {
                    case MinigameModalType.FootbalShots:
                        backgroundBase.sprite = FootballBg;
                        break;
                    case MinigameModalType.BasketShots:
                        backgroundBase.sprite = BasketBg;
                        break;
                }
            }
        }
    }*/

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if (CurrentMinigameStyle != _LastMinigameStyle) {
			switch (CurrentMinigameStyle) {
			case MinigameModalType.FootbalShots:
				backgroundBase.sprite = FootballBg;
				break;
			case MinigameModalType.BasketShots:
				backgroundBase.sprite = BasketBg;
				break;
			}
			_LastMinigameStyle = CurrentMinigameStyle;
		}
	}

    public void OnShow()
    {
        gameObject.SetActive(true);
    }


    public void OnHide(GameObject go) {
        go.SetActive(false);
    }

}
