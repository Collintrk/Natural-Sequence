using System;
namespace BoardModel
{
    public class Space
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Occupied { get; set; }
        public bool NextLegalMove { get; set; }
        public bool IsPassage { get; set; }

        public Space(int x, int y)
        {
            Row = x;
            Column = y;
            Occupied = false;

        }
    }
}
