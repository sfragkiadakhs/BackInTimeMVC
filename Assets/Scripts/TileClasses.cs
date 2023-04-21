using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TileClasses{

    public class Circle
    {
        public int tile_id;
        public int circle_id;
        public float x,y,z;

        public Circle(int tile_id,int circle_id){
            this.tile_id = tile_id;
            this.circle_id = circle_id;
        }

        public void setPosition(float x,float y,float z){
            this.x = x;this.y = y; this.z =z;
        }

        public Vector3 getPosition(){
            return new Vector3(x,y,z);
        }
    }

    public class Tile
    {
        public int tile_id;
        public int number_of_circles;

        public Circle[] insideCircles;
        public Circle[] outsideCircles;

        public Vector3 TilePosition;

        public String rule;


        Vector3[] vertices;


        public Tile(int tile_id, int number_of_circles,int initial_dot){
            Vector2 dot_outside,dot_inside;
            int dots_created = 0;
            
            this.tile_id = tile_id;
            this.number_of_circles = number_of_circles;

            if(tile_id==0)
                insideCircles = null;
            else
                insideCircles = new Circle[number_of_circles];        
            
            outsideCircles = new Circle[number_of_circles];
        
            while(dots_created < number_of_circles){
                Spiral spiral = new Spiral();
                dot_outside =  spiral.CalculateSpiral( 1,  (float)0.1, initial_dot);
                outsideCircles[dots_created] = new Circle(tile_id,dots_created);
                outsideCircles[dots_created].setPosition(dot_outside.x,dot_outside.y,0);


                // GameObject dotInstance = (GameObject)Instantiate(s_dot);
                // dotInstance.name = "tile_"+tile_id+"dot_"+dots_created;
                // dotInstance.transform.position = new Vector3(dot_outside.x,dot_outside.y,0);
                // dotInstance.transform.localScale = new Vector3(s_dotScale,s_dotScale,s_dotScale);

                if(insideCircles!= null){
                    dot_inside =  spiral.CalculateSpiral( 1,  (float)0.1, initial_dot-360);
                    insideCircles[dots_created] = new Circle(tile_id,dots_created);
                    insideCircles[dots_created].setPosition(dot_inside.x,dot_inside.y,0);

                }
                initial_dot++;
                dots_created++;

            }
            
            float x,y,z;
            // taking the position the player moves
            if(tile_id == 0){
                x = outsideCircles[315].x + ( outsideCircles[0].x - outsideCircles[315].x )/2;
                y = outsideCircles[315].y + ( outsideCircles[0].y - outsideCircles[315].y )/2;
                z = outsideCircles[315].z + ( outsideCircles[0].z - outsideCircles[315].z )/2;
            }else{
                x = outsideCircles[(int)(dots_created/2)].x + ( insideCircles[(int)(dots_created/2)].x - outsideCircles[(int)(dots_created/2)].x )/2;
                y = outsideCircles[(int)(dots_created/2)].y + ( insideCircles[(int)(dots_created/2)].y - outsideCircles[(int)(dots_created/2)].y )/2;
                z = outsideCircles[(int)(dots_created/2)].z + ( insideCircles[(int)(dots_created/2)].z - outsideCircles[(int)(dots_created/2)].z )/2;
            }
            TilePosition = new Vector3(x,y,z);

        } 

        public int getNumberOfCircles(){
            return number_of_circles;
        }

        public Vector3 getTilePosition(){
            return TilePosition;
        }


        public Vector3[] getVertices(){
            Vector3[] vertices;

            int vertices_sum = 0;


            if(tile_id == 0){
                for(int i = 0; i < number_of_circles; i++)
                    vertices_sum ++;

                vertices = new Vector3[vertices_sum];

                for(int i = 0; i < outsideCircles.Length; i++)
                        vertices[i] = outsideCircles[i].getPosition();
            }else{
                for(int i = 0; i < number_of_circles; i++)
                    vertices_sum += 2;

                vertices = new Vector3[vertices_sum];
                for(int i = 0; i < insideCircles.Length; i++)
                    vertices[i] = insideCircles[i].getPosition();

                for(int i = 0; i < outsideCircles.Length; i++)
                    vertices[i + insideCircles.Length] = outsideCircles[i].getPosition();
            }
            this.vertices = vertices;
            return vertices;
        }

        public Vector2[] getUV(){
            Vector2[] UVs;
 
                UVs = new Vector2[vertices.Length];

                    float minX = vertices[0].x;
                    float maxX = vertices[0].x;
                    float minY = vertices[0].y;
                    float maxY = vertices[0].y;

                for(int i = 0; i < vertices.Length; i++){
                    if(vertices[i].x<minX) minX = vertices[i].x;
                    if(vertices[i].x>maxX) maxX = vertices[i].x;
                    if(vertices[i].y<minY) minY = vertices[i].y;
                    if(vertices[i].y>maxY) maxY = vertices[i].y;
                }

                for(int i = 0; i < vertices.Length; i++){
                    UVs[i] = new Vector2((vertices[i].x - minX)/(maxX-minX),(vertices[i].y-minY)/(maxY-minY));
                }
 
 
             return UVs;
        }

        public int[] getTriangles(){
            int triangles_sum = 0;
            int[] triangles;

            if(tile_id == 0){
                for(int i_out = 1; i_out < outsideCircles.Length-1;i_out++){
                    triangles_sum += 3;
                }

                triangles = new int[triangles_sum];
                int triangles_index = 0; // to move every loop, on 3 nodes
                for(int i_out = 1; i_out < outsideCircles.Length-1;i_out++){
                    // out[i_out] out[0] out[i_out+1] 
                    triangles[triangles_index] = i_out; 
                    triangles_index++;
                    triangles[triangles_index] = 0;
                    triangles_index++;
                    triangles[triangles_index] = i_out + 1;
                    triangles_index++;
                }
            }else{
                for(int i_out = 0; i_out < outsideCircles.Length-1;i_out++){ // we get until node_n-1, cause it already creates a triangle with node_n
                    triangles_sum += 6;
                }
                triangles = new int[triangles_sum];
                int triangles_index = 0; // to move every loop, on 6 nodes
                for(int i_in = 1; i_in < insideCircles.Length;i_in++){ // we get until node_n-1, cause it already creates a triangle with node_n
                    // in[i_in] out[i_in-1] in[i_in-1]
                    // in[i_in] out[i_in] out[i_in-1]
                    
                    // triangle 1
                    triangles[triangles_index] = i_in;
                    triangles_index++;
                    triangles[triangles_index] = i_in + outsideCircles.Length - 1;
                    triangles_index++;
                    triangles[triangles_index] = i_in - 1;
                    triangles_index++;
                    // triangle 2
                    triangles[triangles_index] = i_in;
                    triangles_index++;
                    triangles[triangles_index] = i_in + outsideCircles.Length;
                    triangles_index++;
                    triangles[triangles_index] = i_in + outsideCircles.Length - 1;
                    triangles_index++;
                }
            }

            return triangles;
        }

        public void setRule(String rule){
            // we should check for typo of rule name
            this.rule = rule;
        }

        public String getRule(){
            return rule;
        }

    }

    public class Tiles
    {
        public Tile[] tiles;
        public int[,] tiles_formation = new int[,] {{1,360},{1,180},{4,90},{8,45},{16,30},{-1,15}};
        public int initial_dot = 0;   //starting dot for a tile
        public int totalCircles = 0; 
        public int number_of_tiles;

        public Tiles(int number_of_tiles){
            this.number_of_tiles = number_of_tiles;
            tiles = new Tile[number_of_tiles];
            int position_tiles_formation = 0;
            for(int i = 0; i< number_of_tiles; i++){ // how many tiles do you want?

                if(tiles_formation[position_tiles_formation,0]==0)   // use of the how many tiles we want for specific degrees, if is 0 go to next number of tiles for available degrees 
                    position_tiles_formation++;

                tiles[i] = new Tile(i,tiles_formation[position_tiles_formation,1],initial_dot); // creates a tile with an id and the number of degrees it needs from the initial_dot
                initial_dot += tiles_formation[position_tiles_formation,1];

                if(tiles_formation[position_tiles_formation,0]!=-1)  // I use -1 as infinite, since we cant have negative number of tiles
                    tiles_formation[position_tiles_formation,0]--;   // so if its not -1, decrease the the tiles left to create for the specific degrees
                
                totalCircles+= tiles[i].getNumberOfCircles();
            }
            
            Array.Reverse(tiles);
        }

        public Tile[] getTiles(){
            return tiles;
        }

        public int getTotalCircles(){
            return totalCircles;
        }

            
        public void setRule(int tile_id, String rule){      // had to reverse the setRule so that the rule could adjust to the right tile
            tiles[number_of_tiles-1-tile_id].setRule(rule);

        }

        public String getRule(int tile_id){  
            return tiles[tile_id].getRule();
        }

    }

    public class Spiral{
        public Vector3 CalculateSpiral(float degree, float scale, int count){
            double angle = count * (degree * Mathf.Deg2Rad);

            float r = scale * Mathf.Sqrt(count);

            float x = (float)angle * r * (float)System.Math.Cos(angle);
            float y = (float)angle * r * (float)System.Math.Sin(angle);
            float z = -0.2f;
            Vector3 vec2 = new Vector3(x,y,z);
            return vec2;
        }
    }

}