using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using CapaEntidad;

namespace CapaDatos
{
    public class D_Contactos
    {
        private string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramacionII;Data Source=JA-Johnson-M\\JOHNSON";

        public void Insertar(E_Contactos contacto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertarContacto", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                cmd.Parameters.AddWithValue("@Fecha_Nacimiento", contacto.Fecha_Nacimiento);
                cmd.Parameters.AddWithValue("@Direccion", contacto.Direccion);
                cmd.Parameters.AddWithValue("@Genero", contacto.Genero);
                cmd.Parameters.AddWithValue("@Estado_Civil", contacto.Estado_Civil);
                cmd.Parameters.AddWithValue("@Movil", contacto.Movil);
                cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                cmd.Parameters.AddWithValue("@Correo_Electronico", contacto.Correo_Electronico);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(E_Contactos contacto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ModificarContacto", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", contacto.ID);
                cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                cmd.Parameters.AddWithValue("@Fecha_Nacimiento", contacto.Fecha_Nacimiento);
                cmd.Parameters.AddWithValue("@Direccion", contacto.Direccion);
                cmd.Parameters.AddWithValue("@Genero", contacto.Genero);
                cmd.Parameters.AddWithValue("@Estado_Civil", contacto.Estado_Civil);
                cmd.Parameters.AddWithValue("@Movil", contacto.Movil);
                cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                cmd.Parameters.AddWithValue("@Correo_Electronico", contacto.Correo_Electronico);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int ID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EliminarContacto", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public E_Contactos Buscar(int ID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("BuscarContacto", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new E_Contactos
                    {
                        ID = reader["ID"] != DBNull.Value ? (int)reader["ID"] : 0,
                        Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty,
                        Apellido = reader["Apellido"] != DBNull.Value ? reader["Apellido"].ToString() : string.Empty,
                        Fecha_Nacimiento = reader["Fecha_Nacimiento"] != DBNull.Value ? reader["Fecha_Nacimiento"].ToString() : string.Empty,
                        Direccion = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : string.Empty,
                        Genero = reader["Genero"] != DBNull.Value ? reader["Genero"].ToString() : string.Empty,
                        Estado_Civil = reader["Estado_Civil"] != DBNull.Value ? reader["Estado_Civil"].ToString() : string.Empty,
                        Movil = reader["Movil"] != DBNull.Value ? Convert.ToInt64(reader["Movil"]) : 0L,
                        Telefono = reader["Telefono"] != DBNull.Value ? Convert.ToInt64(reader["Telefono"]) : 0L,
                        Correo_Electronico = reader["Correo_Electronico"] != DBNull.Value ? reader["Correo_Electronico"].ToString() : string.Empty
                    };

                }
                else
                {
                    return null;
                }
            }
        }

        public List<E_Contactos> ObtenerTodos()
        {
            List<E_Contactos> listaContactos = new List<E_Contactos>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ObtenerTodosLosContactos", conn); // Nombre del procedimiento almacenado
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    E_Contactos contacto = new E_Contactos
                    {
                        ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                        Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty,
                        Apellido = reader["Apellido"] != DBNull.Value ? reader["Apellido"].ToString() : string.Empty,
                        Fecha_Nacimiento = reader["Fecha_Nacimiento"] != DBNull.Value ? reader["Fecha_Nacimiento"].ToString() : string.Empty,
                        Direccion = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : string.Empty,
                        Genero = reader["Genero"] != DBNull.Value ? reader["Genero"].ToString() : string.Empty,
                        Estado_Civil = reader["Estado_Civil"] != DBNull.Value ? reader["Estado_Civil"].ToString() : string.Empty,
                        Movil = reader["Movil"] != DBNull.Value ? Convert.ToInt64(reader["Movil"]) : 0L,
                        Telefono = reader["Telefono"] != DBNull.Value ? Convert.ToInt64(reader["Telefono"]) : 0L,
                        Correo_Electronico = reader["Correo_Electronico"] != DBNull.Value ? reader["Correo_Electronico"].ToString() : string.Empty
                    };

                    listaContactos.Add(contacto);
                }
            }

            return listaContactos;
        }
    }

}
