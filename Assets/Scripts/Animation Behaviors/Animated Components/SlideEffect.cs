using UnityEngine;
using System.Collections;

public class SlideEffect : MonoBehaviour, IAnimated {
	
	public enum Direction {
		Top,
		Bottom,
		Left,
		Right
	}

	[SerializeField]
	private GoEaseType _easeType;
	
	[SerializeField]
	private Direction _entranceDirectionFrom;
	
	[SerializeField]
	private float _distanceMultiplier = 1f;
	
	[SerializeField]
	private float _speed = 1f;
	
	[SerializeField]
	private float _delay = 0f;
	
	[SerializeField]
	private bool _playAlways = false;

	private GoTweenConfig _initialConfig = null;
	private GoTweenConfig _outsideConfig = null;

	void Awake() {
		RectTransform rectTransf = (transform as RectTransform);
		Vector2 pivot = rectTransf.pivot;
		_initialConfig = new GoTweenConfig();
		_initialConfig.pivot( new Vector2(pivot.x, pivot.y));
		_initialConfig.setDelay(_delay);
		
		_outsideConfig = new GoTweenConfig();
		GetEntranceDirectionConfig(ref _outsideConfig);
		_outsideConfig.setDelay(_delay);
		//_outsideConfig.anchoredPosition( new Vector2(rectTransf.rect.width, pos.y));
	}
	
	void Start() {
	}

	public void Open(float inheritedSpeed) {
		if (!_playAlways) {
			Play (inheritedSpeed, _initialConfig);
		} else {
			PlayFrom(inheritedSpeed, _outsideConfig, _initialConfig);
		}
	}

	public void Close(float inheritedSpeed) {
		if (!_playAlways) {
			Play (inheritedSpeed, _outsideConfig);
		} else {
			PlayFrom(inheritedSpeed, _initialConfig, _outsideConfig);
		}
	}
	
	private void Play(float inheritedSpeed, GoTweenConfig config) {
		if (config != null) {
			Go.to(transform, Mathf.Max(Mathf.Abs(1f / (_speed * inheritedSpeed)), 0.0001f), config).easeType = _easeType;
		}
	}
	private void PlayFrom(float inheritedSpeed, GoTweenConfig configFrom, GoTweenConfig configTo) {
		if (configFrom != null && configTo != null) {
			Go.to(transform, 1f, configFrom).complete();

			Go.to(transform, Mathf.Max(Mathf.Abs(1f / (_speed * inheritedSpeed)), 0.0001f), configTo).easeType = _easeType;
		}
	}
	
	private void GetEntranceDirectionConfig(ref GoTweenConfig config) {
		RectTransform rectTransf = (transform as RectTransform);
		Vector2 pivot = rectTransf.pivot;

		switch (_entranceDirectionFrom) {
		case Direction.Top:
			config.pivot( new Vector2(pivot.x, pivot.y + _distanceMultiplier));
			break;
		case Direction.Bottom:
			config.pivot( new Vector2(pivot.x, pivot.y - _distanceMultiplier));
			break;
		case Direction.Left:
			config.pivot( new Vector2(pivot.x - _distanceMultiplier, pivot.y));
			break;
		case Direction.Right:
			config.pivot( new Vector2(pivot.x + _distanceMultiplier, pivot.y));
			break;
		default:
			Debug.LogError("Slide effect direction not covered");
			break;
		}
	}
	
}
