using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace LAB3PistoliaGinoSemanaUNO
{
    public partial class GestionForm : Form
    {
        public string connectionString = "Server = localhost\\SQLEXPRESS; Database = Gestion; Trusted_Connection = True";
        Conexion c = new Conexion();
        public GestionForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            c.Conectar(dgvGestion);
            

            cmbTarea.Items.Clear();
            cmbTarea.Items.Add("Limpieza");
            cmbTarea.Items.Add("Atencion al cliente");
            cmbTarea.Items.Add("logistica");
            cmbTarea.SelectedIndex = 0;

            cmbPrioridad.Items.Clear();
            cmbPrioridad.Items.Add("Alta");
            cmbPrioridad.Items.Add("Media");
            cmbPrioridad.Items.Add("Baja");
            cmbTarea.SelectedIndex = -1;

            txtId.Text = "";
            txtTitulo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtEstado.Text = "";

            string Titulo = txtTitulo.Text;
            string Nombre = txtNombre.Text;
            string Descripcion = txtDescripcion.Text;
            string Estado = txtEstado.Text;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Usuarios (Id, Titulo, Nombre, Descripcion, Prioridad, Tarea, Estado) VALUES (@id, @Titulo, @Nombre, @Descripcion, @Prioridad, @Tarea, @Estado)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                int Id = Convert.ToInt32(txtId.Text);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@Prioridad", cmbPrioridad.Text);
                cmd.Parameters.AddWithValue("@Tarea", cmbTarea.Text);
                cmd.Parameters.AddWithValue("@Estado", txtEstado.Text);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Usuario guardado exitosamente.");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Id, Titulo, Nombre, Descripcion, Prioridad, Tarea, Estado FROM Usuarios WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTitulo.Text = reader["Titulo"].ToString();
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                        cmbPrioridad.Text = reader["Prioridad"].ToString();
                        cmbTarea.Text = reader["Tarea"].ToString();
                        txtEstado.Text = reader["Estado"].ToString();

                        MessageBox.Show("Consulta realizada exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string updateQuery = "UPDATE Usuarios SET Id = @Titulo, Nombre = @Nombre, Descripcion = @Descripcion, Prioridad = @Prioridad, Tarea = @Tarea, Estado = @Estado WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@Prioridad", cmbPrioridad.Text);
                cmd.Parameters.AddWithValue("@Tarea", cmbTarea.Text);
                cmd.Parameters.AddWithValue("@Estado", txtEstado.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario modificado exitosamente.");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Usuarios WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("El usuario eliminado exitosamente.");

            }
        }
    }
}

