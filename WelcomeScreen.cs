using System;
using System.Threading;

namespace SpaceInvaders
{
    public class WelcomeScreen
    {
        public void IntroduceFleet(){
            Console.Clear();
            string year = "YEAR 2596";
            string location ="LOCATION: BOGOTA COL - UNITED ARMORED FORCES";
            string intro1 = "New history part 1";
        

            Console.SetCursorPosition(5, 8);
            for (int i = 0; i < year.Length; i++)
            {
                Console.Write(year[i]);
                Thread.Sleep(60);
            }

            Console.SetCursorPosition(5, 10);
            for (int i = 0; i < location.Length; i++)
            {
                Console.Write(location[i]);
                Thread.Sleep(60);
            }
            
            Console.SetCursorPosition(5, 12);
            for (int i = 0; i < intro1.Length; i++)
            {
                Console.Write(intro1[i]);
                Thread.Sleep(60);
            }

            Thread.Sleep(1000);
            
        }
        public void Instructions()
        {
            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("INSTRUCTIONS");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("CONTROLS:");
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("Move: WASD or arrows");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("Fire: Spacebar");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("The game will be over if 5 Enemies escaped.");
            Console.SetCursorPosition(5, 15);
            Console.WriteLine("Press any key to start game.");
            Console.ReadKey();
        }

        public void RenderWelcomeScreen(){
            IntroduceFleet();
            Instructions();
        }
    }
}