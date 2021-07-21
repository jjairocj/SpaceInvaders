namespace SpaceInvaders
{
    public class GameObjects
    {
        public int PosX {get; set;}
        public int PosY { get; set; }
        
        public int LastPosX {get; set;}
        public int LastPosY { get; set; }
        

        public GameObjects(int x, int y){
            PosX = x;
            PosY = y;
        }
    }
}