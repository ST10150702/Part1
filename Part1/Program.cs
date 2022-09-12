//Game Dev Project
//Part 1

using System;

namespace Part1
{
    //Abstract class Tile
    public abstract class Tile
    {
        static int TileX, TileY;
        string sTileType;

        public enum TileType
        {
            Hero,Enemy,Gold,Weapon
        }

        public static void Initiate(int X, int Y)
        {
            TileX = X;
            TileY = Y;
        }

        public class ObstacleClass
        {
            public string Obstacle(int posX, int posY)
            {

                Tile.Initiate(posX, posY);
                return ("Obstacle");

            }
        }

        public class EmptyTileClass
        {
            public string EmptyTile(int posX, int posY)
            {
                Tile.Initiate(posX, posY);
                return ("Empty Tile");
            }
        }

    }

    



}

