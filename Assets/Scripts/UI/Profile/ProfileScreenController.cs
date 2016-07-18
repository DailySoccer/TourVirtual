using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProfileScreenController : MonoBehaviour {

	public Text penaltiesScore;
	public Text BasketScore;
	public Text HiddenObjectsScore;

	public Button ShowPacks;
	public Text PacksCountText;
	int PacksCount;
	int MaxPacksCount;

	public Button ShowAchievements;
	public Text AchivementCountText;
	int AchievementsCount;
	int MaxAchivemenstCount;

	public Text rankingPosition;
	public Text rankingScore;

	bool alreadyOpen;

	GUIScreen screen;
	Color oldColor;
	UnityEngine.Rendering.AmbientMode oldMode;

	
	// Use this for initialization
	void Start () {
		//Debug.LogError("===> { ProfileScreen/ScoresResume:\n TODO: Necesito info de PACKS y ACHIEVEMENTS del usuario \n } <==");
		screen = GetComponent<GUIScreen> ();
		UpdateData();
		alreadyOpen = false;
	}

	void Update() {
		if (screen.InOpenState && !alreadyOpen) {
			UpdateData ();
			alreadyOpen = true;
			Debug.LogError("UPDATING PROFILE");
			oldMode = RenderSettings.ambientMode; 
			RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
			oldColor = RenderSettings.ambientLight;
			RenderSettings.ambientLight = new Color32(90,95,107,255);
		}
		else if (screen.InCloseState && alreadyOpen) {
			alreadyOpen = false;
			RenderSettings.ambientMode = oldMode; 
			RenderSettings.ambientLight = oldColor;
			Debug.LogError("NOT UPDATING PROFILE");
		}
	}

	void UpdateData() {

		penaltiesScore.text 	= UserAPI.Instance.GetScore (UserAPI.MiniGame.FreeKicks).ToString();// (1000 * Time.deltaTime).ToString();
		BasketScore.text		= UserAPI.Instance.GetScore (UserAPI.MiniGame.FreeShoots).ToString();//(1000 * Time.deltaTime).ToString();
		HiddenObjectsScore.text = UserAPI.Instance.GetScore (UserAPI.MiniGame.HiddenObjects).ToString();//(1000 * Time.deltaTime).ToString();

		PacksCount = UserAPI.Instance.ContentPack (out MaxPacksCount);
		ShowPacks.gameObject.SetActive(PacksCount > 0 ? true : false);

		AchievementsCount = UserAPI.Instance.GetAchievements (out MaxAchivemenstCount);
		ShowAchievements.gameObject.SetActive(AchievementsCount > 0 ? true : false);

		PacksCountText.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 		PacksCount.ToString(), MaxPacksCount.ToString());
		AchivementCountText.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 	AchievementsCount.ToString(), MaxAchivemenstCount.ToString());

		foreach (UserAPI.ScoreEntry se in UserAPI.Instance.GetFanRanking()) {
			if (se.IsMe)
            {
                rankingScore.text = se.Score.ToString();
                rankingPosition.text = se.Position.ToString();
                break;
            }
		}
	}
}
