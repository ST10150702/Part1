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
        public static int GoldPurse;

        public string[] Vision = { "North", "South", "East", "West" };

        //Movement Enum
        public enum Movement
        {
            NoMovement, Up, Down, Left, Right
        }¿¿

        public GoldPurse()
        {
            return GoldPurse;
        }

        public void Pickup(Item i)
        {
            if (i == "Gold")
            {
                GoldPurse++;
            }
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
        public static float EnemyHP;
        public static string EnemySymbol;

        public Enemy(int posX, int posY, int EnemyHP, int givenEnemyDamage, string Symbol)
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
        public SwampCreature(int posX, int posY)
        {

            Enemy.X = posX;
            Enemy.Y = posY;
            Enemy.EnemyHP= 10;
            Enemy.EnemyDamage = 1;
            Enemy.EnemySymbol = "$";

        }

        //Player ReturnMove override method
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

        //Hero class
        public class Hero : Character
        {
            int HeroX, HeroY, HeroDmg, HeroMaxHP;
            float HeroHP;
         
            //Hero Constructor
            public Hero(int posX, int posY, int HP)
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
                string Output = "Player Stats: \n HP: " + (Convert.ToString(HeroHP/HeroMaxHP)) + "\n Damage: " + HeroDmg + "\n Gold: " + (Convert.ToString(Character.GoldPurse) + "\n" + "[" + HeroX + " " + HeroY + "]";
                return Output;
            }

        }

    }

    public class Map
    {
        //Map creation array
        char[,] Tile = new string[8, 15] { {"X","X","X","X", "X" , "X" , "X" , "X" , "X" , "X" , "X" , "X" , "X" , "X" , "X" }, 
            {"X","*","*","*","*","*","*","*","*","*","*","*","*","*","X"},{"X","*","*","*","*","*","*","*","*","*","*","*","*","*","X"} 
            {"X","*","*","*","*","*","*","*","*","*","*","*","*","*","X"},
            {"X","*","*","*","*","*","*","*","*","*","*","*","*","*","X"},{"X","*","*","*","*","*","*","*","*","*","*","*","*","*","X"},
            {"X","*","*","*","*","*","*","*","*","*","*","*","*","*","X"},{"X","*","*","*","*","*","*","*","*","*","*","*","*","*","X"}};

        //Map variables
        Map Hero = new Map();
        string[] Enemy = { "Swamp Creatures", "Mage" };
        String[] Item = new string[Gold];
        static Random rndNumbers = new Random();

        int NumEnemies; 
        int MapWidth;
        int MapHeight;
        static int Gold;

        //Map constructor
        public Map(int MaxWidth, int MinWidth, int MaxHeight, int MinHeight, int NumberOfEnemies, int AmountOfGold)
        {
            MapWidth = MaxWidth;
            MapHeight = MaxHeight;
            NumEnemies = NumberOfEnemies;
            Gold = AmountOfGold;


            Create();
        }

        //Create()
        public void Create()
        {
            int i, k, PosX, PosY;
            i = rndNumbers.Next(1,6);

            for (k = 0; k <= i; k++)
            {
                PosX = rndNumbers.Next(1, 6);
                PosY = rndNumbers.Next(1, 6);

                Gold Gold = new Gold(PosX,PosY);
            }

            UpdateVision();


        }

        //UpdateVision
        public void UpdateVision()
        {

        }

        //Tile create
        private static Tile Create(Tile.TileType Type)
        {
            Random rnd = new Random();
            int TileX = rnd.Next(1, 16);
            int TileY = rnd.Next(1, 9);

            return (Tile);

        }

        public Item GetItemAtPosition(int X, int Y)
        {
            int i;
            for (i = 0; i < Item.Length; i++)
            {
                if (Item(X, Y))
                {
                    return Item;
                }
                else if (Item[i] == null)
                {
                    return null;
                }
            }
            
            
        }

    }

    //Q3.3
    //Game engine Class
    public class GameEngine
    {
        private Map map;

        public Map getMap()
        {
            return map;
        }

        GameEngine Map = new GameEngine();


        public bool MovePlayer()
        {
            if (SwampCreature.Hero.TileX == Item.TileX && SwampCreature.Hero.TileY == Item.TileY)
            {
                return true;
            }
        }

        public void EnemyAttacks()
        {
           
        }

        public void EnemyMove()
        {

        }

        //Q4.1
        private void Save()
        {
            string fileName = @"E:\Uni\Game Dev\Semester 2\Game Dev Project\Part1\bin";
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                binWriter.Write(Map.getMap);
            }
        }

        //Q4.2
        private void Load()
        {
            string fileName = @"E:\Uni\Game Dev\Semester 2\Game Dev Project\Part1\bin";
            using (BinaryReader binReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                Map map = Map.getMap(binReader.ReadString());
            }
        }

    }


    //Part 2
    //Q2.1
    public abstract class Item : Tile
    {

        public Item(int X, int Y)
        {
            Initiate(X, Y);

        }

        public abstract Type ToString();

       

    }

    //Q2.2
    //Concrete Class Gold
    public class Gold 
    {
        private int GoldAmount;
        private Random rndAmount;
        private int X, Y;

        public Gold(int PosX, int PosY)
        {
            X = PosX;
            Y = PosY;
            
            Item = new Item(X, Y);
            rndAmount.Next(1, 6);

        }

        //Q2.3
        //Concrete Class Mage
        public class Mage : Enemy
        {
            public Mage(int PosMageX, int PosMageY) 
            {
                Enemy.X = PosMageX;
                Enemy.Y = PosMageY;
                EnemyHP = 5;
                EnemyDamage = 5;
                EnemySymbol = "M";

            }

            public override Movement ReturnMove(Movement Move = Movement.NoMovement)
            {
                return 0;
            }

            public override bool CheckRange(Character target)
            {
                return base.CheckRange(target);
            }
        }



    }



}

