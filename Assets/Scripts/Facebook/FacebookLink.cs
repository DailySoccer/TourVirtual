using UnityEngine;
using System.Collections;

public class FacebookLink{

	#region Constants
#if DEV
	public static string source = "https://www.domain.com/";
#elif PRE
	public static string source = "https://www.domain.com/";
#elif PRO
	public static string source = "https://www.domain.com/";
#else
	public static string source = "https://www.domain.com/";
#endif

	public static string AchievementShareLink = "achievement/";
	public static string ContentShareLink = "content/";
	public static string PointsShareLink = "points/";
	public static string RecordShareLink = "record/";
	public static string RankingShareLink = "ranking/";
	#endregion

	#region Public members
	public System.Uri contentURL;
	public string contentTitle;
	public string contentDescription;
	public System.Uri photoURL;
#endregion

#region Public methods
	public FacebookLink()
	{
		contentURL = null;
		contentTitle = string.Empty;
		contentDescription = string.Empty;
		photoURL = null;
	}
	public FacebookLink(System.Uri newContentURL, string newContentTitle, string newContentDescription, System.Uri newPhotoURL)
	{
		contentURL = newContentURL;
		contentTitle = newContentTitle;
		contentDescription = newContentDescription;
		photoURL = newPhotoURL;
	}
	public static FacebookLink AchievementShare(string achievement)
	{
		return new FacebookLink(new System.Uri("https://www.unusualwonder.com/"), "Logro conseguido", "¡He conseguido el logro " + achievement + "!", new System.Uri(source + AchievementShareLink));
	}
	public static FacebookLink ContentUnlockedShare()
	{
		return new FacebookLink(new System.Uri("https://www.unusualwonder.com/"), "Contenido desbloqueado", "He desbloqueado contenido nuevo.", new System.Uri(source + ContentShareLink));
	}
	public static FacebookLink PointsShare(bool isRecord, int points, string game)
	{
		return new FacebookLink(new System.Uri("https://www.unusualwonder.com/"), isRecord ? "Récord" : "Puntuación", "He conseguido " + (isRecord ? "un record de " : string.Empty) + points + " puntos en el juego " + game + ".", new System.Uri(source + (isRecord ? RecordShareLink : PointsShareLink)));
	}
	public static FacebookLink RankingShare(int rankPos)
	{
		return new FacebookLink(new System.Uri("https://www.unusualwonder.com/"), "Clasificación", "He conseguido el puesto " + rankPos + ".", new System.Uri(source + RankingShareLink));
	}
#endregion
}
