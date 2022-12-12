using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
    [ SerializeField ]
    public GameObject player;

    [ SerializeField ]
    public GameObject daveUFO;

    [ SerializeField ]
    public GameObject topLeftTotem;

    [ SerializeField ]
    public GameObject topRightTotem;

    [ SerializeField ]
    public GameObject backLeftTotem;

    [ SerializeField ]
    public GameObject backRightTotem;

    UnityEngine.AI.NavMeshAgent agent;

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) < 50) {
            agent.destination = player.transform.position;
        } else {
            float tLeftDist = topLeftTotem.GetComponent<Interaction>().distToPlayer;
            float tRightDist = topRightTotem.GetComponent<Interaction>().distToPlayer;
            float bLeftDist = backLeftTotem.GetComponent<Interaction>().distToPlayer;
            float bRightDist = backRightTotem.GetComponent<Interaction>().distToPlayer;

            float shortDist;

            // if tLeftDist is shortest, = 0
            // if bLeftDist is shortest = 1
            // if tRightDist is shortest = 2
            // if bRightDist is shortest = 3

            if (tLeftDist < tRightDist) {
                
                if (bLeftDist < bRightDist) {

                    if (tLeftDist < bLeftDist){
                        shortDist = 0;
                    } else {
                        shortDist = 1;
                    }

                } else {
                    if (tLeftDist < bRightDist){
                        shortDist = 0;
                    } else {
                        shortDist = 3;
                    }
                }

            } else {

                if (bLeftDist < bRightDist) {

                    if (tRightDist < bLeftDist){
                        shortDist = 2;
                    } else {
                        shortDist = 1;
                    }

                } else {
                    if (tRightDist < bRightDist){
                        shortDist = 2;
                    } else {
                        shortDist = 3;
                    }
                }
            }

            // take the value assigned given the shortest value and set the agent destination accordingly
            switch (shortDist) {
                case 0:
                    agent.destination = topLeftTotem.transform.position;
                    break;
                case 1:
                    agent.destination = backLeftTotem.transform.position;
                    break;
                case 2:
                    agent.destination = topRightTotem.transform.position;
                    break;
                case 3:
                    agent.destination = backRightTotem.transform.position;
                    break;
            }
            
        }
        
    }
}
