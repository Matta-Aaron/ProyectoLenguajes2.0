using Model.Data;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PruebaCarrito.Model.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }
        
       [Test]
        public void CompanniaBussinessListarProductos()
        {

            ProductoData productoDao = new ProductoData();
            List<Producto> lista = new List<Producto>();
            int idProductoIndice = 1;
            lista = productoDao.ObtenerProductoRango(idProductoIndice);
            Assert.IsNotEmpty(lista);

            idProductoIndice = 50;
            lista = productoDao.ObtenerProductoRango(50);
            Assert.IsEmpty(lista);

        }
        
        [Test]
        public void CompanniaBussinessBuscarProducto()
        {

            ProductoData productoDao = new ProductoData();
            Producto producto;
            int idProductoIndice = 1;
            producto = productoDao.ObtenerProducto(idProductoIndice);
            Assert.IsNotNull(producto);
            
        }

        [Test]
        public void CompanniaBussinessBuscarProducto2()
        {

            ProductoData productoDao = new ProductoData();

            Assert.AreEqual("Huawei P30 Pro", productoDao.ObtenerProducto(1).Nombre);
            Assert.AreEqual(1, productoDao.ObtenerProducto(1).Id);
            Assert.AreEqual(2, productoDao.ObtenerProducto(1).Impuesto);
            Assert.AreEqual(1029, productoDao.ObtenerProducto(1).Presio);
            //Assert.AreEqual(8, productoDao.ObtenerProducto(1).Cantidad);



        }


        [Test]
        public void CompanniaBussinessActualizarInventario()
        {

            BodegaData bodegaData = new BodegaData();

            bodegaData.Actualiza(1, 8);

            ProductoData productoDao = new ProductoData();
            Assert.AreEqual(8, productoDao.ObtenerProducto(1).Cantidad);

        }


        [Test]
        public void CompanniaBussinessRecuperarCarrito()
        {

            CarritoData carritoDao = new CarritoData();
            Carrito carrito;
            carrito = carritoDao.ObtenerCarrito(2);
            Assert.IsNotNull(carrito);

        }

        [Test]
        public void CompanniaBussinessAgregar()
        {

            CarritoData carritoDao = new CarritoData();
            List<Producto> listaProducto = new List<Producto>();
            listaProducto.Add(new Producto());
            Carrito carrito = new Carrito();
            
            Assert.IsNotNull(carrito);

        }
        



    }
}