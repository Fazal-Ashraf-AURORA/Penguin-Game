using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class Mainmenu : MonoBehaviour
{
    public Animator animator;
    //public New_PlayerControlScript playerControlScript;

    public void OnPlayClicked() {
        StartCoroutine(LoadLevel("LevelSelection"));

    }


    public void OnQuitClicked() {
        Application.Quit();
        Debug.Log("Quit");
    }


    public IEnumerator LoadLevel(string level) {
        animator.SetTrigger("Walk");

        yield return new WaitForSeconds(1.6f);

        SceneManager.LoadScene(level);
    }
}
