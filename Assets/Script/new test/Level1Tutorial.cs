using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Tutorial : MonoBehaviour {

    [Header("Player Anim Ref")]
    public Animator player;
    public New_PlayerControlScript playCntScript;
    public GameObject clickIcon, clickText;
    public int level1start; 

    RaycastHit hit;
    public bool hitFloor; 

    // Use this for initialization
    void Start() {
        hitFloor = false;
        level1start = 1; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level1start == 1)
        {
            StartCoroutine(PlayerWait());

            if (Input.GetMouseButtonDown(0))
            {
                Ray worldPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(worldPoint, out hit))
                {
                    if (hit.collider.gameObject.name == "Floor")
                    {
                        hitFloor = true;
                    }
                }
            }
        }
       
        
    }

        IEnumerator PlayerWait() {        
            yield return new WaitForSeconds(1.7f);
            player.Play("idle");
            playCntScript.moveSpeed = 0;
            clickIcon.SetActive(true);
            clickText.SetActive(true);

        if (hitFloor)
        {
            level1start = 0;
            player.Play("walk");
            playCntScript.moveSpeed = 0.01f;
            clickIcon.SetActive(false);
            clickText.SetActive(false);
        }
       }
    
}