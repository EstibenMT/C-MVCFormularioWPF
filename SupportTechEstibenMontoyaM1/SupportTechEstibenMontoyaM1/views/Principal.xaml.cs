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
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {            
        String[] datosUsuario = null;
        SqlConnection conexionSql;
        public Principal(String[] user)
        {
            InitializeComponent();
            datosUsuario = user;
            string conexion = ConfigurationManager.ConnectionStrings["SupportTechEstibenMontoyaM1.Properties.Settings.SupportTechEstibenMontoyaM1ConnectionString"].ConnectionString;
            conexionSql = new SqlConnection(conexion);
            MessageBox.Show("Bienvenido: " + user[4] + " " + user[5] + "\nNivel: " + user[2],
                "Información", MessageBoxButton.OK,MessageBoxImage.Information);
        }
        
        private void MenuUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (datosUsuario[2] == "Admin")
            {
                Usuarios usuarios = new Usuarios();
                usuarios.Owner = this;
                usuarios.Show();
                
            }
            else
            {
                MessageBox.Show("No tiene permisos suficientes", "Alerta",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


        }

        private void MenuCambiar_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void MenuSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuPersonal_Click(object sender, RoutedEventArgs e)
        {
            if (datosUsuario[2] == "Admin")
            {
                Personal personal = new Personal();
                personal.Owner = this;
                personal.Show();

            }
            else
            {
                EditarPersonal editarPersonal = new EditarPersonal();

                int id = Convert.ToInt32(datosUsuario[3]);
                try
                {
                    string consulta = "SELECT * FROM personal WHERE Id = @Id";
                    SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                    SqlDataAdapter adaptador = new SqlDataAdapter(miCommand);
                    using (adaptador)
                    {
                        miCommand.Parameters.AddWithValue("@Id", id);
                        DataTable dtPersonal = new DataTable();
                        adaptador.Fill(dtPersonal);
                        // enviar datos al formulario
                        editarPersonal.txtDocumento.Text = dtPersonal.Rows[0]["documento"].ToString();
                        editarPersonal.txtNombre.Text = dtPersonal.Rows[0]["nombre"].ToString();
                        editarPersonal.txtApellidos.Text = dtPersonal.Rows[0]["apellidos"].ToString();
                        editarPersonal.txtEspecialidad.Text = dtPersonal.Rows[0]["especialidad"].ToString();
                        editarPersonal.dpkFechaIngreso.Text = dtPersonal.Rows[0]["fechaIngreso"].ToString();
                        editarPersonal.txtHorario.Text = dtPersonal.Rows[0]["horario"].ToString();
                        editarPersonal.txtEmail.Text = dtPersonal.Rows[0]["mail"].ToString();
                        editarPersonal.txtWhast.Text = dtPersonal.Rows[0]["whats"].ToString();
                        editarPersonal.txtId.Text = id.ToString();
                        editarPersonal.Owner = this;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                editarPersonal.ShowDialog();
            }


        }

        private void MenuTicket_Click(object sender, RoutedEventArgs e)
        {
            Tickets ticket = new Tickets(datosUsuario);
            ticket.Owner = this;
            ticket.Show();

        }

        private void MenuSeguimiento_Click(object sender, RoutedEventArgs e)
        {          

            if (datosUsuario[2] == "Admin")
            {
                Seguimientos seguimientos = new Seguimientos();
                seguimientos.Owner = this;
                seguimientos.Show();
            }
            else
            {
                MessageBox.Show("No tiene permisos suficientes", "Alerta",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

        }
    }
}
