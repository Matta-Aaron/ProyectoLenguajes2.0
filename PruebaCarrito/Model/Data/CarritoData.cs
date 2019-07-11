using PruebaCarrito.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Model.Data
{
    public class CarritoData
    {
        private string connectionString;

        private string sqlconnect = "data source = " +
                "163.178.173.148;initial " +
                "catalog=ProyectoLenguajes;user id=estudiantesrp;password=estudiantesrp;" +
                "multipleactiveresultsets=True";

        public CarritoData()
        {
            this.connectionString = sqlconnect;
        }

        public int conteoCarritos(int idUsuario)
        {
            int numeroCarrito = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT COUNT(IdCarrito) FROM Carrito WHERE IdUsuario = " + idUsuario;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            numeroCarrito = reader.GetInt32(0);
                            return numeroCarrito;
                        }

                        reader.Close();

                    };
                }

                connection.Close();

            }
            return numeroCarrito;
        }

        public Carrito ObtenerCarrito(int idUsuario)
        {

            Carrito carrito;
            List<Producto> listaProductos = new List<Producto>();
            List<int> idProductos = new List<int>();
            int idCarrito = 0;
            int cantidadProductos = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT c.IdCarrito, c.CantidadProductos FROM Carrito c WHERE c.IdUsuario = " + idUsuario;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            idCarrito = reader.GetInt32(0);
                            cantidadProductos = reader.GetInt32(1);


                        }

                        reader.Close();

                    };
                }

                connection.Close();

            }

            if (idCarrito != 0)
            {

                idProductos = ObtenerIdProductos(idUsuario);

                listaProductos = ObtenerProductos(idProductos);
                carrito = new Carrito(idUsuario, idCarrito, listaProductos, cantidadProductos);
                return carrito;

            }
            else
            {
                idCarrito = conteoCarritos(idUsuario) + 1;
                listaProductos.Add(new Producto( 1 ));
                carrito = new Carrito(idUsuario, idCarrito, listaProductos, cantidadProductos);
                InsertarCarrito(carrito);
                return ObtenerCarrito(idUsuario);
            }

        }


        public List<Producto> ObtenerProductos(List<int> idProductos)
        {
            List<Producto> listaProductos = new List<Producto>();
            ProductoData productoDao = new ProductoData();
            for (int i = 0; i < idProductos.Count; i++)
            {
                listaProductos.Add(productoDao.ObtenerProducto(idProductos[i]));
            }

            return listaProductos;
        }


        public List<int> ObtenerIdProductos(int idUsuario)
        {
            List<int> idProductos = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT c.IdProducto FROM Carrito c WHERE c.IdUsuario = " + idUsuario;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int idProducto = reader.GetInt32(0);

                            idProductos.Add(idProducto);
                        }
                        reader.Close();
                    };
                }
                connection.Close();
            }

            return idProductos;
        }


        public void InsertarCarrito(Carrito carrito)
        {
            List<Producto> lista = new List<Producto>();
            lista = carrito.ListaProductos;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Carrito(IdProducto, IdCarrito, IdUsuario, CantidadProductos) VALUES (@IdProducto, @IdCarrito, @IdUsuario, @CantidadProductos)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (lista.Count <= 0)
                    {
                        command.Parameters.Add(new SqlParameter("@IdProducto", carrito.ListaProductos[0].Id));
                        command.Parameters.Add(new SqlParameter("@IdCarrito", conteoCarritos(carrito.IdUsuario)));
                        command.Parameters.Add(new SqlParameter("@IdUsuario", carrito.IdUsuario));
                        command.Parameters.Add(new SqlParameter("@CantidadProductos", carrito.CantidadProducto));
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        for (int i = 0; i < lista.Count; i++)
                        {
                            command.Parameters.Add(new SqlParameter("@IdProducto", carrito.ListaProductos[i].Id));
                            command.Parameters.Add(new SqlParameter("@IdCarrito", carrito.Id));
                            command.Parameters.Add(new SqlParameter("@IdUsuario", carrito.IdUsuario));
                            command.Parameters.Add(new SqlParameter("@CantidadProductos", carrito.CantidadProducto));
                            command.ExecuteNonQuery();
                        }
                    }
                }
                connection.Close();
            }
;
        }


        public void ActualizaCarrito(Carrito carrito)
        {

            List<Producto> lista = new List<Producto>();
            lista = carrito.ListaProductos;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string sqlCarrito = "UPDATE Producto set IdProducto=@IdProducto, IdUsuario=@IdUsuario WHERE IdCarrito= " + carrito.Id;

                using (SqlCommand command = new SqlCommand(sqlCarrito, connection))
                {

                    for (int i = 0; i < lista.Count; i++)
                    {
                        command.Parameters.AddWithValue("IdProducto", carrito.ListaProductos[i].Id);
                        command.Parameters.AddWithValue("IdUsuario", carrito.IdUsuario);
                        command.ExecuteNonQuery();
                    }

                }
                connection.Close();
            }
        }


        public void BorrarCarrito(int idCarrito)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE Carrito WHERE IdCarrito = " + idCarrito;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }



        public List<Producto> ObtenerProdusctosCarrito(int idUsuario)
        {

            Carrito carrito;
            List<Producto> listaProductos = new List<Producto>();
            List<int> idProductos = new List<int>();
            int idCarrito = 0;
            int cantidadProductos = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT c.IdCarrito, c.CantidadProductos FROM Carrito c WHERE c.IdUsuario = " + idUsuario;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            idCarrito = reader.GetInt32(0);
                            cantidadProductos = reader.GetInt32(1);


                        }

                        reader.Close();

                    };
                }

                connection.Close();

            }

            if (idCarrito != 0)
            {

                idProductos = ObtenerIdProductos(idUsuario);

                listaProductos = ObtenerProductos(idProductos);
                carrito = new Carrito(idUsuario, idCarrito, listaProductos, cantidadProductos);
                return listaProductos;

            }
            else
            {
                idCarrito = conteoCarritos(idUsuario) + 1;
                listaProductos.Add(new Producto(1));
                carrito = new Carrito(idUsuario, idCarrito, listaProductos, cantidadProductos);
                InsertarCarrito(carrito);
                return listaProductos;
            }

        }

    }
}