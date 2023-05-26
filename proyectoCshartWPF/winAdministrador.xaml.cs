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

namespace proyectoCshartWPF
{
    /// <summary>
    /// Lógica de interacción para winAdministrador.xaml
    /// </summary>
    public partial class winAdministrador : Window
    {
        public winAdministrador()
        {
            InitializeComponent();
        }

        private void btnCambiarContra_Click(object sender, RoutedEventArgs e)
        {
            Window1 ventana=new Window1();
            ventana.Show();
        }
    }
}
