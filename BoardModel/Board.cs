using System;
namespace BoardModel
{
    public class Board
    {
        public Board(int s)
        {
            Size = s;

            // create 2D array for the board
            Grid = new Space[Size, Size];

            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Space(i,j);
                }
            }
        }
        public int Size { get; set; }
        public Space[,] Grid {get; set;}

        public void ClearBoard()
        {
            //step 1 - clear board
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j].Occupied = false;
                    Grid[i, j].NextLegalMove = false;
                }
            }
        }

        public void MarkLegalMoves(Space currentSpace, string piece)
        {

            //Step 2 - find all legal moves for the given piece
            switch (piece)
            {
                case "Rabbit":
                    for (int i = 1; i <= 5; i++)
                    {
                        if (currentSpace.Row + i <= 17 && currentSpace.Row + i >= 1)
                        {
                            Grid[currentSpace.Row + i, currentSpace.Column].NextLegalMove = true;
                        }

                        if(currentSpace.Column + i <= 17 && currentSpace.Column +i >= 1)
                        {
                            Grid[currentSpace.Row, currentSpace.Column + i].NextLegalMove = true;
                        }

                        if (currentSpace.Row - i <= 17 && currentSpace.Row - i >= 1)
                        {
                            Grid[currentSpace.Row - i, currentSpace.Column].NextLegalMove = true;
                        }

                        if (currentSpace.Column - i <= 17 && currentSpace.Column - i >= 1)
                        {
                            Grid[currentSpace.Row, currentSpace.Column - i].NextLegalMove = true;
                        }
                    }
                    break;

                case "Hedgehog":
                    for(int i = 1; i <= 5; i++)
                    {
                        if (currentSpace.Row + i <= 17 && currentSpace.Row + i >= 1)
                        {
                            Grid[currentSpace.Row + i, currentSpace.Column].NextLegalMove = true;
                        }

                        if (currentSpace.Column + i <= 17 && currentSpace.Column + i >= 1)
                        {
                            Grid[currentSpace.Row, currentSpace.Column + i].NextLegalMove = true;
                        }

                        if (currentSpace.Row - i <= 17 && currentSpace.Row - i >= 1)
                        {
                            Grid[currentSpace.Row - i, currentSpace.Column].NextLegalMove = true;
                        }

                        if (currentSpace.Column - i <= 17 && currentSpace.Column - i >= 1)
                        {
                            Grid[currentSpace.Row, currentSpace.Column - i].NextLegalMove = true;
                        }
                    }
                    break;

                case "Owl":
                    for (int i = 2; i >= -2; i--)
                    {
                        for (int j = -2; j <= 2; j++)
                        {
                            if (currentSpace.Row + i >= 1 && currentSpace.Row + i <= 17 && currentSpace.Column + j >= 1 && currentSpace.Column + j <= 17)
                            {
                                if (j == 0 && i == 0) Grid[currentSpace.Row, currentSpace.Column].NextLegalMove = false;
                                else Grid[currentSpace.Row + i, currentSpace.Column + j].NextLegalMove = true;
                            }
                        }
                    }
                    break;

                case "Rooster":
                    for (int i = 2; i >= -2; i--)
                    {
                        for (int j = -2; j <= 2; j++)
                        {
                            if (currentSpace.Row + i >= 1 && currentSpace.Row + i <= 17 && currentSpace.Column + j >= 1 && currentSpace.Column + j <= 17)
                            {
                                if (j == 0 && i == 0) Grid[currentSpace.Row, currentSpace.Column].NextLegalMove = false;
                                else Grid[currentSpace.Row + i, currentSpace.Column + j].NextLegalMove = true;
                            }
                        }
                    }
                    break;

                case "Wolf":
                    for (int i = 1; i <= 3; i++)
                    {
                        if (currentSpace.Row + i <= 17 && currentSpace.Row + i >= 1)
                        {
                            Grid[currentSpace.Row + i, currentSpace.Column].NextLegalMove = true;
                        }

                        if (currentSpace.Column + i <= 17 && currentSpace.Column + i >= 1)
                        {
                            Grid[currentSpace.Row, currentSpace.Column + i].NextLegalMove = true;
                        }

                        if (currentSpace.Row - i <= 17 && currentSpace.Row - i >= 1)
                        {
                            Grid[currentSpace.Row - i, currentSpace.Column].NextLegalMove = true;
                        }

                        if (currentSpace.Column - i <= 17 && currentSpace.Column - i >= 1)
                        {
                            Grid[currentSpace.Row, currentSpace.Column - i].NextLegalMove = true;
                        }
                    }
                    break;

                case "Lion":
                    for (int i = 1; i <= 3; i++)
                    {
                        if (currentSpace.Row + i <= 17 && currentSpace.Row + i >= 1)
                        {
                            Grid[currentSpace.Row + i, currentSpace.Column].NextLegalMove = true;
                        }

                        if (currentSpace.Column + i <= 17 && currentSpace.Column + i >= 1)
                        {
                            Grid[currentSpace.Row, currentSpace.Column + i].NextLegalMove = true;
                        }

                        if (currentSpace.Row - i <= 17 && currentSpace.Row - i >= 1)
                        {
                            Grid[currentSpace.Row - i, currentSpace.Column].NextLegalMove = true;
                        }

                        if (currentSpace.Column - i <= 17 && currentSpace.Column - i >= 1)
                        {
                            Grid[currentSpace.Row, currentSpace.Column - i].NextLegalMove = true;
                        }
                    }
                    break;

                case "Dragon":
                    for (int i = 5; i >= -5; i--)
                    {
                        for (int j = -5; j <= 5; j++)
                        {
                            if (currentSpace.Row + i >= 1 && currentSpace.Row + i <= 17 && currentSpace.Column + j >= 1 && currentSpace.Column + j <= 17)
                            {
                                if (j == 0 && i == 0) Grid[currentSpace.Row, currentSpace.Column].NextLegalMove = false;
                                else Grid[currentSpace.Row + i, currentSpace.Column + j].NextLegalMove = Math.Abs(i) + Math.Abs(j) <= 5;
                            }
                        }
                    }
                    break;

                case "Unicorn":
                    for (int i = 2; i >= -2; i--)
                    {
                        for (int j = -2; j <= 2; j++)
                        {
                            if (currentSpace.Row + i >= 1 && currentSpace.Row + i <= 17 && currentSpace.Column + j >= 1 && currentSpace.Column + j <= 17)
                            {
                                if (j == 0 && i == 0) Grid[currentSpace.Row, currentSpace.Column].NextLegalMove = false;
                                else Grid[currentSpace.Row + i, currentSpace.Column + j].NextLegalMove = Math.Abs(i) + Math.Abs(j) <= 2;
                            }
                        }
                    }
                    break;

                case "Umbrella":
                    for (int i = 2; i >= -2; i--)
                    {
                        for (int j = -2; j <= 2; j++)
                        {
                            if (currentSpace.Row + i >= 1 && currentSpace.Row + i <= 17 && currentSpace.Column + j >= 1 && currentSpace.Column + j <= 17)
                            {
                                if (j == 0 && i == 0) Grid[currentSpace.Row, currentSpace.Column].NextLegalMove = false;
                                else Grid[currentSpace.Row + i, currentSpace.Column + j].NextLegalMove = Math.Abs(i) + Math.Abs(j) <= 2;
                            }
                        }
                    }
                    break;

                default:

                    break;
            }
            //Grid[currentSpace.Row, currentSpace.Column].Occupied = true;
        }

        public void MarkOccupied(int row, int col)
        {
            Grid[row, col].Occupied = true;
        }
    }
}
