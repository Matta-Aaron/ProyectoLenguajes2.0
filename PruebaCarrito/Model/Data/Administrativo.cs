using PruebaCarrito.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class Administrativo
    {
        ProductoData productoData = new ProductoData();
        BodegaData inventarioData = new BodegaData();
        CarritoData carritoData = new CarritoData();
        CompradorData compradorData = new CompradorData();

        public void insertarProducto(Producto producto)
        {

            productoData.InsertarProducto(producto);

        }

        public void borraProducto(int IdProducto)
        {

            productoData.BorrarProducto(IdProducto);

        }

        public void actualizarProducto(Producto producto)
        {

            productoData.Actualiza(producto);

        }

        /*Actualizar las cantidades disponibles.
         Manejo de productos en carritos. En update y Delete*/

        public void actualizarProductoCantidad(int IdProducto, int NuevaCantidad)
        {

            Producto productoNuevo = productoData.ObtenerProducto(IdProducto);

            productoNuevo.Nombre = productoNuevo.Nombre;
            productoNuevo.Descripcion = productoNuevo.Descripcion;
            productoNuevo.Id = productoNuevo.Id;
            productoNuevo.Impuesto = productoNuevo.Impuesto;
            productoNuevo.Cantidad = NuevaCantidad;
            productoNuevo.Presio = productoNuevo.Presio;
            productoNuevo.Url = productoNuevo.Url;


            productoData.Actualiza(productoNuevo);

        }

        public void actualizaProductoCarrito(int idUser, Producto productoNuevo)
        {

            List<Producto> listaProductos = carritoData.ObtenerProdusctosCarrito(idUser);

            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (productoNuevo.Id == listaProductos[i].Id)
                {
                    listaProductos[i].Nombre = productoNuevo.Nombre;
                    listaProductos[i].Descripcion = productoNuevo.Descripcion;
                    listaProductos[i].Id = productoNuevo.Id;
                    listaProductos[i].Impuesto = productoNuevo.Impuesto;
                    listaProductos[i].Cantidad = productoNuevo.Cantidad;
                    listaProductos[i].Presio = productoNuevo.Presio;
                    listaProductos[i].Url = productoNuevo.Url;


                }
            }

        }

        public void eliminaProdustosCarrito(int idUser, int idProducto)
        {
            List<Producto> listaProductos = carritoData.ObtenerProdusctosCarrito(idUser);
            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (idProducto == listaProductos[i].Id)
                {
                    listaProductos.Remove(listaProductos[i]);
                }
            }

        }

        /*Mantenimiento de la información organizacional y de los parámetros del sistema(impuesto de ventas)*/

        public void actualizarImpuesto(int idProducto,int nuevoImpuesto)
        {
            Producto producto = productoData.ObtenerProducto(idProducto);

            producto.Nombre = producto.Nombre;
            producto.Descripcion = producto.Descripcion;
            producto.Id = producto.Id;
            producto.Impuesto = nuevoImpuesto;
            producto.Cantidad = producto.Cantidad;
            producto.Presio = producto.Presio;
            producto.Url = producto.Url;


            productoData.Actualiza(producto);

        }

        /*Permitir la autenticación y autorización de usuarios administrativos*/

       public bool PermitirAcceso(string usuario,string password)
        {
            bool encontrado = false;

            List<Comprador> listaCompradores = compradorData.ObtenerCompradores();

            for (int i = 0; i < listaCompradores.Count; i++)
            {
                if (listaCompradores[i].Nombre.Equals(usuario)&& listaCompradores[i].Password.Equals(password))
                {
                     encontrado = true;
                }
            }
            return encontrado;

        }





    }
}
