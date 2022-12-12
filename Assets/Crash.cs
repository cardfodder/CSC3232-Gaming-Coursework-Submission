using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [ SerializeField ]
    GameObject UFOObject;

    [ SerializeField ]
    GameObject spotlight;

    [ SerializeField ]
    GameObject tractorBeam;

    [ SerializeField ]
    GameObject dustFloor;

    [ SerializeField ]
    GameObject chassis;

    [ SerializeField ]
    GameObject bottom;

    [ SerializeField ]
    GameObject explosive;

    public bool exploded = false;

    public int detonate = 0;

    // Update is called once per frame
    void Update()
    {
        if (detonate == 4) {
            if (exploded == false) {
                tractorBeam.GetComponent<ParticleSystem>().Stop();
                dustFloor.GetComponent<ParticleSystem>().Stop();
                explosive.GetComponent<ParticleSystem>().Play();
                UFOObject.GetComponent<flightPath>().isCrashing = true;
                chassis.GetComponent<Rigidbody>().useGravity = true;
                bottom.GetComponent<Rigidbody>().useGravity = true;
                chassis.GetComponent<Rigidbody>().velocity = new Vector3(10,0,0);
                spotlight.GetComponent<Light>().intensity = 0;
                exploded = true;
            }
        }
    }
}
