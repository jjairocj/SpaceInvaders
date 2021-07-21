using System;
using System.Collections.Generic;

namespace SpaceInvaders
{
    public class GameBoard
    {
        public void SetBoardSize(int width, int height){
            Console.SetWindowSize(width, height); 
        }

        public void ClearScreen(){
            Console.Clear();
        }

        public void RenderHero(Hero hero){
            
            Console.ForegroundColor = ConsoleColor.Green;
            if(hero.PosX < 0)
                hero.PosX = 0;
            else if(hero.PosX > 80)
                hero.PosX = 80;
            else if(hero.PosY < 0)
                hero.PosY = 0;
            else if(hero.PosY > 30)
                hero.PosY = 30;
            Console.SetCursorPosition(hero.PosX, hero.PosY);
            Console.Write(hero.Symbol);
            Console.ResetColor();
        }

        public void RenderInvader(List<Invader> invaders){
            Console.ForegroundColor = ConsoleColor.Red;
            if (invaders != null)
            {
                foreach (var invader in invaders)
                {
                    if (invader.PosY == 30)
                    {
                        RemoveOutOfBoundInvader(invader);
                    }
                    else
                    {
                        Console.SetCursorPosition(invader.PosX, invader.PosY);
                        Console.Write(invader.Symbol);
                    }
                }
            }
            Console.ResetColor();
        }
        public void RenderBullets(List<Bullet> bullets)
        {
            if (bullets != null)
            {
                foreach (var bullet in bullets)
                {
                    if (bullet.PosY == 0)
                    {
                        RemoveOutOfBoundBullet(bullet);
                    }
                    else
                    {
                        Console.SetCursorPosition(bullet.PosX, bullet.PosY);
                        Console.Write(bullet.Symbol);
                    }
                }
            }
        }

         private void RemoveOutOfBoundBullet(Bullet bullet){
            if (bullet != null)
            {
                Console.SetCursorPosition(bullet.PosX, bullet.PosY);
                Console.Write('\0');
            }
        }

        private void RemoveOutOfBoundInvader(Invader invader){
            if (invader != null)
            {
                Console.SetCursorPosition(invader.PosX, invader.PosY);
                Console.Write('\0');
            }
        }

        public void DisplayGameScore(int gameScore){
            Console.SetCursorPosition(5,32);
            Console.Write($"Game Score: {gameScore}");
        }

        public void DisplayEscapedInvadersCount(int escapesCount){
            Console.SetCursorPosition(50,32);
            Console.Write($"Escaped Invaders: {escapesCount}");
        }

        public void HideCursor(){
            Console.CursorVisible = false;
        }


    }


}