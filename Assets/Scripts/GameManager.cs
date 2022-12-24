using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public UICanvas uICanvas;
    public static GameManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("Lobby");
        uICanvas.PanelHome.SetActive(false);
        uICanvas.PanelInGame.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PlayCurrentLevel()
    {
        uICanvas.PanelHome.SetActive(false);
        uICanvas.PanelInGame.SetActive(true);
        var currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel");
        SceneManager.LoadScene($"level_{currentLevelIndex}");
        GameManager.instance.uICanvas.PanelInGame.SetActive(true);
    }

    public void PlayLevelByIndex(int levelIndex)
    {
        SceneManager.LoadScene($"level_{levelIndex}");
        GameManager.instance.uICanvas.PanelInGame.SetActive(true);
    }

    public void NextLevel()
    {
        var currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel");
        currentLevelIndex++;
        PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
        PlayCurrentLevel();
    }

    public void OnClickPlay()
    {
        PlayCurrentLevel();
        
    }
    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void OnClickQuit()
    {
        ReturnHome();
    }

    public void WinGame()
    {
        if (PlayerPrefs.GetInt("CurrentLevel")==4)
        {
            SceneManager.LoadScene(7);
        }
        else
        {
            NextLevel();
        }
    }

    public void LoseGame()
    {

    }
}

