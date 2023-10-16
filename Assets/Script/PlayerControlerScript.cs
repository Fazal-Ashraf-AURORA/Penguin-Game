using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlerScript : MonoBehaviour {
    [Header("Player Move and Rotation")]
    public float rotationRate = 90;
    public float moveSpeed;

    [Header("Player RayCasting")]
    public GameObject rayPoint;
    public float maxRayDistance;

    [Header("Player Distance Calculation")]
    public float distanceTravelled = -.5f;
    Vector3 lastPosition;

    [Header("Player Stemina")]
    public GameObject steminaBar;
    public float maxStemina = 4.5f;
    public float pengStemina; 


    // Use this for initialization
    void Start() {
       lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        MoveCharacter(); //this helped character Movement 
         
        distanceTravelled -= Vector3.Distance(transform.position, lastPosition);//show Distance Travelled by Player 
        lastPosition = transform.position;// this will help to track last frame position of character 

        PlayerSteminaControler();// Player Stemina controler function 

        //** Player stemina calculation Logic works here 
        pengStemina = distanceTravelled / maxStemina;
        Vector3 tempStemina = steminaBar.transform.localScale;
        tempStemina.x = pengStemina + 1f;
        steminaBar.transform.localScale = tempStemina;
        //** stemina calculation end here 

        // this will chnage the Stemina bar color to red if player distance traelled <= -3.5f
        if (distanceTravelled <= -3.5f)
        {
            steminaBar.GetComponent<Image>().color = new Color(255,0,0);
        }// this function end here 

    }


    private void FixedUpdate()
    {
        ///*** this section helps to cast the ray from the player, with fix ray distance 0.35f. and if it hit to Wall collider our charcter will rotate 90 degree y axis
        Vector3 forward = rayPoint.transform.TransformDirection(Vector3.up);
        Ray ray = new Ray(rayPoint.transform.position, forward);
        RaycastHit hit;
        Debug.DrawRay(rayPoint.transform.position, forward * maxRayDistance, Color.green);

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            if (hit.collider)
            {
                if (hit.collider.tag == "wall")
                {
                    transform.Rotate(0, rotationRate, 0);
                }
            }

        }// this section end here 


    } 

    //**** this function is for character movement 
    private void MoveCharacter()
    {
        transform.Translate(Vector3.forward * moveSpeed);
    }//** this end here 

    //** this function moniter player stemina, and if its <= -4.5, player will stop walking and Game Over 
    public void PlayerSteminaControler()
    {
        if (distanceTravelled <= -4.5f)
        {
            moveSpeed = 0;
            this.gameObject.GetComponent<Animator>().Play("idle");

        }
    }//*** this end here 


    //** this function help to collect fish, and reset Player stemina 
    IEnumerator OnTriggerStay(Collider other)
    {
        if (other.tag == "fish")
        {
            Destroy(other.gameObject);
            yield return new WaitForSeconds(.3f);
            distanceTravelled = -.5f;
        }
    }//** this end here 

}
