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
    /// Interaction logic for Personal.xaml
    /// </summary>
    public partial class Personal : Window
    {
        SqlConnection conexionSql;
        public Personal()
        {
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["SupportTechEstibenMontoyaM1.Properties.Settings.SupportTechEstibenMontoyaM1ConnectionString"].ConnectionString;
            conexionSql = new SqlConnection(conexion);
            TablaPersonal();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDocumento.Text.Trim() == "" || txtNombre.Text.Trim() == ""
                || txtApellidos.Text.Trim() == "" || txtEspecialidad.Text.Trim() == ""
                || dpkFechaIngreso.Text.Trim() == "" || txtHorario.Text.Trim().Trim() == ""
                || txtEmail.Text.Trim() == "" || txtWhast.Text.Trim() == "") 
            {
                MessageBox.Show("Debe diligenciar todos los campos", "Alerta",
                    MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            string consulta = "INSERT INTO personal(nombre, apellidos, especialidad, fechaIngreso, horario, documento, mail, whats) "
                + "VALUES(@nombre, @apellidos, @especialidad, @fechaIngreso, @horario, @documento, @mail, @whats);";
            SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
            conexionSql.Open();
            miCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
            miCommand.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
            miCommand.Parameters.AddWithValue("@especialidad", txtEspecialidad.Text);
            miCommand.Parameters.AddWithValue("@fechaIngreso", dpkFechaIngreso.SelectedDate);
            miCommand.Parameters.AddWithValue("@horario", txtHorario.Text);
            miCommand.Parameters.AddWithValue("@documento",txtDocumento.Text);
            miCommand.Parameters.AddWithValue("@mail", txtEmail.Text);
            miCommand.Parameters.AddWithValue("@whats", txtWhast.Text);
            miCommand.ExecuteNonQuery();
            conexionSql.Close();
            MessageBox.Show("Registro exitoso", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
            LimpiarCampos();
            while(dtgPersonal.Items.Count > 0)
            {
                dtgPersonal.Items.RemoveAt(0);
            }
            TablaPersonal();
            dtgPersonal.Items.Refresh();
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtEspecialidad.Clear();
            dpkFechaIngreso.SelectedDate = null;
            txtHorario.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtWhast.Clear();
        }

        private void TablaPersonal()
        {
            string consulta = "SELECT * FROM personal;";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionSql);
            using (adaptador) 
            {
                DataTable dtPersonal = new DataTable();
                adaptador.Fill(dtPersonal);
                foreach (DataRow row in dtPersonal.Rows)
                {
                    var newRow = dtgPersonal.Items.Add(
                        new
                        {
                            Id = row["Id"].ToString(),
                            documento = row["documento"].ToString(),
                            nombre = row["nombre"].ToString(),
                            apellidos = row["apellidos"].ToString(),
                            especialidad = row["especialidad"].ToString(),
                            fechaIngreso = row["fechaIngreso"].ToString(),
                            horario = row["horario"].ToString(),
                            mail = row["mail"].ToString(),
                            whats = row["whats"].ToString()                            
                        }
                        );
                }
            }

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarPersonal editarPersonal = new EditarPersonal();
            //capturar el id del personal para enviar los datos al formulario
            dynamic selectRow = dtgPersonal.SelectedItem;
            if ( selectRow == null ) 
            {
                MessageBox.Show("Selecciones una fila en la tabla" + " antes de realizar la accion editar", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            int id = Convert.ToInt32(selectRow.Id);
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
            while (dtgPersonal.Items.Count > 0)
            {
                dtgPersonal.Items.RemoveAt(0);
            }
            TablaPersonal();
            dtgPersonal.Items.Refresh();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
