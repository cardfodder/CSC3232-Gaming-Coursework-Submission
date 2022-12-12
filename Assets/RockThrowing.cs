using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrowing : MonoBehaviour
{
    [ Header("References") ]
    [ SerializeField ]
    public Transform cam;
    [ SerializeField ]
    public Transform attackPoint;
    [ SerializeField ]
    public GameObject objectToThrow;

    [ Header("Settings") ]
    [ SerializeField ]
    public int totalThrows;
    [ SerializeField ]
    public float throwCooldown;

    [ Header("Throwing") ]
    [ SerializeField ]
    public KeyCode throwKey = KeyCode.Mouse0;
    [ SerializeField ]
    public float throwForce;
    [ SerializeField ]
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = ((cam.transform.forward * throwForce) + (transform.up * throwUpwardForce));

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows = totalThrows - 1;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

}
