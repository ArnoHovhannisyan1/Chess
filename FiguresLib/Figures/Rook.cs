using ChessProject;
using FiguresLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Figures
{
    public class Rook : IFigure
    {
        public bool ToUp { get; set; }
        public bool isBlack { get; set; }
        public Coords Coords { get; set; }

        public string theType => "Rook";

        public Rook(Coords cords, bool isBlack)
        {
            this.isBlack = isBlack;
            Coords = cords;
        }


        public List<Coords> LegalMoves()
        {
            List<Coords> coords = new List<Coords>();
            Coords tempCords = new Coords(Coords.x, Coords.y);
            if (tempCords.x < 8)
            {
                while ( tempCords.x < 8 && AllPositions.BoardBehind[tempCords.x + 1, tempCords.y] == null)
                {
                    tempCords.x++;
                    coords.Add(tempCords);
                }
                if (tempCords.x < 8 && AllPositions.BoardBehind[tempCords.x + 1, tempCords.y] != null)
                {
                    foreach (var item in AllPositions.FigsOnBoard)
                    {
                        if (item.Coords.x == tempCords.x + 1 && item.Coords.y == tempCords.y)
                        {
                            if ((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                            {
                                coords.Add(item.Coords); break;
                            }
                        }
                    }
                }
            }

            tempCords = new Coords(Coords.x, Coords.y);
            if (tempCords.x > 1)
            {
                while (tempCords.x > 1 && AllPositions.BoardBehind[tempCords.x - 1, tempCords.y] == null)
                {
                    tempCords.x--;
                    coords.Add(tempCords);
                }
                if (tempCords.x > 1 && AllPositions.BoardBehind[tempCords.x - 1, tempCords.y] != null)
                {
                    foreach (var item in AllPositions.FigsOnBoard)
                    {
                        if (item.Coords.x == tempCords.x - 1 && item.Coords.y == tempCords.y)
                        {
                            if ((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                            {
                                coords.Add(item.Coords); break;
                            }
                        }
                    }
                }
            }

            tempCords = new Coords(Coords.x, Coords.y);
            if (tempCords.y > 1)
            {
                while (tempCords.y > 1 && AllPositions.BoardBehind[tempCords.x, tempCords.y - 1] == null)
                {
                    tempCords.y--;
                    coords.Add(tempCords);
                }
                if (tempCords.y > 1 && AllPositions.BoardBehind[tempCords.x, tempCords.y - 1] != null)
                {
                    foreach (var item in AllPositions.FigsOnBoard)
                    {
                        if (item.Coords.x == tempCords.x && item.Coords.y == tempCords.y - 1)
                        {
                            if ((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                            {
                                coords.Add(item.Coords); break;
                            }
                        }
                    }
                }
            }

            tempCords = new Coords(Coords.x, Coords.y);
            if (tempCords.y < 8)
            {
                while ( tempCords.y < 8 && AllPositions.BoardBehind[tempCords.x, tempCords.y + 1] == null)
                {
                    tempCords.y++;
                    coords.Add(tempCords);
                }
                if (tempCords.y < 8 && AllPositions.BoardBehind[tempCords.x, tempCords.y + 1] != null)
                {
                    foreach (var item in AllPositions.FigsOnBoard)
                    {
                        if (item.Coords.x == tempCords.x && item.Coords.y == tempCords.y + 1)
                        {
                            if ((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                            {
                                coords.Add(item.Coords); break;
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
                    figure = null;
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
