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
    public abstract class Character : Tile
    {

        float HP, Damage;
        int MaxHP;

        public string[] Vision = { "North", "South", "East", "West" };

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

        public abstract Movement ReturnMove(Movement Move = 0);

    }

    //Enemy Class that inherits from Character class
    public abstract class Enemy : Character
    {
        public Random rnd = new Random();
        public static int EnemyMaxHP, EnemyDamage, X, Y;
        public float EnemyHP;
        public string EnemySymbol;

        public void constructEnemy(int posX, int posY, int EnemyHP, int givenEnemyDamage, string Symbol)
        {
            X = posX;
            Y = posY;
            EnemyMaxHP = EnemyHP;
            EnemyDamage = givenEnemyDamage;
            EnemySymbol = Symbol;
        }

        private static void ToString()
        {
            Console.WriteLine("Enemy at " + (Convert.ToString(X)) + " " + (Convert.ToString(Y)) + (Convert.ToString(EnemyDamage)));
        }

    }

    public class SwampCreature : Enemy
    {
        public void constructSwampCreature(int posX, int posY)
        {
            X = posX;
            Y = posY;
            EnemyHP = 10;
            EnemyDamage = 1;
            EnemySymbol = "$";
        }

        public override Movement ReturnMove(Movement Move = Movement.NoMovement)
        {
            int MovementInt = rnd.Next(1, 6);
            
            if (MovementInt == 1)
            {
                
                return Movement.NoMovement;
                
            }
            else if (MovementInt == 2)
            {

                return Movement.Up;

            }
            else if (MovementInt == 3)
            {
                return Movement.Down;

            }

            else if (MovementInt == 4)
            {

                return Movement.Left;

            }
            else if (MovementInt == 5)

                return Movement.Right;

            else
                return 0;
        }

        public class Hero : Character
        {
            int HeroX, HeroY, HeroDmg, HeroMaxHP;
            float HeroHP;
         

            public void constructHero(int posX, int posY, int HP)
            {
                HeroX = posX;
                HeroY = posY;
                HeroHP = HP;
                HeroMaxHP = HP;
                HeroDmg = 2;

                Initiate(HeroX, HeroY);
            }

            //Override ReturnMove within Character Subclass
            public override Movement ReturnMove(Movement Move = Movement.NoMovement)
            {
                if (Move == Movement.NoMovement)
                {
                    return 0;
                }
                else if (Move == Movement.Up)
                {
                    return Movement.Up;
                }
                else if (Move == Movement.Down)
                {
                    return Movement.Down;
                }
                else if (Move == Movement.Left)
                {
                    return Movement.Left;
                }
                else if (Move == Movement.Right)
                {
                    return Movement.Right;
                }
                else
                    return 0;
            }

            //Overrided ToString method in Character Subclass
            private string ToString()
            {
                string Output = "Player Stats: \n HP: " + (Convert.ToString(HeroHP/HeroMaxHP)) + "\n Damage: " + HeroDmg + "[" + HeroX + " " + HeroY + "]";
                return Output;
            }

        }

    }

}

