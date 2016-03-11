#if !LITE_VERSION
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProfileScreenController : MonoBehaviour {

	public Text penaltiesScore;
	public Text BasketScore;
	public Text HiddenObjectsScore;

	public Text PacksCountText;
	int PacksCount;
	int MaxPacksCount;
	public Text AchivementCountText;
	int AchievementsCount;
	int MaxAchivemenstCount;


	
	// Use this for initialization
	void Start () {
		//Debug.LogError("===> { ProfileScreen/ScoresResume:\n TODO: Necesito info de PACKS y ACHIEVEMENTS del usuario \n } <==");
	}

	void Update() {
		penaltiesScore.text 	= UserAPI.Instance.GetScore (UserAPI.MiniGame.FreeKicks).ToString();// (1000 * Time.deltaTime).ToString();
		BasketScore.text		= UserAPI.Instance.GetScore (UserAPI.MiniGame.FreeShoots).ToString();//(1000 * Time.deltaTime).ToString();
		HiddenObjectsScore.text = UserAPI.Instance.GetScore (UserAPI.MiniGame.HiddenObjects).ToString();//(1000 * Time.deltaTime).ToString();
		PacksCount = UserAPI.Instance.ContentPack (out MaxPacksCount);
		AchievementsCount = UserAPI.Instance.GetAchievements (out MaxAchivemenstCount);

		PacksCountText.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 		PacksCount.ToString(), MaxPacksCount.ToString());
		AchivementCountText.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 	AchievementsCount.ToString(), MaxAchivemenstCount.ToString());
		
	}
}

#endif