using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FlockManager;

public class Flock : MonoBehaviour
{
    public float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(FlockManager.manager.minSpeed, FlockManager.manager.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10) < 10) {
            // angry boids space
            ApplyBOIDS();
        }
    }

    void ApplyBOIDS() {
        GameObject[] gos;
        gos = FlockManager.manager.allBirds;

        Vector3 centre = Vector3.zero;
        Vector3 avoid = Vector3.zero;

        float groupSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach(GameObject go in gos) {
            if (go != this.gameObject) {
                // make the birds stay together and stay in some kind of a flock
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);

                if (nDistance <= FlockManager.manager.neighbourDist) {
                    centre += go.transform.position;
                    groupSize = groupSize + 1;

                    if (nDistance < 1.0f) {
                        avoid = avoid + (this.transform.position - go.transform.position);

                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    groupSpeed = groupSpeed + anotherFlock.speed;
                }
            }
        }

        if (groupSize > 0) {
            // rotate toward direction
            centre = centre/groupSize + (FlockManager.manager.targetPos - this.transform.position);
            speed = groupSpeed / groupSize;
            Vector3 direction = (centre + avoid) - transform.position;
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockManager.manager.rotationSpeed * Time.deltaTime);
            }
        }
    }
}
