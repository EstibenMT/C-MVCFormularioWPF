using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace SupportTechEstibenMontoyaM1.views
{
    /// <summary>
    /// Interaction logic for EditarPersonal.xaml
    /// </summary>
    public partial class EditarPersonal : Window
    {
        SqlConnection conexionSql;
        public EditarPersonal()
        {
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["SupportTechEstibenMontoyaM1.Properties.Settings.SupportTechEstibenMontoyaM1ConnectionString"].ConnectionString;
            conexionSql = new SqlConnection(conexion);
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDocumento.Text.Trim() == "" || txtNombre.Text.Trim() == ""
                || txtApellidos.Text.Trim() == "" || txtEspecialidad.Text.Trim() == ""
                || dpkFechaIngreso.Text.Trim() == "" || txtHorario.Text.Trim().Trim() == ""
                || txtEmail.Text.Trim() == "" || txtWhast.Text.Trim() == "")
            {
                MessageBox.Show("Debe diligenciar todos los campos", "Alerta",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                string consulta = "UPDATE personal SET nombre=@nombre, "
                + "apellidos=@apellidos, especialidad=@especialidad, "
                + "fechaIngreso=@fechaIngreso, horario=@horario, "
                + "documento=@documento, mail=@mail, whats=@whats WHERE Id=@Id;";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                conexionSql.Open();
                miCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                miCommand.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                miCommand.Parameters.AddWithValue("@especialidad", txtEspecialidad.Text);
                miCommand.Parameters.AddWithValue("@fechaIngreso", dpkFechaIngreso.SelectedDate);
                miCommand.Parameters.AddWithValue("@horario", txtHorario.Text);
                miCommand.Parameters.AddWithValue("@documento", txtDocumento.Text);
                miCommand.Parameters.AddWithValue("@mail", txtEmail.Text);
                miCommand.Parameters.AddWithValue("@whats", txtWhast.Text);
                miCommand.Parameters.AddWithValue("@Id", txtId.Text);
                miCommand.ExecuteNonQuery();
                conexionSql.Close();
                MessageBox.Show("Actualización exitosa", "Informacion",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
