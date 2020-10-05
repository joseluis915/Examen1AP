using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Examen1AP.BLL;
using Examen1AP.Entidades;

namespace Examen1AP.UI.Registros
{
    public partial class rCiudades : Window
    {
        private Ciudades ciudades = new Ciudades();
        public rCiudades()
        {
            InitializeComponent();
            this.DataContext = ciudades;
        }
        //LIMPIAR
        private void Limpiar()
        {
            this.ciudades = new Ciudades();
            this.DataContext = ciudades;
        }
        //VALIDAR
        private bool Validar()
        {
            bool esValido = true;
            if (CiudadIdTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        //BUSCAR
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuarios = CiudadesBLL.Buscar(Utilidades.ToInt(CiudadIdTextbox.Text));
            if (ciudades != null)
                this.ciudades = usuarios;
            else
                this.ciudades = new Ciudades();

            this.DataContext = this.ciudades;
        }
        //NUEVO
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //GUARDAR
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = CiudadesBLL.Guardar(ciudades);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //ELIMINAR
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (CiudadesBLL.Eliminar(Utilidades.ToInt(CiudadIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}