using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    TileView tileView;
    TileModel tileModel;

    public void BuildTiles(int numberOfTiles){
        tileView = new TileView();

        tileModel = new TileModel(numberOfTiles);
        tileView.showTiles(tileModel.getTiles());
        tileView.showSpiral(tileModel.getTiles());

        
        
        // tileModel.getTiles().setRule(0,"2");
        // tileModel.getTiles().setRule(1,"-1");
        // tileModel.getTiles().setRule(2,"stop");
        // tileModel.getTiles().setRule(3,"extra");

    }

    public TileModel getTileModel(){
        return tileModel;
    }



}
