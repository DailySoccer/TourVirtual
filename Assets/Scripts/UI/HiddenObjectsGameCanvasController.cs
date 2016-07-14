using UnityEngine;


public class HiddenObjectsGameCanvasController : MonoBehaviour
{

	//public UIScreen HiddenObjectsMinigameHUD;
	public ModalHiddenObjectsGameScreen ModalHiddenObjectsGameScreen;
	public GameObject TopMenu;

	Animator _topMenuAnimator;

	HiddenObjects.HiddenObjects hiddenObjs;
	private SceneClicker _sceneClicker;

	// Use this for initialization
	private void Awake()
	{

		_topMenuAnimator = TopMenu.GetComponent<Animator>();
		_sceneClicker = GetComponentInChildren<SceneClicker>();
		_sceneClicker.SceneClick += OnSceneClick;

		hiddenObjs = HiddenObjects.HiddenObjects.Instance;
			//GameObject.FindGameObjectWithTag ("MainManager").GetComponent<HiddenObjects.HiddenObjects> ();
	}

	private void OnDestroy()
	{
		if(_sceneClicker != null)
			_sceneClicker.SceneClick -= OnSceneClick;
		_sceneClicker = null;
	}

	void HandleOnGameSuccess()
	{
		HiddenObjectsGameOver();
	}

	void HandleOnGameFail()
	{
		HiddenObjectsGameOver();
	}

	void HiddenObjectsGameOver()
	{
		hiddenObjs.OnGameSuccess -= HandleOnGameSuccess;
		hiddenObjs.OnGameFail -= HandleOnGameFail;
		IsHiddenObjectHUD_Open = false;
	}

	public void LaunchHiddenObjectMinigameModal()
	{
		ModalHiddenObjectsGameScreen.Launch_HiddenObjectModal(HiddenObjects.HiddenObjectGameResult.TUTORIAL_INICIO, "", true);
	}


	public void StartHiddenObjectsGame()
	{

		if (ModalHiddenObjectsGameScreen.IsGameFinished)
		{
			AudioInGameController.Instance.PlayDefinition(SoundDefinitions.MAIN_THEME, true);
			// Cerramos la modal
			ModalHiddenObjectsGameScreen.IsOpen = false;
			return;
		}

		hiddenObjs.OnGameSuccess -= HandleOnGameSuccess;
		hiddenObjs.OnGameSuccess += HandleOnGameSuccess;
		hiddenObjs.OnGameFail -= HandleOnGameFail;
		hiddenObjs.OnGameFail += HandleOnGameFail;

		// Cerramos la modal
		ModalHiddenObjectsGameScreen.IsOpen = false;

		if (ModalHiddenObjectsGameScreen.StartGameAfterClose)
		{
			// Comienza el juego
			hiddenObjs.Play(ModalHiddenObjectsGameScreen);
			//Activa el hud de hiddenObjects
			IsHiddenObjectHUD_Open = true;
		}
	}

	public void ForceStopHiddenObjectsGame()
	{
		// Finaliza el juego
		hiddenObjs.Stop();
		//Desctiva el hud de hiddenObjects
		HiddenObjectsGameOver();
	}


	public bool IsHiddenObjectHUD_Open
	{
		get { return Animator.GetBool("IsOpen"); }
		set
		{
			if (Animator != null)
			{
				Animator.SetBool("IsOpen", value);
			}
		}
	}

	public Animator Animator
	{
		get
		{
			if (_topMenuAnimator == null)
			{
				_topMenuAnimator = GetComponent<Animator>();
			}
			return _topMenuAnimator;
		}
	}

	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="clickedGo"></param>
	public void OnSceneClick(GameObject clickedGo)
	{
		if (clickedGo.layer != LayerMask.NameToLayer("Content"))
			return;

		var contentList = clickedGo.GetComponent<ContentList>();
		if (contentList == ContentManager.Instance.ContentNear
		    && ContentManager.Instance.ContentNear.ContentKey.Contains("JUEGO"))
			LaunchHiddenObjectMinigameModal();
	}


}
