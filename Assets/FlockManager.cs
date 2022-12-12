using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager manager;
    public GameObject bird;
    public int birdCount = 15;
    public GameObject[] allBirds;
    public Vector3 flightArea = new Vector3(5, 5, 5);
    public Vector3 targetPos = Vector3.zero;



    [Header("Bird Settings")]
    [ SerializeField ]
    public float minSpeed = 2;
    [ SerializeField ]
    public float maxSpeed = 5;

    [ SerializeField ]
    public float neighbourDist;
    [ SerializeField ]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        allBirds = new GameObject[birdCount];
        for (int i = 0; i < birdCount; i++) {
            // spawn the birds in
            Vector3 position = transform.position + new Vector3(Random.Range(-flightArea.x, flightArea.x), Random.Range(-flightArea.y, flightArea.y), Random.Range(-flightArea.z, flightArea.z));

            allBirds[i] = Instantiate(bird, position, Quaternion.identity);
        }
        manager = this;
        targetPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10) < 10) {
            targetPos = transform.position + new Vector3(Random.Range(-flightArea.x, flightArea.x), Random.Range(-flightArea.y, flightArea.y), Random.Range(-flightArea.z, flightArea.z));
        }
    }
}
