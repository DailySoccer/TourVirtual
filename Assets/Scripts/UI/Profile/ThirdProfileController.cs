using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ThirdProfileController : MonoBehaviour {
	
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
	
	public void Setup(string  UserID) {
		Debug.LogError ("[ThirdProfileController in " + name + "]: Me tienen que pasar los datos del otro player");
		// Conseguimos la info del player, quizás a través del ID es posible (Ver con Fernando)

		penaltiesScore.text 	= (1000 * Time.deltaTime).ToString();
		BasketScore.text		= (1000 * Time.deltaTime).ToString();
		HiddenObjectsScore.text = (1000 * Time.deltaTime).ToString();
		
		PacksCount 	  = (int)(1000 * Time.deltaTime);
		MaxPacksCount = (int)(1000 * Time.deltaTime);
		
		AchievementsCount 	= (int)(1000 * Time.deltaTime);
		MaxAchivemenstCount = (int)(1000 * Time.deltaTime);
		
		PacksCountText.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 		PacksCount.ToString(), MaxPacksCount.ToString());
		AchivementCountText.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 	AchievementsCount.ToString(), MaxAchivemenstCount.ToString());
		
	}
}
