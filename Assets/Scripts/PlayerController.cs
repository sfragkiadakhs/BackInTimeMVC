using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerModel playerModel;
    PlayerView playerView;

    public int queue = 0;
    
    public void initiatePlayers(){
        playerModel = new PlayerModel();
        playerView = new PlayerView();


        int numOfPlayers = 6; //PlayerPrefs.GetInt("numOfPlayers");
        playerModel.setPlayers(numOfPlayers);
        playerView.createPlayers(numOfPlayers,playerModel.getColors());

    }

    public void playerMovement(TileModel tileModel){
            int numOfPlayers = 6; 
            if(Input.GetKeyDown(KeyCode.Space)){
                if(queue == numOfPlayers)
                    queue = 0;
                PlayerClasses.Player[] players = playerModel.getPlayers();

                TileClasses.Tiles tiles = tileModel.getTiles();

                players[queue].movePosition(  new System.Random().Next(1, 6));
                print(players[queue].getPosition());
                
                // Checking if player has lost his turn
                if(players[queue].getMoveable()){
                    Vector3 playerPosOnTile = tiles.getTiles()[players[queue].getPosition()].getTilePosition();
                    playerView.movePlayerObject(queue,new Vector3(playerPosOnTile.x, playerPosOnTile.y, 0));
                    Debug.Log(tiles.getRule(players[queue].getPosition()));
                    if(tiles.getRule(players[queue].getPosition())=="stop"){ // for stoping
                        players[queue].setMoveable(false);
                        

                    }else if(tiles.getRule(players[queue].getPosition())=="extra"){ // for stoping
                        Debug.Log("Play Again Motherfucker");
                        queue--;

                    }else if(int.TryParse(tiles.getRule(players[queue].getPosition()) , out int movement) ){   // if the rule is an integer we move the players object

                        // print("Advantage "+movement);
                        players[queue].movePosition(movement);

                        playerPosOnTile = tiles.getTiles()[players[queue].getPosition()].getTilePosition();
                        playerView.movePlayerObject(queue,new Vector3(playerPosOnTile.x, playerPosOnTile.y, 0));

                        
                    }
                    // else if(tiles.getRule(players[queue].getPosition())=="FromStart"){ // go to start
                    //     Debug.Log("Unlucky u go to the begin 😦 ");
                    //     playerPosOnTile = tiles.getTiles()[players[queue].getPosition()].getTilePosition();
                    //     playerView.movePlayerObject(queue,new Vector3(74, -19, 0));


                    // }
                    queue++;
                }
                else{
                    players[queue].setMoveable(true);
                    queue++;
                }

            }
    }

    // public getPlayer(){
    //     return playerModel.getPlayers()[queue];
    // }

}
