using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float rotationRate = 90;
    public float moveSpeed = .01f;


    public GameObject rayPoint;
    public float maxRayDistance;

    public int playerStemina = 5;

   





    // Update is called once per frame
    void Update () {
       MoveCharacter();

        if (playerStemina <= 0)
        {
            this.gameObject.GetComponent<Animator>().Play("idle");
            moveSpeed = 0; 
        }
	}

    private void FixedUpdate()
    {
        Vector3 forward = rayPoint.transform.TransformDirection(Vector3.up);
        Ray ray = new Ray(rayPoint.transform.position, forward);
        RaycastHit hit;
       Debug.DrawRay(rayPoint.transform.position, forward * maxRayDistance, Color.red);
       
        if (Physics.Raycast(ray,out hit ,maxRayDistance))
        {
            if (hit.collider)
            {
                if (hit.collider.tag == "wall")
                {
                   transform.Rotate(0, rotationRate, 0);
                   
                }
            }


        }
    }

    private void MoveCharacter()
    {
        transform.Translate(Vector3.forward * moveSpeed);
    }


   /* private void OnTriggerExit(Collider other)
    {
        if (other.tag == "static")
        {
            playerStemina -= 1; 
        }
    }*/



}
