using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMill : MonoBehaviour
{


    // Update is called once per frame
    void  FixedUpdate()
    {
        transform.Rotate(new Vector3(0,1,0));
    }
}
