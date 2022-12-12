using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [ Header("Movement") ]
    [ SerializeField ]
    public float moveSpeed;

    [ SerializeField ]
    public float groundDrag;

    [ Header("Ground Check") ]
    [ SerializeField ]
    public float playerHeight;
    [ SerializeField ]
    public LayerMask whatIsGround;
    [ SerializeField ]
    bool grounded;

    [ SerializeField ]
    public Transform orientation;

    [ SerializeField ]
    GameObject UFO;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public bool dead = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (UFO.GetComponent<flightPath>().state == 2) {
            if (transform.position.y < 180){
                rb.velocity = transform.up * 20;
            } else {
                // reload the scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        } else {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            MyInput();
            SpeedControl();

            if (grounded) {
                rb.drag = groundDrag;
            } else {
                rb.drag = 0;
            }
        }
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed

        if (flatVel.magnitude > moveSpeed) {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }
    }
}
