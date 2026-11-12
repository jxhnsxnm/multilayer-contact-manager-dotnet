using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarContactos();
            Limpiar();
        }

        N_Contactos negocio = new N_Contactos();
        private void buscar_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            E_Contactos contacto = negocio.Buscar(ID);
            if (contacto != null)
            {
                txtID.Text = Convert.ToString(contacto.ID);
                txtNombre.Text = Convert.ToString(contacto.Nombre);
                txtApellido.Text = Convert.ToString(contacto.Apellido);
                txtFechaNac.Text = Convert.ToString(contacto.Fecha_Nacimiento);
                txtDireccion.Text = Convert.ToString(contacto.Direccion);
                txtGenero.Text = Convert.ToString(contacto.Genero);
                txtEstado.Text = Convert.ToString(contacto.Estado_Civil);
                txtMovil.Text = Convert.ToString(contacto.Movil);
                txtTelefono.Text = Convert.ToString(contacto.Telefono);
                txtEmail.Text = Convert.ToString(contacto.Correo_Electronico);
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }

        }

        private void insertar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Contactos nuevoContacto = new E_Contactos
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Fecha_Nacimiento = txtFechaNac.Text,
                    Direccion = txtDireccion.Text,
                    Genero = txtGenero.Text,
                    Estado_Civil = txtEstado.Text,
                    Movil = long.Parse(txtMovil.Text),
                    Telefono = long.Parse((txtTelefono.Text)),
                    Correo_Electronico = txtEmail.Text
                };
                negocio.Insertar(nuevoContacto);
                MessageBox.Show("Contacto insertado con éxito.");
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            CargarContactos();
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            // Modificar un contacto
            try
            {
                int ID = int.Parse(txtID.Text); // Asegúrate de tener un campo para el ID
                E_Contactos contacto = new E_Contactos
                {
                    ID = ID,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Fecha_Nacimiento = txtFechaNac.Text,
                    Direccion = txtDireccion.Text,
                    Genero = txtGenero.Text,
                    Estado_Civil = txtEstado.Text,
                    Movil = long.Parse(txtMovil.Text),
                    Telefono = long.Parse((txtTelefono.Text)),
                    Correo_Electronico = txtEmail.Text
                };
                negocio.Modificar(contacto);
                MessageBox.Show("Contacto modificado con éxito.");
                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtFechaNac.Clear();
            txtDireccion.Clear();
            txtGenero.Clear();
            txtEstado.Clear();
            txtMovil.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            dataGridView1.CurrentCell = null;
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(txtID.Text);
                negocio.Eliminar(ID);
                MessageBox.Show("Contacto eliminado con éxito.");
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            CargarContactos();
        }

        private void CargarContactos()
        {
            try
            {
                List<E_Contactos> contactos = negocio.ObtenerTodos();
                dataGridView1.DataSource = contactos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los contactos: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
                txtID.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ID"].Value);
                txtNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Apellido"].Value);
                txtFechaNac.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Fecha_Nacimiento"].Value);
                txtDireccion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Direccion"].Value);
                txtGenero.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Genero"].Value);
                txtEstado.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Estado_Civil"].Value);
                txtMovil.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Movil"].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Telefono"].Value);
                txtEmail.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Correo_Electronico"].Value);   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
