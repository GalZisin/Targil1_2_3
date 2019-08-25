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

namespace _210819_slider_Textbox
{
    /// <summary>
    /// Interaction logic for Targil2_Etgar.xaml
    /// </summary>
    public partial class Targil2_Etgar : Window
    {
        ViewModelTargil2 vm2;
        public Targil2_Etgar()
        {
        
            InitializeComponent();
            vm2 = new ViewModelTargil2();
            DataContext = vm2;
        }
    }
}
