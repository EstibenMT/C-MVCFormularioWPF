using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
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
    /// Interaction logic for EditarSeguimiento.xaml
    /// </summary>
    public partial class EditarSeguimiento : Window
    {
        SqlConnection conexionSql;
        String[] estados = { "En proceso", "En espera", "Pendiente", "Terminado", "Cancelado" };

        public EditarSeguimiento()
        {
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["SupportTechEstibenMontoyaM1.Properties.Settings.SupportTechEstibenMontoyaM1ConnectionString"].ConnectionString;
            conexionSql = new SqlConnection(conexion);
            foreach (string estado in estados)
            {
                cmbEstado.Items.Add(estado);
            }
            ListaPersonal();
            ListaTickets();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTicket.SelectedIndex == -1 || cmbTecnico.SelectedIndex == -1
                || txtSeguimiento.Text.Trim() == "" || cmbEstado.Text == "")
            {
                MessageBox.Show("Debe diligenciar todos los campos", "Alerta",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                string consulta = "UPDATE seguimientos SET " +
                    "idTicket=@idTicket, idPersonal=@idPersonal, seguimiento=@seguimiento, estado=@estado " +
                    "WHERE Id=@Id;";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                conexionSql.Open();
                miCommand.Parameters.AddWithValue("@idTicket", cmbTicket.SelectedValue);
                miCommand.Parameters.AddWithValue("@idPersonal", cmbTecnico.SelectedValue);
                miCommand.Parameters.AddWithValue("@seguimiento", txtSeguimiento.Text);
                miCommand.Parameters.AddWithValue("@estado", cmbEstado.Text);
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

        private void ListaTickets()
        {
            string consulta = "SELECT Id, CONCAT(Id,' ', asunto) AS ticket FROM tickets;";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionSql);
            using (adaptador)
            {
                DataTable dtArea = new DataTable();
                adaptador.Fill(dtArea);
                cmbTicket.DisplayMemberPath = "ticket";
                cmbTicket.SelectedValuePath = "Id";
                cmbTicket.ItemsSource = dtArea.DefaultView;
            }
        }
        private void ListaPersonal()
        {
            string consulta = "SELECT Id, CONCAT(Id,' ',nombre,' ',apellidos,' ', especialidad) AS empleado FROM personal;";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionSql);
            using (adaptador)
            {
                DataTable dtArea = new DataTable();
                adaptador.Fill(dtArea);
                cmbTecnico.DisplayMemberPath = "empleado";
                cmbTecnico.SelectedValuePath = "Id";
                cmbTecnico.ItemsSource = dtArea.DefaultView;
            }
        }
    }
}
