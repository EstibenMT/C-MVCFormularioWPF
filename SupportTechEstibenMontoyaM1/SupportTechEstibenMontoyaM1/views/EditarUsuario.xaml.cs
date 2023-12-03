using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;

namespace SupportTechEstibenMontoyaM1.views
{
    /// <summary>
    /// Interaction logic for EditarUsuario.xaml
    /// </summary>
    public partial class EditarUsuario : Window
    {
        SqlConnection conexionSql;
        String[] niveles = { "Admin", "Tecnico" };
        public EditarUsuario()
        {
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["SupportTechEstibenMontoyaM1.Properties.Settings.SupportTechEstibenMontoyaM1ConnectionString"].ConnectionString;
            conexionSql = new SqlConnection(conexion);
            foreach (var item in niveles)
            {
                cmbNivel.Items.Add(item);
            }
            ListaPersonal();
            ListaPersonal();
        }

        private void ListaPersonal()
        {
            try
            {
                string consulta = "SELECT Id, CONCAT(documento,' ', nombre,' ', apellidos) AS nombre FROM personal;";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionSql);
                using (adaptador)
                {
                    DataTable dtPersonal = new DataTable();
                    adaptador.Fill(dtPersonal);
                    cmbEmpleado.DisplayMemberPath = "nombre";
                    cmbEmpleado.SelectedValuePath = "Id";
                    cmbEmpleado.ItemsSource = dtPersonal.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtClave.Password.Trim() == "" ||
                txtConfirmar.Password.Trim() == "" || cmbEmpleado.SelectedIndex == -1
                || cmbNivel.Text.ToString() == "")
            {
                MessageBox.Show("Debe diligenciar todos los campos", "Alerta",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // validar contraseña
            if (txtClave.Password != txtConfirmar.Password)
            {
                MessageBox.Show("Las contraseñas no coinciden..", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                string consulta = "UPDATE usuarios SET login=@login, " +
                    "pass=@pass, nivel=@nivel, idPersonal=@idPersonal " +
                    "WHERE Id=@Id;";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                conexionSql.Open();
                miCommand.Parameters.AddWithValue("@login", txtUsuario.Text);
                miCommand.Parameters.AddWithValue("@pass", txtClave.Password);
                miCommand.Parameters.AddWithValue("@nivel", cmbNivel.Text);
                miCommand.Parameters.AddWithValue("@idPersonal", cmbEmpleado.SelectedValue);
                miCommand.Parameters.AddWithValue("@Id", txtId.Text);
                miCommand.ExecuteNonQuery();
                conexionSql.Close();
                MessageBox.Show("Actualización exitosa", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
