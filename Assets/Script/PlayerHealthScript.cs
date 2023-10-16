using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript1 : MonoBehaviour {

    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
