using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flightPath : MonoBehaviour
{
    [ SerializeField ]
    GameObject playerTarget;

    [ SerializeField ]
    public bool isCrashing = false;

    [ SerializeField ]
    float maxDistance;

    [ SerializeField ]
    GameObject UFO;

    [ SerializeField ]
    float detectionDistance = 60f;

    float targetDistanceFromPlayer;

    float daveDistanceFromPlayer;

    [ SerializeField ]
    public int state = 0;
    //state 0 is patrol
    //state 1 is investigate
    //state 2 is kill mode
    //state 3 is exploded

    public Vector3 targetLocation;

    bool travelling = false;

    public float UFOSpeed = 10;

    float timeRemaining = 5f;

    void FixedUpdate() {
        // if (isCrashing == false) {
        //     transform.RotateAround(orbitTarget.transform.position, Vector3.up, 20 * Time.deltaTime);
        // }

        float xSeperationDave = Mathf.Abs(transform.position.x - playerTarget.transform.position.x);
        float zSeperationDave = Mathf.Abs(transform.position.z - playerTarget.transform.position.z);
        daveDistanceFromPlayer = Mathf.Sqrt(xSeperationDave * xSeperationDave + zSeperationDave * zSeperationDave);
        
        if (GetComponent<Crash>().exploded == true) {
            state = 3;
        }

        switch (state){
            case 0:
                // PATROL STATE: look around randomly within a certain radius of the player. distace/totems-active+1
                    if (travelling == true) {
                        transform.position = Vector3.MoveTowards(transform.position, targetLocation, UFOSpeed);
                    } else {
                        targetLocation = new Vector3(Random.Range(60f, 920f), 190, Random.Range(105f, 920f));

                        // get target distance from player ignoring the y axis
                        float xSeperation = Mathf.Abs(targetLocation.x - playerTarget.transform.position.x);
                        float zSeperation = Mathf.Abs(targetLocation.z - playerTarget.transform.position.z);
                        
                        // if the target distance is too far from the player then we will make a new one on the next go around
                        targetDistanceFromPlayer = Mathf.Sqrt(xSeperation * xSeperation + zSeperation * zSeperation);
                        if (targetDistanceFromPlayer < (maxDistance/GetComponent<Crash>().detonate + 1)) {
                            travelling = true;
                        }
                        
                    }
                    
                    if (Vector3.Distance(transform.position, targetLocation) < 0.02f){
                        travelling = false;
                    }

                    if (daveDistanceFromPlayer < detectionDistance && Input.anyKey) {
                        travelling = false;
                        state = 1;
                    }

                break;
            case 1:
                // INVESTIGATE STATE: instead of random location, investigate location of interest, where a rock hit nearby, or if a player moved within a certain radius
                    
                    
                    if (travelling == true) {
                        transform.position = Vector3.MoveTowards(transform.position, targetLocation, UFOSpeed);
                    } else {
                        // Debug.Log("Player location = " + playerTarget.transform.position);
                        targetLocation = new Vector3(playerTarget.transform.position.x + Random.Range(-15f, 15f), 190, playerTarget.transform.position.z + Random.Range(-15f, 15f));
                        travelling = true;
                        // Debug.Log("New vector = " + targetLocation);
                    }

                    if (Vector3.Distance(transform.position, targetLocation) < 0.02f){
                        travelling = false;
                        state = 0;
                    }

                    if (daveDistanceFromPlayer < 5 || Input.anyKey && daveDistanceFromPlayer < 10) {
                        state = 2;
                    }
                        

                break;
            case 2:
                // KILL STATE: always update target location as the player's location until you have killed them
                    targetLocation = new Vector3(playerTarget.transform.position.x, 190, playerTarget.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, targetLocation, UFOSpeed);
                break;
            case 3:
                // DEATH STATE: activate crash script and end game
                
                if (timeRemaining <= 0) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                } else {
                    timeRemaining -= Time.deltaTime;
                }
                break;
            
        }
    }
}
