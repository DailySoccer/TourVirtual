using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProfileScreenController : MonoBehaviour {

	public Text penaltiesScore;
	public Text BasketScore;
	public Text HiddenObjectsScore;

	public Text PacksCount;
	public int MaxPacksCount;
	public Text AchivementCount;
	public int MaxAchivementCount;
	
	// Use this for initialization
	void Start () {
		Debug.LogError("===> { ProfileScreen/ScoresResume:\n TODO: Necesito las Puntuaciones de 'Minijuegos' del usuario \n } <==");
		Debug.LogError("===> { ProfileScreen/ScoresResume:\n TODO: Necesito info de PACKS y ACHIEVEMENTS del usuario \n } <==");
	}

	void Update() {
		penaltiesScore.text 		= (1000 * Time.deltaTime).ToString();
		BasketScore.text		= (1000 * Time.deltaTime).ToString();
		HiddenObjectsScore.text= (1000 * Time.deltaTime).ToString();

		PacksCount.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 		((int)(250 * Time.deltaTime)).ToString(), MaxPacksCount.ToString());
		AchivementCount.text = string.Format ("<size=50><color=#151c2b>{0}</color></size><size=30><color=#3d4964>/{1}</color></size>", 	((int)(800 * Time.deltaTime)).ToString(), MaxAchivementCount.ToString());
		
	}
}
