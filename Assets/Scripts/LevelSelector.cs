using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public Text levelText;
    public static int selectedLevel;

    // Start is called before the first frame update
    void Start()
    {
        //loading level numbers on level selection screen on runtime
        levelText.text = level.ToString();
    }

    public void OpenScene() {
        //This for loading level selection screen
        //SceneManager.LoadScene("Level " + level.ToString());

        //This if for the universal level selection for loading the universal level upon selection
        selectedLevel = level;
        SceneManager.LoadScene("UniversalLevel");
    }

    public void BackToMainmenu() {
        SceneManager.LoadScene("Mainmenu");
    }
}


