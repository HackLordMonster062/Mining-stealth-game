using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour {
	public static BombManager current;

	public int level;
	public int bombs;
	public float radius;
	float time;

	public LevelSettings obj;

	void Start() {
		current = this;

		level = obj.Level;
		bombs = obj.Bombs;
		radius = obj.Radius;
		time = obj.Time;

		GameEvents.current.onTimerOff += Explode;
	}

	void Update() {
		if (time < 0) {
			GameEvents.current.TimerOff();
			time = 0;
		} else {
			time -= Time.deltaTime;
		}
	}

	void Explode() {
		
	}
}
