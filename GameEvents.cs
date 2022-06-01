using System;
using UnityEngine;

public class GameEvents : MonoBehaviour {
	public static GameEvents current;

	private void Awake() {
		current = this;
	}

	public event Action onTimerOff;
	public void TimerOff() {
		if (onTimerOff != null) {
			onTimerOff();
		}
	}

	public event Action onPlayerMine;
	public void PlayerMine() {
		if (onPlayerMine != null) {
			onPlayerMine();
		}
	}
}
