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

namespace Serialization
{
    /// <summary>
    /// Interaction logic for window.xaml
    /// </summary>
    public partial class window : Window
    {
        public window()
        {
            InitializeComponent();
        }
        public void SetupWindow(Games GG)
        {
            txtdes.Text = GG.summary;
            txtdate.Text = GG.release_date;
            txtscore.Text = GG.meta_source;
            txtuser.Text = GG.user_review;
        }
    }
}
