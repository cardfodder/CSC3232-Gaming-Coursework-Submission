using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    float width = 0.1f;
    bool falling = true;

    [ SerializeField ]
    GameObject fRightBRight;

    [ SerializeField ]
    GameObject bLeftBRight;

    [ SerializeField ]
    GameObject bLeftFLeft;

    [ SerializeField ]
    GameObject fRightFLeft;

    [ SerializeField ]
    GameObject fRightBleft;

    [ SerializeField ]
    GameObject fleftBRight;

    [ SerializeField ]
    GameObject bLeftUFO;

    [ SerializeField ]
    GameObject fLeftUFO;

    [ SerializeField ]
    GameObject fRightUFO;

    [ SerializeField ]
    GameObject bRightUFO;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (falling == true) {
            width = width - 0.01f;
        }
        else {
            width = width + 0.01f;
        }

        if (width <= 0){
            falling = false;
        }
        else if (0.1 <= width) {
            falling = true;
        }
        
        fRightBRight.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        bLeftBRight.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        bLeftFLeft.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        fRightFLeft.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        fRightBleft.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        fleftBRight.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        bLeftUFO.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        fLeftUFO.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        fRightUFO.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
        bRightUFO.GetComponent<LineRenderer>().SetWidth(width, 0.12f-width);
    }
}
