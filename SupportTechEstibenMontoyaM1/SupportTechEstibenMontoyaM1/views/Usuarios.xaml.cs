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
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        SqlConnection conexionSql;
        String[] niveles = { "Admin", "Tecnico" };
        public Usuarios()
        {
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["SupportTechEstibenMontoyaM1.Properties.Settings.SupportTechEstibenMontoyaM1ConnectionString"].ConnectionString;
            conexionSql = new SqlConnection(conexion);
            foreach (var item in niveles)
            {
                cmbNivel.Items.Add(item);
            }
            ListaPersonal();
            DatosUsuarios();
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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //validar los campos
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
            string estado = "Inactivo";
            if (chkEstado.IsChecked == true)
            {
                estado = "Activo";
            }
            try
            {
                string consulta = "INSERT INTO usuarios(login, pass, nivel, estado, idPersonal) " +
                    "VALUES(@login, @pass, @nivel, @estado, @idPersonal);";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                conexionSql.Open();
                miCommand.Parameters.AddWithValue("@login", txtUsuario.Text);
                miCommand.Parameters.AddWithValue("@pass", txtClave.Password);
                miCommand.Parameters.AddWithValue("@nivel", cmbNivel.Text);
                miCommand.Parameters.AddWithValue("@estado", estado);
                miCommand.Parameters.AddWithValue("@idPersonal", cmbEmpleado.SelectedValue);
                miCommand.ExecuteNonQuery();
                conexionSql.Close();
                MessageBox.Show("Registro exitoso", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
                while (dtgUsuarios.Items.Count > 0)
                {
                    dtgUsuarios.Items.RemoveAt(0);
                }
                DatosUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtClave.Clear();
            txtConfirmar.Clear();
            cmbEmpleado.SelectedIndex = -1;
            cmbNivel.SelectedIndex = -1;
            chkEstado.IsChecked = false;
        }

        private void DatosUsuarios()
        {
            string consulta = "SELECT usuarios.*, CONCAT(nombre,' ',apellidos) " 
                + "AS empleado FROM usuarios INNER JOIN personal " 
                + "ON usuarios.idPersonal = personal.Id;";
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionSql);
                using (adaptador)
                {
                    DataTable tablaUsuarios = new DataTable();
                    adaptador.Fill(tablaUsuarios);
                    foreach (DataRow row in tablaUsuarios.Rows)
                    {
                        var newRow = dtgUsuarios.Items.Add(new
                        {
                            Id = row["Id"].ToString(),
                            login = row["login"].ToString(),
                            pass = row["pass"].ToString(),
                            nivel = row["nivel"].ToString(),
                            empleado = row["empleado"].ToString(),
                            idPersonal = row["idPersonal"].ToString(),
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

        private void btnCambiarEstado_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectRow = dtgUsuarios.SelectedItem;
            if (selectRow == null) 
            {
                MessageBox.Show("Selecciones un registro en la tabla" + " antes de realizar la accion cambiar estado", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else 
            {
                int Id = Convert.ToInt32(selectRow.Id);
                try
                {
                    if (MessageBox.Show("¿Está seguro de cambiar el estado?", "Confirmación",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        string consulta = "UPDATE usuarios SET estado = " 
                            + "(CASE WHEN estado = 'Activo' THEN 'Inactivo' ELSE 'Activo' END) "
                            + "WHERE Id = @Id ;";
                        SqlCommand miComand = new SqlCommand(consulta, conexionSql);
                        conexionSql.Open();
                        miComand.Parameters.AddWithValue("Id", Id);
                        miComand.ExecuteNonQuery();
                        conexionSql.Close();
                        while (dtgUsuarios.Items.Count > 0)
                        {
                            dtgUsuarios.Items.RemoveAt(0);
                        }
                        DatosUsuarios();
                        MessageBox.Show("El estado ha sido cambiado","Informacion",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarUsuario editarUsuario = new EditarUsuario();
            dynamic selectRow = dtgUsuarios.SelectedItem;
            if (selectRow == null)
            {
                MessageBox.Show("Selecciones una fila en la tabla" + " antes de realizar la accion editar", "Informacion",
                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            int id = Convert.ToInt32(selectRow.Id);
            try
            {
                string consulta = "SELECT usuarios.*, CONCAT(nombre,' ',apellidos) "
                + "AS empleado FROM usuarios INNER JOIN personal "
                + "ON usuarios.idPersonal = personal.Id " 
                + "WHERE usuarios.Id = @Id;";
                SqlCommand miCommand = new SqlCommand(consulta, conexionSql);
                SqlDataAdapter adaptador = new SqlDataAdapter(miCommand);
                using (adaptador)
                {
                    miCommand.Parameters.AddWithValue("@Id", id);
                    DataTable dtUsuario = new DataTable();
                    adaptador.Fill(dtUsuario);
                    // enviar datos al formulario
                    
                    editarUsuario.txtUsuario.Text = dtUsuario.Rows[0]["login"].ToString();
                    //editarUsuario.txtClave.Password = dtUsuario.Rows[0]["pass"].ToString();
                    editarUsuario.cmbNivel.SelectedValue = dtUsuario.Rows[0]["nivel"].ToString();
                    editarUsuario.cmbEmpleado.SelectedValue = dtUsuario.Rows[0]["idPersonal"].ToString();
                    editarUsuario.txtId.Text = id.ToString();
                    editarUsuario.Owner = this;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            editarUsuario.ShowDialog();
            while (dtgUsuarios.Items.Count > 0)
            {
                dtgUsuarios.Items.RemoveAt(0);
            }
            DatosUsuarios();          
            dtgUsuarios.Items.Refresh();
        }
    }
}
