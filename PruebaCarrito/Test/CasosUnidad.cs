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
            //trae los 50 de la lista
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

            Assert.AreEqual("Google Pixel 3XL", productoDao.ObtenerProducto(1).Nombre);
            Assert.AreEqual(2, productoDao.ObtenerProducto(1).Id);
            Assert.AreEqual(2, productoDao.ObtenerProducto(1).Impuesto);
            Assert.AreEqual(1029, productoDao.ObtenerProducto(1).Presio);
            Assert.AreEqual(5, productoDao.ObtenerProducto(1).Cantidad);



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

            //Sino esta registrada
            carrito = carritoDao.ObtenerCarrito(4);
            Assert.IsNotNull(carrito);

        }
        
        [Test]
        public void CompanniaBussinessAgregar()
        {

            CarritoData carritoDao = new CarritoData();
            List<Producto> listaProducto = new List<Producto>();
            listaProducto.Add(new Producto(3));
            Carrito carrito = new Carrito(3, 1, listaProducto, 6);
            carritoDao.InsertarCarrito(carrito);
       
            carrito = carritoDao.ObtenerCarrito(3);
            Assert.IsNotNull(carrito);
            Assert.AreEqual(1, carrito.Id);
            Assert.AreEqual(3, carrito.ListaProductos[0].Id);
        }
        
        


    }
}