using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class N_Contactos
    {
        private D_Contactos contactoData = new D_Contactos();

        public void Insertar(E_Contactos contacto)
        {
            // Aquí podrías agregar validaciones
            if (string.IsNullOrEmpty(contacto.Nombre))
                throw new Exception("El nombre es obligatorio.");

            contactoData.Insertar(contacto);
        }

        public void Modificar(E_Contactos contacto)
        {
            if (contacto.ID <= 0)
                throw new Exception("El ID no es válido.");

            contactoData.Modificar(contacto);
        }

        public void Eliminar(int ID)
        {
            if (ID <= 0)
                throw new Exception("El ID no es válido.");

            contactoData.Eliminar(ID);
        }

        public E_Contactos Buscar(int ID)
        {
            if (ID <= 0)
                throw new Exception("El ID no es válido.");

            return contactoData.Buscar(ID);
        }

        public List<E_Contactos> ObtenerTodos()
        {
            return contactoData.ObtenerTodos();
        }
    }
}
