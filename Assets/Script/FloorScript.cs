using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        transform.tag = "static";
    }

    private void OnCollisionExit(Collision collision)
    {
        transform.tag = "floor";
    }
}
