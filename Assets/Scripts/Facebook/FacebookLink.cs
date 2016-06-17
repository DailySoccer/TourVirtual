using UnityEngine;
using System.Collections;

public class FacebookLink{

	#region Constants

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
		return new FacebookLink(null, "Logro conseguido", "¡He conseguido el logro " + achievement + "!", null);
	}
	public static FacebookLink ContentUnlockedShare()
	{
		return new FacebookLink(null, "Contenido desbloqueado", "He desbloqueado contenido nuevo.", null);
	}
	public static FacebookLink PointsShare(bool isRecord, int points, string game)
	{
		return new FacebookLink(null, isRecord ? "Récord" : "Puntuación", "He conseguido " +(isRecord ? "un record de " : string.Empty) + points + " puntos en el juego " + game + ".", null);
	}
	public static FacebookLink RankingShare(int rankPos)
	{
		return new FacebookLink(null, "Clasificación", "He conseguido el puesto " + rankPos + ".", null);
	}
	#endregion
}
