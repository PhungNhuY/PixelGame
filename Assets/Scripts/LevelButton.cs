using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelButton : MonoBehaviour
{
    public int LevelIndex;
    public void OnClick()
    {
        SceneManager.LoadScene($"level_{LevelIndex}");
        GameManager.instance.uICanvas.PanelInGame.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
