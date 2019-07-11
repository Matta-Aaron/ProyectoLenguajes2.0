using Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    class ProductoCantidad
    {
        private Producto producto;
        private int cantidad;

    

        public ProductoCantidad(Producto producto,  int cantidad)
        {
            if (cantidad <= 0) throw new Exception("La cantidad debe ser un numero positivo o diferente de cero");

            this.producto = producto;
            this.cantidad = cantidad;

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
