using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	

	void Start() {
		GameEvents.current.onTimerOff += Explode;
	}

	void Explode() {
		Collider[] parts = Physics.OverlapSphere(transform.position, BombManager.current.radius, 1 << 6);

		foreach (Collider i in parts) {
			MapPart part = i.transform.GetComponent<MapPart>();

			if (part != null) {
				if (part.HP > 0) {
					part.HP--;
					if (part.HP <= 0) {
						print("destroyed");
						// Add score
					}
				}
			}
		}
	}
}