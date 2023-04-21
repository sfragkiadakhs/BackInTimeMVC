using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel : MonoBehaviour
{

    public TileClasses.Tiles tiles;
    public int numberOfTiles;


    public TileModel(int numberOfTiles){
        this.numberOfTiles = numberOfTiles;

        tiles = new TileClasses.Tiles(numberOfTiles);
    }

    public int getNumberOfTiles(){
        return numberOfTiles;
    }

    public TileClasses.Tiles getTiles(){
        return tiles;
    }

}
