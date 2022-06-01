using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	public static bool isPaused;

	public void quit() {
		Application.Quit();
	}

	public void Pause(bool pause) {
		Cursor.lockState = CursorLockMode.None;
		Time.timeScale = pause ? 0 : 1;
		isPaused = pause;
		gameObject.SetActive(pause);
	}
}
