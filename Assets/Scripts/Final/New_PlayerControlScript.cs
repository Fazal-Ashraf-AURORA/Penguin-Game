using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class New_PlayerControlScript : MonoBehaviour {

    [Header("Player Move and Rotation")]
    public float rotationRate = 90;
    public float moveSpeed;
   

    [Header("Player Animator")]
    public Animator playerAnimator;

    [Header("Player Distance Calculation")]
    public float distanceTravelled = 0f;
    Vector3 lastPosition;

    [Header("Player Stamina")]
    public GameObject staminaBar;
    public float maxStamina = 4.4f;
    public float pengStamina;

    [Header("Camera")]
    public Animator grpCamera;

    [Header("Player RayPoint")]
    public GameObject rayPoint;
    public float maxRayDistance;
    public bool reachedIgloo;

    [Header("UI Elements")]
    public GameObject GameEndUI;
    public bool levelComplete = false;
    public bool resetLevel;

    #region Penguin Animations

    const string PENGUIN_IDLE = "Penguin_idle";
    const string PENGUIN_WALK = "Penguin_walk";
    const string PENGUIN_INTERACT = "Penguin_interact";
    const string PENGUIN_DEATH = "Penguin_death";

    #endregion


    private void Awake() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
    }
    // Use this for initialization
    private void Start () {
        Application.targetFrameRate = 60;
        maxRayDistance = 0.4f;
        lastPosition = transform.position;
        reachedIgloo = false;
        resetLevel = false;



    }

    // Update is called once per frame
    private void Update () {
   
        MoveCharacter();

        distanceTravelled -= Vector3.Distance(transform.position, lastPosition);//show Distance Travelled by Player 
        lastPosition = transform.position;// this will help to track last frame position of character 

        PlayerStaminaControler();// Player Stemina controler function 


        //** Player stemina calculation Logic works here 
        pengStamina = distanceTravelled / maxStamina;
        Vector3 tempStamina = staminaBar.transform.localScale;
        tempStamina.x = pengStamina + 1f;
        staminaBar.transform.localScale = tempStamina;
        //** stemina calculation end here 

        // this will chnage the Stemina bar color to red if player distance traelled <= -3.5f
        if (distanceTravelled <= -3.5f)
        {
            staminaBar.GetComponent<Image>().color = new Color(255, 0, 0);
        }
        if (distanceTravelled > -3.5f) {
            staminaBar.GetComponent<Image>().color = new Color(0, 255, 0);
        }
        // this function end here 
    }


    private void FixedUpdate()
    {
        Vector3 forward = rayPoint.transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(rayPoint.transform.position, forward);
        RaycastHit hit;
        Debug.DrawRay(rayPoint.transform.position, forward * maxRayDistance, Color.green);

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            if (hit.collider)
            {
                if (hit.collider.tag == "Igloo")
                {
                    reachedIgloo = true;

                }
            }

        }


    }



    //**** this function is for character movement 
    private void MoveCharacter()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }//** this end here 

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bluefront" || other.gameObject.tag == "whitefront")
        {
            yield return new WaitForSeconds(.4f);
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if (other.gameObject.tag == "blueright" || other.gameObject.tag == "whiteright")
        {
            yield return new WaitForSeconds(.4f);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

        if (other.gameObject.tag == "blueback" || other.gameObject.tag == "whiteback")
        {
            yield return new WaitForSeconds(.4f);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (other.gameObject.tag == "blueleft" || other.gameObject.tag == "whiteleft")
        {
            yield return new WaitForSeconds(.4f);
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if (reachedIgloo)
        {
            grpCamera.Play("CutScene");
            yield return new WaitForSeconds(.3f);
            //transform.localScale = new Vector3(.5f, .5f, .5f);
            //Vector3 tempScale = transform.localScale;
            //tempScale.x -= .5f;
            //tempScale.y -= .5f;
            //tempScale.z -= .5f;
            //transform.localScale = tempScale;
            moveSpeed = 0;
            playerAnimator.Play(PENGUIN_IDLE);
            yield return new WaitForSeconds(1.8f);
            moveSpeed = 0.5f;
            playerAnimator.Play(PENGUIN_WALK);
            yield return new WaitForSeconds(1.5f);
            //gameObject.SetActive(false);
            moveSpeed = 0;
            playerAnimator.Play(PENGUIN_IDLE);
            levelComplete = true;
            yield return new WaitForSeconds(2f);
            GameEndUI.SetActive(true);
        }
        if (other.gameObject.tag == "Reset") {
            resetLevel = true;
            Debug.Log("Reset Player");
        }
    }

    //** this function help to collect fish, and reset Player stemina 
    IEnumerator OnTriggerStay(Collider other)
    {
        if (other.tag == "fish")
        {
            playerAnimator.Play(PENGUIN_INTERACT);
            Destroy(other.gameObject);
            yield return new WaitForSeconds(.3f);
            distanceTravelled = 0f;
        }
    }//** this end here 

    //** this function moniter player stemina, and if its <= -4.5, player will stop walking and Game Over 
    public void PlayerStaminaControler()
    {
        if (distanceTravelled <= -4.0f)
        {
            moveSpeed = 0;
            playerAnimator.Play(PENGUIN_DEATH);
            StartCoroutine(ResetLevel());
        }

        
    }//*** this end here 
    public IEnumerator ResetLevel() {
        yield return new WaitForSeconds(2);
            GameEndUI.SetActive(true);
    }

}
