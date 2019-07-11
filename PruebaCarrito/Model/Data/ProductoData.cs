using Model.Data;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PruebaCarrito.Model.Data
{
    public class ProductoData
    {
        private string connectionString;

        string sqlconnect = "data source = " +
                "163.178.173.148;initial " +
                "catalog=ProyectoLenguajes;user id=estudiantesrp;password=estudiantesrp;" +
                "multipleactiveresultsets=True";

        public ProductoData(string connectiostring)
        {
            this.connectionString = connectiostring;
        }

        public List<Producto> ObtenerProducto(int idProducto)
        {
            List<Producto> producto = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select p.Nombre, p.Descripcion, p.Id, p.Impuesto, p.Cantidad from Producto p where p.id = " + idProducto;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader.GetString(0);
                            string descripcion = reader.GetString(1);
                            int id = reader.GetInt32(2);
                            int impuesto = reader.GetInt32(3);
                            int cantidadDis = reader.GetInt32(4);
                            

                            producto.Add(new Producto(nombre, descripcion, id, impuesto, cantidadDis));
                        }
                        reader.Close();
                    };
                }
                connection.Close();
            }

            return producto;
        }



        public void InsertarProducto(Producto producto)
        {
            Inventario inventario = new Inventario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "insert into Producto(Nombre, Descripcion, Id, Impuesto, Cantidad) values(@Nombre, @Descripcion, @Id, @Impuesto, @Cantidad)";
                string sqlInventario = "insert into Inventario(IdProducto, CantidadProducto) values (@IdProducto,@CantidadProducto)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Nombre", producto.Nombre));
                    command.Parameters.Add(new SqlParameter("@Descripcion",producto.Descripcion));
                    command.Parameters.Add(new SqlParameter("@Id", producto.Id));
                    command.Parameters.Add(new SqlParameter("@Impuesto", producto.Impuesto));
                    command.Parameters.Add(new SqlParameter("@Cantidad", producto.Cantidad));
                    SqlCommand commandBodega = new SqlCommand(sqlInventario, connection);
                    commandBodega.Parameters.Add(new SqlParameter("@IdProducto", inventario.IdProducto));
                    commandBodega.Parameters.Add(new SqlParameter("@CantidadProducto", inventario.CantidadProductos));
                    command.ExecuteNonQuery();
                    commandBodega.ExecuteNonQuery();
                }
                connection.Close();
            }
;
        }


        public void Actualiza(Producto producto)
        {
            Inventario inventario = new Inventario();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string sqlProducto = "update Producto set Nombre=@Nombre, Descripcion=@Descripcion,Id=@Id,Impuesto=@Impuesto,Cantidad=@Cantidad where id= " + producto.Id;
                string sqlInventario = "update Inventario set CantidadProducto = @CantidadProducto where IdProducto = " + inventario.IdProducto;
                using (SqlCommand command = new SqlCommand(sqlProducto, connection))
                {
                    command.Parameters.AddWithValue("Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("Id", producto.Id);
                    command.Parameters.AddWithValue("Impuesto", producto.Impuesto);
                    command.Parameters.AddWithValue("Cantidad", producto.Cantidad);

                    SqlCommand commandBodega = new SqlCommand(sqlInventario, connection);
                    commandBodega.Parameters.AddWithValue("CantidadProducto", inventario.CantidadProductos);
                    command.ExecuteNonQuery();
                    commandBodega.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void BorrarProducto(int Id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlBodega = "delete Inventario where IdProducto = " + Id;
                string sqlProducto = "delete Producto where Id = " + Id;
                using (SqlCommand command = new SqlCommand(sqlBodega, connection))
                {
                    SqlCommand commandProducto = new SqlCommand(sqlProducto, connection);
                    command.ExecuteNonQuery();
                    commandProducto.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
