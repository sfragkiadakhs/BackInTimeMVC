using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : Element
{
    // Data
    // public GameModel game;
    public PlayerModel players;
    // public SettingsModel settings;

    public string gameState;

    public void setGameState(string gameState){
        this.gameState = gameState;
    }

    public string getGameState(){
        return gameState;
    }
    

}