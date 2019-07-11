using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class Inventario
    {
        private int idProducto;
        private int cantidadProductos;
    

        public Inventario(int idProducto, int cantidadProductos)
        {
            if (idProducto <= 0) throw new Exception("El id del producto debe ser un numero positivo o diferente de cero");
            if (cantidadProductos <= 0) throw new Exception("La cantidad de productos debe ser un numero positivo o diferente de cero");

            this.idProducto = idProducto;
            this.cantidadProductos = cantidadProductos;

        }
        public Inventario()
        {
        }

        public int IdProducto
        {
            get
            {
                return idProducto;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                idProducto = value;
            }
        }

        public int CantidadProductos
        {
            get
            {
                return cantidadProductos;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                cantidadProductos = value;
            }
        }

    }
}
