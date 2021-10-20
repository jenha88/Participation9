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
        private List<Games> updategames;
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("all_games.csv").Skip(1);
            foreach (var item in lines)
            {
                G.Add(new Games(item));
            }


            PopulateCB(G);
            PopulateLB(G);
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
        private void PopulateLB(List<Games> gm)
        {
            lstbox.Items.Clear();
            foreach (var g in gm)
            {
                lstbox.Items.Add(g);
            }
        }
      
            private void btb_Click(object sender, RoutedEventArgs e)
            {

            string jj = JsonConvert.SerializeObject(G);
            File.WriteAllText("games.json", jj);

        }

      
        private void lstbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Games selection = (Games)lstbox.SelectedItem;
            window w = new window();
            w.SetupWindow(selection);
            w.ShowDialog();

        }

        private void cbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updategames = FillGames(G);
            PopulateLB(updategames);

        }
  
        private List<Games> FillGames(List<Games> GMS)
        {
            string ggg = cbBox.SelectedValue.ToString();
            List<Games> updategames = new List<Games>();
            foreach (var item in GMS)
            {
                if (ggg.ToLower()=="all")
                {
                    updategames.Add(item);
                }
                else if (item.platform.Contains(ggg))
                {
                    updategames.Add(item);
                }
            }
            return updategames;
        }
    }
    }

