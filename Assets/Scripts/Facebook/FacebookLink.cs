using UnityEngine;
using System.Collections;

public class FacebookLink{

	#region Constants
#if DEV
	public static string source = "https://rmdevcdntour.blob.core.windows.net/virtualtour-assets/Facebook/";
#elif PRE
	public static string source = "https://rmdevcdntour.blob.core.windows.net/virtualtour-assets/Facebook/";
#elif PRO
	public static string source = "https://rmdevcdntour.blob.core.windows.net/virtualtour-assets/Facebook/";
#else
	public static string source = "https://rmdevcdntour.blob.core.windows.net/virtualtour-assets/Facebook/";
#endif

	public static string AchievementShareLink = "Logros/";
	public static string ContentShareLink = "Packs/";
	public static string ContentShareFilePrefix = "PostFacebookPacks";
	public static string PointsShareLink = "Juegos/";
	public static string PointsShareFilePrefix = "Face_";
	public static string PointsShareFileSuffixNormal = "_Puntos";
	public static string PointsShareFileSuffixRecord = "_Record";
	public static string RankingShareFile = "PostFacebookRanking";
	public static string FileExt = ".jpg";
	public enum GameType {
		BASKET,
		FUTBOL,
		TESORO
	};
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
	public static FacebookLink AchievementShare(string achievementID, string achievementName)
	{
		return new FacebookLink(new System.Uri("https://www.unusualwonder.com/"), "Logro conseguido", "¡He conseguido el logro " + achievementName + "!", new System.Uri(source + AchievementShareLink + achievementID + FileExt));
	}
	public static FacebookLink ContentUnlockedShare(int room, int pack)
	{
		return new FacebookLink(new System.Uri("https://www.unusualwonder.com/"), "Contenido desbloqueado", "He desbloqueado contenido nuevo.", new System.Uri(source + ContentShareLink + room.ToString("00") + pack.ToString("00") + FileExt));
	}
	public static FacebookLink PointsShare(bool isRecord, int points, GameType game)
	{
		return new FacebookLink(new System.Uri("https://www.unusualwonder.com/"), isRecord ? "Récord" : "Puntuación", "He conseguido " + (isRecord ? "un record de " : string.Empty) + points + " puntos en el juego " + game + ".", new System.Uri(source + PointsShareLink + PointsShareFilePrefix + game + (isRecord ? PointsShareFileSuffixRecord : PointsShareFileSuffixNormal) + FileExt));
	}
	public static FacebookLink RankingShare(int rankPos)
	{
		return new FacebookLink(new System.Uri("https://www.unusualwonder.com/"), "Clasificación", "He conseguido el puesto " + rankPos + ".", new System.Uri(source + RankingShareFile + FileExt));
	}
#endregion
}
