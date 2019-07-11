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

        public void actualizarProductoCantidad(int IdProducto,int NuevaCantidad)
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



    }
}
