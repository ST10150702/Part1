//Game Dev Project
//Part 1

using System;

namespace Part1
{
    //Abstract class Tile
    public abstract class Tile
    {
        public static int TileX, TileY;
        string sTileType;

        public enum TileType
        {
            Hero,Enemy,Gold,Weapon
        }

        //Initiate Class
        public static void Initiate(int X, int Y)
        {
            TileX = X;
            TileY = Y;
        }

        //ObstacleClass
        public class ObstacleClass
        {
            public string Obstacle(int posX, int posY)
            {

                Tile.Initiate(posX, posY);
                return ("Obstacle");

            }
        }
        //EmptyTileClass
        public class EmptyTileClass
        {
            public string EmptyTile(int posX, int posY)
            {
                Tile.Initiate(posX, posY);
                return ("Empty Tile");
            }
        }

    }

    //Character Abstract Class
    public abstract class Character
    {

        float HP, Damage;
        int MaxHP;

        string[] Vision = { "North", "South", "East", "West" };

        //Movement Enum
        public enum Movement
        {
            NoMovement, Up, Down, Left, Right
        }

        //Attack Method
        public virtual void Attack(Character target)
        {
            target.HP = HP - Damage; 
        }

        //isDead Method
        public bool isDead(float HP)
        {
            if (HP == 0)
            {
                return true;
            }
            else
                return false;  
        }

        //CheckRange Method
        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) == 1)
            {
                return true;
            }
            else
                return false;
        }

        //DistanceTo Method
        private int DistanceTo(Character target)
        {
            
        }

        //Movement Method
        public void Move(Movement Move)
        {
            if (Move == Movement.Up)
            {
                Tile.TileY = Tile.TileY + 1;
            }
            else if (Move == Movement.Down)
            {
                Tile.TileY = Tile.TileY - 1;
            }
            else if (Move == Movement.Left)
            {
                Tile.TileX = Tile.TileX - 1;
            }
            else if (Move == Movement.Right)
            {
                Tile.TileX = Tile.TileX + 1;
            }
        }

        public Movement ReturnMove(Movement Move = 0)
        {
           
        }

    }



}

