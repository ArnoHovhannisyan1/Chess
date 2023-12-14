using ChessProject;
using FiguresLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Figures
{
    public class King : IFigure
    {

        
        public bool isBlack { get; set; }
        public Coords Coords { get; set; }
        public string theType { get { return "King"; } }

        public King (Coords coords, bool isBlack)
        {
            this.isBlack = isBlack;
            Coords = coords;
            //if (isBlack && blackside > cords.x)
            //{
            //    ToUp = true;
            //}
            //else if (isBlack && blackside < cords.x)
            //{
            //    ToUp = false;
            //}
            //else if (!isBlack && blackside < cords.x)
            //{
            //    ToUp = true;
            //}
            //else if (!isBlack && blackside > cords.x)
            //{
            //    ToUp = false;
            //}
        }
            
        public List<Coords> LegalMoves()
        {
            List<Coords> coords = new List<Coords>();
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (i == Coords.x - 1 && j == Coords.y - 1 || i == Coords.x + 1 && j == Coords.y + 1)
                    {
                        if (AllPositions.BoardBehind[i, j] == null)
                        {
                            coords.Add(new Coords(i, j));
                        }
                        else
                        {
                            if (isBlack)
                            {
                                if (AllPositions.BoardBehind[i, j] == "W")
                                {
                                    coords.Add(new Coords(i, j));
                                }
                            }
                            else
                            {
                                if (AllPositions.BoardBehind[i, j] == "B")
                                {
                                    coords.Add(new Coords(i, j));
                                }
                            }
                        }
                    }
                    if (i == Coords.x - 1 && j == Coords.y + 1 || i == Coords.x + 1 && j == Coords.y - 1)
                    {
                        if (AllPositions.BoardBehind[i, j] == null)
                        {
                            coords.Add(new Coords(i, j));
                        }
                        else
                        {
                            if (isBlack)
                            {
                                if (AllPositions.BoardBehind[i, j] == "W")
                                {
                                    coords.Add(new Coords(i, j));
                                }
                            }
                            else
                            {
                                if (AllPositions.BoardBehind[i, j] == "B")
                                {
                                    coords.Add(new Coords(i, j));
                                }
                            }
                        }
                    }
                    if (i == Coords.x - 1 && j == Coords.y || i == Coords.x + 1 && j == Coords.y)
                    {
                        if (AllPositions.BoardBehind[i, j] == null)
                        {
                            coords.Add(new Coords(i, j));
                        }
                        else
                        {
                            if (isBlack)
                            {
                                if (AllPositions.BoardBehind[i, j] == "W")
                                {
                                    coords.Add(new Coords(i, j));
                                }
                            }
                            else
                            {
                                if (AllPositions.BoardBehind[i, j] == "B")
                                {
                                    coords.Add(new Coords(i, j));
                                }
                            }
                        }
                    }
                    if (i == Coords.x && j == Coords.y - 1 || i == Coords.x && j == Coords.y + 1)
                    {
                        if (AllPositions.BoardBehind[i, j] == null)
                        {
                            coords.Add(new Coords(i, j));
                        }
                        else
                        {
                            if (isBlack)
                            {
                                if (AllPositions.BoardBehind[i, j] == "W")
                                {
                                    coords.Add(new Coords(i, j));
                                }
                            }
                            else
                            {
                                if (AllPositions.BoardBehind[i, j] == "B")
                                {
                                    coords.Add(new Coords(i, j));
                                }
                            }
                        }
                    }
                }
            }
            return coords;
        }

        public bool MoveFigure(Coords coords)
        {
            if (LegalMoves().Contains(coords))
            {
                IFigure figure = null;
                foreach (IFigure fig in AllPositions.FigsOnBoard)
                {
                    if (fig.Coords.x == coords.x && fig.Coords.y == coords.y)
                    {
                        figure = fig;
                    }
                }
                if (figure != null)
                {
                    AllPositions.FigsOnBoard.Remove(figure);
                    AllPositions.UpdateBehindBoard();
                }
                Coords = coords;
                AllPositions.UpdateBehindBoard();
                if(isBlack)
                {
                    AllPositions.BlackKingCoordinates = Coords;
                }
                else
                {
                    AllPositions.WhiteKingCoordinates = Coords;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
