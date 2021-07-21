using System;
using System.Collections.Generic;

namespace SpaceInvaders
{
    public class GameState
    {
        public Hero Hero { get; set;}
        public List<Invader> Invaders {get; set;}
        public List<Bullet> Bullets {get; set;}
        public int GameScore {get; set;}
        public int EscapedInvaderCount { get; set; }

        public GameState()
        {
            Hero = new Hero(38,30);
            Bullets = new List<Bullet>();
            Invaders = new List<Invader>(){
                new Invader(20,0)
            };
        }

        public void GetKeyPress(){

            if(Console.KeyAvailable){
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Hero.PosY -= 1;
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                            Hero.PosX -= 1;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Hero.PosY += 1;
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                            Hero.PosX += 1;
                        break;

                    case ConsoleKey.Spacebar:
                        Bullets.Add(new Bullet(Hero.PosX, Hero.PosY));
                        break;
                }
            }
        }

        public void GenerateInvader(){
            Random random = new Random();
            int xPosition = random.Next(10,70);
            var invader = new Invader(xPosition, 0);
            Invaders.Add(invader);
        }

        public void UpdateBulletLocation(){
            var activeBullets = new List<Bullet>();
            if(Bullets != null){
                foreach(var bullet in Bullets){
                    if(!CheckKill(bullet)){
                        if(bullet.PosY != 0){
                            bullet.PosY -= 1;
                            activeBullets.Add(bullet);
                        }
                    }
                }
            }
            Bullets = activeBullets;
        }

        public bool CheckKill(Bullet bullet){
            if(bullet != null){
                var killedInvader = Invaders.Find(x => x.PosX == bullet.PosX && x.PosY ==bullet.PosY);
                if(killedInvader != null){
                    Invaders.Remove(killedInvader);
                    GameScore++;
                    return true;
                }
                return false;
            }
            return false;
        }

        public void UpdateInvaderLocation(){
            var activeInvaders = new List<Invader>();

            if(Invaders != null){
                foreach(var invader in Invaders){
                    if(invader.PosY != 30)
                    {
                        invader.PosY += 1;
                        activeInvaders.Add(invader);
                    }
                    else if(invader.PosY == 30){
                        EscapedInvaderCount++;
                    }
                }
            }
            Invaders = activeInvaders;
        }

        public bool CheckGameOver(){
            return EscapedInvaderCount >= 5;
        }

    }

}