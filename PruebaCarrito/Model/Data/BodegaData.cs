using Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PruebaCarrito.Model.Data
{
    public class BodegaData
    {
        private string connectionString;

        private string sqlconnect = "data source = " +
                "163.178.173.148;initial " +
                "catalog=ProyectoLenguajes;user id=estudiantesrp;password=estudiantesrp;" +
                "multipleactiveresultsets=True";

        public BodegaData()
        {
            this.connectionString = sqlconnect;
        }

        public List<Inventario> ObtenerBodega()
        {
            List<Inventario> bodega = new List<Inventario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select IdProducto, CantidadProducto from Inventario";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int cantidad = reader.GetInt32(1);
                            bodega.Add(new Inventario(id,cantidad));
                        }
                        reader.Close();
                    };
                }
                connection.Close();
            }

            return bodega;
        }

        public void InsertarBodega( int idProducto, int cantidadProducto)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "insert into Inventario(IdProducto,CantidadProducto) values(@IdProducto,@CantidadProducto)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@IdProducto",idProducto));
                    command.Parameters.Add(new SqlParameter("@CantidadProducto", cantidadProducto));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
;
        }


        public void Actualiza(int idProducto, int cantidadProducto)
        {
            if (idProducto<=1)
            {
                idProducto = 2;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"UPDATE Producto SET 
                          Cantidad = @Cantidad
                    WHERE Id = " + idProducto;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("Cantidad", cantidadProducto);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"UPDATE Inventario SET 
                          CantidadProductos = @Cantidad
                    WHERE IdProducto = " + idProducto;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("Cantidad", cantidadProducto);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void BorrarBodega(int Id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"DELETE FROM Inventario 
                   WHERE IdProducto = @Id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("Id", Id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


    }
}
