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
    /// Interaction logic for Seguimientos.xaml
    /// </summary>
    public partial class Seguimientos : Window
    {
        SqlConnection conexionSql;
        String[] estados = { "En proceso", "En espera", "Pendiente", "Terminado", "Cancelado" };
        public Seguimientos()
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
            TablaSeguimientos();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
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
                string consulta = "INSERT INTO seguimientos" +
                    "(idTicket, idPersonal, seguimiento, estado) " +
                    "VALUES(@idTicket, @idPersonal, @seguimiento, @estado);";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                conexionSql.Open();
                miCommand.Parameters.AddWithValue("@idTicket", cmbTicket.SelectedValue);
                miCommand.Parameters.AddWithValue("@idPersonal", cmbTecnico.SelectedValue);
                miCommand.Parameters.AddWithValue("@seguimiento", txtSeguimiento.Text);
                miCommand.Parameters.AddWithValue("@estado", cmbEstado.Text);
                miCommand.ExecuteNonQuery();
                conexionSql.Close();
                MessageBox.Show("Registro exitoso", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
                while (dtgSeguimientos.Items.Count > 0)
                {
                    dtgSeguimientos.Items.RemoveAt(0);
                }
                TablaSeguimientos();
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

        private void LimpiarCampos()
        {
            cmbEstado.SelectedIndex = -1;
            cmbTecnico.SelectedIndex = -1;
            cmbTicket.SelectedIndex = -1;
            txtSeguimiento.Clear();
        }

        private void TablaSeguimientos()
        {
            try
            {
                string consulta = "SELECT seguimientos.*, tickets.asunto, CONCAT(personal.nombre,' ',personal.apellidos) AS empleado, personal.especialidad " +
                    "FROM seguimientos INNER JOIN tickets " +
                    "ON seguimientos.idTicket = tickets.Id " +
                    "INNER JOIN personal " +
                    "ON personal.Id = seguimientos.idPersonal;";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionSql);
                using (adaptador)
                {
                    DataTable dtSeguimeintos = new DataTable();
                    adaptador.Fill(dtSeguimeintos);
                    foreach (DataRow row in dtSeguimeintos.Rows)
                    {
                        var newRow = dtgSeguimientos.Items.Add(new
                        {
                            Id = row["Id"].ToString(),
                            idTicket = row["idTicket"].ToString(),
                            asunto = row["asunto"].ToString(),
                            idPersonal = row["idPersonal"].ToString(),
                            tecnico = row["empleado"].ToString(),
                            seguimiento = row["seguimiento"].ToString(),
                            especialidad = row["especialidad"].ToString(),
                            estado = row["estado"].ToString()
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgSeguimientos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectRow = dtgSeguimientos.SelectedItem;
            if (selectRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro de la tabla" + " antes de realizar la accion de eliminar", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int Id = Convert.ToInt32(selectRow.Id);
                try
                {
                    string consulta = "DELETE FROM seguimientos WHERE Id = @Id;";
                    if (MessageBox.Show("¿Esta seguro de eliminar el seguimeinto?",
                        "Confirmación", MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                        conexionSql.Open();
                        miCommand.Parameters.AddWithValue("@Id", Id);
                        miCommand.ExecuteNonQuery();
                        conexionSql.Close();
                        MessageBox.Show("El seguimiento ha sido eliminado correctamente", "Informacion",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                        while (dtgSeguimientos.Items.Count > 0)
                        {
                            dtgSeguimientos.Items.RemoveAt(0); // eliminar datos antiguos dataGrid
                        }
                        TablaSeguimientos(); // actualizar la tabla dataGrid
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarSeguimiento editarSeguimiento = new EditarSeguimiento();
            dynamic selectRow = dtgSeguimientos.SelectedItem;
            if (selectRow == null)
            {
                MessageBox.Show("Selecciones una fila en la tabla" + " antes de realizar la accion editar", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            int id = Convert.ToInt32(selectRow.Id);
            try
            {
                string consulta = "SELECT seguimientos.*, tickets.asunto, CONCAT(personal.nombre,' ',personal.apellidos) AS empleado, personal.especialidad " +
                    "FROM seguimientos INNER JOIN tickets " +
                    "ON seguimientos.idTicket = tickets.Id " +
                    "INNER JOIN personal " +
                    "ON personal.Id = seguimientos.idPersonal " +
                    "WHERE seguimientos.Id = @Id;";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                SqlDataAdapter adaptador = new SqlDataAdapter(miCommand);
                using (adaptador)
                {
                    miCommand.Parameters.AddWithValue("@Id", id);
                    DataTable dtSeguimiento = new DataTable();
                    adaptador.Fill(dtSeguimiento);
                    // enviar datos al formulario

                    editarSeguimiento.cmbTicket.SelectedIndex = (Convert.ToInt32(dtSeguimiento.Rows[0]["idTicket"]) - 1);
                    editarSeguimiento.txtSeguimiento.Text = dtSeguimiento.Rows[0]["seguimiento"].ToString();
                    editarSeguimiento.cmbTecnico.SelectedIndex = (Convert.ToInt32(dtSeguimiento.Rows[0]["idPersonal"]) - 1);
                    editarSeguimiento.cmbEstado.SelectedValue = dtSeguimiento.Rows[0]["estado"].ToString();
                    editarSeguimiento.txtId.Text = id.ToString();
                    editarSeguimiento.Owner = this;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            editarSeguimiento.ShowDialog();
            while (dtgSeguimientos.Items.Count > 0)
            {
                dtgSeguimientos.Items.RemoveAt(0);
            }
            TablaSeguimientos();
            dtgSeguimientos.Items.Refresh();
        }
    }
}
