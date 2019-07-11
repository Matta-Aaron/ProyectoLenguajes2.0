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
            
        }
        
    }
}