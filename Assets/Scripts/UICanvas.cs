using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour

{
    public GameObject PanelInGame;
    public GameObject PanelHome;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        PanelInGame.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
