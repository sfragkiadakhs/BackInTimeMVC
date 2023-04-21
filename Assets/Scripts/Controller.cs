using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Element
{
    public Model model;
    public View view;

    public PlayerController playerController;
    public TileController tileController;

    // Start is called before the first frame update
    void Start()
    {
        // model.setGameState("in menu");
        view.showMenu();



    }

    // Update is called once per frame
    void Update()
    {   
        if(model.getGameState() == "in game")
            playerController.playerMovement(tileController.getTileModel());
        // else if(model.getGameState() == "")


    }


    public void startGame(){
        PlayerPrefs.SetInt("numOfTiles", 20);
        PlayerPrefs.SetInt("numOfPlayers", 6);
        
        tileController = new TileController();
        tileController.BuildTiles(20);
        playerController = new PlayerController();
        playerController.initiatePlayers();

        model.setGameState("in game");

    }




    public TileController getTileController(){
        return tileController;
    }
}