using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour {

    public bool resetLevel;
    public bool levelComplete;
    public New_PlayerControlScript playerController;
    public Animator transition;
    [SerializeField] float transitionTime = 1f;

  

    public void Start() {
        playerController = FindObjectOfType<New_PlayerControlScript>();
        resetLevel = playerController.resetLevel;
        levelComplete = playerController.levelComplete;

        if (playerController == null) {
            Debug.LogError("New_PlayerControlScript not found in the scene.");
        }
    }

    public void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex + 1);
        StartCoroutine(LoadLevel(currentSceneIndex + 1));
    }

    public IEnumerator LoadLevel(int level) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(level);
    }

    public void RestartLevel() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void Update() {
        if (playerController != null && playerController.resetLevel == true) {
            //Application.LoadLevel(Application.loadedLevel);
            //Debug.Log("Reset Level");
            RestartLevel();
        }

        if(levelComplete == true ) {
            transition.SetTrigger("Start");
        }
    }

    public void GoBackToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
    }


}

