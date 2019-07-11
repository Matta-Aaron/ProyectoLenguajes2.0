using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class CompradorData
    {
        private string nombre;
        private string password;
        private int id;
        private string email;


        public CompradorData(string nombre, string password, int id, string email)
        {
            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre no puede ser nulo");
            if (string.IsNullOrEmpty(password) ||
                string.IsNullOrWhiteSpace(password)) throw new Exception("La password no puede ser nulo");
            if (id <= 0) throw new Exception("El id del comprador debe ser un numero positivo o diferente de cero");
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrWhiteSpace(email)) throw new Exception("La password no puede ser nulo");


            this.nombre = nombre;
            this.password = password;
            this.id = id;
            this.email = email;

        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                nombre = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                password = value;
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

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                email = value;
            }
        }


    }
}
