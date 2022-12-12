using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowMovement : MonoBehaviour
{
    [ SerializeField ]
    GameObject cameraTrack;

    // Update is called once per frame
    void Update()
    {
        Vector3 location = cameraTrack.transform.position;
        transform.position = location;
        transform.position = new Vector3(location.x - 17, location.y, location.z);
    }
}
