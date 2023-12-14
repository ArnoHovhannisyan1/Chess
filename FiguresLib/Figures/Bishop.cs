using ChessProject;
using FiguresLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Figures
{
    public class Bishop : IFigure
    {
        public Bishop(Coords cords, bool isBlack)
        {
            this.isBlack = isBlack;
            Coords = cords;
        }
        public bool ToUp { get; set; }
        public bool isBlack { get; set; }
        public Coords Coords { get; set; }
        public string theType { get { return "Bishop"; } }

        public int sum;
        public int dif;

        public List<Coords> LegalMoves()
        {

            sum = Coords.x + Coords.y;
            dif = Coords.x - Coords.y;
            List<Coords> list = new List<Coords>();

            List<Coords> forPP = new List<Coords>();
            Coords first = new Coords(Coords.x, Coords.y);
            if(first.x != 8 && first.y != 8)
            {
                while ( first.x <= 7 && first.y <= 7 && AllPositions.BoardBehind[first.x+1, first.y+1] == null)
                {
                    first = new Coords(first.x + 1, first.y + 1);
                    list.Add(first);
                }
                if((first.x < 8 && first.y < 8) &&  AllPositions.BoardBehind[first.x + 1, first.y + 1] != null )
                {
                    foreach(var item in AllPositions.FigsOnBoard)
                    {
                        if(item.Coords.x == first.x + 1 && item.Coords.y == first.y + 1)
                        {
                            if((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                            {
                                list.Add(item.Coords); break;
                            }
                        }
                    }
                }
            }


            first = new Coords(Coords.x, Coords.y);
            if (first.x != 8 && first.y != 1)
            {
                while (first.x <= 7 && first.y >= 2 && AllPositions.BoardBehind[first.x + 1, first.y - 1] == null)
                {
                    first = new Coords(first.x + 1, first.y - 1);
                    list.Add(first);
                }
                if ((first.x < 8 && first.y > 1) && AllPositions.BoardBehind[first.x + 1, first.y - 1] != null)
                {
                    foreach (var item in AllPositions.FigsOnBoard)
                    {
                        if (item.Coords.x == first.x + 1 && item.Coords.y == first.y - 1)
                        {
                            if ((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                            {
                                list.Add(item.Coords); break;
                            }
                        }
                    }
                }
            }



            first = new Coords(Coords.x, Coords.y);
            if (first.x != 1 && first.y != 1)
            {
                while (first.x >= 2 && first.y >= 2 && AllPositions.BoardBehind[first.x - 1, first.y - 1] == null)
                {
                    first = new Coords(first.x - 1, first.y - 1);
                    list.Add(first);
                }
                if ((first.x > 1 && first.y > 1) && AllPositions.BoardBehind[first.x - 1, first.y - 1] != null)
                {
                    foreach (var item in AllPositions.FigsOnBoard)
                    {
                        if (item.Coords.x == first.x - 1 && item.Coords.y == first.y - 1)
                        {
                            if ((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                            {
                                list.Add(item.Coords); break;
                            }
                        }
                    }
                }
            }

            first = new Coords(Coords.x, Coords.y);
            if (first.x != 1 && first.y != 8)
            {
                while (first.x >= 2 && first.y <= 7 && AllPositions.BoardBehind[first.x - 1, first.y + 1] == null)
                {
                    first = new Coords(first.x - 1, first.y + 1);
                    list.Add(first);
                }
                if ((first.x > 1 && first.y < 8) && AllPositions.BoardBehind[first.x - 1, first.y + 1] != null)
                {
                    foreach (var item in AllPositions.FigsOnBoard)
                    {
                        if (item.Coords.x == first.x - 1 && item.Coords.y == first.y + 1)
                        {
                            if ((item.isBlack && !isBlack) || (!item.isBlack && isBlack))
                            {
                                list.Add(item.Coords); break;
                            }
                        }
                    }
                }
            }
            return list;

            //List<Coords> coords = new List<Coords>();

            ////this.sum = Coords.x + Coords.y;
            ////this.dif = Coords.x - Coords.y; ;
            ////for (int i = 1; i <= 8; i++)
            ////{
            ////    for (int j = 1; j <= 8; j++)
            ////    {
            ////        if (i + j == sum)
            ////        {
            ////            if(i != Coords.x && j != Coords.y)
            ////            {
            ////            coords.Add(new Coords(i, j));
            ////            }
            ////        }
            ////        if (i - j == dif)
            ////        {
            ////            if (i != Coords.x && j != Coords.y)
            ////            {
            ////                coords.Add(new Coords(i, j));
            ////            }
            ////        }
            ////    }
            ////}



            //Coords tempCoords = new Coords(Coords.x, Coords.y);

            ////if (tempCoords.x != 8 && tempCoords.y != 8)
            ////{
            ////    while (AllPositions.BoardBehind[tempCoords.x + 1, tempCoords.y + 1] == null
            ////        && (tempCoords.x != 8 || tempCoords.y != 8))
            ////    {
            ////        tempCoords.x += 1;
            ////        tempCoords.y += 1;
            ////        coords.Add(tempCoords);
            ////    }
            ////}

            //this.sum = Coords.x + Coords.y;
            //this.dif = Coords.x - Coords.y;
            //if (tempCoords.x != 8 && tempCoords.y != 8)
            //{
            //    if(tempCoords.x < tempCoords.y)
            //    {
            //        for(int i = 1;  i <= 8-tempCoords.y; i++)
            //        {
            //            if (this.sum == tempCoords.x + tempCoords.y + i + i 
            //                && this.dif == tempCoords.x - tempCoords.y - i + i)
            //            {
            //                if (AllPositions.BoardBehind[tempCoords.x + i, tempCoords.y + i] == null)
            //                {
            //                    coords.Add(new Coords(tempCoords.x + i, tempCoords.y + i));
            //                }
            //            }
            //        }
            //    }





            //    bool toStop = false;
            //    for (int i = tempCoords.x + 1; i <= 8; i++)
            //    {
            //        if (!toStop)
            //        {
            //            for (int j = tempCoords.y + 1; j <= 8; j++)
            //            {
            //                if (this.sum == i + j && this.dif == i - j)
            //                {
            //                    if (AllPositions.BoardBehind[i, j] == null)
            //                    {
            //                        coords.Add(new Coords(i, j));
            //                    }
            //                    else
            //                    {
            //                        break;
            //                        toStop = true;
            //                    }
            //                }
            //            }
            //        }
            //    }
        }





            //    tempCoords = new Coords(Coords.x, Coords.y);

            //    if (tempCoords.x != 1 && tempCoords.y != 1)
            //    {
            //        while (AllPositions.BoardBehind[tempCoords.x - 1, tempCoords.y - 1] == null
            //                                && tempCoords.x != 1
            //                                && tempCoords.y != 1)
            //        {
            //            tempCoords.x -= 1;
            //            tempCoords.y -= 1;
            //            coords.Add(tempCoords);
            //        }

            //    }               

            //    tempCoords = new Coords(Coords.x, Coords.y);
            //    if (tempCoords.x != 8 && tempCoords.y != 1)
            //    {
            //        while (AllPositions.BoardBehind[tempCoords.x + 1, tempCoords.y - 1] == null
            //                            && tempCoords.x != 8
            //                            && tempCoords.y != 1)
            //        {
            //            tempCoords.x += 1;
            //            tempCoords.y -= 1;
            //            coords.Add(tempCoords);
            //        }
            //    }


            //    tempCoords = new Coords(Coords.x, Coords.y);
            //    if (tempCoords.x > 1 && tempCoords.y < 8)
            //    {
            //        while (AllPositions.BoardBehind[tempCoords.x - 1, tempCoords.y + 1] == null
            //                       && tempCoords.x > 1
            //                       && tempCoords.y < 8)
            //        {
            //            tempCoords.x -= 1;
            //            tempCoords.y += 1;
            //            coords.Add(tempCoords);
            //        }
            //    }



        //    return coords;
        //}

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


