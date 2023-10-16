using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour {

    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
