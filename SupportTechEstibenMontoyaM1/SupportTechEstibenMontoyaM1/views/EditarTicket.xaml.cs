using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Interaction logic for EditarTicket.xaml
    /// </summary>
    public partial class EditarTicket : Window
    {
        SqlConnection conexionSql;
        String[] niveles = { "Administrativo", "Operativo" };
        String[] prioridad = { "Urgente", "Alta", "Media", "Baja" };
        String[] usuario = null;
        public EditarTicket(String[] datosUsuario)
        {
            usuario = datosUsuario;
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["SupportTechEstibenMontoyaM1.Properties.Settings.SupportTechEstibenMontoyaM1ConnectionString"].ConnectionString;
            conexionSql = new SqlConnection(conexion);
            foreach (var item in niveles)
            {
                cmbNivel.Items.Add(item);
            }
            foreach (var item in prioridad)
            {
                cmbPrioridad.Items.Add(item);
            }
            ListaAreas();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbArea.SelectedIndex == -1 || txtDepartamento.Text.Trim() == ""

                || txtDescripcion.Text.Trim() == "" || cmbPrioridad.Text == ""

                || txtReporta.Text.Trim() == "" || cmbNivel.Text == ""

                || txtWhatsapp.Text.Trim() == "" || dpkFecha.Text == "")

            {
                MessageBox.Show("Debe diligenciar los campos obligatorios", "Alerta",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                string consulta = "UPDATE tickets SET " +
                    "idArea=@idArea, departamento=@departamento, asunto=@asunto, descripcion=@descripcion, prioridad=@prioridad, " +
                    "reporta=@reporta, puesto=@puesto, nivel=@nivel, whatsapp=@whatsapp, fecha=@fecha, comentarios=@comentarios, " +
                    "sucursal=@sucursal, idUsuario=@idUsuario  WHERE Id=@Id;";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                conexionSql.Open();
                miCommand.Parameters.AddWithValue("@idArea", cmbArea.SelectedValue);
                miCommand.Parameters.AddWithValue("@departamento", txtDepartamento.Text);
                miCommand.Parameters.AddWithValue("@asunto", txtAsunto.Text);
                miCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                miCommand.Parameters.AddWithValue("@prioridad", cmbPrioridad.Text);
                miCommand.Parameters.AddWithValue("@reporta", txtReporta.Text);
                miCommand.Parameters.AddWithValue("@puesto", txtPuesto.Text);
                miCommand.Parameters.AddWithValue("@nivel", cmbNivel.Text);
                miCommand.Parameters.AddWithValue("@whatsapp", txtWhatsapp.Text);
                miCommand.Parameters.AddWithValue("@fecha", dpkFecha.SelectedDate);
                miCommand.Parameters.AddWithValue("@comentarios", txtComentarios.Text);
                miCommand.Parameters.AddWithValue("@sucursal", txtSucursal.Text);
                miCommand.Parameters.AddWithValue("@idUsuario", usuario[0]);
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListaAreas()
        {
            try
            {
                string consulta = "SELECT Id, descripcion FROM areas;";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionSql);
                using (adaptador)
                {
                    DataTable dtArea = new DataTable();
                    adaptador.Fill(dtArea);
                    cmbArea.DisplayMemberPath = "descripcion";
                    cmbArea.SelectedValuePath = "Id";
                    cmbArea.ItemsSource = dtArea.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimpiarCampos()
        {
            cmbArea.SelectedIndex = -1;
            cmbNivel.SelectedIndex = -1;
            cmbPrioridad.SelectedIndex = -1;
            txtAsunto.Clear();
            txtComentarios.Clear();
            txtSucursal.Clear();
            txtDepartamento.Clear();
            txtDescripcion.Clear();
            txtPuesto.Clear();
            txtReporta.Clear();
            txtWhatsapp.Clear();
            dpkFecha.SelectedDate = null;
        }
    }
}
