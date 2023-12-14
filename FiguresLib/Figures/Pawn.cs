using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using FiguresLib;
using ChessProject;

namespace ProjectLibrary.Figures
{
    public class Pawn : IFigure
    {
        public Coords Coords { get; set; }
        public bool isBlack { get; set; }
        public string theType { get { return "Pawn"; } }

        public bool ToUp;
        public int blackSide = 8;

        public Pawn(Coords cords, bool IsBlack, int blackside)
        {
            this.isBlack = IsBlack;
            Coords = cords;
            if(isBlack && blackside > cords.x)
            {
                ToUp = true;
            }
            else if(isBlack && blackside < cords.x)
            {
                ToUp = false;
            }
            else if(!isBlack && blackside < cords.x)
            {
                ToUp = true;
            }
            else if(!isBlack && blackside > cords.x)
            {
                ToUp = false;
            }
        }

        public List<Coords> coords = new List<Coords>();

 
        public List<Coords> LegalMoves()
        {
            coords.Clear();

            bool BonusStep = false;
            if (ToUp && Coords.x == 7)
            {
                BonusStep = true;
            }
            else if(!ToUp && Coords.x == 2)
            {
                BonusStep = true;
            }

            bool isFree = false;
            bool isFree2 = false;
            Coords waiter = new Coords();
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (ToUp)
                    {
                        if ((i == Coords.x - 1 && j == Coords.y - 1) || (i == Coords.x - 1 && j == Coords.y + 1))
                        {
                            if (AllPositions.BoardBehind[i, j] == "B")
                            {
                                coords.Add(new Coords(i, j));
                            }
                        }
                        if ((i == Coords.x - 1 && j == Coords.y) && AllPositions.BoardBehind[i, j] == null)
                        {
                            coords.Add(new Coords(i, j));
                            isFree = true;

                        }
                        if ((i == Coords.x - 2 && j == Coords.y) && AllPositions.BoardBehind[i, j] == null && BonusStep)
                        {
                            waiter = new Coords(i, j);
                            isFree2 = true;
                        }
                        if (isFree && isFree2)
                        {
                            coords.Add(waiter);
                        }

                    }
                    else
                    {
                        if ((i == Coords.x + 1 && j == Coords.y - 1) || (i == Coords.x + 1 && j == Coords.y + 1))
                        {
                            if (AllPositions.BoardBehind[i, j] == "W")
                            {
                                coords.Add(new Coords(i, j));
                            }
                        }
                        if ((i == Coords.x + 1 && j == Coords.y) && AllPositions.BoardBehind[i, j] == null)
                        {
                            coords.Add(new Coords(i, j));
                            isFree = true;

                        }
                        if ((i == Coords.x + 2 && j == Coords.y) && AllPositions.BoardBehind[i, j] == null && BonusStep)
                        {
                            waiter = new Coords(i, j);
                            isFree2 = true;
                        }
                        if (isFree && isFree2)
                        {
                            coords.Add(waiter);
                        }
                    }
                }
            }
            return coords;
        }


        public bool MoveFigure(Coords coords)
        {
            if(LegalMoves().Contains(coords))
            {
                IFigure figure = null;
                foreach(IFigure fig in AllPositions.FigsOnBoard)
                {
                    if(fig.Coords.x == coords.x && fig.Coords.y == coords.y)
                    {
                        figure = fig;
                    }
                }
                if(figure != null)
                {
                AllPositions.FigsOnBoard.Remove(figure);
                figure = null;
                AllPositions.UpdateBehindBoard();
                    AllPositions.UpdateDetailedBoard();
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
