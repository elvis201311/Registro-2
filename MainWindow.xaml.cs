using Registro.BLL;
using Registro.Entidades;
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


namespace Registro
{

    public partial class MainWindow : Window
    {
        private Estudiantes estudiante = new Estudiantes();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = estudiante;


        }

        private void Limpiar()
        {
            this.estudiante = new Estudiantes();
            this.DataContext = estudiante;

        }

        private bool Validar()
        {
            bool valido = true;

            if (nombreTextBox.Text.Length == 0 || telefonoTextBox.Text.Length == 0 ||
                direccionTextBox.Text.Length == 0 || idBox.Text.Length == 0 || cedulaTextBox.Text.Length == 0 || fechaNDatePicker.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Verifique que todos los campos esten llenos.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (nombreTextBox.Text.Length == 0 || nombreTextBox.Text.Length < 2)
            {
                valido = false;
                MessageBox.Show("Verifique que haya introducido un nombre valido.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return valido;
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            var estudiante = EstudiantesBLL.Buscar(int.Parse(idBox.Text));

            if (estudiante != null)
            {
                this.estudiante = estudiante;
            }
            else
            {
                this.estudiante = new Estudiantes();
            }

            this.DataContext = this.estudiante;
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            var key = EstudiantesBLL.Guardar(estudiante);

            if (key)
            {
                Limpiar();
                MessageBox.Show("Guardad", "Exitosamente", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Fallo.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(int.Parse(idBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado.", "Exitosamente",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el registro", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}