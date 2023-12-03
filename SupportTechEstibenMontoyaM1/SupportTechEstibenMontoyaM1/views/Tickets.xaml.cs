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
    /// Interaction logic for Tickets.xaml
    /// </summary>
    public partial class Tickets : Window
    {
        SqlConnection conexionSql;
        String[] niveles = { "Administrativo", "Operativo" };
        String[] prioridad = { "Urgente", "Alta", "Media", "Baja" };
        String[] usuario = null;
        public Tickets(String[] datosUsuario)
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
            TablaTickets();

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
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
                string consulta = "INSERT INTO tickets" +
                    "(idArea, departamento, asunto, descripcion, prioridad, " +
                    "reporta, puesto, nivel, whatsapp, fecha, comentarios, " +
                    "sucursal, idUsuario) " +
                    "VALUES(@idArea, @departamento, @asunto, @descripcion, @prioridad, " +
                    "@reporta, @puesto, @nivel, @whatsapp, @fecha, @comentarios, " +
                    "@sucursal, @idUsuario);";
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
                miCommand.ExecuteNonQuery();
                conexionSql.Close();
                MessageBox.Show("Registro exitoso", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
                while (dtgTickets.Items.Count > 0)
                {
                    dtgTickets.Items.RemoveAt(0);
                }
                TablaTickets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void TablaTickets()
        {
            if (usuario[2] == "Admin")
            {
                try
                {
                    string consulta = "SELECT tickets.*, areas.descripcion AS area " +
                        "FROM tickets INNER JOIN areas " +
                        "ON tickets.idArea = areas.Id;";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionSql);
                    using (adaptador)
                    {
                        DataTable dtTickets = new DataTable();
                        adaptador.Fill(dtTickets);
                        foreach (DataRow row in dtTickets.Rows)
                        {
                            var newRow = dtgTickets.Items.Add(new
                            {
                                Id = row["Id"].ToString(),
                                area = row["area"].ToString(),
                                departamento = row["departamento"].ToString(),
                                asunto = row["asunto"].ToString(),
                                descripcion = row["descripcion"].ToString(),
                                prioridad = row["prioridad"].ToString(),
                                puesto = row["puesto"].ToString(),
                                nivel = row["nivel"].ToString(),
                                whatsapp = row["whatsapp"].ToString(),
                                fecha = row["fecha"].ToString(),
                                sucursal = row["sucursal"].ToString(),
                                comentarios = row["comentarios"].ToString()
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
            else 
            {
                try
                {
                    int id = Convert.ToInt32(usuario[0]);
                    string consulta = "SELECT tickets.*, areas.descripcion AS area " +
                        "FROM tickets INNER JOIN areas " +
                        "ON tickets.idArea = areas.Id " +
                        "WHERE tickets.idUsuario = @id;";
                    SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                    SqlDataAdapter adaptador = new SqlDataAdapter(miCommand);
                    using (adaptador)
                    {
                        miCommand.Parameters.AddWithValue("@id", id);
                        DataTable dtTickets = new DataTable();                        
                        adaptador.Fill(dtTickets);
                        foreach (DataRow row in dtTickets.Rows)
                        {
                            var newRow = dtgTickets.Items.Add(new
                            {
                                Id = row["Id"].ToString(),
                                area = row["area"].ToString(),
                                departamento = row["departamento"].ToString(),
                                asunto = row["asunto"].ToString(),
                                descripcion = row["descripcion"].ToString(),
                                prioridad = row["prioridad"].ToString(),
                                puesto = row["puesto"].ToString(),
                                nivel = row["nivel"].ToString(),
                                whatsapp = row["whatsapp"].ToString(),
                                fecha = row["fecha"].ToString(),
                                sucursal = row["sucursal"].ToString(),
                                comentarios = row["comentarios"].ToString()
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

        }

        private void dtgTickets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectRow = dtgTickets.SelectedItem;
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
                    string consulta = "DELETE FROM tickets WHERE Id = @Id;";
                    if (MessageBox.Show("¿Esta seguro de eliminar el ticket?",
                        "Confirmación", MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                        conexionSql.Open();
                        miCommand.Parameters.AddWithValue("@Id", Id);
                        miCommand.ExecuteNonQuery();
                        conexionSql.Close();
                        MessageBox.Show("El ticket ha sido eliminado correctamente");
                        while (dtgTickets.Items.Count > 0)
                        {
                            dtgTickets.Items.RemoveAt(0); // eliminar datos antiguos dataGrid
                        }
                        TablaTickets(); // actualizar la tabla dataGrid
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
            EditarTicket editarTicket = new EditarTicket(usuario);
            //capturar el id del personal para enviar los datos al formulario
            dynamic selectRow = dtgTickets.SelectedItem;
            if (selectRow == null)
            {
                MessageBox.Show("Selecciones una fila en la tabla" + " antes de realizar la accion editar", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            int id = Convert.ToInt32(selectRow.Id);
            try
            {
                string consulta = "SELECT tickets.*, areas.descripcion AS area " +
                    "FROM tickets INNER JOIN areas " +
                    "ON tickets.idArea = areas.Id " +
                    "WHERE tickets.Id = @Id;";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                SqlDataAdapter adaptador = new SqlDataAdapter(miCommand);
                using (adaptador)
                {
                    miCommand.Parameters.AddWithValue("@Id", id);
                    DataTable dtTicket = new DataTable();
                    adaptador.Fill(dtTicket);
                    // enviar datos al formulario
                    editarTicket.cmbArea.SelectedIndex = (Convert.ToInt32(dtTicket.Rows[0]["idArea"]) - 1);
                    editarTicket.txtDepartamento.Text = dtTicket.Rows[0]["departamento"].ToString();
                    editarTicket.txtAsunto.Text = dtTicket.Rows[0]["asunto"].ToString();
                    editarTicket.txtDescripcion.Text = dtTicket.Rows[0]["descripcion"].ToString();
                    editarTicket.cmbPrioridad.SelectedValue = dtTicket.Rows[0]["prioridad"].ToString();
                    editarTicket.txtReporta.Text = dtTicket.Rows[0]["reporta"].ToString();
                    editarTicket.txtPuesto.Text = dtTicket.Rows[0]["puesto"].ToString();
                    editarTicket.cmbNivel.SelectedValue = dtTicket.Rows[0]["nivel"].ToString();
                    editarTicket.txtWhatsapp.Text = dtTicket.Rows[0]["whatsapp"].ToString();
                    editarTicket.dpkFecha.Text = dtTicket.Rows[0]["fecha"].ToString();
                    editarTicket.txtComentarios.Text = dtTicket.Rows[0]["comentarios"].ToString();
                    editarTicket.txtSucursal.Text = dtTicket.Rows[0]["sucursal"].ToString();
                    editarTicket.txtId.Text = id.ToString();
                    editarTicket.Owner = this;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            editarTicket.ShowDialog();
            while (dtgTickets.Items.Count > 0)
            {
                dtgTickets.Items.RemoveAt(0);
            }
            TablaTickets();
            dtgTickets.Items.Refresh();

        }
    }
}
