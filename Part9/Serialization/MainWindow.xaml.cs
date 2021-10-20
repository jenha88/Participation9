using Newtonsoft.Json;
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
           
            cbBox.Items.Add("all");
            cbBox.SelectedIndex=0;
            foreach (var item in gg)
            {
             
                if (!cbBox.Items.Contains(item.platform))
                {
                    cbBox.Items.Add(item.platform);
                }
            }

        }
            private void btb_Click(object sender, RoutedEventArgs e)
            {

            string jj = JsonConvert.SerializeObject(G);
            File.WriteAllText("games.json", jj);

        }

      
       

        private void lstbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Games selection = (Games)lstbox.SelectedItems;
            window w = new window();
            w.SetupWindow(selection);
            w.ShowDialog();

        }
    }
    }

