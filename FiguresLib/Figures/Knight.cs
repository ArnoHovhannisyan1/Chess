using ChessProject;
using FiguresLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Figures
{
    public class Knight : IFigure
    {
        public bool isBlack { get; set; }
        public Coords Coords { get; set; }
        public bool ToUp { get; set; }
        public string theType { get { return "Knight"; } }

        public List<Coords> listOfLegalMoves = new List<Coords>();

        public Knight(Coords coords, bool isBlack) 
        {
            this.isBlack = isBlack;
            Coords = coords;
        }

        public List<Coords> LegalMoves()
        {
            listOfLegalMoves.Clear(); 

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (i == Coords.x - 2 && j == Coords.y - 1 || i == Coords.x - 2 && j == Coords.y + 1
                       || i == Coords.x - 1 && j == Coords.y - 2 || i == Coords.x + 1 && j == Coords.y - 2
                       || i == Coords.x + 2 && j == Coords.y - 1 || i == Coords.x + 2 && j == Coords.y + 1
                       || i == Coords.x - 1 && j == Coords.y + 2 || i == Coords.x + 1 && j == Coords.y + 2)
                    {
                        if (AllPositions.BoardBehind[i,j] == null)
                        {
                           listOfLegalMoves.Add(new Coords(i,j));
                        }
                        else
                        {
                            foreach(var item in AllPositions.FigsOnBoard)
                            {
                                if(item.Coords.x == i && item.Coords.y == j)
                                {
                                    if ((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                                    {
                                        listOfLegalMoves.Add(item.Coords); break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return listOfLegalMoves;
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
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
