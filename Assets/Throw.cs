using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [ SerializeField ]
    GameObject playerCamera;

    [ SerializeField ]
    GameObject rock;

    [ SerializeField ]
    float throwStrength = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) {
            //Instantiate(rock).transform.position = playerCamera.transform.position;
            //rock.GetComponent<Rigidbody>().AddForce(GetForceVector(), ForceMode.Force);
        //}
    }

    //Vector3 GetForceVector() {
        //Vector3 throwAngle = eulerAngles(playerCamera.transform.rotation);
        //return throwAngle * throwStrength;
    //}
}
