﻿using System;
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

        public Producto(string nombre, string descripcion, int id, int impuesto, int cantidad)
        {
            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre no puede ser nulo");
            if (string.IsNullOrEmpty(descripcion) ||
                string.IsNullOrWhiteSpace(descripcion)) throw new Exception("La descripcion no puede ser nulo");
            if (id <= 0) throw new Exception("El id del producto debe ser un numero positivo o diferente de cero");
            
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.id = id;
            this.impuesto = impuesto;
            this.cantidad = cantidad;
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


    }
}
