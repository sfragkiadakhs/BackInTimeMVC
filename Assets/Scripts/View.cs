using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class View : Element
{
    public GameObject BoardCanvas;
    public GameObject menuPanel;
    
    // Start is called before the first frame update
    void Awake()
    {
        BoardCanvas = GameObject.Find("application/view/BoardCanvas");
        menuPanel = GameObject.Find("application/view/BoardCanvas/MenuPanel");
        BoardCanvas.SetActive(true);

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMenu(){
        menuPanel.SetActive(true);
    }

    public void startGame(){
        Controller controller = GameObject.FindObjectOfType<Controller>();
        controller.startGame();
        menuPanel.SetActive(false);        
    }

}