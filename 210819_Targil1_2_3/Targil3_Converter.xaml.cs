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
    /// Interaction logic for Targil3_Converter.xaml
    /// </summary>
    public partial class Targil3_Converter : Window
    {
        public Person obj { get; set; }

        public Targil3_Converter()
        {
            InitializeComponent();
            obj = new Person() { Name = "hi im person" };
            this.DataContext = this;
        }

        public class Person
        {
            public string Name { get; set; }

            public override string ToString()
            {
                return $"Person name {Name}";
            }
        }
    }
}
