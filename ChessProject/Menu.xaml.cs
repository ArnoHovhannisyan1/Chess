using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ChessProject
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public string name { get; set; }
        public Menu(string name)
        {
            InitializeComponent();
            this.name = name;
            NameField.Text = name;
        }
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            ChessBoard board = new ChessBoard();
            board.Show();
            this.Close();
        }
    }
}
