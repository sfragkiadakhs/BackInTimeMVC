using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    GameObject[] player_object;

    public void createPlayers(int numOfPlayers,PlayerClasses.PlayerColor playerColors)
    {
         player_object = new GameObject[numOfPlayers];


        for(int i = 0; i< numOfPlayers; i++){
            player_object[i] =  GameObject.CreatePrimitive(PrimitiveType.Cube);
            player_object[i].transform.position = new Vector3(-95, 100, 0);
            player_object[i].transform.localScale = new Vector3(5,5,5);

            var playerRenderer = player_object[i].GetComponent<Renderer>();
            playerRenderer.material.SetColor("_Color", playerColors.getColor(i) );
        }
    }

    public void movePlayerObject(int playerN,Vector3 movement){
        player_object[playerN].transform.position  = movement;
    
    }
    
}
