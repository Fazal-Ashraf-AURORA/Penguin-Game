using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UniversalLevelManager : MonoBehaviour {

    //public Sprite[] backgrounds;
    public Image background;
    public Text text;
    int level;

    public void Start()
    {
        int level = LevelSelector.selectedLevel;
        //Debug.Log("here" +level);
       // Debug.Log(level);
        text.text = "LEVEL "+level.ToString();
        //background.sprite = backgrounds[level-1];
    }
    private void Update() {
         level = LevelSelector.selectedLevel;
    }

    public void GoBackToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
    }

    public void GoBackToMainmenu() {
        SceneManager.LoadScene("Mainmenu");
    }

    public void BeginGame() {
        SceneManager.LoadScene("Level "+level.ToString());
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }
}