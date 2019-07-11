using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class Carrito
    {
        private string usuario;
        private int id;
        private List<Producto> listaProdcutos;

        public Carrito(string usuario, string password, int id)
        {
            if (string.IsNullOrEmpty(usuario) ||
                string.IsNullOrWhiteSpace(usuario)) throw new Exception("El usuario no puede ser nulo");
            if (id <= 0) throw new Exception("El id del carrito debe ser un numero positivo o diferente de cero");
            
            this.usuario = usuario;
            this.id = id;
           
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                usuario = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                id = value;
            }
        }
        
    }
}
