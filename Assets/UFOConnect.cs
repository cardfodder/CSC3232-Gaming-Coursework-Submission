using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOConnect : MonoBehaviour
{
    [ SerializeField ]
    GameObject connectTarget;
    [ SerializeField ]
    GameObject bLeft;
    [ SerializeField ]
    GameObject bRight;
    [ SerializeField ]
    GameObject fLeft;
    [ SerializeField ]
    GameObject fRight;

    // Update is called once per frame
    void Update()
    {
        Vector3 reference = connectTarget.transform.position;
        bLeft.GetComponent<LineRenderer>().SetPosition(1, new Vector3(reference.x - 273, reference.y - 33, reference.z - 424));
        bRight.GetComponent<LineRenderer>().SetPosition(1, new Vector3(reference.x - 273, reference.y - 33, reference.z - 424));
        fLeft.GetComponent<LineRenderer>().SetPosition(1, new Vector3(reference.x - 273, reference.y - 33, reference.z - 424));
        fRight.GetComponent<LineRenderer>().SetPosition(1, new Vector3(reference.x - 273, reference.y - 33, reference.z - 424));
    }
}
