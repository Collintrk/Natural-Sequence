using System;
namespace BoardModel
{
    public class Piece
    {
        //name is the how the piece is displayed on the board
        public string name { get; set; }
        //type is the actual piece classification, ie Dragon, Rabbit, etc.
        public string type { get; set; }
        public string color { get; set; }
        public bool inPlay { get; set; }

        public Piece(string type, string name, string color, bool inPlay)
        {
            this.type = type;
            this.name = name;
            this.color = color;
            this.inPlay = inPlay;

        }
    }
}
