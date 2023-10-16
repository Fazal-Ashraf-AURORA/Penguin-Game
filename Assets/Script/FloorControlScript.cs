using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControlScript : MonoBehaviour {

    RaycastHit hit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray worldPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(worldPoint, out hit))
            {
                if (hit.collider.gameObject.tag == "floor")
                {
                    hit.collider.gameObject.GetComponent<Animator>().Play("Floor_Ani");
                    Vector3 temp = hit.collider.gameObject.GetComponent<BoxCollider>().size;
                    temp.y = 1.0f;
                    hit.collider.gameObject.GetComponent<BoxCollider>().size = temp;
                    hit.collider.gameObject.tag = "wall";
                }
            }
        }
    }
}

