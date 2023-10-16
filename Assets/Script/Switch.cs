using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    [Header("Texture Ref")]
    public Texture switchOn;
    public Texture switchOff;

    [Header("Button Ref")]
    public GameObject switchButton;

    public GameObject switchPlate; 

    public bool textureOn; 

    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && switchButton.GetComponent<MeshRenderer>().material.mainTexture.name == "SwitchOn")
        {
            Debug.Log("play tile open animation here");
            switchPlate.transform.eulerAngles = new Vector3(switchPlate.transform.rotation.x, switchPlate.transform.rotation.y + 90, switchPlate.transform.rotation.z);
            switchPlate.GetComponent<Animator>().Play("SwitchPlateAni_Open");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && switchButton.GetComponent<MeshRenderer>().material.mainTexture.name == "SwitchOn")
        {
            switchButton.GetComponent<MeshRenderer>().material.mainTexture = switchOff;
            
        }
    }


}
