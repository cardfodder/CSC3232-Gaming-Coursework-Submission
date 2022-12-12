using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [ SerializeField ]
    GameObject gravityTarget;

    [ SerializeField ]
    bool clockwise;

    void FixedUpdate() {
        Rigidbody r = GetComponent<Rigidbody>();
        r.AddForce(GetForceVector(), ForceMode.Force);
    }

    [ SerializeField ]
    float gravityScale;

    [ SerializeField ]
    float initialVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = transform.forward * initialVelocity;
    }

    Vector3 GetForceVector() {
        Vector3 direction = gravityTarget.transform.position - transform.position;

        float d = direction.magnitude;
        float reverseDir = 1;
        float strength = 1.0f/(d*d);

        if (clockwise == false) {
            reverseDir = 1;
        }

        return direction.normalized * strength * gravityScale * reverseDir;
    }

}
