using UnityEngine;
using System.Collections;

public class FadeImageEffect : MonoBehaviour, IAnimated {

	[SerializeField]
	private GoEaseType _easeType;
	
	[SerializeField]
	private float _speed = 1f;
	
	[SerializeField]
	private float _delay = 0f;
	
	[SerializeField]
	private bool _playAlways = false;

	private UnityEngine.UI.Image _imgToFade;

	private GoTweenConfig _initialConfig = null;
	private GoTweenConfig _finalConfig = null;

	void Awake() {
	
		_imgToFade = GetComponent<UnityEngine.UI.Image>();
		Debug.Log("-------------------------------------------" + _imgToFade);
		_initialConfig = new GoTweenConfig();
		_initialConfig.colorProp("color", new Color(_imgToFade.color.r, _imgToFade.color.g, _imgToFade.color.b, 1), false);
		_initialConfig.setDelay(_delay);

		_finalConfig = new GoTweenConfig();
		_finalConfig.colorProp("color",  new Color(_imgToFade.color.r, _imgToFade.color.g, _imgToFade.color.b, 0), false);
		_finalConfig.setDelay(_delay);

	}

	void Start() {
	}

	public void Open(float inheritedSpeed) {
		if (!_playAlways) {
			Play (inheritedSpeed, _initialConfig);
		} else {
			PlayFrom(inheritedSpeed, _finalConfig, _initialConfig);
		}
	}

	public void Close(float inheritedSpeed) {
		if (!_playAlways) {
			Play (inheritedSpeed, _finalConfig);
		} else {
			PlayFrom(inheritedSpeed, _initialConfig, _finalConfig);
		}
	}
	
	private void Play(float inheritedSpeed, GoTweenConfig config) {
		if (config != null) {
			Go.to(_imgToFade, Mathf.Max(Mathf.Abs(1f / (_speed * inheritedSpeed)), 0.0001f), config).easeType = _easeType;
		}
	}
	private void PlayFrom(float inheritedSpeed, GoTweenConfig configFrom, GoTweenConfig configTo) {
		if (configFrom != null && configTo != null) {
			Go.to(_imgToFade, 1f, configFrom).complete();
			
			Go.to(_imgToFade, Mathf.Max(Mathf.Abs(1f / (_speed * inheritedSpeed)), 0.0001f), configTo).easeType = _easeType;
		}
	}

	
}
