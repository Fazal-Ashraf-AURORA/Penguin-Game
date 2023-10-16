using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_FloorControlScript : MonoBehaviour {

    [Header("Ref For Texturea")]
    public Texture blueFrontTexture;
    public Texture blueBackTexture;
    public Texture blueLeftTexture;
    public Texture blueRightTexture;
    public Texture whiteFrontTexture;
    public Texture whiteBackTexture;
    public Texture whiteLeftTexture;
    public Texture whiteRightTexture;

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
                //*** Blue tile direction texture and Tag change logic
                if (hit.collider.gameObject.tag == "bluefront")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture = blueRightTexture;
                    hit.collider.tag = "blueright";
                }

                else if (hit.collider.gameObject.tag == "blueright")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture = blueBackTexture;
                    hit.collider.tag = "blueback";
                }

                else if (hit.collider.gameObject.tag == "blueback")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture = blueLeftTexture;
                    hit.collider.tag = "blueleft";
                }

                else if (hit.collider.gameObject.tag == "blueleft")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture = blueFrontTexture;
                    hit.collider.tag = "bluefront";
                }//*** Blue tile direction and Tag change logic end here 

                //*** white tile direction texture and Tag change logic
                else if (hit.collider.gameObject.tag == "whitefront")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture = whiteRightTexture;
                    hit.collider.tag = "whiteright";
                }

                else if (hit.collider.gameObject.tag == "whiteright")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture = whiteBackTexture;
                    hit.collider.tag = "whiteback";
                }

                else if (hit.collider.gameObject.tag == "whiteback")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture = whiteLeftTexture;
                    hit.collider.tag = "whiteleft";
                }

                else if (hit.collider.gameObject.tag == "whiteleft")
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture = whiteFrontTexture;
                    hit.collider.tag = "whitefront";
                }//*** white tile direction and Tag change logic end here 

            }//**Physics.Raycast end here 

        }//** input get button down end here 

    }
}
