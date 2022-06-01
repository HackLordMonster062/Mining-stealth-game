using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinerController : MonoBehaviour {

    public float Radius;
    public float Angle;
    public LayerMask PlayerMask;

    PickaxeBomb PBref;
    NavMeshAgent agent;

    bool isConscious = true;
    bool isGoing;

    bool playerIsMining;
	
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        PBref = GameObject.FindGameObjectWithTag("Player").GetComponent<PickaxeBomb>();
    }

    void Update() {
        if (isConscious) {
            if (PlayerInView()) {
                StartCoroutine("CheckPlayer()");
            }
        }
    }

    void Go() {
        if (!isGoing) {

		}
	}

    IEnumerable CheckPlayer() {
        if (isGoing) { 
            // (Start following player)
        }

        isConscious = false;

        bool stop = false;
        while (!stop) {
            switch (SuspicionBar.bar.state) {
                case 0:
                    if (PBref.state) SuspicionBar.bar.count += .1f;
                    else stop = true;
                    break;

                case 1:


                default:
                    yield return new WaitForSeconds(Time.deltaTime);
                    break;
            }
        }

        // (Stop following player)
        yield return new WaitForSeconds(2);
        isConscious = true;
    }

    bool PlayerInView() {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector3.SqrMagnitude(player.position - transform.position) <= Radius*Radius) {
            if (Vector3.Angle(transform.forward, (player.position - transform.position).normalized) < Angle) {
                return true;
			}
		}

        return false;
	}

    IEnumerable Mine(float time) {
        //anim.SetBool("Mining", true);
        yield return new WaitForSeconds(time);
        //anim.SetBool("Mining", false);
        
    }

    void PlayerMining() {

	}
}
