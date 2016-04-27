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
	
	public void Setup(string[]  dataModel) {
		penaltiesScore.text = dataModel[(int)PlayerDataModel.PTOS_FUTBOL]; //(1000 * Time.deltaTime).ToString();
		BasketScore.text		=  dataModel [(int)PlayerDataModel.PTOS_BASKET]; //(1000 * Time.deltaTime).ToString();
		HiddenObjectsScore.text =  dataModel [(int)PlayerDataModel.PTOS_HIDDENOBJECTS]; //(1000 * Time.deltaTime).ToString();
		
		PacksCount 	  =  int.Parse(dataModel [(int)PlayerDataModel.PACKS].Split('/')[0]); //(int)(1000 * Time.deltaTime);
		MaxPacksCount =  int.Parse(dataModel [(int)PlayerDataModel.PACKS].Split('/')[1]); //(int)(1000 * Time.deltaTime);
		
		AchievementsCount 	= int.Parse(dataModel [(int)PlayerDataModel.LOGROS].Split('/')[0]); //(int)(1000 * Time.deltaTime);
		MaxAchivemenstCount = int.Parse(dataModel [(int)PlayerDataModel.LOGROS].Split('/')[1]); //(int)(1000 * Time.deltaTime);
		
		PacksCountText.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 		PacksCount.ToString(), MaxPacksCount.ToString());
		AchivementCountText.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 	AchievementsCount.ToString(), MaxAchivemenstCount.ToString());
		
	}
}