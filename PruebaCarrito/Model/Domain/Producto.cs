using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class Producto
    {
        private string nombre;
        private string descripcion;
        private int id;
        private int impuesto;
        private int cantidad;
        private int precio;
        private string url;

        public Producto(string nombre, string descripcion, int id, int impuesto, int cantidad,int precio,string url)
        {
            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre no puede ser nulo");
            if (string.IsNullOrEmpty(descripcion) ||
                string.IsNullOrWhiteSpace(descripcion)) throw new Exception("La descripcion no puede ser nulo");
            if (id <= 0) throw new Exception("El id del producto debe ser un numero positivo o diferente de cero");
            if (precio < 0) throw new Exception("El precio del producto debe ser un numero positivo o diferente de cero");
            if (string.IsNullOrEmpty(url) ||
               string.IsNullOrWhiteSpace(url)) throw new Exception("La url no puede ser nulo");

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.id = id;
            this.impuesto = impuesto;
            this.cantidad = cantidad;
            this.precio = precio;
            this.url = url;
        }

        public Producto( int id)
        {
            
            if (id <= 0) throw new Exception("El id del producto debe ser un numero positivo o diferente de cero");
            
            this.id = id;
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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                descripcion = value;
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

        public int Impuesto
        {
            get
            {
                return impuesto;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }


                impuesto = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                cantidad = value;
            }
        }
        public int Presio
        {
            get
            {
                return precio;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                precio = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                url = value;
            }
        }

    }
}
