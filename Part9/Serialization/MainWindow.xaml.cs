using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Games> G = new List<Games>();
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("all_games.csv").Skip(1);
            foreach (var item in lines)
            {
                G.Add(new Games(item));
            }

            foreach (var g in G)
            {
                lstbox.Items.Add(g);
            }

            PopulateCB(G);
        }
        private void PopulateCB(List<Games> gg)
        {
            cbBox.Items.Clear();
            string[] value = Item.platform.Split(',');
            foreach (var item in gg)
            {
                cbBox.Items.Add(item);
            }

        }
            private void btb_Click(object sender, RoutedEventArgs e)
            {

                window w = new window();


            }

            private void cbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Games selecteditem = (Games)cbBox.SelectedItem;
            }
        }
    }

