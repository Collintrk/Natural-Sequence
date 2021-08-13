using System;
namespace BoardModel
{
    //if a space is occupied, it has a piece
    public class Space
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Occupied { get; set; }
        public bool NextLegalMove { get; set; }
        public bool IsPassage { get; set; }
        public String Color { get; set; }
        public Piece Piece { get; set; }

        public Space(int x, int y)
        {
            Row = x;
            Column = y;
            Occupied = false;

        }
    }
}
