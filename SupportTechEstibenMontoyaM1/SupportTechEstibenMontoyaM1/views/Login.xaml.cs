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
using System.Configuration;// configurar la coneccion
using System.Data.SqlClient;// Sql server
using System.Data;//Data Table

namespace SupportTechEstibenMontoyaM1.views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection conexionSql;
        public Login()
        {
            InitializeComponent();
            //Ininciamos la conexion
            string conexion = ConfigurationManager.ConnectionStrings["SupportTechEstibenMontoyaM1.Properties.Settings.SupportTechEstibenMontoyaM1ConnectionString"].ConnectionString;
            conexionSql = new SqlConnection(conexion);
            //try
            //{
            //    conexionSql.Open(); // abrir conexion
            //    MessageBox.Show("Conexion exitosa");
            //    conexionSql.Close(); // cerrar conexion

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
                Application.Current.Shutdown();            
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            //Validaciones
            //Campos vacios
            if (txtLogin.Text.Trim()=="" && txtPass.Password.Trim()=="") 
            {
                MessageBox.Show("Debe llenar todos los campos","Información",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string login = txtLogin.Text.Trim();
            string pass = txtPass.Password.Trim();
            //Validacion de excepciones
            try
            {
                // consulta del usuarios en la db
                string consulta = "SELECT usuarios.*, personal.nombre, personal.apellidos FROM usuarios INNER JOIN personal ON usuarios.idPersonal = personal.Id WHERE usuarios.login COLLATE SQL_Latin1_General_CP1_CS_AS = @login AND usuarios.pass COLLATE SQL_Latin1_General_CP1_CS_AS = @pass;";
                SqlCommand micommand = new SqlCommand(consulta, conexionSql);
                SqlDataAdapter adaptador = new SqlDataAdapter(micommand);
                using(adaptador) 
                { 
                    micommand.Parameters.AddWithValue("@login", login);
                    micommand.Parameters.AddWithValue("@pass", pass);
                    DataTable usuario = new DataTable();
                    adaptador.Fill(usuario);
                    if (IsDataTableEmply(usuario)==false)
                    {
                        //Validacion de estado activo o inactivo
                        string status = usuario.Rows[0]["estado"].ToString();
                        if (status.Trim() == "Activo")
                        {
                            // ingreso del usaurio
                            string userId = usuario.Rows[0]["Id"].ToString();
                            string userName = usuario.Rows[0]["login"].ToString();
                            string userNivel = usuario.Rows[0]["nivel"].ToString();
                            string userPersonal = usuario.Rows[0]["idPersonal"].ToString();
                            string userFirstName = usuario.Rows[0]["nombre"].ToString();
                            string userLastName = usuario.Rows[0]["apellidos"].ToString();
                            String[] user = { userId, userName, userNivel, userPersonal, userFirstName, userLastName };
                            Principal principal = new Principal(user);
                            principal.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El usuario se encuentra inactivo",
                                "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrecta", 
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //metodo para validar tablas vacias
        private bool IsDataTableEmply(DataTable dataTable) 
        {
            return (dataTable == null || dataTable.Rows.Count == 0);
        }

    }
}
