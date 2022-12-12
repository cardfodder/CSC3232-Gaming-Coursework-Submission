using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertUFO : MonoBehaviour
{
    bool collided = false;

    [ SerializeField ]
    GameObject UFO;

    void OnCollisionEnter(Collision collision)
    {
        if (collided == false) {
            if (UFO.GetComponent<flightPath>().state != 2 && UFO.GetComponent<flightPath>().state != 3) {
                UFO.GetComponent<flightPath>().state = 1;
                UFO.GetComponent<flightPath>().targetLocation = new Vector3(transform.position.x, 190, transform.position.y);
                collided = true;
            }
        }
    }

}
