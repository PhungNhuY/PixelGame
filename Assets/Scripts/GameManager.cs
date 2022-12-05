using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //public int levelIndex;
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
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Lobby");
        uICanvas.PanelHome.SetActive(false);
    }
    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void OnClickQuit()
    {
        uICanvas.PanelInGame.SetActive(false);
        uICanvas.PanelHome.SetActive(false);
        OnClickPlay();
    }
}
