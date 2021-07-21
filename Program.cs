using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceInvaders
{
    class Game
    {
        static int FrameCount = 0;
        static void Main(string[] args)
        {
            RenderWelcomeScreen();
            var gameState = new GameState();

            while(true){
                var initialTimeStamp = DateTime.Now;
                var state = HandleFrame(gameState);
                if(state.CheckGameOver())
                {
                    RenderGameOverScreen(state);
                    var key = Console.ReadKey(true).Key;

                    while(true){
                        if(key == ConsoleKey.Q || key == ConsoleKey.Enter)
                            break;
                        else 
                            key = Console.ReadKey(true).Key;
                    }
                    if(key== ConsoleKey.Q)
                        break;
                    else if(key == ConsoleKey.Enter){
                        state.EscapedInvaderCount = 0;
                        state.GameScore = 0;
                        state.Hero = new Hero(38,30);
                        state.Invaders = new List<Invader>();
                        state.Bullets = new List<Bullet>();
                    }
                }
                Render(state);
                gameState = state;
                FrameCount++;
                Thread.Sleep(30);
            }
        }

        static void Render(GameState state)
        {
            var board = new GameBoard();

            board.SetBoardSize(80, 35);
            //board.ClearScreen();
            board.RenderHero(state.Hero);
            board.RenderInvader(state.Invaders);
            board.RenderBullets(state.Bullets);
            board.DisplayGameScore(state.GameScore);
            board.DisplayEscapedInvadersCount(state.EscapedInvaderCount);
            board.HideCursor();
        }
        static GameState HandleFrame(GameState state){
            state.GetKeyPress();
            state.UpdateBulletLocation();

            if (FrameCount % 10 == 0)
                state.UpdateInvaderLocation();
            if (FrameCount % 60 == 0)
                state.GenerateInvader();
            return state;
        }
    
        static void RenderGameOverScreen(GameState state)
        {
            Console.Clear();
            Console.SetCursorPosition(30, 14);
            Console.Write("Game Over");
            Console.SetCursorPosition(28, 20);
            Console.Write(String.Format("Your Score: {0}", state.GameScore));
            Thread.Sleep(1000);
            Console.SetCursorPosition(15, 32);
            Console.Write("Press Enter key to play again. Press Q to quit the game.");
        }


        static void RenderWelcomeScreen()
        {
            var welcomeScreen = new WelcomeScreen();
            welcomeScreen.RenderWelcomeScreen();
        }

    }
}
