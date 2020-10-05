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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Examen1AP.UI.Registros;
using Examen1AP.UI.Consultas;

namespace Examen1AP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rCuidadMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCiudades rCiudades = new rCiudades();
            rCiudades.Show();
        }

        private void cCuidadMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cCiudades cCiudades = new cCiudades();
            cCiudades.Show();
        }
    }
}
