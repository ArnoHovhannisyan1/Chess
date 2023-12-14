using FiguresLib;
using ProjectLibrary;
using ProjectLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChessProject
{
    public partial class ChessBoard : Window
    {
       
        private DispatcherTimer WhitesTimer;
        private TimeSpan countdownDuration = TimeSpan.FromMinutes(10);
        private TimeSpan remainingTime;

        private DispatcherTimer BlacksTimer;
        private TimeSpan countdownDuration2 = TimeSpan.FromMinutes(10);
        private TimeSpan remainingTime2;

        List<Rectangle> rects = new List<Rectangle>();
      //  List<Coords> LegalMoves = new List<Coords>();
        System.Windows.UIElement ancord = new System.Windows.UIElement();
        Rectangle destRect = new Rectangle();
        public bool SomeOneIsSelected;
        //IFigure MovingFigure;


        public ChessBoard()
        {
            InitializeComponent();
            InitializeMenuAnimation();
            AddFiguresOnBoard();
            UpdateMyGrid();

            remainingTime = countdownDuration;
            WhitesTimer = new DispatcherTimer();
            WhitesTimer.Interval = TimeSpan.FromSeconds(1); // Set the interval (1 second)
            WhitesTimer.Tick += Timer_Tick;
            WhitesTimer.Start();

            remainingTime2 = countdownDuration2;
            BlacksTimer = new DispatcherTimer();
            BlacksTimer.Interval = TimeSpan.FromSeconds(1);
            BlacksTimer.Tick += Timer_Tick;
            BlacksTimer.Start();

            if(AllPositions.BlacksToMove)
            {
                WhitesTimer.Stop();
            }
            else
            {
                BlacksTimer.Stop();
            }
            //AllPositions.TendToEatResponse();
            //UpdateMyGrid();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (sender == WhitesTimer)
            {
                if (remainingTime.TotalSeconds > 0)
                {
                    remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                    countdownLabel1.Content = remainingTime.ToString(@"mm\:ss");
                }
                else
                {
                    countdownLabel1.Content = "00:00";
                    WhitesTimer.Stop();
                }
            }
            else if(sender == BlacksTimer)
            {
                if (remainingTime2.TotalSeconds > 0)
                {
                    remainingTime2 = remainingTime2.Subtract(TimeSpan.FromSeconds(1));
                    countdownLabel2.Content = remainingTime2.ToString(@"mm\:ss");
                }
                else
                {
                    countdownLabel2.Content = "00:00";
                    BlacksTimer.Stop();
                }
            }
        }

        private void AddFiguresOnBoard()
        {
            Pawn WhitePawn1 = new(new Coords(7, 1), false, 1);
            Pawn WhitePawn2 = new(new Coords(7, 2), false, 1);
            Pawn WhitePawn3 = new(new Coords(7, 3), false, 1);
            Pawn WhitePawn4 = new(new Coords(7, 4), false, 1);
            Pawn WhitePawn5 = new(new Coords(7, 5), false, 1);
            Pawn WhitePawn6 = new(new Coords(7, 6), false, 1);
            Pawn WhitePawn7 = new(new Coords(7, 7), false, 1);
            Pawn WhitePawn8 = new(new Coords(7, 8), false, 1);

            Pawn BlackPawn1 = new(new Coords(2, 1), true, 1);
            Pawn BlackPawn2 = new(new Coords(2, 2), true, 1);
            Pawn BlackPawn3 = new(new Coords(2, 3), true, 1);
            Pawn BlackPawn4 = new(new Coords(2, 4), true, 1);
            Pawn BlackPawn5 = new(new Coords(2, 5), true, 1);
            Pawn BlackPawn6 = new(new Coords(2, 6), true, 1);
            Pawn BlackPawn7 = new(new Coords(2, 7), true, 1);
            Pawn BlackPawn8 = new(new Coords(2, 8), true, 1);

            Bishop BlackBishop1 = new(new Coords(1, 3), true);
            Bishop BlackBishop2 = new(new Coords(1, 6), true);
            Bishop WhiteBishop1 = new(new Coords(8, 3), false);
            Bishop WhiteBishop2 = new(new Coords(8, 6), false);

            Rook BlackRook1 = new(new Coords(1, 1), true);
            Rook BlackRook2 = new(new Coords(1, 8), true);
            Rook WhiteRook1 = new(new Coords(8, 1), false);
            Rook WhiteRook2 = new(new Coords(8, 8), false);




            Knight BlackKnight1 = new(new Coords(1, 2), true);
            Knight BlackKnight2 = new(new Coords(1, 7), true);
            Knight WhiteKnight1 = new(new Coords(8, 2), false);
            Knight WhiteKnight2 = new(new Coords(8, 7), false);

            Queen BlackQueen = new(new Coords(1, 5), true);
            Queen WhiteQueen = new(new Coords(8, 4), false);

            King BlackKing = new(new Coords(1, 4), true);
            King WhiteKing = new(new Coords(8, 5), false);


            AllPositions.FigsOnBoard.Add((IFigure)BlackPawn1);
            AllPositions.FigsOnBoard.Add((IFigure)BlackPawn2);
            AllPositions.FigsOnBoard.Add((IFigure)BlackPawn3);
            AllPositions.FigsOnBoard.Add((IFigure)BlackPawn4);
            AllPositions.FigsOnBoard.Add((IFigure)BlackPawn5);
            AllPositions.FigsOnBoard.Add((IFigure)BlackPawn6);
            AllPositions.FigsOnBoard.Add((IFigure)BlackPawn7);
            AllPositions.FigsOnBoard.Add((IFigure)BlackPawn8);

            AllPositions.FigsOnBoard.Add((IFigure)WhitePawn1);
            AllPositions.FigsOnBoard.Add((IFigure)WhitePawn2);
            AllPositions.FigsOnBoard.Add((IFigure)WhitePawn3);
            AllPositions.FigsOnBoard.Add((IFigure)WhitePawn4);
            AllPositions.FigsOnBoard.Add((IFigure)WhitePawn5);
            AllPositions.FigsOnBoard.Add((IFigure)WhitePawn6);
            AllPositions.FigsOnBoard.Add((IFigure)WhitePawn7);
            AllPositions.FigsOnBoard.Add((IFigure)WhitePawn8);


            AllPositions.FigsOnBoard.Add((IFigure)WhiteBishop1);
            AllPositions.FigsOnBoard.Add((IFigure)WhiteBishop2);
            AllPositions.FigsOnBoard.Add((IFigure)BlackBishop1);
            AllPositions.FigsOnBoard.Add((IFigure)BlackBishop2);

            AllPositions.FigsOnBoard.Add((IFigure)WhiteRook1);
            AllPositions.FigsOnBoard.Add((IFigure)WhiteRook2);
            AllPositions.FigsOnBoard.Add((IFigure)BlackRook1);
            AllPositions.FigsOnBoard.Add((IFigure)BlackRook2);

            AllPositions.FigsOnBoard.Add((IFigure)WhiteKnight1);
            AllPositions.FigsOnBoard.Add((IFigure)WhiteKnight2);
            AllPositions.FigsOnBoard.Add((IFigure)BlackKnight1);
            AllPositions.FigsOnBoard.Add((IFigure)BlackKnight2);

            AllPositions.FigsOnBoard.Add((IFigure)WhiteQueen);
            AllPositions.FigsOnBoard.Add((IFigure)BlackQueen);

            AllPositions.FigsOnBoard.Add((IFigure)WhiteKing);
            AllPositions.FigsOnBoard.Add((IFigure)BlackKing);

            AllPositions.BlackKingCoordinates = BlackKing.Coords;
            AllPositions.WhiteKingCoordinates = WhiteKing.Coords;

            AllPositions.UpdateBehindBoard();
        }
   
        private async void HighlightRectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = e.GetPosition(MyGrid);
            UIElement? figs = MyGrid.InputHitTest(mousePoint) as UIElement;
            Coords destinationCoords = new Coords(Grid.GetRow(figs), Grid.GetColumn(figs));
            if (AllPositions.MovingFigure != null && AllPositions.CurrentLegalMoves.Contains(destinationCoords))
            {
                AllPositions.MovingFigure.MoveFigure(destinationCoords);
                AllPositions.BlacksToMove = !AllPositions.BlacksToMove;
                AllPositions.UpdateBehindBoard();
                UpdateMyGrid();
            }
            AllPositions.CurrentLegalMoves.Clear();
            foreach (var rec in rects)
            {
                MyGrid.Children.Remove(rec);
            }
            rects.Clear();
            SomeOneIsSelected = false;
                            bool temp = AllPositions.BlackKingCanBeProtected();

            if (AllPositions.LetsCheckShax(AllPositions.MovingFigure))
            {
                var highlightRectangle = new Rectangle
                {
                    Fill = Brushes.Red,
                    Opacity = 0.5,
                    Width = 50,
                    Height = 50,
                };
                Panel.SetZIndex(highlightRectangle, 1);
                Coords AttackedKingCoords = new Coords();
                if (AllPositions.MovingFigure.isBlack)
                {
                    AttackedKingCoords = AllPositions.WhiteKingCoordinates;
                }
                else
                {
                    AttackedKingCoords = AllPositions.BlackKingCoordinates;
                }
                Grid.SetColumn(highlightRectangle, AttackedKingCoords.y);
                Grid.SetRow(highlightRectangle, AttackedKingCoords.x);
                rects.Add(highlightRectangle);
                MyGrid.Children.Add(highlightRectangle);
            }
            AllPositions.MovingFigure = null;
            await Task.Delay(3000);
            AllPositions.TendToEatResponse();
            UpdateMyGrid();
            if (AllPositions.BlacksToMove)
            {
                WhitesTimer.Stop();
                BlacksTimer.Start();
            }
            if (!AllPositions.BlacksToMove)
            {
                BlacksTimer.Stop();
                WhitesTimer.Start();
            }
        }

        private void ShowLegalMovesOf(IFigure figure)
        {
            string[,] det = AllPositions.DetailedBoard;
            string[,] beh = AllPositions.BoardBehind;

            SomeOneIsSelected = true;
            AllPositions.MovingFigure = figure;
            AllPositions.CurrentLegalMoves.Clear();
            if (rects.Count != 0)
            {
                foreach (var item in rects)
                {
                    MyGrid.Children.Remove(item);
                }
                rects.Clear();
                SomeOneIsSelected = false;
            }

            if (AllPositions.AnyShax())
            {
                foreach (Coords item in figure.LegalMoves())
                {
                    if (!AllPositions.CheckLocalShax(figure, item))
                    {
                        var highlightRectangle = new Rectangle
                        {
                            Fill = Brushes.Green,
                            Opacity = 0.5,
                            Width = 50,
                            Height = 50,
                        };
                        Panel.SetZIndex(highlightRectangle, 1);
                        AllPositions.CurrentLegalMoves.Add(item);
                        highlightRectangle.MouseDown += HighlightRectangle_MouseDown;
                        Grid.SetColumn(highlightRectangle, item.y);
                        Grid.SetRow(highlightRectangle, item.x);
                        rects.Add(highlightRectangle);
                        MyGrid.Children.Add(highlightRectangle);
                    }
                }
            }
            else
            {
                foreach (var item in figure.LegalMoves())
                {
                    if (!AllPositions.CheckLocalShax(AllPositions.MovingFigure, item))
                    {
                        var highlightRectangle = new Rectangle
                        {
                            Fill = Brushes.Green,
                            Opacity = 0.5,
                            Width = 50,
                            Height = 50,
                        };
                        Panel.SetZIndex(highlightRectangle, 1);
                        AllPositions.CurrentLegalMoves.Add(item);
                        highlightRectangle.MouseDown += HighlightRectangle_MouseDown;
                        Grid.SetColumn(highlightRectangle, item.y);
                        Grid.SetRow(highlightRectangle, item.x);
                        rects.Add(highlightRectangle);
                        MyGrid.Children.Add(highlightRectangle);
                    }
                }
            }
            AllPositions.BlacksToMove = figure.isBlack;
        }

        public async void Figure_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = e.GetPosition(MyGrid);
            UIElement? figs = MyGrid.InputHitTest(mousePoint) as UIElement;
            

            if (SomeOneIsSelected && AllPositions.CurrentLegalMoves.Contains(new Coords(Grid.GetRow(figs), Grid.GetColumn(figs))))
            {
                AllPositions.MovingFigure.MoveFigure(new Coords(Grid.GetRow(figs), Grid.GetColumn(figs)));
                //AllPositions.UpdateDetailedBoard();

                //AllPositions.UpdateBehindBoard();

                MyGrid.Children.Remove(figs); //pti vor aranc srae ashxati

                AllPositions.BlacksToMove = !AllPositions.BlacksToMove;
                //UpdateMyGrid();
               
                foreach (var rec in rects)
                {
                    MyGrid.Children.Remove(rec);
                }
                SomeOneIsSelected = false;
                UpdateMyGrid();
                AllPositions.CurrentLegalMoves.Clear();
                rects.Clear();

                if (AllPositions.LetsCheckShax(AllPositions.MovingFigure))
                {
                    var highlightRectangle = new Rectangle
                    {
                        Fill = Brushes.Red,
                        Opacity = 0.5,
                        Width = 50,
                        Height = 50,
                    };
                    Panel.SetZIndex(highlightRectangle, 1);
                    Coords AttackedKingCoords = new Coords();
                    if(AllPositions.MovingFigure.isBlack)
                    {
                        AttackedKingCoords = AllPositions.WhiteKingCoordinates;
                    }
                    else
                    {
                        AttackedKingCoords = AllPositions.BlackKingCoordinates;
                    }
                    Grid.SetColumn(highlightRectangle, AttackedKingCoords.y);
                    Grid.SetRow(highlightRectangle, AttackedKingCoords.x);
                    rects.Add(highlightRectangle);
                    MyGrid.Children.Add(highlightRectangle);
                }

                AllPositions.MovingFigure = null;
                await Task.Delay(3000);

                AllPositions.TendToEatResponse();
                UpdateMyGrid();

                if (AllPositions.BlacksToMove)
                {
                    WhitesTimer.Stop();
                    BlacksTimer.Start();
                }
                if (!AllPositions.BlacksToMove)
                {
                    BlacksTimer.Stop();
                    WhitesTimer.Start();
                }
            }
            else if(SomeOneIsSelected && !AllPositions.CurrentLegalMoves.Contains(new Coords(Grid.GetRow(figs), Grid.GetColumn(figs))))
            {
                SomeOneIsSelected = false;
                Figure_MouseDown(sender, e);
            }
            else
            {
                foreach (var item in AllPositions.FigsOnBoard)
                {
                    if (item.Coords.x == Grid.GetRow(figs) && item.Coords.y == Grid.GetColumn(figs))
                    {
                        if (AllPositions.BlacksToMove == item.isBlack && item.LegalMoves().Count != 0)
                        {
                            SomeOneIsSelected = true;
                            ShowLegalMovesOf(item);
                            break;
                        }
                    }
                }
            }
        }
       
        private void UpdateMyGrid()
        {
            List<UIElement> ElementsToRemove = new List<UIElement> ();
            foreach(UIElement element in MyGrid.Children)
            {
                if(Grid.GetZIndex(element) == 2)
                {
                    ElementsToRemove.Add(element);
                }
            }
            
            foreach(UIElement element in ElementsToRemove)
            {
                MyGrid.Children.Remove(element);
            }

            foreach (var item in AllPositions.FigsOnBoard)
            {
                Image? image = null;
                switch (item)
                {
                    case Pawn:
                        if (item.isBlack)
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\PawnB.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        else
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\PawnW.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        break;

                    case Bishop:
                        if (item.isBlack)
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\BishopB.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        else
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\BishopW.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        break;

                    case Rook:
                        if (item.isBlack)
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\RookB.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        else
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\RookW.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        break;
                    case Knight:
                        if (item.isBlack)
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\KnightB.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        else
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\KnightW.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        break;
                    case Queen:
                        if (item.isBlack)
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\QueenB.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        else
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\QueenW.png")),
                                Width = 50,
                                Height = 50
                            };
                            //MyGrid.Children.Add(WhiteRookImage);
                            //WhiteRookImage.MouseDown += Figure_MouseDown;
                            //Panel.SetZIndex(WhiteRookImage, 2);
                            //Grid.SetRow(WhiteRookImage, item.Coords.x);
                            //Grid.SetColumn(WhiteRookImage, item.Coords.y);
                        }
                        break;
                    case King:
                        if (item.isBlack)
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\KingB.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        else
                        {
                            image = new Image
                            {
                                Source = new BitmapImage(new Uri("C:\\Users\\arnoh\\OneDrive\\Desktop\\ChessProject\\ChessProject\\Figures\\KingW.png")),
                                Width = 50,
                                Height = 50
                            };
                        }
                        break;
                }
                MyGrid.Children.Add(image);
                image.MouseDown += Figure_MouseDown;
                Panel.SetZIndex(image, 2);
                Grid.SetRow(image, item.Coords.x);
                Grid.SetColumn(image, item.Coords.y);
                


            }
        }

        private bool isMenuExpanded = false;

        private void CollapsibleMenu_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (!isMenuExpanded)
            {
                ExpandMenu();
            }
        }

        private void CollapsibleMenu_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (isMenuExpanded)
            {
                CollapseMenu();
            }
        }

        private void InitializeMenuAnimation()
        {
            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase(),
            };

            ThicknessAnimation marginAnimation = new ThicknessAnimation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase(),
            };

            Storyboard.SetTargetName(widthAnimation, "collapsibleMenu");
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Menu.WidthProperty));

            Storyboard.SetTargetName(marginAnimation, "collapsibleMenu");
            Storyboard.SetTargetProperty(marginAnimation, new PropertyPath(Menu.MarginProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(marginAnimation);

            this.Resources.Add("MenuAnimation", storyboard);

            collapsibleMenu.MouseEnter += CollapsibleMenu_MouseEnter;
            collapsibleMenu.MouseLeave += CollapsibleMenu_MouseLeave;
        }

        private void ExpandMenu()
        {
            var storyboard = (Storyboard)this.Resources["MenuAnimation"];

            var widthAnimation = (DoubleAnimation)storyboard.Children[0];
            widthAnimation.To = 120;

            var marginAnimation = (ThicknessAnimation)storyboard.Children[1];
            marginAnimation.To = new Thickness(0, 0, 0, 0); // No change in margins

            storyboard.Begin(this);

            isMenuExpanded = true;
        }

        private void CollapseMenu()
        {
            var storyboard = (Storyboard)this.Resources["MenuAnimation"];

            var widthAnimation = (DoubleAnimation)storyboard.Children[0];
            widthAnimation.To = 43;

            var marginAnimation = (ThicknessAnimation)storyboard.Children[1];
            marginAnimation.To = new Thickness(0, 0, 0, 0);

            storyboard.Begin(this);

            isMenuExpanded = false;
        }

        private void MenuItem_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
   
