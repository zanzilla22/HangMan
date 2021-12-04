using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class sceneManager : MonoBehaviour
{
    public string singlePlayerScene;


    public void loadSinglePlayer()
    {
        SceneManager.LoadScene(singlePlayerScene);
    }
    public void backOut()
    {
        Application.Quit();
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
