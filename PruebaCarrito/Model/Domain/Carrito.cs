using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class Carrito
    {
        private int idUsuario;
        private int id;
        private List<Producto> listaProductos;
        private int cantidadProducto;


        public Carrito(int idUsuario, int id, List<Producto> listaProductos, int cantidadProducto)
        {

            if (idUsuario <= 0) throw new Exception("El idUsuario no puede ser nulo");
            if (id <= 0) throw new Exception("El id no puede ser nulo");

            this.idUsuario = idUsuario;
            this.id = id;
            this.listaProductos = listaProductos;
            this.cantidadProducto = cantidadProducto;

        }

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                idUsuario = value;
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


        public List<Producto> ListaProductos
        {
            get
            {
                return listaProductos;
            }
            set
            {
                listaProductos = value;
            }
        }


        public int CantidadProducto
        {

            get
            {
                return cantidadProducto;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                cantidadProducto = value;
            }

        }

    }
}
