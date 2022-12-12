using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [ SerializeField ]
    GameObject floater;

    [ SerializeField ]
    GameObject beam;

    [ SerializeField ]
    GameObject UFO;

    bool triggered = false;

    public float distToPlayer = 0;

    [ SerializeField ]
    public GameObject player;

    void OnTriggerEnter(Collider collision) {
        if (triggered == false) {
            if (collision.gameObject.tag == "Player") {
                floater.GetComponent<Light>().range = 5;
                Color c1 = new Color(166, 2, 2);
                Color c2 = new Color(166, 2, 2);
                beam.GetComponent<LineRenderer>().SetColors(c1, c2);
                UFO.GetComponent<Crash>().detonate += 1;
                GetComponent<AudioSource>().Play();
                triggered = true;
            }
        }
        
    }

    void Update() 
    {
        // I'm storing the distance to the player to make it easier to implement so i dont have to call multiple components in the "Patrol" script
        distToPlayer = Vector3.Distance(player.transform.position, transform.position);
    }
    
}
