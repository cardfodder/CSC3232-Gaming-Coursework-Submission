using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [ SerializeField ]
    GameObject rayCastField;

    int layermask = 9;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
            
            Debug.Log("Hit!");
            
        }
    }
}
