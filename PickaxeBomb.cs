using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeBomb : MonoBehaviour {
    public GameObject Bomb;
    public GameObject Pickaxe;
    public GameObject Prefab;

    [Space]
    public float force;

    public bool state = true; //false - Pickaxe true - Bomb

    BombManager Manager;
	
    void Start() {
        Manager = BombManager.current;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (state) {
                swap(false);
			} else {
                GameEvents.current.PlayerMine();
                //mine
			}
		}

        if (Input.GetMouseButtonDown(1) && Manager.bombs > 0) {
            if (!state) {
                swap(true);
            } else {
                Rigidbody rb = Instantiate(Prefab, Bomb.transform.position, Bomb.transform.rotation).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * force);
                Manager.bombs--;

                if (Manager.bombs <= 0) swap(false);
            }
        }
    }

    void swap(bool tool) {
        Pickaxe.SetActive(!tool);
        Bomb.SetActive(tool);

        state = tool;
	}
}
