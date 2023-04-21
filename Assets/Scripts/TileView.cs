using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : MonoBehaviour
{
    GameObject[] gameObjectTiles;


    public void showTiles(TileClasses.Tiles tiles)
    {
        gameObjectTiles = new GameObject[tiles.getTiles().Length];

        foreach (TileClasses.Tile tile in tiles.getTiles()){
            createTileObject(tile);
        }
    }

    public void createTileObject(TileClasses.Tile tile){
        
        Vector3[] vertices = tile.getVertices();
        Vector2[] uv = tile.getUV();
        int[] triangles = tile.getTriangles();

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
                
        gameObjectTiles[tile.tile_id] = new GameObject("Mesh"+tile.tile_id, typeof(MeshFilter),typeof(MeshRenderer));
        gameObjectTiles[tile.tile_id].transform.localScale = new Vector3(1,1,1);

        gameObjectTiles[tile.tile_id].GetComponent<MeshFilter>().mesh = mesh;

        Material mat = new Material(Shader.Find("Standard"));
        gameObjectTiles[tile.tile_id].GetComponent<MeshRenderer>().material.CopyPropertiesFromMaterial(mat);
        
        gameObjectTiles[tile.tile_id].AddComponent<MeshCollider>();
        // gameObjectTiles[tile.tile_id].AddComponent<ClickTile>();
        ClickTile a = gameObjectTiles[tile.tile_id].AddComponent<ClickTile>();
        gameObjectTiles[tile.tile_id].transform.parent = GameObject.Find("application/view/Tiles").transform;
        a.Tilenumber = tile.tile_id;
        mesh.RecalculateNormals();    //couldnt cast light right on tiles, savior https://answers.unity.com/questions/1038189/generated-mesh-not-being-lit.html  

    }


    public void showSpiral(TileClasses.Tiles tiles)
    {

        Color color = Color.white;

        GameObject myLine = new GameObject("Line");            // Setting of Line
        myLine.transform.position = new Vector3(0,0,0);        // * position of the line
        myLine.AddComponent<LineRenderer>();                   // * adding a renderer for our line
        
        LineRenderer lr = myLine.GetComponent<LineRenderer>();  // Setting line renderer
        lr.material = new Material(Shader.Find("Standard"));    // * our material

        Color lineColor = new Color(0.58f, 0.58f, 0.58f, 1.0f);
        lr.material.SetColor("_Color", lineColor);



        lr.positionCount  = tiles.getTotalCircles();            // * total positions on line 
        lr.generateLightingData = true;                         // * to have good lightning when light get on the renderer
        lr.SetColors(color, color);                             // * setting colors
        lr.SetWidth(1f, 1f);                                // * width of line
        
        
        TileClasses.Spiral spiral = new TileClasses.Spiral();
        for(int i = 0; i < tiles.getTotalCircles(); i++){
            lr.SetPosition(i, spiral.CalculateSpiral(1, (float)0.1, i));
        }
        // GameObject.Destroy(myLine, duration);
    }



}
