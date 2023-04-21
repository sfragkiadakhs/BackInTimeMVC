using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public PlayerClasses.Player[] players;
    public PlayerClasses.PlayerColor playerColor;
    // public PlayerModel(){

    // }

    public void setPlayers(int numOfPlayers){
         
        players = new PlayerClasses.Player[numOfPlayers];
        for(int i = 0; i< numOfPlayers; i++)
            players[i] = new PlayerClasses.Player();

        playerColor = new PlayerClasses.PlayerColor();
         
    }

    public PlayerClasses.Player[] getPlayers(){return players;}
    public PlayerClasses.PlayerColor getColors(){return playerColor;}
}




namespace PlayerClasses{

    public class Player{
        int position;
        bool moveable;
        public Player(){
            position = -1;
            moveable = true;
        }
        public void movePosition(int steps){
            if(position+ steps < PlayerPrefs.GetInt("numOfTiles"))
                position+=steps;
            else{
                position = PlayerPrefs.GetInt("numOfTiles") - 1;
                // print("Player won");
            }
        }
        public int getPosition(){
            return position;
        }
        public void setMoveable(bool moveable){
            this.moveable = moveable;
        }
        public bool getMoveable(){
            return moveable;
        }
    }

    public class PlayerColor{
        
        Color[] playerColors = new Color[6];

        public PlayerColor(){
            // Setting the colors
            for(int i = 0; i<6; i++)
                playerColors[i] = new Color();

            playerColors[0] = Color.red;
            playerColors[1] = Color.blue;
            playerColors[2] = Color.green;
            playerColors[3] = Color.yellow;
            playerColors[4] = Color.black;
            playerColors[5] = Color.white;       
        }

        public Color getColor(int index){
            return playerColors[index];
        }
    }
}